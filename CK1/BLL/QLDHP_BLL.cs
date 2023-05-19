using CK1.DAL;
using CK1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK1.BLL
{
    internal class QLDHP_BLL
    {
        private static QLDHP_BLL _Instance;
        public static QLDHP_BLL Instance
        {
            get
            {
                if(_Instance == null) 
                {
                    _Instance = new QLDHP_BLL();
                }
                return _Instance;

            }
            private set { }
        }

        public List<CBBItem> GetCBBItem()
        {
            List<CBBItem> list = new List<CBBItem>();
            foreach(HocPhan i in QLDHP_DAL.Instance.getAllLHP())
            {
                list.Add(new CBBItem { Value = i.MaHocPhan, Text = i.NameHocPhan });
            }
            return list;
        }

        public List<string> GetListLSH()
        {
            List<string> list = new List<string>(); 
            foreach(string i in QLDHP_DAL.Instance.getAllLSH())
            {
                list.Add(i);
            }
            return list;
        }

        public List<SinhVienHocPhan> GetListSV(string MaHP, string name)
        {
            return QLDHP_DAL.Instance.GetAllSV(MaHP, name);
        }

        public SinhVienHocPhan getSVByMSSV(string MSSV, string MaHP)
        {
            SinhVienHocPhan data = null;
            foreach(SinhVienHocPhan sv in QLDHP_DAL.Instance.GetAllSV("0","").ToList())
            {
                if(sv.MSSV == MSSV && sv.TenHocPhan == MaHP)
                {
                    data = sv;
                }
            }
            return data;
        }

        public SinhVienHocPhan getSVByMSSV2(string MSSV)
        {
            SinhVienHocPhan data = null;
            foreach (SinhVienHocPhan sv in QLDHP_DAL.Instance.GetAllSV("0","").ToList())
            {
                if (sv.MSSV == MSSV )
                {
                    data = sv;
                }
            }
            return data;
        }

        public void DelSV(List<KeyValuePair<string, string>> list)
        {
            foreach (KeyValuePair<string, string> pair in list)
            {
                QLDHP_DAL.Instance.DelSV(pair.Key, pair.Value);
            }
        }

        public void Add_Update(SinhVienHocPhan sv, bool isAdd)
        {
            QLDHP_DAL.Instance.Add_Update(sv, isAdd);
        }

        public static List<T> SortByProperty<T>(List<T> list, string propertyName)
        {
            PropertyInfo property = typeof(T).GetProperty(propertyName);

            return list.OrderBy(p => property.GetValue(p)).ToList();
        }
    }
}
