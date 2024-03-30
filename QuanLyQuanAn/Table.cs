using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Data;

namespace QuanLyQuanAn
{
    public class Table
    {
        private int iD;

        public int ID
        { 
            get
            {
                return iD;
            }          
            set
            {
                iD = value;
            } 
        }
        private String ten;
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
        private String trangthai;
        public string TrangThai
        {
            get
            {
                return trangthai;
            }
            set
            {
                trangthai = value;
            }
        }
        public Table(int iD , String ten , String trangthai)
        {
            this.ID = iD;
            this.Ten = ten;
            this.TrangThai = trangthai;
        }
        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Ten = row["ten"].ToString();
            this.TrangThai = row["trangthai"].ToString();
        }
    }  
}
