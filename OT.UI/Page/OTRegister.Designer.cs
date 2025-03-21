namespace OT.UI.Page
{
    partial class OTRegister
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            LinePanel = new Panel();
            panel1 = new Panel();
            LineTxtBox = new Component.CustomTextBox();
            ViewBtn = new Button();
            CheckAllBtn = new Button();
            SearchBtn = new Button();
            TimePicker = new Control.DatePicker();
            LineListPanel = new Panel();
            checkedListLine = new CheckedListBox();
            RegisterPanel = new Panel();
            panel7 = new Panel();
            MSTSearchTxb = new Component.CustomTextBox();
            FilterHRCbb = new Component.CustomComboBox();
            HRPanel = new Panel();
            RejectAllBtn = new FontAwesome.Sharp.IconButton();
            AcceptAllBtn = new FontAwesome.Sharp.IconButton();
            HRImportBtn = new FontAwesome.Sharp.IconButton();
            SecretaryImportBtn = new FontAwesome.Sharp.IconButton();
            ExportExcelBtn = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            nextBtn = new FontAwesome.Sharp.IconButton();
            prevBtn = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            PageNumeric = new NumericUpDown();
            TotalPageLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            TangCaDataGridView = new DataGridView();
            panel6 = new Panel();
            LinePanel.SuspendLayout();
            panel1.SuspendLayout();
            LineListPanel.SuspendLayout();
            RegisterPanel.SuspendLayout();
            panel7.SuspendLayout();
            HRPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PageNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TangCaDataGridView).BeginInit();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // LinePanel
            // 
            LinePanel.BackColor = Color.WhiteSmoke;
            LinePanel.Controls.Add(panel1);
            LinePanel.Controls.Add(LineListPanel);
            LinePanel.Dock = DockStyle.Left;
            LinePanel.Location = new Point(0, 0);
            LinePanel.Name = "LinePanel";
            LinePanel.Size = new Size(230, 505);
            LinePanel.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.Controls.Add(LineTxtBox);
            panel1.Controls.Add(ViewBtn);
            panel1.Controls.Add(CheckAllBtn);
            panel1.Controls.Add(SearchBtn);
            panel1.Controls.Add(TimePicker);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(230, 151);
            panel1.TabIndex = 2;
            // 
            // LineTxtBox
            // 
            LineTxtBox.BackColor = Color.White;
            LineTxtBox.BorderStyle = BorderStyle.FixedSingle;
            LineTxtBox.Location = new Point(10, 99);
            LineTxtBox.Name = "LineTxtBox";
            LineTxtBox.Padding = new Padding(1);
            LineTxtBox.Size = new Size(100, 35);
            LineTxtBox.TabIndex = 3;
            LineTxtBox.CustomKeyDown += LineTxtBox_CustomKeyDown;
            // 
            // ViewBtn
            // 
            ViewBtn.BackColor = Color.DodgerBlue;
            ViewBtn.FlatStyle = FlatStyle.Flat;
            ViewBtn.ForeColor = Color.White;
            ViewBtn.Location = new Point(10, 8);
            ViewBtn.Name = "ViewBtn";
            ViewBtn.Size = new Size(99, 37);
            ViewBtn.TabIndex = 2;
            ViewBtn.Text = "Xem";
            ViewBtn.UseVisualStyleBackColor = false;
            ViewBtn.Click += ViewBtn_Click;
            // 
            // CheckAllBtn
            // 
            CheckAllBtn.BackColor = Color.DodgerBlue;
            CheckAllBtn.FlatStyle = FlatStyle.Flat;
            CheckAllBtn.ForeColor = Color.White;
            CheckAllBtn.Location = new Point(115, 8);
            CheckAllBtn.Name = "CheckAllBtn";
            CheckAllBtn.Size = new Size(103, 37);
            CheckAllBtn.TabIndex = 1;
            CheckAllBtn.Text = "Chọn tất cả";
            CheckAllBtn.UseVisualStyleBackColor = false;
            CheckAllBtn.Click += CheckAllBtn_Click;
            // 
            // SearchBtn
            // 
            SearchBtn.BackColor = Color.DodgerBlue;
            SearchBtn.FlatStyle = FlatStyle.Flat;
            SearchBtn.ForeColor = Color.White;
            SearchBtn.Location = new Point(116, 98);
            SearchBtn.Name = "SearchBtn";
            SearchBtn.Size = new Size(102, 37);
            SearchBtn.TabIndex = 1;
            SearchBtn.Text = "Tìm kiếm";
            SearchBtn.UseVisualStyleBackColor = false;
            SearchBtn.Click += SearchBtn_Click;
            // 
            // TimePicker
            // 
            TimePicker.CustomFormat = "dd/MM/yyyy";
            TimePicker.Font = new Font("Segoe UI", 9.5F);
            TimePicker.Format = DateTimePickerFormat.Custom;
            TimePicker.Location = new Point(10, 54);
            TimePicker.MinimumSize = new Size(0, 35);
            TimePicker.Name = "TimePicker";
            TimePicker.Size = new Size(208, 35);
            TimePicker.TabIndex = 0;
            // 
            // LineListPanel
            // 
            LineListPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            LineListPanel.AutoScroll = true;
            LineListPanel.Controls.Add(checkedListLine);
            LineListPanel.Location = new Point(0, 157);
            LineListPanel.Name = "LineListPanel";
            LineListPanel.Size = new Size(230, 348);
            LineListPanel.TabIndex = 1;
            // 
            // checkedListLine
            // 
            checkedListLine.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            checkedListLine.FormattingEnabled = true;
            checkedListLine.Location = new Point(10, 1);
            checkedListLine.Name = "checkedListLine";
            checkedListLine.Size = new Size(208, 346);
            checkedListLine.TabIndex = 0;
            checkedListLine.ItemCheck += checkedListLine_ItemCheck;
            // 
            // RegisterPanel
            // 
            RegisterPanel.BackColor = Color.White;
            RegisterPanel.Controls.Add(panel7);
            RegisterPanel.Controls.Add(HRImportBtn);
            RegisterPanel.Controls.Add(SecretaryImportBtn);
            RegisterPanel.Controls.Add(ExportExcelBtn);
            RegisterPanel.Dock = DockStyle.Top;
            RegisterPanel.Location = new Point(0, 0);
            RegisterPanel.Name = "RegisterPanel";
            RegisterPanel.Size = new Size(743, 55);
            RegisterPanel.TabIndex = 2;
            // 
            // panel7
            // 
            panel7.Controls.Add(MSTSearchTxb);
            panel7.Controls.Add(FilterHRCbb);
            panel7.Controls.Add(HRPanel);
            panel7.Dock = DockStyle.Right;
            panel7.Location = new Point(315, 0);
            panel7.Name = "panel7";
            panel7.Size = new Size(428, 55);
            panel7.TabIndex = 8;
            // 
            // MSTSearchTxb
            // 
            MSTSearchTxb.BackColor = Color.White;
            MSTSearchTxb.BorderStyle = BorderStyle.FixedSingle;
            MSTSearchTxb.Location = new Point(231, 10);
            MSTSearchTxb.Name = "MSTSearchTxb";
            MSTSearchTxb.Padding = new Padding(1);
            MSTSearchTxb.Size = new Size(190, 34);
            MSTSearchTxb.TabIndex = 4;
            MSTSearchTxb.CustomKeyDown += MSTSearchTxb_CustomKeyDown;
            // 
            // FilterHRCbb
            // 
            FilterHRCbb.DrawMode = DrawMode.OwnerDrawFixed;
            FilterHRCbb.DropDownStyle = ComboBoxStyle.DropDownList;
            FilterHRCbb.FormattingEnabled = true;
            FilterHRCbb.ItemHeight = 28;
            FilterHRCbb.Items.AddRange(new object[] { "Tất cả", "Đã duyệt", "Chưa duyệt" });
            FilterHRCbb.Location = new Point(93, 10);
            FilterHRCbb.Name = "FilterHRCbb";
            FilterHRCbb.Size = new Size(130, 34);
            FilterHRCbb.TabIndex = 4;
            // 
            // HRPanel
            // 
            HRPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            HRPanel.Controls.Add(RejectAllBtn);
            HRPanel.Controls.Add(AcceptAllBtn);
            HRPanel.Location = new Point(0, 0);
            HRPanel.Name = "HRPanel";
            HRPanel.Size = new Size(87, 55);
            HRPanel.TabIndex = 0;
            // 
            // RejectAllBtn
            // 
            RejectAllBtn.BackColor = Color.Red;
            RejectAllBtn.FlatStyle = FlatStyle.Flat;
            RejectAllBtn.ForeColor = Color.White;
            RejectAllBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            RejectAllBtn.IconColor = Color.White;
            RejectAllBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            RejectAllBtn.IconSize = 24;
            RejectAllBtn.Location = new Point(48, 9);
            RejectAllBtn.Margin = new Padding(0);
            RejectAllBtn.Name = "RejectAllBtn";
            RejectAllBtn.Size = new Size(38, 35);
            RejectAllBtn.TabIndex = 10;
            RejectAllBtn.UseVisualStyleBackColor = false;
            RejectAllBtn.Click += RejectAllBtn_Click;
            // 
            // AcceptAllBtn
            // 
            AcceptAllBtn.BackColor = Color.LimeGreen;
            AcceptAllBtn.FlatStyle = FlatStyle.Flat;
            AcceptAllBtn.ForeColor = Color.White;
            AcceptAllBtn.IconChar = FontAwesome.Sharp.IconChar.Check;
            AcceptAllBtn.IconColor = Color.White;
            AcceptAllBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            AcceptAllBtn.IconSize = 24;
            AcceptAllBtn.Location = new Point(4, 9);
            AcceptAllBtn.Margin = new Padding(0);
            AcceptAllBtn.Name = "AcceptAllBtn";
            AcceptAllBtn.Size = new Size(38, 35);
            AcceptAllBtn.TabIndex = 9;
            AcceptAllBtn.UseVisualStyleBackColor = false;
            AcceptAllBtn.Click += AcceptAllBtn_Click;
            // 
            // HRImportBtn
            // 
            HRImportBtn.BackColor = Color.Turquoise;
            HRImportBtn.FlatStyle = FlatStyle.Flat;
            HRImportBtn.ForeColor = Color.White;
            HRImportBtn.IconChar = FontAwesome.Sharp.IconChar.Upload;
            HRImportBtn.IconColor = Color.White;
            HRImportBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            HRImportBtn.IconSize = 24;
            HRImportBtn.ImageAlign = ContentAlignment.MiddleLeft;
            HRImportBtn.Location = new Point(136, 9);
            HRImportBtn.Name = "HRImportBtn";
            HRImportBtn.Size = new Size(85, 35);
            HRImportBtn.TabIndex = 7;
            HRImportBtn.Text = "Nhân sự";
            HRImportBtn.TextAlign = ContentAlignment.MiddleRight;
            HRImportBtn.UseVisualStyleBackColor = false;
            HRImportBtn.Click += HRImportBtn_Click;
            // 
            // SecretaryImportBtn
            // 
            SecretaryImportBtn.BackColor = Color.MediumSpringGreen;
            SecretaryImportBtn.FlatStyle = FlatStyle.Flat;
            SecretaryImportBtn.ForeColor = Color.White;
            SecretaryImportBtn.IconChar = FontAwesome.Sharp.IconChar.Upload;
            SecretaryImportBtn.IconColor = Color.White;
            SecretaryImportBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            SecretaryImportBtn.IconSize = 24;
            SecretaryImportBtn.ImageAlign = ContentAlignment.MiddleLeft;
            SecretaryImportBtn.Location = new Point(56, 9);
            SecretaryImportBtn.Name = "SecretaryImportBtn";
            SecretaryImportBtn.Size = new Size(75, 35);
            SecretaryImportBtn.TabIndex = 2;
            SecretaryImportBtn.Text = "Thư ký";
            SecretaryImportBtn.TextAlign = ContentAlignment.MiddleRight;
            SecretaryImportBtn.UseVisualStyleBackColor = false;
            SecretaryImportBtn.Click += SecretaryImportBtn_Click;
            // 
            // ExportExcelBtn
            // 
            ExportExcelBtn.BackColor = Color.LimeGreen;
            ExportExcelBtn.FlatStyle = FlatStyle.Flat;
            ExportExcelBtn.ForeColor = Color.White;
            ExportExcelBtn.IconChar = FontAwesome.Sharp.IconChar.Download;
            ExportExcelBtn.IconColor = Color.White;
            ExportExcelBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            ExportExcelBtn.IconSize = 24;
            ExportExcelBtn.Location = new Point(11, 9);
            ExportExcelBtn.Margin = new Padding(0);
            ExportExcelBtn.Name = "ExportExcelBtn";
            ExportExcelBtn.Size = new Size(41, 35);
            ExportExcelBtn.TabIndex = 0;
            ExportExcelBtn.UseVisualStyleBackColor = false;
            ExportExcelBtn.Click += ExportExcelBtn_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(panel5);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 462);
            panel2.Name = "panel2";
            panel2.Size = new Size(743, 43);
            panel2.TabIndex = 4;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(panel3);
            panel5.Dock = DockStyle.Right;
            panel5.Location = new Point(510, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(233, 43);
            panel5.TabIndex = 0;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(nextBtn);
            panel4.Controls.Add(prevBtn);
            panel4.Location = new Point(3, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(85, 39);
            panel4.TabIndex = 7;
            // 
            // nextBtn
            // 
            nextBtn.BackColor = Color.DodgerBlue;
            nextBtn.Cursor = Cursors.Hand;
            nextBtn.FlatStyle = FlatStyle.Flat;
            nextBtn.ForeColor = Color.White;
            nextBtn.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            nextBtn.IconColor = Color.White;
            nextBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            nextBtn.IconSize = 24;
            nextBtn.Location = new Point(42, 2);
            nextBtn.Margin = new Padding(0);
            nextBtn.Name = "nextBtn";
            nextBtn.Size = new Size(41, 35);
            nextBtn.TabIndex = 4;
            nextBtn.UseVisualStyleBackColor = false;
            nextBtn.Click += nextBtn_Click;
            // 
            // prevBtn
            // 
            prevBtn.BackColor = Color.DodgerBlue;
            prevBtn.Cursor = Cursors.Hand;
            prevBtn.FlatStyle = FlatStyle.Flat;
            prevBtn.ForeColor = Color.White;
            prevBtn.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            prevBtn.IconColor = Color.White;
            prevBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            prevBtn.IconSize = 24;
            prevBtn.Location = new Point(1, 2);
            prevBtn.Margin = new Padding(0);
            prevBtn.Name = "prevBtn";
            prevBtn.Size = new Size(41, 35);
            prevBtn.TabIndex = 3;
            prevBtn.UseVisualStyleBackColor = false;
            prevBtn.Click += prevBtn_Click;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(PageNumeric);
            panel3.Controls.Add(TotalPageLabel);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(91, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(134, 35);
            panel3.TabIndex = 6;
            // 
            // PageNumeric
            // 
            PageNumeric.Location = new Point(39, 8);
            PageNumeric.Name = "PageNumeric";
            PageNumeric.Size = new Size(50, 23);
            PageNumeric.TabIndex = 8;
            PageNumeric.KeyDown += PageNumeric_KeyDown;
            // 
            // TotalPageLabel
            // 
            TotalPageLabel.AutoSize = true;
            TotalPageLabel.BackColor = Color.White;
            TotalPageLabel.Location = new Point(101, 11);
            TotalPageLabel.Name = "TotalPageLabel";
            TotalPageLabel.Size = new Size(19, 15);
            TotalPageLabel.TabIndex = 7;
            TotalPageLabel.Text = "10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Location = new Point(89, 11);
            label3.Name = "label3";
            label3.Size = new Size(12, 15);
            label3.TabIndex = 6;
            label3.Text = "/";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Location = new Point(3, 10);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 5;
            label2.Text = "Trang";
            // 
            // TangCaDataGridView
            // 
            TangCaDataGridView.AllowUserToAddRows = false;
            TangCaDataGridView.AllowUserToDeleteRows = false;
            TangCaDataGridView.AllowUserToOrderColumns = true;
            TangCaDataGridView.AllowUserToResizeColumns = false;
            TangCaDataGridView.AllowUserToResizeRows = false;
            TangCaDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TangCaDataGridView.BackgroundColor = Color.White;
            TangCaDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TangCaDataGridView.EnableHeadersVisualStyles = false;
            TangCaDataGridView.Location = new Point(0, 55);
            TangCaDataGridView.Name = "TangCaDataGridView";
            TangCaDataGridView.RowHeadersVisible = false;
            TangCaDataGridView.Size = new Size(743, 407);
            TangCaDataGridView.TabIndex = 5;
            TangCaDataGridView.CellClick += TangCaDataGridView_CellClick;
            TangCaDataGridView.CellEndEdit += TangCaDataGridView_CellEndEdit;
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.Controls.Add(TangCaDataGridView);
            panel6.Controls.Add(panel2);
            panel6.Controls.Add(RegisterPanel);
            panel6.Dock = DockStyle.Fill;
            panel6.Location = new Point(230, 0);
            panel6.Name = "panel6";
            panel6.Size = new Size(743, 505);
            panel6.TabIndex = 1;
            // 
            // OTRegister
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel6);
            Controls.Add(LinePanel);
            Name = "OTRegister";
            Size = new Size(973, 505);
            Load += OTRegister_Load;
            LinePanel.ResumeLayout(false);
            panel1.ResumeLayout(false);
            LineListPanel.ResumeLayout(false);
            RegisterPanel.ResumeLayout(false);
            panel7.ResumeLayout(false);
            HRPanel.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PageNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)TangCaDataGridView).EndInit();
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel LinePanel;
        private Panel RegisterPanel;
        private Panel LineListPanel;
        private Button SearchBtn;
        private Control.DatePicker TimePicker;
        private CheckedListBox checkedListLine;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton ExportExcelBtn;
        private Button CheckAllBtn;
        private FontAwesome.Sharp.IconButton SecretaryImportBtn;
        private Button ViewBtn;
        private MaterialSkin.Controls.MaterialListView materialListView1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton prevBtn;
        private FontAwesome.Sharp.IconButton nextBtn;
        private Label label2;
        private Panel panel3;
        private Label TotalPageLabel;
        private Label label3;
        private Panel panel5;
        private Panel panel4;
        private NumericUpDown PageNumeric;
        private DataGridView TangCaDataGridView;
        private Panel panel6;
        private FontAwesome.Sharp.IconButton HRImportBtn;
        private Panel panel7;
        private Panel HRPanel;
        private FontAwesome.Sharp.IconButton AcceptAllBtn;
        private FontAwesome.Sharp.IconButton RejectAllBtn;
        private Component.CustomComboBox FilterHRCbb;
        private Component.CustomTextBox LineTxtBox;
        private Component.CustomTextBox MSTSearchTxb;
    }
}
