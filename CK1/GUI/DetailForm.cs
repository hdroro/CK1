using CK1.BLL;
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
    public partial class DetailForm : Form
    {
        public DetailForm(string s, string s2, bool isAdd)
        {
            InitializeComponent();
            this.MSSV = s;
            this.TenHocPhan = s2;
            this.isAdd = isAdd;
            SetCBB();
            SetGUI();
        }
        private string MSSV;
        private string TenHocPhan;

        private bool isAdd;
        public delegate void MyDel(string MaHP, string name);

        public MyDel d { get; set; }
            

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        void SetGUI()
        {
            txt_DiemTK.Enabled = false;

            SinhVienHocPhan svhp = QLDHP_BLL.Instance.getSVByMSSV(MSSV, TenHocPhan);
            if ( svhp != null) 
            {
                txt_MSSV.Text = svhp.MSSV.ToString();
                txt_MSSV.Enabled = false;
                txt_Name.Text = svhp.Name.ToString();
                cbb_LopSH.Text = svhp.LSH.ToString();
                txt_Name.Enabled = true;
                cbb_LopSH.Enabled = true;
                cbb_HP.Text = svhp.TenHocPhan.ToString();
                cbb_HP.Enabled = false;
                dateTime.Value = svhp.NgayThi;
                txt_DiemTB.Text = svhp.DBT.ToString();
                txt_DiemGK.Text = svhp.DGK.ToString();
                txt_DiemCK.Text = svhp.DCK.ToString();
                txt_DiemTK.Text = svhp.DTK.ToString();

                if(svhp.Gender == true)
                {
                    rd_Nam.Checked = true;
                } else rd_Nu.Checked = true;    
            }
        }

        void SetCBB()
        {
            cbb_HP.Items.AddRange(QLDHP_BLL.Instance.GetCBBItem().ToArray());
            cbb_LopSH.Items.AddRange(QLDHP_BLL.Instance.GetListLSH().ToArray());
        }



        public void UpdateTK()
        {
            double bt, gk, ck;
            if (double.TryParse(txt_DiemTB.Text, out bt) && double.TryParse(txt_DiemGK.Text, out gk) && double.TryParse(txt_DiemCK.Text, out ck))
            {
                double tk = (bt + gk) * 0.2f + ck * 0.3f;
                txt_DiemTK.Text = tk.ToString("#.##");
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid numbers for the grades.");
            }
        }



        private void txt_DiemTB_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_DiemTB.Text) && !string.IsNullOrEmpty(txt_DiemGK.Text) && !string.IsNullOrEmpty(txt_DiemCK.Text))
            {
                UpdateTK();
            }
            else
            {
                txt_DiemTK.Text = "";
            }
        }

        private void txt_DiemGK_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_DiemTB.Text) && !string.IsNullOrEmpty(txt_DiemGK.Text) && !string.IsNullOrEmpty(txt_DiemCK.Text))
            {
                UpdateTK();
            }
            else
            {
                txt_DiemTK.Text = "";
            }

        }

        private void txt_DiemCK_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_DiemTB.Text) && !string.IsNullOrEmpty(txt_DiemGK.Text) && !string.IsNullOrEmpty(txt_DiemCK.Text))
            {
                UpdateTK();
            }
            else
            {
                txt_DiemTK.Text = "";
            }

        }

        private void btn_OK_Click(object sender, EventArgs e)
        {

            try
            {
                SinhVienHocPhan svhp = new SinhVienHocPhan()
                {
                    MSSV = txt_MSSV.Text,
                    Name = txt_Name.Text,
                    LSH = cbb_LopSH.Text,
                    TenHocPhan = cbb_HP.Text,
                    Gender = Convert.ToBoolean(rd_Nam.Checked.ToString()),
                    DBT = Convert.ToDouble(txt_DiemTB.Text),
                    DGK = Convert.ToDouble(txt_DiemGK.Text),
                    DCK = Convert.ToDouble(txt_DiemCK.Text),
                    NgayThi = Convert.ToDateTime(dateTime.Value.ToString()),
                };

                QLDHP_BLL.Instance.Add_Update(svhp, isAdd);
                d("0", "");
                this.Dispose();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txt_MSSV_TextChanged(object sender, EventArgs e)
        {
            string MSSV = txt_MSSV.Text;
            if(txt_Name.Text == "" && cbb_LopSH.Text == "")
            {
                SinhVienHocPhan sv = QLDHP_BLL.Instance.getSVByMSSV2(MSSV);
                if (sv != null)
                {
                    txt_Name.Text = sv.Name;
                    cbb_LopSH.Text = sv.LSH.ToString();

                    txt_Name.Enabled = false;
                    cbb_LopSH.Enabled = false;
                }
            }
            else
            {
                txt_Name.Text = "";
                cbb_LopSH.Text = "";
                txt_Name.Enabled = true;
                cbb_LopSH.Enabled = true;
            }
        }
    }
}
