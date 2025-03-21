using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace OT.UI.Component
{
    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            this.DrawMode = DrawMode.OwnerDrawFixed;
            this.DropDownStyle = ComboBoxStyle.DropDownList;
            this.ItemHeight = 28;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            e.DrawBackground();
            e.DrawFocusRectangle();

            using (Brush textBrush = new SolidBrush(e.ForeColor))
            using (StringFormat sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center; // Căn giữa dọc
                e.Graphics.DrawString(Items[e.Index].ToString(), Font, textBrush, e.Bounds, sf);
            }
        }
    }
}
