using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace QuanLyQuanAn
{
    public class Account
    {
        private static Account instance;

        public static Account Instance
        {
            get { if (instance == null) instance = new Account(); return instance; }
            private set { instance = value; }
        }
        private Account()
        {

        }
          
        public bool Login(String UserName , String PassWord)
        {         
            String query = "SELECT * FROM dbo.TaiKhoanDangNhap Where TenDangNhap = '" + UserName + "' And MatKhau = '" + PassWord + "' ";
            DataTable result = DataD.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0; 
        }
    }

}
