using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Xml.Linq;


namespace QuanLyQuanAn
{
    public class Tablecs
    {
        private static Tablecs instance;

        public static Tablecs Instance 
        { 
            get
            {
                if (instance == null) instance = new Tablecs(); return Tablecs.instance;
            }
            set
            {
                Tablecs.instance = value;
            }
        }

        public static int TableWidth = 80;
        public static int TableHeight = 80;
        private Tablecs()
        {
            
        }

        public void SwitchTable(int id1 , int id2)
        {
            DataD.Instance.ExecuteQuery("USP_SwichTable  @idTable1 , @idTable2", new object[] { id1, id2 });
        }
        public List<Table> LoadTableList()
        {
            List<Table> TableList = new List<Table>();
            DataTable data = DataD.Instance.ExecuteQuery("USP_GetTableList");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                TableList.Add(table);
            }
            return TableList;           
        }
       
    }
    
}
