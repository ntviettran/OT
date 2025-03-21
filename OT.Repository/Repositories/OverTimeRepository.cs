using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OT.Core;
using OT.Core.Dto;
using OT.Core.Entities;
using OT.Repositories.Interfaces;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace OT.Repositories.Repositories
{

    public class OverTimeRepository : BaseRepository, IOverTimeRepository
    {
        public OverTimeRepository(IDbContextFactory<AppDbContext> dbContextFactory) : base(dbContextFactory)
        {
        }

        public async Task<List<string>> GetLines(string mst, string phongban, string macongty)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                if (phongban.Contains("HRD"))
                {
                    return await dbContext.SecretaryManagers.Where(s => s.Chuyen_to.StartsWith(macongty[2].ToString())).Select(s => s.Chuyen_to).Distinct().ToListAsync();
                }

                return await dbContext.SecretaryManagers.Where(s => s.MST == mst && s.Nha_may == macongty).Select(s => s.Chuyen_to).ToListAsync();
            }
            catch
            {
                return new List<string>();
            }

        }

        public async Task<IEnumerable<OverTime>> GetOverTime(DateOnly date, string macongty, List<string>? lines)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                DateTime dateParam = date.ToDateTime(TimeOnly.MinValue); 

                string lineFilter = lines != null && lines.Any()
                    ? $"AND Chuyen_to IN ({string.Join(",", lines.Select(l => $"'{l}'"))})"
                    : "";

                string sql = $@"SELECT * FROM Dang_ky_tang_ca 
                    WHERE Ngay_dang_ky = @dateParam 
                    AND Nha_may = @macongty
                    {lineFilter}";

                var parameters = new[]
                {
                    new SqlParameter("@dateParam", dateParam),
                    new SqlParameter("@macongty", macongty)
                };

                var data = await dbContext.OverTimes
                    .FromSqlRaw(sql, parameters)
                    .ToListAsync();

                return data;
            }
            catch
            {
                return new List<OverTime>();
            }
        }

        public async Task<(IEnumerable<OverTime> data, int totalPages)> GetOverTimeWithTotal(DateOnly date, string macongty, int page, int size, int filter, List<string>? lines, string? searchMST)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                string dataQuery = @"
                    WITH CTE AS (
                        SELECT *, ROW_NUMBER() OVER (ORDER BY Ngay_dang_ky DESC) AS RowNum
                        FROM Dang_ky_tang_ca
                        WHERE Ngay_dang_ky = @date AND Nha_may = @macongty
                        {0} {1} {2}
                    )
                    SELECT * FROM CTE WHERE RowNum BETWEEN @startRow AND @endRow";

                int startRow = (page - 1) * size + 1;
                int endRow = page * size;

                // Danh sách tham số SQL
                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@date", date),
                    new SqlParameter("@macongty", macongty),
                    new SqlParameter("@startRow", startRow),
                    new SqlParameter("@endRow", endRow)
                };

                string filterCondition = "";
                if (filter != 0)
                {
                    filterCondition = filter == 1 ? "AND HR = 'OK'" : "AND HR is null";   
                }

                // Điều kiện bổ sung
                string linesCondition = "";
                if (lines != null && lines.Count > 0)
                {
                    linesCondition = "AND Chuyen_to IN (" + string.Join(",", lines.Select((_, i) => "@line" + i)) + ")";
                    parameters.AddRange(lines.Select((line, i) => new SqlParameter("@line" + i, line)));
                }

                string mstCondition = "";
                if (!string.IsNullOrEmpty(searchMST))
                {
                    mstCondition = "AND MST LIKE @searchMST";
                    parameters.Add(new SqlParameter("@searchMST", "%" + searchMST + "%"));
                }

                // Thay thế vào câu lệnh SQL
                dataQuery = string.Format(dataQuery, filterCondition, linesCondition, mstCondition);

                // Lấy tổng số bản ghi sau khi áp dụng filter
                var countQuery = @"
                    SELECT COUNT(*) AS Value FROM Dang_ky_tang_ca
                    WHERE Ngay_dang_ky = @date AND Nha_may = @macongty
                    " + linesCondition + " " + mstCondition;

                int totalRecords = await dbContext.Database.SqlQueryRaw<int>(countQuery, parameters.ToArray()).FirstAsync();

                int totalPages = (int)Math.Ceiling(totalRecords / (double)size);

                // Lấy dữ liệu theo trang
                var data = await dbContext.OverTimes
                    .FromSqlRaw(dataQuery, parameters.ToArray())
                    .ToListAsync();

                return (data, totalPages);
            }
            catch
            {
                return (new List<OverTime>(), 0);
            }
        }

        public async Task<(int status, string message)> UpdateHRByID(int id, string? status)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                var record = await dbContext.OverTimes.FirstOrDefaultAsync(ot => ot.ID == id);
                if (record != null)
                {
                    record.HR = status;
                    var rowsAffected = dbContext.SaveChanges();

                    return rowsAffected > 0
                        ? (200, "Cập nhật thành công!")
                        : (204, "Không có thay đổi nào.");
                }

                return (404, "Không tìm thấy bản ghi nào");
            } catch
            {
                return (500, "Có lỗi xảy ra từ hệ thống");
            }
        }

        public async Task<(int status, string message)> UpdateOTTime(int id, TimeSpan? time, string column)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                var record = new OverTime { ID = id }; // Tạo đối tượng chỉ với ID
                
                dbContext.OverTimes.Attach(record); // Attach vào DbContext
                dbContext.Entry(record).Property(column).IsModified = true;
                dbContext.Entry(record).Property(column).CurrentValue = time;
                var rowsAffected = dbContext.SaveChanges();

                return rowsAffected > 0
                  ? (200, "Cập nhật thành công!")
                  : (204, "Không có thay đổi nào.");
            } catch
            {
                return (500, "Có lỗi xảy ra từ hệ thống");
            }
        }

        private DataTable ConvertToDataTable(List<OverTime> data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Nha_may", typeof(string));
            table.Columns.Add("MST", typeof(string));
            table.Columns.Add("Ho_ten", typeof(string));
            table.Columns.Add("Chuc_vu", typeof(string));
            table.Columns.Add("Chuyen_to", typeof(string));
            table.Columns.Add("Bo_phan", typeof(string));
            table.Columns.Add("Ngay_dang_ky", typeof(DateTime));
            table.Columns.Add("Tang_ca_sang", typeof(TimeSpan));
            table.Columns.Add("Tang_ca_sang_thuc_te", typeof(TimeSpan));
            table.Columns.Add("Gio_tang_ca", typeof(TimeSpan));
            table.Columns.Add("Gio_tang_ca_thuc_te", typeof(TimeSpan));
            table.Columns.Add("Tang_ca_dem", typeof(TimeSpan));
            table.Columns.Add("Tang_ca_dem_thuc_te", typeof(TimeSpan));
            table.Columns.Add("ca", typeof(string));
            table.Columns.Add("Gio_vao", typeof(TimeSpan));
            table.Columns.Add("Gio_ra", typeof(TimeSpan));

            foreach (var item in data)
            {
                table.Rows.Add(
                    item.Nha_may, item.MST, item.Ho_ten, item.Chuc_vu, item.Chuyen_to, item.Bo_phan,
                    item.Ngay_dang_ky.ToDateTime(TimeOnly.MinValue), item.Tang_ca_sang, item.Tang_ca_sang_thuc_te, item.Gio_tang_ca,
                    item.Gio_tang_ca_thuc_te, item.Tang_ca_dem, item.Tang_ca_dem_thuc_te,
                    item.ca, item.Gio_vao, item.Gio_ra
                );
            }
            return table;
        }


        public async Task<(int status, string message)> ImportOT(List<OverTime> listOvertime)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                using var connection = new SqlConnection(dbContext.Database.GetDbConnection().ConnectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand("InsertDangKyTangCa", connection);
                command.CommandType = CommandType.StoredProcedure;

                var dt = ConvertToDataTable(listOvertime);
                var tvpParam = command.Parameters.AddWithValue("@DangKyTangCa", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.DangKyTangCaTableType";

                
                var rowEffected = await command.ExecuteNonQueryAsync();

                return rowEffected > 0 ? (200, "Đăng ký thành công")
                                       : (204, "Không có thay đổi nào");
            }
            catch
            {
                return (500, "Có lỗi xảy ra từ hệ thống");
            }
        }

        private DataTable ConvertToDataTableHR(List<DOT_HR> data)
        {
            DataTable table = new DataTable();
            table.Columns.Add("ID", typeof(int));
            table.Columns.Add("HR", typeof(string));

            foreach (var item in data)
            {
                table.Rows.Add(item.ID, item.HR);
            }
            return table;
        }

        public async Task<(int status, string message)> ImportOTByHR(List<DOT_HR> listHR)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                using var connection = new SqlConnection(dbContext.Database.GetDbConnection().ConnectionString);
                await connection.OpenAsync();

                using var command = new SqlCommand("UpdateOverTimeHR", connection);
                command.CommandType = CommandType.StoredProcedure;

                var dt = ConvertToDataTableHR(listHR);
                var tvpParam = command.Parameters.AddWithValue("@HRTable", dt);
                tvpParam.SqlDbType = SqlDbType.Structured;
                tvpParam.TypeName = "dbo.OverTimeHRType";


                var rowEffected = await command.ExecuteNonQueryAsync();

                return rowEffected > 0 ? (200, "Duyệt thành công")
                                       : (204, "Không có thay đổi nào");
            }
            catch
            {
                return (500, "Có lỗi xảy ra từ hệ thống");
            }
        }

        public async Task<(int status, string message)> AcceptAllStatusOT(DateOnly date, string macongty, string? status, List<string>? lines)
        {
            using var dbContext = _dbContextFactory.CreateDbContext();
            try
            {
                string dataQuery = @"Update Dang_ky_tang_ca Set HR = {0} Where Ngay_dang_ky = @date And Nha_may = @macongty {1}";

                var parameters = new List<SqlParameter>
                {
                    new SqlParameter("@date", date),
                    new SqlParameter("@macongty", macongty),
                };

                string linesCondition = "";
                if (lines != null && lines.Count > 0)
                {
                    linesCondition = "AND Chuyen_to IN (" + string.Join(",", lines.Select((_, i) => "@line" + i)) + ")";
                    parameters.AddRange(lines.Select((line, i) => new SqlParameter("@line" + i, line)));
                }

                dataQuery = string.Format(dataQuery, status != null ? $"'{status}'" : "NULL", linesCondition);

                var rowEffected = await dbContext.Database.ExecuteSqlRawAsync(dataQuery, parameters.ToArray());

                return rowEffected > 0 ? (200, "Duyệt thành công")
                                       : (204, "Không có thay đổi nào");
            } catch
            {
                return (500, "Có lỗi xảy ra từ hệ thống");
            }
        }
    }
}
