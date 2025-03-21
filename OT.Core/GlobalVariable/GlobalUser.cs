using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OT.Core.Dto;

namespace OT.Core.GlobalVariable
{
    public class GlobalUser
    {
        public static int Masothe { get; set; }
        public static string Hoten { get; set; } = "";
        public static string Nhamay { get; set; } = "NT1";
        public static string Phanquyen { get; set; } = "user";
        public static string Phongban { get; set; } = "";

        public static void Login(DUser? user)
        {
            if (user == null) return;

            Masothe = user.masothe;
            Hoten = user.hoten;
            Nhamay = user.nhamay;
            Phanquyen = user.phanquyen;
            Phongban = user.phongban;
        }

        public static void Logout()
        {
            Masothe = 0;
            Hoten = "";
            Nhamay = "NT1";
            Phanquyen = "user";
            Phongban = "";
        }
    }
}
