using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OfficeOpenXml;
using OT.Core.Dto;
using OT.Core.Entities;
using OT.Core.GlobalVariable;
using OT.Services.Interfaces;

namespace OT.UI.Page
{
    public partial class OTRegister : UserControl
    {
        private readonly IOverTimeService _overTimeService;
        private List<string> _originalItems;
        private List<string> _selectedItems = new List<string>();
        private int _currentPage = 1;
        private int _pageSize = 50;
        private int _totalPages = 0;

        public OTRegister(IOverTimeService overTimeService)
        {
            InitializeComponent();
            _overTimeService = overTimeService;
            PageNumeric.Value = _currentPage;

            LineTxtBox.PlaceholderText = "Nhập chuyền";
            MSTSearchTxb.PlaceholderText = "Nhập MST";

            FilterHRCbb.SelectedIndex = 0;
            FilterHRCbb.SelectedIndexChanged += filterHRCbb_SelectedIndexChanged;

            if (!GlobalUser.Phongban.Contains("HRD"))
            {
                HRPanel.Visible = false;
                HRImportBtn.Visible = false;
            }
        }

        #region InitForm
        private void OTRegister_Load(object sender, EventArgs e)
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.SetProperty,
                null, TangCaDataGridView, new object[] { true });
            initLines();
            loadListView();
        }

        private async void initLines()
        {
            _originalItems = await _overTimeService.GetLines(GlobalUser.Masothe.ToString(), GlobalUser.Phongban, GlobalUser.Nhamay);
            checkedListLine.Items.AddRange(_originalItems.ToArray());
        }

        private void loadListView()
        {
            // Đặt tiêu đề cột
            var columns = new (string Name, string Header, int Width)[]
            {
                ("MST", "MST", 60), ("Ho_ten", "Họ tên", 150), ("Chuyen", "Chuyền", 70),
                ("Tang_ca_sang", "Tăng ca sáng", 80), ("Tang_ca_sang_thuc_te", "Tăng ca sáng thực tế", 80),
                ("Gio_tang_ca", "Tăng ca", 80), ("Gio_tang_ca_thuc_te", "Tăng ca thực tế", 80),
                ("Tang_ca_dem", "Tăng ca đêm", 80), ("Tang_ca_dem_thuc_te", "Tăng ca đêm thực tế", 80),
                ("ca", "Ca", 60), ("Gio_vao", "Giờ vào", 100), ("Gio_ra", "Giờ ra", 100)
            };

            string[] editColumns = { "Tang_ca_sang", "Tang_ca_sang_thuc_te", "Gio_tang_ca", "Gio_tang_ca_thuc_te", "Tang_ca_dem", "Tang_ca_dem_thuc_te" };

            // Các cột cần cố định (Frozen)
            string[] frozenColumns = { "MST", "Ho_ten", "Chuyen" };

            foreach (var col in columns)
            {
                int index = TangCaDataGridView.Columns.Add(col.Name, col.Header); // Thêm cột với Name và HeaderText

                // Đặt Name của cột để có thể gọi bằng code
                TangCaDataGridView.Columns[index].Name = col.Name;

                // Các cột nào không được edit thì readonly true
                TangCaDataGridView.Columns[index].ReadOnly = !editColumns.Contains(col.Name);

                // Kiểm tra nếu cột này cần cố định (Frozen)
                TangCaDataGridView.Columns[index].Frozen = frozenColumns.Contains(col.Name);

                // Căn giữa tiêu đề cột
                TangCaDataGridView.Columns[index].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

                // Đặt chiều rộng cho cột
                TangCaDataGridView.Columns[index].Width = col.Width;

                TangCaDataGridView.Columns[index].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            }

            DataGridViewTextBoxColumn idColumn = new DataGridViewTextBoxColumn();
            idColumn.Name = "HR";
            idColumn.HeaderText = "HR";
            idColumn.Visible = false;
            TangCaDataGridView.Columns.Add(idColumn);

            if (!TangCaDataGridView.Columns.Contains("ActionButton") && GlobalUser.Phongban.Contains("HRD"))
            {
                DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn();
                buttonColumn.Name = "ActionButton";
                buttonColumn.HeaderText = "Phê duyệt";
                buttonColumn.UseColumnTextForButtonValue = false;
                buttonColumn.FlatStyle = FlatStyle.Flat;
                TangCaDataGridView.Columns.Add(buttonColumn);
            }

            // Tự động điều chỉnh kích thước cột theo tiêu đề
            TangCaDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        #endregion

        #region Sidebar
        private void checkedListLine_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            string item = checkedListLine.Items[e.Index].ToString();

            if (e.NewValue == CheckState.Checked)
            {
                if (!_selectedItems.Contains(item))
                {
                    _selectedItems.Add(item);
                }
            }
            else if (e.NewValue == CheckState.Unchecked)
            {
                _selectedItems.Remove(item);
            }
        }

        private void SearchLine()
        {
            string searchText = LineTxtBox.Text.ToLower();

            // Lọc danh sách theo từ khóa
            var filteredItems = _originalItems
                .Where(item => item.ToLower().Contains(searchText))
                .ToList();

            // Cập nhật CheckedListBox
            checkedListLine.Items.Clear();
            foreach (var item in filteredItems)
            {
                int index = checkedListLine.Items.Add(item);
                if (_selectedItems.Contains(item)) // Khôi phục trạng thái checked
                {
                    checkedListLine.SetItemChecked(index, true);
                }
            }
        }

        private void LineTxtBox_CustomKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchLine();
            }
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            SearchLine();
        }

        private void ViewBtn_Click(object sender, EventArgs e)
        {
            _currentPage = 1;
            updateDataListView();
        }

        private void CheckAllBtn_Click(object sender, EventArgs e)
        {
            if (CheckAllBtn.Text == "Chọn tất cả")
            {
                _selectedItems = _originalItems;
                for (var index = 0; index < _originalItems.Count; index++)
                {
                    checkedListLine.SetItemChecked(index, true);
                }

                CheckAllBtn.Text = "Bỏ tất cả";
                CheckAllBtn.BackColor = Color.Red;
            } else
            {
                _selectedItems = new List<string>();
                for (var index = 0; index < _originalItems.Count; index++)
                {
                    checkedListLine.SetItemChecked(index, false);
                }

                CheckAllBtn.Text = "Chọn tất cả";
                CheckAllBtn.BackColor = Color.DodgerBlue;
            }
        }

        #endregion

        #region OTDataGrid
        private void activeRow(DataGridViewRow dataGridViewRow)
        {
            dataGridViewRow.DefaultCellStyle.BackColor = Color.White;
            if (TangCaDataGridView.Columns.Contains("ActionButton"))
            {
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dataGridViewRow.Cells["ActionButton"];
                buttonCell.Value = "Phê duyệt";
                buttonCell.Style.BackColor = Color.Green;
                buttonCell.Style.ForeColor = Color.White;
            }

            // Các cột cho phép chỉnh sửa
            string[] editColumns = { "Tang_ca_sang", "Tang_ca_sang_thuc_te", "Gio_tang_ca", "Gio_tang_ca_thuc_te", "Tang_ca_dem", "Tang_ca_dem_thuc_te" };
            foreach (var column in editColumns)
            {
                dataGridViewRow.Cells[column].ReadOnly = false;
            }
        }

        private void disabledRow(DataGridViewRow dataGridViewRow)
        {
            dataGridViewRow.DefaultCellStyle.BackColor = Color.Yellow;
            if (TangCaDataGridView.Columns.Contains("ActionButton"))
            {
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dataGridViewRow.Cells["ActionButton"];
                buttonCell.Value = "Bỏ phê duyệt";
                buttonCell.Style.BackColor = Color.Red;
                buttonCell.Style.ForeColor = Color.White;
            }

            // Các cột không cho phép chỉnh sửa
            string[] editColumns = { "Tang_ca_sang", "Tang_ca_sang_thuc_te", "Gio_tang_ca", "Gio_tang_ca_thuc_te", "Tang_ca_dem", "Tang_ca_dem_thuc_te" };
            foreach (var column in editColumns)
            {
                dataGridViewRow.Cells[column].ReadOnly = true;
            }
        }

        private async void updateDataListView()
        {
            Cursor.Current = Cursors.WaitCursor;

            TangCaDataGridView.SuspendLayout();
            TangCaDataGridView.Rows.Clear();

            // Lấy ngày từ TimePicker
            DateOnly time = DateOnly.FromDateTime(TimePicker.Value);

            // Lấy ra danh sách được chọn, nếu không chọn mặc định null
            List<string>? lines = _originalItems;
            if (_selectedItems.Count > 0)
            {
                lines = _selectedItems;
            }

            // Lấy ra filter
            int filterType = FilterHRCbb.SelectedItem?.ToString() switch
            {
                "Đã duyệt" => 1,
                "Chưa duyệt" => 2,
                _ => 0
            };

            // Lấy ra mst search
            string? mst = MSTSearchTxb.Text != "" ? MSTSearchTxb.Text : null;

            // Gọi API để lấy dữ liệu
            var (dataList, totalPage) = await _overTimeService.GetOverTimeWithTotal(time, GlobalUser.Nhamay, _currentPage, _pageSize, filterType, lines, mst);
            _totalPages = totalPage;

            // Thêm dữ liệu vào DataGridView
            foreach (var data in dataList)
            {
                int rowIndex = TangCaDataGridView.Rows.Add(
                    data.MST,
                    data.Ho_ten,
                    data.Chuyen_to,
                    data.Tang_ca_sang.HasValue ? data.Tang_ca_sang.Value.ToString(@"hh\:mm") : "",
                    data.Tang_ca_sang_thuc_te.HasValue ? data.Tang_ca_sang_thuc_te.Value.ToString(@"hh\:mm") : "",
                    data.Gio_tang_ca.HasValue ? data.Gio_tang_ca.Value.ToString(@"hh\:mm") : "",
                    data.Gio_tang_ca_thuc_te.HasValue ? data.Gio_tang_ca_thuc_te.Value.ToString(@"hh\:mm") : "",
                    data.Tang_ca_dem.HasValue ? data.Tang_ca_dem.Value.ToString(@"hh\:mm") : "",
                    data.Tang_ca_dem_thuc_te.HasValue ? data.Tang_ca_dem_thuc_te.Value.ToString(@"hh\:mm") : "",
                    data.ca,
                    data.Gio_vao.HasValue ? data.Gio_vao.Value.ToString(@"hh\:mm") : "",
                    data.Gio_ra.HasValue ? data.Gio_ra.Value.ToString(@"hh\:mm") : "",
                    data.HR,
                    ""
                );

                DataGridViewRow dataGridViewRow = TangCaDataGridView.Rows[rowIndex];
                dataGridViewRow.Tag = data.ID;

                // Đổi màu theo giá trị data.HR
                if (data.HR == "OK")
                {
                    disabledRow(dataGridViewRow);
                }
                else
                {
                    activeRow(dataGridViewRow);
                }
            }

            // Hiển thị đường lưới (nếu chưa bật)
            TangCaDataGridView.GridColor = Color.Black;
            TangCaDataGridView.CellBorderStyle = DataGridViewCellBorderStyle.Single;

            // Cập nhật giao diện
            TangCaDataGridView.ResumeLayout();
            UpdatePagination();
        }


        private async void TangCaDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (TangCaDataGridView.Columns.Contains("ActionButton"))
            {
                // Kiểm tra nếu cột được nhấn là cột Button
                if (e.ColumnIndex == TangCaDataGridView.Columns["ActionButton"]!.Index && e.RowIndex >= 0)
                {
                    DataGridViewRow dataGridViewRow = TangCaDataGridView.Rows[e.RowIndex];
                    int id = (int)dataGridViewRow.Tag!;

                    string hr = dataGridViewRow.Cells["HR"].Value != null ? dataGridViewRow.Cells["HR"].Value!.ToString()! : "";

                    if (hr == "")
                    {
                        (int status, string message) = await _overTimeService.UpdateHrByID(id, "OK");
                        if (status == 200)
                        {
                            dataGridViewRow.Cells["HR"].Value = "OK";
                            disabledRow(dataGridViewRow);
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        (int status, string message) = await _overTimeService.UpdateHrByID(id, null);
                        if (status == 200)
                        {
                            dataGridViewRow.Cells["HR"].Value = null;
                            activeRow(dataGridViewRow);
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async void TangCaDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow dataGridViewRow = TangCaDataGridView.Rows[e.RowIndex];
                string columnName = TangCaDataGridView.Columns[e.ColumnIndex].Name;
                string timeString = dataGridViewRow.Cells[e.ColumnIndex].Value != null ? dataGridViewRow.Cells[e.ColumnIndex].Value.ToString() : null;
                int id = (int)dataGridViewRow.Tag!;

                (int status, string message) = await _overTimeService.UpdateOTTime(id, timeString, columnName);
                if (status != 200)
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Pagination

        private void UpdatePagination()
        {
            prevBtn.Enabled = true;
            nextBtn.Enabled = true;

            if (_currentPage == 1)
            {
                prevBtn.Enabled = false;
            }

            if (_currentPage == _totalPages)
            {
                nextBtn.Enabled = false;
            }

            PageNumeric.Value = _currentPage;
            TotalPageLabel.Text = _totalPages.ToString();
        }

        private void PageNumeric_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _currentPage = (int)PageNumeric.Value;
                if (_currentPage > _totalPages)
                {
                    _currentPage = _totalPages;
                }

                if (_currentPage <= 0)
                {
                    _currentPage = 1;
                }

                PageNumeric.Value = _currentPage;

                updateDataListView();
            }
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (_currentPage < _totalPages)
            {
                _currentPage++;
                PageNumeric.Value = _currentPage;
                updateDataListView();
            }
        }

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                PageNumeric.Value = _currentPage;
                updateDataListView();
            }
        }
        #endregion

        #region Header
        private async void ExportExcelBtn_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DateOnly time = DateOnly.FromDateTime(TimePicker.Value);
            await _overTimeService.ExportExcel(time, GlobalUser.Nhamay, _selectedItems.Count > 0 ? _selectedItems : _originalItems);
        }

        private bool IsEmptyRow(ExcelWorksheet ws, int row)
        {
            for (int col = 2; col <= 18; col++)
            {
                if (!string.IsNullOrWhiteSpace(ws.Cells[row, col].Text))
                    return false; 
            }
            return true; 
        }

        private async void SecretaryImportBtn_Click(object sender, EventArgs e)
        {

            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Đặt License

                        var lstOverTimes = new List<OverTime>(); // Danh sách dữ liệu từ Excel

                        using (var package = new ExcelPackage(new FileInfo(ofd.FileName)))
                        {
                            var ws = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên

                            int rowCount = ws.Dimension.Rows; // Đếm số dòng có dữ liệu
                            for (int row = 2; row <= rowCount; row++) // Bỏ qua dòng tiêu đề
                            {
                                if (IsEmptyRow(ws, row)) continue;

                                var overTime = new OverTime
                                {
                                    Nha_may = ws.Cells[row, 2].Text,
                                    MST = ws.Cells[row, 3].Text,
                                    Ho_ten = ws.Cells[row, 4].Text,
                                    Chuc_vu = ws.Cells[row, 5].Text,
                                    Chuyen_to = ws.Cells[row, 6].Text,
                                    Bo_phan = ws.Cells[row, 7].Text,

                                    Ngay_dang_ky = DateOnly.TryParseExact(ws.Cells[row, 8].Text, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out var ngaydangky) ? ngaydangky : default,

                                    Tang_ca_sang = TimeSpan.TryParse(ws.Cells[row, 9].Text, out var tcs) ? tcs : (TimeSpan?)null,
                                    Tang_ca_sang_thuc_te = TimeSpan.TryParse(ws.Cells[row, 10].Text, out var tcstt) ? tcstt : (TimeSpan?)null,
                                    Gio_tang_ca = TimeSpan.TryParse(ws.Cells[row, 11].Text, out var gtc) ? gtc : (TimeSpan?)null,
                                    Gio_tang_ca_thuc_te = TimeSpan.TryParse(ws.Cells[row, 12].Text, out var gtctt) ? gtctt : (TimeSpan?)null,
                                    Tang_ca_dem = TimeSpan.TryParse(ws.Cells[row, 13].Text, out var tcd) ? tcd : (TimeSpan?)null,
                                    Tang_ca_dem_thuc_te = TimeSpan.TryParse(ws.Cells[row, 14].Text, out var tcdtt) ? tcdtt : (TimeSpan?)null,

                                    ca = ws.Cells[row, 15].Text,
                                    Gio_vao = TimeSpan.TryParse(ws.Cells[row, 16].Text, out var gv) ? gv : (TimeSpan?)null,
                                    Gio_ra = TimeSpan.TryParse(ws.Cells[row, 17].Text, out var gr) ? gr : (TimeSpan?)null,

                                    HR = ws.Cells[row, 18].Text
                                };

                                lstOverTimes.Add(overTime);
                            }
                        }

                        (int status, string message) = await _overTimeService.ImportOT(lstOverTimes);
                        if (status == 200)
                        {
                            if (MessageBox.Show("Đăng ký tăng ca thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                            {
                                updateDataListView();
                            }
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void HRImportBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook|*.xlsx" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // Đặt License

                        var lstHR = new List<DOT_HR>(); // Danh sách dữ liệu từ Excel

                        using (var package = new ExcelPackage(new FileInfo(ofd.FileName)))
                        {
                            var ws = package.Workbook.Worksheets[0]; // Lấy sheet đầu tiên

                            int rowCount = ws.Dimension.Rows; // Đếm số dòng có dữ liệu
                            for (int row = 2; row <= rowCount; row++) // Bỏ qua dòng tiêu đề
                            {
                                if (IsEmptyRow(ws, row)) continue;

                                var hr = new DOT_HR
                                {
                                    ID = int.TryParse(ws.Cells[row, 1].Text, out int id) ? id : 0,
                                    HR = ws.Cells[row, 18].Text
                                };

                                lstHR.Add(hr);
                            }
                        }

                        (int status, string message) = await _overTimeService.ImportOTByHR(lstHR);
                        if (status == 200)
                        {
                            if (MessageBox.Show("Duyệt tăng ca thành công!") == DialogResult.OK)
                            {
                                updateDataListView();
                            }
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void AcceptOT(string messageSuccess, string? stt)
        {
            try
            {
                DateOnly date = DateOnly.FromDateTime(TimePicker.Value);

                List<string>? lines = null;
                if (_selectedItems.Count > 0)
                {
                    lines = _selectedItems;
                }

                (int status, string message) = await _overTimeService.AcceptAllStatusOT(date, GlobalUser.Nhamay, stt, lines);
                if (status == 200)
                {
                    if (MessageBox.Show(messageSuccess, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        updateDataListView();
                    }
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void AcceptAllBtn_Click(object sender, EventArgs e)
        {
            AcceptOT("Duyệt tăng ca thành công", "OK");
        }

        private void RejectAllBtn_Click(object sender, EventArgs e)
        {
            AcceptOT("Bỏ duyệt tăng ca thành công!", null);
        }

        private void MSTSearchTxb_CustomKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _currentPage = 1;
                updateDataListView();
            }
        }

        private void filterHRCbb_SelectedIndexChanged(object sender, EventArgs e)
        {
            _currentPage = 1;
            updateDataListView();
        }

        #endregion
    }
}