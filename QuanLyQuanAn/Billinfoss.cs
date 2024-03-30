using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn
{
    public class Billinfoss
    {
        public static Billinfoss instance;

        public static Billinfoss Instance 
        {
            get { if (instance == null) instance = new Billinfoss(); return Billinfoss.instance; }
            private set { Billinfoss.instance = value; } 
        }
        public Billinfoss()
        {

        }
        public List<Billinfo> GetListBillinfo(int id)
        {
            List<Billinfo> listBillinfo = new List<Billinfo>();
            DataTable Data = DataD.Instance.ExecuteQuery(" SELECT * FROM dbo.ThongTinHoaDon where idHoaDon = " + id );
            foreach (DataRow item in Data.Rows)
            {
                Billinfo info = new Billinfo(item);
                listBillinfo.Add(info);
            }
            return listBillinfo;
        }
        public void InsertBillInfo(int idHoaDon , int idMonAn , int Count)
        {
            DataD.Instance.ExecuteNonQuery(" USP__InsertThongTinHoaDon @idHoaDon , @idMonAn , @Count " , new object[] { idHoaDon , idMonAn , Count });
        }
     
    }
}
