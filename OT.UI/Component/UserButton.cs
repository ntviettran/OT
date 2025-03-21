using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using OT.Core.GlobalVariable;

namespace OT.UI.Component
{
    public partial class UserButton : UserControl
    {
        private IconButton btnUser;
        private ContextMenuStrip dropdownMenu;
        private ToolStripMenuItem lblUserInfo;
        private ToolStripSeparator separator;
        private ToolStripMenuItem btnLogout;

        private string _userName = "";
        private string _mst = "";
        private Color _iconColor = Color.Black;

        public event EventHandler LogoutClicked;

        public UserButton()
        {
            InitializeComponent();
            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            btnUser = new IconButton
            {
                Size = new Size(24, 24),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.Transparent,
                IconChar = IconChar.User,
                IconColor = _iconColor,
                IconSize = 24,
                Cursor = Cursors.Hand
            };
            btnUser.FlatAppearance.BorderSize = 0;
            btnUser.FlatAppearance.MouseOverBackColor = btnUser.BackColor;
            btnUser.FlatAppearance.MouseDownBackColor = btnUser.BackColor;
            btnUser.Click += BtnUser_Click;

            Controls.Add(btnUser);

            dropdownMenu = new ContextMenuStrip();
            dropdownMenu.RenderMode = ToolStripRenderMode.System;

            lblUserInfo = new ToolStripMenuItem($"{_mst} - {_userName}");

            separator = new ToolStripSeparator();


            btnLogout = new ToolStripMenuItem("Đăng xuất");
            btnLogout.Click += BtnLogout_Click;

            dropdownMenu.Items.Add(lblUserInfo);
            dropdownMenu.Items.Add(separator);
            dropdownMenu.Items.Add(btnLogout);
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            dropdownMenu.Show(btnUser, new Point(0, btnUser.Height));
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            if (this.Parent is Form parentForm)
            {
                parentForm.Hide();
                if (GlobalService.ServiceProvider != null)
                {
                    var loginForm = GlobalService.ServiceProvider.GetRequiredService<Login>();
                    loginForm.Show();
                    GlobalUser.Logout();
                }
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                lblUserInfo.Text = $"{_mst} - {_userName}";
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string MST
        {
            get { return _mst; }
            set
            {
                _mst = value;
                lblUserInfo.Text = $"{_mst} - {_userName}";
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color IconColor
        {
            get { return _iconColor; }
            set
            {
                _iconColor = value;
                btnUser.IconColor = _iconColor;
                this.Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IconChar Icon
        {
            get { return btnUser.IconChar; }
            set { btnUser.IconChar = value; }
        }
    }
}
