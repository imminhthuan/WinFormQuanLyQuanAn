using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyQuanAn
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();

            LoadDoanhThu();

            LoadMonAn();

            LoadDanhMuc();

            LoadBanAn();

            LoadTaiKhoan();
        }
        
     
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnShowCategory_Click(object sender, EventArgs e)
        {

        }

        private void dtgvAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void Form4_Load(object sender, EventArgs e)
        {     
           
        }
        void LoadDoanhThu()
        {
            String ConnectionSTR = "Data Source=LAPTOP-7JIKMVLO\\SQLEXPRESS;Initial Catalog=QL_Quan_An;Integrated Security=True";
            SqlConnection conn = new SqlConnection(ConnectionSTR);
            String query = "SELECT * FROM dbo.HoaDon";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            DataTable Data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(Data);
            conn.Close();
            dtgvBill.DataSource = Data;
        }
        void LoadMonAn()
        {
            String ConnectionSTR = "Data Source=LAPTOP-7JIKMVLO\\SQLEXPRESS;Initial Catalog=QL_Quan_An;Integrated Security=True";
            SqlConnection conn = new SqlConnection(ConnectionSTR);
            String query = "SELECT * FROM dbo.MonAn";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            DataTable Data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(Data);
            conn.Close();
            dtgvFood.DataSource = Data;
        }
        void LoadDanhMuc()
        {
            String ConnectionSTR = "Data Source=LAPTOP-7JIKMVLO\\SQLEXPRESS;Initial Catalog=QL_Quan_An;Integrated Security=True";
            SqlConnection conn = new SqlConnection(ConnectionSTR);
            String query = "SELECT * FROM dbo.MonAn";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            DataTable Data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(Data);
            conn.Close();
            dtgvCategory.DataSource = Data;
        }
        void LoadBanAn()
        {
            String ConnectionSTR = "Data Source=LAPTOP-7JIKMVLO\\SQLEXPRESS;Initial Catalog=QL_Quan_An;Integrated Security=True";
            SqlConnection conn = new SqlConnection(ConnectionSTR);
            String query = "SELECT * FROM dbo.BanAn";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            DataTable Data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(Data);
            conn.Close();
            dtgvTable.DataSource = Data;
        }
        void LoadTaiKhoan()
        {
            String ConnectionSTR = "Data Source=LAPTOP-7JIKMVLO\\SQLEXPRESS;Initial Catalog=QL_Quan_An;Integrated Security=True";
            SqlConnection conn = new SqlConnection(ConnectionSTR);
            String query = "SELECT * FROM dbo.TaiKHoanDangNhap";
            conn.Open();
            SqlCommand command = new SqlCommand(query, conn);
            DataTable Data = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(Data);
            conn.Close();
            dtgvAccount.DataSource = Data;
        }

    }
}
