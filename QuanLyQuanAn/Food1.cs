using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;


namespace QuanLyQuanAn
{
    public class Food1
    {
        private static Food1 instance;

        public static Food1 Instance 
        { 
            get
            {
                if(instance == null) instance = new Food1(); return Food1.instance;
            }
            private set
            {
                Food1.instance = value;
            }
        }
        private Food1()
        {

        }
        public List<Food> GetFoodByCategoryID(int id)
        {
            List<Food> list = new List<Food>();
            string query = "select * from dbo.MonAn where idDanhMucMonAn =" + id;
            DataTable Data = DataD.Instance.ExecuteQuery(query);
            foreach (DataRow item in Data.Rows)
            {
                Food food = new Food(item);
                list.Add(food);               
            }
            return list;
        }
   
    }
}
