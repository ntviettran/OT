using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

namespace OT.UI.Component
{
    public class CustomTextBox : UserControl
    {
        private TextBox textBox;
        public event KeyEventHandler CustomKeyDown;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string PlaceholderText
        {
            get => textBox.PlaceholderText;
            set => textBox.PlaceholderText = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font
        {
            get => textBox.Font;
            set => textBox.Font = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Color ForeColor
        {
            get => textBox.ForeColor;
            set => textBox.ForeColor = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HorizontalAlignment TextAlign
        {
            get => textBox.TextAlign;
            set => textBox.TextAlign = value;
        }

        public CustomTextBox()
        {
            this.Height = 35; 
            this.Width = 200;
            this.Padding = new Padding(1);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

            textBox = new TextBox
            {
                BorderStyle = BorderStyle.None, // Ẩn border của TextBox gốc
                TextAlign = HorizontalAlignment.Left, // Có thể đổi thành Center nếu muốn
                Dock = DockStyle.Fill, // Tự động giãn để vừa UserControl
                Margin = new Padding(0)
            };

            textBox.KeyDown += TextBox_KeyDown;

            // Căn giữa theo chiều dọc bằng cách dùng Panel
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };
            panel.Padding = new Padding(0, (this.Height - textBox.Height) / 2, 0, 0);
            panel.Controls.Add(textBox);
            this.Controls.Add(panel);
        }

        public CustomTextBox(Color foreColor)
        {
            ForeColor = foreColor;
        }

        private void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            CustomKeyDown?.Invoke(this, e);
        }
    }

}
