using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanAn
{
    public class Food
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

        private int Danhmucmonan;
        public int DanhMucMonAn
        {
            get
            {
                return Danhmucmonan;
            }
            set
            {
                Danhmucmonan = value;
            }
        }

        private float gia;
        public float Gia
        {
            get
            {
                return gia;
            }
            set
            {
                gia = value;
            }
        }
        public Food(int id, String ten, int Danhmucmonan, float gia)
        {
            Id = id;
            Ten  = ten;
            DanhMucMonAn = Danhmucmonan;
            Gia = gia;
        }
        public Food(DataRow row)
        {
            Id = (int)row["id"];
            Ten = row["ten"].ToString();
            DanhMucMonAn = (int)row["idDanhMucMonAn"];
            Gia = (float)Convert.ToDouble(row["gia"].ToString());
        }
    }
}

