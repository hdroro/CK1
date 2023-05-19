using CK1.BLL;
using CK1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetCBB();
        }

        public void SetCBB()
        {
            try
            {
                cbb_Hocphan.Items.Add(new CBBItem { Value = "0", Text = "All" });
                cbb_Hocphan.Items.AddRange(QLDHP_BLL.Instance.GetCBBItem().ToArray());
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void ShowDGV(string MaHP, string name)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("STT", "STT");
            

            dataGridView1.DataSource = QLDHP_BLL.Instance.GetListSV(MaHP, name);
            List<string> myArray = new List<string>() { "MSSV", "MaHP", "Tên SV", "Lớp SH", "Tên học phần", "Điểm BT", "Điểm GK", "Điểm CK", "Tổng kết", "Ngày thi", "Gender" };
            for (int i = 0; i < 10; i++)
            {
                this.dataGridView1.Columns[i+1].HeaderText = myArray[i];
            }

            dataGridView1.Columns["NgayThi"].DefaultCellStyle.Format = "dd/MM/yyyy";


            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dataGridView1.Rows[i].Cells["STT"].Value = (i + 1).ToString();
            }
            dataGridView1.Columns["MSSV"].Visible = false;
            dataGridView1.Columns["Gender"].Visible = false;
            dataGridView1.Columns["MaHP"].Visible = false;

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string MaHP = ((CBBItem)cbb_Hocphan.SelectedItem).Value;
            ShowDGV(MaHP, txt_Search.Text);
            cbb_Sort.Text = "";
        }

        private void btn_Del_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count >= 1)
            {
                List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
                foreach(DataGridViewRow i in dataGridView1.SelectedRows)
                {
                    string key = i.Cells["MSSV"].Value.ToString();
                    string value = i.Cells["MaHP"].Value.ToString();
                    KeyValuePair<string, string> pair = new KeyValuePair<string, string>(key, value);
                    list.Add(pair);
                }
                QLDHP_BLL.Instance.DelSV(list);
            }
            ShowDGV("0", "");
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            DetailForm f2 = new DetailForm("","", true);
            f2.d += new DetailForm.MyDel(ShowDGV);
            f2.Show();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count == 1) 
            {
                string MSSV = dataGridView1.SelectedRows[0].Cells["MSSV"].Value.ToString();
                string TenHP = dataGridView1.SelectedRows[0].Cells["TenHocPhan"].Value.ToString();

                DetailForm f2 = new DetailForm(MSSV, TenHP, false);
                f2.d += new DetailForm.MyDel(ShowDGV);
                f2.Show();
            }
            else
            {
                MessageBox.Show("Khi update bạn chỉ được chọn 1 row!");
            }
            
        }

        private void btn_Sort_Click(object sender, EventArgs e)
        {
            try
            {
                string selectedProperty = cbb_Sort.SelectedItem.ToString();

                dataGridView1.DataSource = QLDHP_BLL.SortByProperty(QLDHP_BLL.Instance.GetListSV(((CBBItem)cbb_Hocphan.SelectedItem).Value, txt_Search.Text), selectedProperty);


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Cells["STT"].Value = (i + 1).ToString();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Bạn cần chọn những trường cần thiết để thực hiện chức năng!");
            }
        }
    }
}
