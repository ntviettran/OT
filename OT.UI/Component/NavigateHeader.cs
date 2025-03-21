using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace OT.UI.Control
{
    public partial class NavigateHeader : UserControl
    {
        private Color _iconColor = Color.Black;
        public NavigateHeader()
        {
            InitializeComponent();
            closeBtn.BackColor = Color.Transparent;
            minimizeBtn.BackColor = Color.Transparent;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color IconColor
        {
            get { return _iconColor; }
            set
            {
                _iconColor = value;
                closeBtn.IconColor = _iconColor;
                minimizeBtn.IconColor = _iconColor;
                this.Invalidate(); 
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            if (this.Parent is Form parentForm)
            {
                parentForm.Hide();
            }
            Environment.Exit(0);
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            if (this.Parent is Form parentForm)
            {
                parentForm.WindowState = FormWindowState.Minimized;
            }
        }
    }
}
