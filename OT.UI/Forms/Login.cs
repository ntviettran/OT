using System.Diagnostics;
using System.Net;
using System.Reflection;
using MaterialSkin;
using MaterialSkin.Controls;
using Microsoft.Extensions.DependencyInjection;
using OT.Core.Dto;
using OT.Core.GlobalVariable;
using OT.Services.Interfaces;
using OT.UI.Forms;

namespace OT.UI
{
    public partial class Login : Form
    {
        private readonly IUserService _userService;

        public Login(IUserService userService)
        {
            InitializeComponent();

            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.ColorScheme = new ColorScheme(
                Primary.Blue600,
                Primary.BlueGrey900,
                Primary.BlueGrey500,
                Accent.LightBlue400,
                TextShade.WHITE
            );

            _userService = userService;
            this.AcceptButton = loginBtn;
        }

        private void handleError(bool show, string message)
        {
            errorLabel.Text = message;
            errorLabel.Visible = show;
        }

        private async void loginBtn_Click(object sender, EventArgs e)
        {
            string fac = facCombobox.SelectedItem!.ToString()!;
            string mst = mstTxtBox.Text;
            string password = passwordTxtBox.Text;

            if (int.TryParse(mst, out int mstParse))
            {
                Cursor.Current = Cursors.WaitCursor;
                var user = await _userService.GetUser(fac, mstParse, password);
                if (user != null)
                {
                    GlobalUser.Login(user);
                    handleError(false, "");

                    if (GlobalService.ServiceProvider != null)
                    {
                        this.Hide();
                        var mainForm = GlobalService.ServiceProvider.GetRequiredService<MainForm>();
                        mainForm.Show();
                    }
                }
                else
                {
                    handleError(true, "Mã số thẻ hoặc mật khẩu không đúng");
                }
            }
            else
            {
                handleError(true, "Mã số thẻ không đúng định dạng");
            }
        }
    }
}
