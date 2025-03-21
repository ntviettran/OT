namespace OT.UI
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            mstTxtBox = new MaterialSkin.Controls.MaterialTextBox();
            label1 = new Label();
            panel1 = new Panel();
            label2 = new Label();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            loginBtn = new MaterialSkin.Controls.MaterialButton();
            errorLabel = new Label();
            facCombobox = new MaterialSkin.Controls.MaterialComboBox();
            navigateHeader1 = new OT.UI.Control.NavigateHeader();
            passwordTxtBox = new MaterialSkin.Controls.MaterialTextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // mstTxtBox
            // 
            mstTxtBox.AnimateReadOnly = false;
            mstTxtBox.BackColor = Color.White;
            mstTxtBox.BorderStyle = BorderStyle.None;
            mstTxtBox.Depth = 0;
            mstTxtBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            mstTxtBox.ForeColor = SystemColors.Desktop;
            mstTxtBox.Hint = "Mã số thẻ";
            mstTxtBox.LeadingIcon = null;
            mstTxtBox.Location = new Point(404, 175);
            mstTxtBox.MaxLength = 50;
            mstTxtBox.MouseState = MaterialSkin.MouseState.OUT;
            mstTxtBox.Multiline = false;
            mstTxtBox.Name = "mstTxtBox";
            mstTxtBox.Size = new Size(299, 50);
            mstTxtBox.TabIndex = 0;
            mstTxtBox.Text = "";
            mstTxtBox.TrailingIcon = null;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.InfoText;
            label1.Location = new Point(457, 27);
            label1.Name = "label1";
            label1.Size = new Size(193, 39);
            label1.TabIndex = 2;
            label1.Text = "Đăng nhập";
            // 
            // panel1
            // 
            panel1.BackColor = Color.DodgerBlue;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(0, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(360, 411);
            panel1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(51, 260);
            label2.Name = "label2";
            label2.Size = new Size(197, 39);
            label2.TabIndex = 2;
            label2.Text = "Nam Thuận";
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.logo_white;
            pictureBox2.Location = new Point(52, 86);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(185, 165);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 1;
            pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.clouds_upright_2x;
            pictureBox1.Location = new Point(283, -4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(100, 412);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // loginBtn
            // 
            loginBtn.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            loginBtn.BackColor = Color.DodgerBlue;
            loginBtn.Cursor = Cursors.Hand;
            loginBtn.Density = MaterialSkin.Controls.MaterialButton.MaterialButtonDensity.Default;
            loginBtn.Depth = 0;
            loginBtn.HighEmphasis = true;
            loginBtn.Icon = null;
            loginBtn.Location = new Point(499, 338);
            loginBtn.Margin = new Padding(4, 6, 4, 6);
            loginBtn.MouseState = MaterialSkin.MouseState.HOVER;
            loginBtn.Name = "loginBtn";
            loginBtn.NoAccentTextColor = Color.Empty;
            loginBtn.Size = new Size(105, 36);
            loginBtn.TabIndex = 2;
            loginBtn.Text = "Đăng Nhập";
            loginBtn.Type = MaterialSkin.Controls.MaterialButton.MaterialButtonType.Contained;
            loginBtn.UseAccentColor = false;
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += loginBtn_Click;
            // 
            // errorLabel
            // 
            errorLabel.AutoSize = true;
            errorLabel.ForeColor = Color.Red;
            errorLabel.Location = new Point(404, 310);
            errorLabel.Name = "errorLabel";
            errorLabel.Size = new Size(32, 15);
            errorLabel.TabIndex = 6;
            errorLabel.Text = "Error";
            errorLabel.Visible = false;
            // 
            // facCombobox
            // 
            facCombobox.AutoResize = false;
            facCombobox.BackColor = Color.FromArgb(255, 255, 255);
            facCombobox.Depth = 0;
            facCombobox.DrawMode = DrawMode.OwnerDrawVariable;
            facCombobox.DropDownHeight = 174;
            facCombobox.DropDownStyle = ComboBoxStyle.DropDownList;
            facCombobox.DropDownWidth = 121;
            facCombobox.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            facCombobox.ForeColor = Color.FromArgb(222, 0, 0, 0);
            facCombobox.FormattingEnabled = true;
            facCombobox.IntegralHeight = false;
            facCombobox.ItemHeight = 43;
            facCombobox.Items.AddRange(new object[] { "NT1", "NT2" });
            facCombobox.Location = new Point(404, 94);
            facCombobox.MaxDropDownItems = 4;
            facCombobox.MouseState = MaterialSkin.MouseState.OUT;
            facCombobox.Name = "facCombobox";
            facCombobox.Size = new Size(299, 49);
            facCombobox.StartIndex = 0;
            facCombobox.TabIndex = 3;
            // 
            // navigateHeader1
            // 
            navigateHeader1.BackColor = Color.White;
            navigateHeader1.Location = new Point(680, 1);
            navigateHeader1.Name = "navigateHeader1";
            navigateHeader1.Size = new Size(71, 32);
            navigateHeader1.TabIndex = 8;
            // 
            // passwordTxtBox
            // 
            passwordTxtBox.AnimateReadOnly = false;
            passwordTxtBox.BackColor = Color.White;
            passwordTxtBox.BorderStyle = BorderStyle.None;
            passwordTxtBox.Depth = 0;
            passwordTxtBox.Font = new Font("Roboto", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            passwordTxtBox.ForeColor = SystemColors.Desktop;
            passwordTxtBox.Hint = "Mật khẩu";
            passwordTxtBox.LeadingIcon = null;
            passwordTxtBox.Location = new Point(404, 255);
            passwordTxtBox.MaxLength = 50;
            passwordTxtBox.MouseState = MaterialSkin.MouseState.OUT;
            passwordTxtBox.Multiline = false;
            passwordTxtBox.Name = "passwordTxtBox";
            passwordTxtBox.Password = true;
            passwordTxtBox.Size = new Size(299, 50);
            passwordTxtBox.TabIndex = 1;
            passwordTxtBox.Text = "";
            passwordTxtBox.TrailingIcon = null;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(745, 405);
            Controls.Add(passwordTxtBox);
            Controls.Add(navigateHeader1);
            Controls.Add(facCombobox);
            Controls.Add(errorLabel);
            Controls.Add(loginBtn);
            Controls.Add(panel1);
            Controls.Add(label1);
            Controls.Add(mstTxtBox);
            ForeColor = SystemColors.MenuHighlight;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MaterialSkin.Controls.MaterialTextBox mstTxtBox;
        private Label label1;
        private Panel panel1;
        private MaterialSkin.Controls.MaterialButton loginBtn;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Label label2;
        private Label errorLabel;
        private MaterialSkin.Controls.MaterialComboBox facCombobox;
        private Control.NavigateHeader navigateHeader1;
        private MaterialSkin.Controls.MaterialTextBox passwordTxtBox;
    }
}
