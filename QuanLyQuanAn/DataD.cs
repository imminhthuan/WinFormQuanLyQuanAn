using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanAn
{
    public  class DataD
    {
        private static DataD instance;
        public static DataD Instance
        {
            get { if (instance == null) instance = new DataD(); return DataD.instance;}
            private set { DataD.instance = value; }
        }
        private DataD(){}

        private String ConnectionSTR = "Data Source=LAPTOP-7JIKMVLO\\SQLEXPRESS;Initial Catalog=QL_Quan_An;Integrated Security=True";
       
        public DataTable ExecuteQuery(String query , object[] parameter = null)
        {
            DataTable Data = new DataTable();
            using (SqlConnection conn = new SqlConnection(ConnectionSTR)) 
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(Data);
                conn.Close();
               
            }
            return Data;
        }
        public int ExecuteNonQuery(String query, object[] parameter = null)
        {
            int Data = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionSTR))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                Data = command.ExecuteNonQuery();
                conn.Close();
            }
            return Data;
        }
        public object ExecuteScalar(String query, object[] parameter = null)
        {
            object Data = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionSTR))
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                if (parameter != null)
                {
                    String[] listPara = query.Split(' ');
                    int i = 0;
                    foreach (String item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }
                Data = command.ExecuteScalar();
                conn.Close();

            }
            return Data;
        }
    }
}

