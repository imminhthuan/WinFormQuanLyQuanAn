using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QuanLyQuanAn
{
    public partial class flogin : Form
    {
        public flogin()
        {
            InitializeComponent();
        }
        private int Dem_SL_DN_Sai = 0;

        private void btnExit_Click(object sender, EventArgs e)
        {                     
             Close();                         
        }

        private void flogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn thoát không","Thông Báo",MessageBoxButtons.OKCancel, MessageBoxIcon.Error) != DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        
        private void btnLogin_Click(object sender, EventArgs e)
        {

            String UserName = txtUserName.Text;
            String PassWord = txtPassWord.Text;
            if (Login( UserName, PassWord))
            {            
                Form2 f = new Form2();
                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else 
            {
                MessageBox.Show("Tài Khoản Hoặc Mật Khẩu Không Đúng!!", "Thông Báo",MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Dem_SL_DN_Sai ++;
                if(Dem_SL_DN_Sai == 3)
                {
                    btnLogin.Enabled = false;
                    timer1.Enabled = true;
                    Dem_SL_DN_Sai = 0;
                }
            }
        }
        bool Login(String UserName, String PassWord)
        {
            return Account.Instance.Login( UserName , PassWord);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Dem_SL_DN_Sai++;
            if(Dem_SL_DN_Sai == 3)
            {
                btnLogin.Enabled = true;
                timer1.Enabled = false;
                Dem_SL_DN_Sai = 0;
            } 
        }

        private void flogin_Load(object sender, EventArgs e)
        {

        }
    }
}
