using CK1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CK1.DAL
{
    internal class QLDHP_DAL
    {
        private static QLDHP_DAL _Instance;
        public static QLDHP_DAL Instance
        {
            get
            {
                if(_Instance == null)
                {
                    _Instance = new QLDHP_DAL();
                }
                return _Instance;
            }
            private set { }
        }

        public List<HocPhan> getAllLHP()
        {
            List<HocPhan> li = new List<HocPhan>();
            using (QLDHP db = new QLDHP())
            {
                li.AddRange(db.HPs.Select(p => p).ToList());
                return li;
            }
        }

        public List<string> getAllLSH()
        {
            List<string> li = new List<string>();
            using (QLDHP db = new QLDHP())
            {
                li.AddRange(db.SVs.Select(p => p.LSH).Distinct().ToList());
                return li;
            }
        }

        public List<SinhVienHocPhan> GetAllSV(string MaHP, string name)
        {
            using (var db = new QLDHP())
            {
                var result = db.HPSVs
                    .Where(sv => (MaHP == "0" ? sv.SVs.Name.Contains(name) : (sv.MaHocPhan == MaHP && sv.SVs.Name.Contains(name))))
                    .Select(sv => new SinhVienHocPhan
                    {
                        MSSV = sv.MSSV,
                        MaHP = sv.HPs.MaHocPhan,
                        Name = sv.SVs.Name,
                        LSH = sv.SVs.LSH,
                        TenHocPhan = sv.HPs.NameHocPhan,
                        DBT = sv.DBT,
                        DGK = sv.DGK,
                        DCK = sv.DCK,
                        DTK = (sv.DBT + sv.DGK) * 0.2 + sv.DCK * 0.3,
                        NgayThi = sv.NgayThi,
                        Gender = sv.SVs.Gender,
                    }
                ).ToList();
                return result;
            }
        }

        public void DelSV(string MSSV, string MaHP)
        {
            using(QLDHP db = new QLDHP())
            {
                var s1 = db.HPSVs.FirstOrDefault(p => p.MSSV == MSSV && p.MaHocPhan == MaHP);
                db.HPSVs.Remove(s1);
                db.SaveChanges();
            }
        }

        public void Add_Update(SinhVienHocPhan svhp, bool isAdd)
        {
            if(!isAdd)
            {
                using (QLDHP db = new QLDHP())
                {
                    var s = db.SVs.FirstOrDefault(sv => sv.MSSV == svhp.MSSV);
                    if (s != null)
                    {
                        s.MSSV = svhp.MSSV;
                        s.Name = svhp.Name;
                        s.LSH = svhp.LSH;
                        s.Gender = svhp.Gender;

                        string MaHocPhan = db.HPs.Where(hp => hp.NameHocPhan == svhp.TenHocPhan).Select(sv => sv.MaHocPhan).FirstOrDefault();
                        var s2 = db.HPSVs.Where(hp => hp.MSSV == svhp.MSSV && hp.MaHocPhan == MaHocPhan).Select(sv => sv).FirstOrDefault();
                        s2.DBT = svhp.DBT;
                        s2.DGK = svhp.DGK;
                        s2.DCK = svhp.DCK;
                        s2.NgayThi = svhp.NgayThi;

                        db.SaveChanges();
                    }
                }
            }
            else
            {
                using (QLDHP db = new QLDHP())
                {
                    var sv = db.SVs.FirstOrDefault(i => i.MSSV == svhp.MSSV);
                    if (sv != null)
                    {
                        db.HPSVs.Add(
                            new HocPhanSinhVien
                            {
                                MSSV = svhp.MSSV,
                                MaHocPhan = db.HPs.FirstOrDefault(hp => hp.NameHocPhan == svhp.TenHocPhan)?.MaHocPhan,
                                DBT = svhp.DBT,
                                DGK = svhp.DGK,
                                DCK = svhp.DCK,
                                NgayThi = svhp.NgayThi
                            }
                        );
                    }
                    else
                    {
                        db.SVs.Add(
                            new SinhVien
                            {
                                MSSV = svhp.MSSV,
                                Name = svhp.Name,
                                LSH = svhp.LSH,
                                Gender = svhp.Gender,
                            }
                        );
                        db.HPSVs.Add(
                            new HocPhanSinhVien
                            {
                                MSSV = svhp.MSSV,
                                MaHocPhan = db.HPs.Where(hp => hp.NameHocPhan == svhp.TenHocPhan).Select(hp => hp.MaHocPhan).FirstOrDefault(),
                                DBT = svhp.DBT,
                                DGK = svhp.DGK,
                                DCK = svhp.DCK,
                                NgayThi = svhp.NgayThi,
                            }
                        );
                    }
                    db.SaveChanges();
                }
            }
        }
    }
}
