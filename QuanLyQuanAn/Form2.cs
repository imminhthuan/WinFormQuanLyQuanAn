using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;



namespace QuanLyQuanAn
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();

            LoadTable();

            LoadCategory();

            LoadComboboxTable(cbChuyenBan);
        }
        void LoadTable()
        {
            flpTable.Controls.Clear();
            List<Table> TableList = Tablecs.Instance.LoadTableList();
            foreach (Table item in TableList)
            {
                Button btn = new Button() { Width = Tablecs.TableWidth, Height = Tablecs.TableHeight };
                btn.Text = item.Ten + Environment.NewLine + item.TrangThai;
                flpTable.Controls.Add(btn);

                if (item.TrangThai != "Trống")
                {
                    btn.BackColor = Color.Green;
                }
                else
                {
                    btn.BackColor = Color.Red;
                }
                btn.Click += btn_Click;
                btn.Tag = item;
                //MessageBox.Show(item);
            }
        }
        void ShowBill(int id)
        {
            lsvHoaDon.Items.Clear();
            List<Menu> listBillinfo = Menuss.Instance.GetListMenuByTable(id);
            float totaPrice = 0;
            foreach (Menu item in listBillinfo)
            {
                ListViewItem lsvItem = new ListViewItem(item.FoodName.ToString());

                lsvItem.SubItems.Add(item.Count.ToString());
                lsvItem.SubItems.Add(item.Price.ToString());
                lsvItem.SubItems.Add(item.TotaPrice.ToString());
                totaPrice += item.TotaPrice;
                lsvHoaDon.Items.Add(lsvItem);
            }
            CultureInfo cultureInfo = new CultureInfo("en-vn");

            txtTotaPrice.Text = totaPrice.ToString("c");
            
            


        }
        public void LoadCategory()
        {
            List<Category> listCategory = Category1.Instance.GetListCategory();
            Console.WriteLine(listCategory.Count);
            cbCategory.DataSource = listCategory;
            cbCategory.DisplayMember = "Ten";
            //Begintesst
            //EndTesst
            
        }
        public void LoadFoodListCategoryID(int id)
        {
            List<Food> list = Food1.Instance.GetFoodByCategoryID(id);
            cbMonAn.DataSource = list;
            cbMonAn.DisplayMember = "Ten";
        }

        void LoadComboboxTable( ComboBox cb)
        {
            cb.DataSource = Tablecs.Instance.LoadTableList();
            cb.DisplayMember = "Ten";
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lsvHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }

        void btn_Click(object sender, EventArgs e)
        {
            int TableID = ((sender as Button).Tag as Table).ID;
            lsvHoaDon.Tag = (sender as Button).Tag;
            ShowBill(TableID);
        
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnThemMon_Click(object sender, EventArgs e)
        {
            Table table = lsvHoaDon.Tag as Table;

            int idHoaDon = Bill.Instance.GetUncheckIDByTableID(table.ID);
            int fooID = (cbMonAn.SelectedItem as Food).Id;
            int count = (int)nmFoodCount.Value;

            if (idHoaDon == -1)
            {
                Bill.Instance.InsertBill(table.ID);
                Billinfoss.Instance.InsertBillInfo(Bill.Instance.GetMaxIDBill() , fooID , count);
            }
            else
            {
                Billinfoss.Instance.InsertBillInfo( idHoaDon, fooID ,  count );
            }
            ShowBill(table.ID);
            LoadTable();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
               
        }

        private void cbCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int id = 0;

            ComboBox cb = sender as ComboBox;

            if (cb.SelectedItem == null)
                return;

            Category selected = cb.SelectedItem as Category;

            id = selected.Id;
            Console.WriteLine(id);
            LoadFoodListCategoryID(id);
        }

       // private void btnThemMon_Click(object sender, EventArgs e)
        //{
            
            
       // }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            
            Table table = lsvHoaDon.Tag as Table;
            int idHoaDon = Bill.Instance.GetUncheckIDByTableID(table.ID);
           
            MessageBox.Show(txtTotaPrice.Text);
            double TotaPrice = Convert.ToDouble(txtTotaPrice.Text.Replace(",", "").Replace("$", ""));
            double finalTotaPrice = TotaPrice;
            if (idHoaDon != -1)
            {
                if (MessageBox.Show(String.Format(" Bạn có Chắc Muốn Thanh Toán Cho " + table.Ten), " Thông Báo ", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                   Bill.Instance.CheckOut(idHoaDon, (float)TotaPrice);
                   ShowBill(table.ID);
                   LoadTable();
                }
            }
           
            
        }

        private void flpTable_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            int id1 = (lsvHoaDon.Tag as Table).ID;
            int id2 = (cbChuyenBan.SelectedItem as Table).ID;
            if (MessageBox.Show(String.Format("Bạn có thật sự muốn chuyển bàn {0} qua bàn {1}", (lsvHoaDon.Tag as Table).Ten, (cbChuyenBan.SelectedItem as Table).Ten), "Thông Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Tablecs.Instance.SwitchTable(id1, id2);

                LoadTable();
            }


        }
        
    }
}
