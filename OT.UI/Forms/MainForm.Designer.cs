namespace OT.UI.Forms
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            NavigateHeader = new Control.NavigateHeader();
            UserButton = new Component.UserButton();
            MainPanel = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            OTRegisterTrip = new ToolStripMenuItem();
            menuStrip1 = new MenuStrip();
            MainPanel.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // NavigateHeader
            // 
            NavigateHeader.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            NavigateHeader.BackColor = Color.DodgerBlue;
            NavigateHeader.Location = new Point(916, 0);
            NavigateHeader.Name = "NavigateHeader";
            NavigateHeader.Size = new Size(71, 24);
            NavigateHeader.TabIndex = 3;
            // 
            // UserButton
            // 
            UserButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            UserButton.BackColor = Color.DodgerBlue;
            UserButton.ForeColor = Color.DodgerBlue;
            UserButton.Location = new Point(893, 0);
            UserButton.Name = "UserButton";
            UserButton.Size = new Size(27, 24);
            UserButton.TabIndex = 4;
            // 
            // MainPanel
            // 
            MainPanel.Controls.Add(panel1);
            MainPanel.Controls.Add(label1);
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 24);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(980, 534);
            MainPanel.TabIndex = 5;
            // 
            // panel1
            // 
            panel1.Location = new Point(716, -25);
            panel1.Name = "panel1";
            panel1.Size = new Size(124, 24);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(850, -17);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 0;
            label1.Text = "label1";
            // 
            // OTRegisterTrip
            // 
            OTRegisterTrip.BackColor = Color.DodgerBlue;
            OTRegisterTrip.ForeColor = Color.White;
            OTRegisterTrip.Name = "OTRegisterTrip";
            OTRegisterTrip.Size = new Size(104, 20);
            OTRegisterTrip.Text = "Đăng ký tăng ca";
            OTRegisterTrip.Click += OTRegisterTrip_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = Color.DodgerBlue;
            menuStrip1.Items.AddRange(new ToolStripItem[] { OTRegisterTrip });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(980, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(980, 558);
            Controls.Add(UserButton);
            Controls.Add(MainPanel);
            Controls.Add(NavigateHeader);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            MainPanel.ResumeLayout(false);
            MainPanel.PerformLayout();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Control.NavigateHeader NavigateHeader;
        private Component.UserButton UserButton;
        private Panel MainPanel;
        private Label label1;
        private ToolStripMenuItem OTRegisterTrip;
        private MenuStrip menuStrip1;
        private Label UserLabel;
        private Panel panel1;
    }
}