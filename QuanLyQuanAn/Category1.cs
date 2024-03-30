using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanAn
{
    internal class Category1
    {
        private static Category1 instance;

        internal static Category1 Instance 
        {
            get
            {
                if(instance == null) instance = new Category1(); return Category1.instance;
            }
            private set
            {
                Category1.instance = value;
            }
        }
        private Category1()
        {

        }
        public List<Category> GetListCategory()
        {
            List<Category> listcategory = new List<Category>();
            string query = "SELECT * FROM DanhMucMonAn";
            DataTable Data = DataD.Instance.ExecuteQuery(query);
            foreach (DataRow item in Data.Rows)
            {
                Category category = new Category(item);

                listcategory.Add(category);
            }

            return listcategory;
        }
    }
}
