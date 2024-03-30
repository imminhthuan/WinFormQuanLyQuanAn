using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace QuanLyQuanAn
{
    public class Bills
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
        private DateTime? DatecheckIn;
        public DateTime? DatecheckIn1
        {
            get
            {
                return DatecheckIn;
            }
            set
            {
                DatecheckIn = value;
            }         
        }
        private DateTime? DatecheckOut;
        public DateTime? DatecheckOut1
        { 
            get
            {
                return DatecheckOut;
            }

            set
            {
                DatecheckOut = value;
            }
        }
        public int trangthai;
        public int Trangthai 
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
        public Bills(int id, DateTime? DatecheckIn, DateTime? DatecheckOut, int trangthai)
        {
            Id = id;
            DatecheckIn1 = DatecheckIn;
            DatecheckOut1 = DatecheckOut;
            Trangthai = trangthai;
        }
        public Bills(DataRow row)
        {
            Id = (int)row["id"];
            DatecheckIn1 = (DateTime?)row["DatecheckIn"];
            var DatecheckOutTemp = row["datecheckOut"];
            if (DatecheckOutTemp.ToString() != "")
                DatecheckOut1 = (DateTime?)DatecheckOutTemp;
            Trangthai = (int)row["trangthai"];
        }
    }
}
