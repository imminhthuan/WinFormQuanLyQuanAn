using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace QuanLyQuanAn
{
    public class Bill
    {
        
        private static Bill instance;

        public static Bill Instance 
        { 
            get
            {
                if (instance == null) instance = new Bill(); return Bill.instance;
            }
            private set
            {
                Bill.instance = value;
            }
        }
        private Bill()
        {

        }
        public int GetUncheckIDByTableID(int ID)
        {
            DataTable Data = DataD.Instance.ExecuteQuery("SELECT * FROM dbo.HoaDon where idBanAn =" + ID + " and TrangThai = 0");

            if(Data.Rows.Count > 0)
            {
                Bills bill = new Bills(Data.Rows[0]);
                return bill.Id;
            }
            
            return -1;
        }

        public void CheckOut(int id , float TotaPrice)
        {
            String query = " UPDATE dbo.HoaDon SET TrangThai = 1 , TotaPrice = " + TotaPrice + " where id = " + id;
            DataD.Instance.ExecuteNonQuery(query);
        }
        public void InsertBill(int id)
        {
            DataD.Instance.ExecuteNonQuery(" exec USP_InSertHoaDon @idBanAn ", new object[] { id });
        }
        public int GetMaxIDBill()
        {
            try
            {
                return (int)DataD.Instance.ExecuteScalar(" SELECT Max(id) FROM dbo.HoaDon ");
                
            }
            catch (Exception)
            {
                return 1;               
            }
        }
    }
}
