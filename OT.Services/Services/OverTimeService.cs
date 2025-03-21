using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OT.Core.Dto;
using OT.Core.Entities;
using OT.Repositories.Interfaces;
using OT.Services.Interfaces;

namespace OT.Services.Services
{
    public class OverTimeService : IOverTimeService
    {
        private readonly IOverTimeRepository _overtimeRepository;

        public OverTimeService(IOverTimeRepository overTimeRepository) {
            _overtimeRepository = overTimeRepository;
        }

        public async Task<List<string>> GetLines(string mst, string phongban, string macongty)
        {
            return await _overtimeRepository.GetLines(mst, phongban, macongty);
        }

        public async Task<(IEnumerable<OverTime> data, int totalPages)> GetOverTimeWithTotal(DateOnly date, string macongty, int page, int size, int filter, List<string>? lines, string? searchMST)
        {
            return await _overtimeRepository.GetOverTimeWithTotal(date, macongty, page, size, filter, lines, searchMST);
        }

        public async Task<(int status, string message)> UpdateHrByID(int id, string? status)
        {
            return await _overtimeRepository.UpdateHRByID(id, status);
        }

        public async Task<(int status, string message)> UpdateOTTime(int id, string timeString, string column)
        {
            if (TimeSpan.TryParse(timeString, out TimeSpan time) || string.IsNullOrEmpty(timeString))
            {
              return await _overtimeRepository.UpdateOTTime(id, string.IsNullOrEmpty(timeString) ? null : time, column);
            }
            else
            {
                return (0, "Định dạng thời gian bị sai, vui lòng kiểm tra lại.");
            }
        }

        public async Task ExportExcel(DateOnly date, string macongty, List<string> lines)
        {
            var data = await _overtimeRepository.GetOverTime(date, macongty, lines);

            string timestamp = DateTime.Now.ToString("ddMMyyyyHHmmss");
            string fileName = $"danhsachtangca_{timestamp}.xlsx";

            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "Excel Workbook|*.xlsx", FileName = fileName })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                        using (var package = new ExcelPackage())
                        {
                            var ws = package.Workbook.Worksheets.Add("Tăng ca");

                            string[] headers = { "ID", "Nhà máy", "MST", "Họ tên", "Chức vụ", "Chuyền tổ", "Bộ phận",
                             "Ngày đăng ký", "Tăng ca sáng", "Tăng ca sáng thực tế", "Giờ tăng ca",
                             "Giờ tăng ca thực tế", "Tăng ca đêm", "Tăng ca đêm thực tế", "Ca",
                             "Giờ vào", "Giờ ra", "HR" };

                            // Ghi tiêu đề
                            for (int col = 0; col < headers.Length; col++)
                            {
                                ws.Cells[1, col + 1].Value = headers[col];
                            }

                            // Thiết lập màu sắc cho Header
                            using (var range = ws.Cells[1, 1, 1, headers.Length])
                            {
                                range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                                range.Style.Fill.BackgroundColor.SetColor(Color.Blue);
                                range.Style.Font.Color.SetColor(Color.White);
                                range.Style.Font.Bold = true;
                            }

                            // Ghi dữ liệu vào từng dòng
                            int row = 2;
                            foreach (var item in data)
                            {
                                ws.Cells[row, 1].Value = item.ID;
                                ws.Cells[row, 2].Value = item.Nha_may;
                                ws.Cells[row, 3].Value = item.MST;
                                ws.Cells[row, 4].Value = item.Ho_ten;
                                ws.Cells[row, 5].Value = item.Chuc_vu;
                                ws.Cells[row, 6].Value = item.Chuyen_to;
                                ws.Cells[row, 7].Value = item.Bo_phan;
                                ws.Cells[row, 8].Value = item.Ngay_dang_ky.ToString("dd/MM/yyyy");
                                ws.Cells[row, 9].Value = item.Tang_ca_sang?.ToString(@"hh\:mm");
                                ws.Cells[row, 10].Value = item.Tang_ca_sang_thuc_te?.ToString(@"hh\:mm");
                                ws.Cells[row, 11].Value = item.Gio_tang_ca?.ToString(@"hh\:mm");
                                ws.Cells[row, 12].Value = item.Gio_tang_ca_thuc_te?.ToString(@"hh\:mm");
                                ws.Cells[row, 13].Value = item.Tang_ca_dem?.ToString(@"hh\:mm");
                                ws.Cells[row, 14].Value = item.Tang_ca_dem_thuc_te?.ToString(@"hh\:mm");
                                ws.Cells[row, 15].Value = item.ca;
                                ws.Cells[row, 16].Value = item.Gio_vao?.ToString(@"hh\:mm");
                                ws.Cells[row, 17].Value = item.Gio_ra?.ToString(@"hh\:mm");
                                ws.Cells[row, 18].Value = item.HR;
                                row++;
                            }

                            // Căn chỉnh kích thước cột tự động
                            ws.Cells.AutoFitColumns();

                            // Lưu file
                            package.SaveAs(new FileInfo(sfd.FileName));
                        }

                        DialogResult result = MessageBox.Show("Xuất file thành công! Bạn có muốn mở file không?",
                                      "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        if (result == DialogResult.Yes)
                        {
                            Process.Start(new ProcessStartInfo(sfd.FileName) { UseShellExecute = true });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        public async Task<(int status, string message)> ImportOT(List<OverTime> listOvertime)
        {
            return await _overtimeRepository.ImportOT(listOvertime);
        }

        public async Task<(int status, string message)> ImportOTByHR(List<DOT_HR> listHR)
        {
            return await _overtimeRepository.ImportOTByHR(listHR);
        }

        public async Task<(int status, string message)> AcceptAllStatusOT(DateOnly date, string macongty, string? status, List<string>? lines)
        {
            return await _overtimeRepository.AcceptAllStatusOT(date, macongty, status, lines);
        }
    }
}
