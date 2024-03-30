using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn
{
    public class Menu
    {
        private String foodname;

        public string FoodName
        {
            get { return foodname; }
            set { foodname = value; }
        }

        private int count;

        public int Count 
        {
            get { return count; }
            set { count = value; }
        }


        private float price;
        public float Price 
        {
            get { return price; }
            set { price = value; }
        }

        private float totaprice;

        public float TotaPrice
        {
            get { return totaprice; }
            set { totaprice = value; }
        }
        public Menu(string foodname, int count , float price , float totaprice = 0)
        {
            FoodName = foodname;           
            Count = count;
            Price = price;
            TotaPrice = totaprice; 

        }
        public Menu(DataRow row)
        {
            FoodName = row["ten"].ToString();
            Count = (int)row["count"];
            Price = (float)Convert.ToDouble(row["gia"].ToString());
            TotaPrice = (float)Convert.ToDouble(row["TongGia"].ToString());
        }
    }
}
