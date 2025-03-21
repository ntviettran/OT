using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using OT.Core.GlobalVariable;
using OT.UI.Control;
using OT.UI.Page;

namespace OT.UI.Forms
{
    public partial class MainForm : Form
    {
        private UserControl? _currentControl;
        public MainForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.Manual;
            this.Bounds = Screen.PrimaryScreen.WorkingArea;

            NavigateHeader.IconColor = Color.White;
            UserButton.IconColor = Color.White;
            UserButton.MST = GlobalUser.Masothe.ToString();
            UserButton.UserName = GlobalUser.Hoten;
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (GlobalService.ServiceProvider != null)
            {
                UserControl otRegister = GlobalService.ServiceProvider.GetRequiredService<OTRegister>();
                ShowUserControl(otRegister);
            }
        }

        private void ShowUserControl(UserControl newControl)
        {
            if (MainPanel == null) return;

            if (_currentControl != null)
            {
                MainPanel.Controls.Remove(_currentControl);
            }

            _currentControl = newControl;
            _currentControl.Dock = DockStyle.Fill;
            MainPanel.Controls.Add(_currentControl);
            _currentControl.BringToFront();
        }

        private void OTRegisterTrip_Click(object sender, EventArgs e)
        {
            if (GlobalService.ServiceProvider != null)
            {
                UserControl otRegister = GlobalService.ServiceProvider.GetRequiredService<OTRegister>();
                ShowUserControl(otRegister);
            }
        }
    }
}
