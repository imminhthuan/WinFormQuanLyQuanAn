using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn
{
    public class Menuss
    {
        private static Menuss instance;

        public static Menuss Instance 
        {
            get { if (instance == null) instance = new Menuss(); return Menuss.instance; }
            private set { Menuss.instance = value; } 
        }

        public Menuss()
        {
            
        }
        public List<Menu> GetListMenuByTable(int id)
        {
            List<Menu> listMenu = new List<Menu>();
            String query = ("SELECT MA.Ten , TTHD.Count , MA.Gia , MA.Gia*TTHD.Count AS TongGia FROM dbo.ThongTinHoaDon AS TTHD, dbo.HoaDon AS HD, dbo.MonAn AS MA where TTHD.idHoaDon = HD.id AND TTHD.idMonAn = MA.id AND HD.TrangThai = 0 AND HD.idBanAn =" + id);
            DataTable data = DataD.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Menu menu = new Menu(item);
                listMenu.Add(menu);
            }           
            return listMenu;
        }
    }
}
