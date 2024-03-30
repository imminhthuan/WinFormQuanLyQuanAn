using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanAn
{
    public class Category
    {
        private int id;
      
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        private string ten;
        public string Ten 
        { 
            get
            {
                return ten;
            }
            set
            {
                ten = value;
            }
        }
        public Category(int id , String ten)
        {
            Id = id;
            Ten = ten;
        }
        public Category(DataRow row)
        {
            Id = (int)row["id"];
            Ten = row["Ten"].ToString();
        }
    }
}
