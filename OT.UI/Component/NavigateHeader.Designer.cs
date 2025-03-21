namespace OT.UI.Control
{
    partial class NavigateHeader
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
            closeBtn = new FontAwesome.Sharp.IconPictureBox();
            minimizeBtn = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)closeBtn).BeginInit();
            ((System.ComponentModel.ISupportInitialize)minimizeBtn).BeginInit();
            SuspendLayout();
            // 
            // closeBtn
            // 
            closeBtn.BackColor = Color.White;
            closeBtn.Cursor = Cursors.Hand;
            closeBtn.ForeColor = Color.Black;
            closeBtn.IconChar = FontAwesome.Sharp.IconChar.X;
            closeBtn.IconColor = Color.Black;
            closeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            closeBtn.IconSize = 24;
            closeBtn.Location = new Point(41, 1);
            closeBtn.Name = "closeBtn";
            closeBtn.Size = new Size(24, 24);
            closeBtn.TabIndex = 0;
            closeBtn.TabStop = false;
            closeBtn.Click += closeBtn_Click;
            // 
            // minimizeBtn
            // 
            minimizeBtn.BackColor = Color.White;
            minimizeBtn.Cursor = Cursors.Hand;
            minimizeBtn.ForeColor = SystemColors.ControlText;
            minimizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            minimizeBtn.IconColor = SystemColors.ControlText;
            minimizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            minimizeBtn.IconSize = 24;
            minimizeBtn.Location = new Point(8, 1);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.Size = new Size(24, 24);
            minimizeBtn.TabIndex = 1;
            minimizeBtn.TabStop = false;
            minimizeBtn.Click += minimizeBtn_Click;
            // 
            // NavigateHeader
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(minimizeBtn);
            Controls.Add(closeBtn);
            Name = "NavigateHeader";
            Size = new Size(71, 24);
            ((System.ComponentModel.ISupportInitialize)closeBtn).EndInit();
            ((System.ComponentModel.ISupportInitialize)minimizeBtn).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private FontAwesome.Sharp.IconPictureBox closeBtn;
        private FontAwesome.Sharp.IconPictureBox minimizeBtn;
    }
}
