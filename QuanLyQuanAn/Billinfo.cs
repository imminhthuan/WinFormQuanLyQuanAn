using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn
{
    public class Billinfo
    {
        private int id;

        public int Id 
        {
            get { return id; }
            set { id = value; } 
        }

        private int HoaDonid;
        public int HoaDonid1
        {
            get { return HoaDonid; }
            set { HoaDonid = value; }
        }

        private int MonAnid;
        public int MonAnid1 
        {
            get { return MonAnid; }
            set { MonAnid = value; } 
        }


        private int Count;
        public int Count1 
        {
            get { return Count; }
            set { Count = value; }
        }

        public Billinfo(int id , int HoaDonid , int MonAnid , int Count)
        {
            Id = id;
            HoaDonid1 = HoaDonid;
            MonAnid1 = MonAnid1;
            Count1 = Count;
        }
        public Billinfo(DataRow row)
        {
            Id = (int)row["id"];
            HoaDonid1 = (int)row["idHoaDon"];
            MonAnid1 = (int)row["idMonAn"];
            Count1 = (int)row["Count"];
        }

     
    }
}
