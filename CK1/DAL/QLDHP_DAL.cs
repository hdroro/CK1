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

        public List<SinhVienHocPhan> GetAllSV(string name)
        {
            using (var context = new QLDHP())
            {
                var result = context.SVs
                    .Join(context.HPSVs, sv => sv.MSSV, hpsv => hpsv.MSSV, (sv, hpsv) => new { sv, hpsv })
                    .Join(context.HPs, sh => sh.hpsv.MaHocPhan, hp => hp.MaHocPhan, (sh, hp) => new SinhVienHocPhan
                    {
                        MSSV = sh.sv.MSSV,
                        MaHP = hp.MaHocPhan,
                        Name = sh.sv.Name,
                        LSH = sh.sv.LSH,
                        TenHocPhan = hp.NameHocPhan,
                        DBT = sh.hpsv.DBT,
                        DGK = sh.hpsv.DGK,
                        DCK = sh.hpsv.DCK,
                        DTK = (sh.hpsv.DBT + sh.hpsv.DGK) * 0.2 + sh.hpsv.DCK * 0.3,
                        NgayThi = sh.hpsv.NgayThi,
                        Gender = sh.sv.Gender,
                    })
                    .Where(svhpsvhp => svhpsvhp.Name.Contains(name))
                    .ToList();
                return result;
            }
        }


        public List<SinhVienHocPhan> GetApartSV(string MaHP, string name)
        {
            using (var context = new QLDHP())
            {
                var result = context.SVs
                    .Join(context.HPSVs, sv => sv.MSSV, hpsv => hpsv.MSSV, (sv, hpsv) => new { sv, hpsv })
                    .Where(svhpsvhp => svhpsvhp.sv.Name.Contains(name) && svhpsvhp.hpsv.MaHocPhan == MaHP)
                    .Join(context.HPs, sh => sh.hpsv.MaHocPhan, hp => hp.MaHocPhan, (sh, hp) => new SinhVienHocPhan
                    {
                        MSSV = sh.sv.MSSV,
                        MaHP = hp.MaHocPhan,
                        Name = sh.sv.Name,
                        LSH = sh.sv.LSH,
                        TenHocPhan = hp.NameHocPhan,
                        DBT = sh.hpsv.DBT,
                        DGK = sh.hpsv.DGK,
                        DCK = sh.hpsv.DCK,
                        DTK = (sh.hpsv.DBT + sh.hpsv.DGK) * 0.2 + sh.hpsv.DCK * 0.3,
                        NgayThi = sh.hpsv.NgayThi,
                        Gender = sh.sv.Gender,
                    })
                    
                    .ToList();
                return result;
            }
        }


        public void DelSV(string MSSV)
        {
            using(QLDHP db = new QLDHP())
            {
                var s1 = db.HPSVs.Where(p => p.MSSV == MSSV);
                foreach (var hpSv in s1)
                {
                    db.HPSVs.Remove(hpSv);
                }
                db.SaveChanges();

                var s = db.SVs.Where(p => p.MSSV == MSSV).FirstOrDefault();
                if (s != null)
                {
                    db.SVs.Remove(s);
                    db.SaveChanges();
                }
            }
        }

        public void Add_Update(SinhVienHocPhan svhp, bool isAdd)
        {
            if(!isAdd)
            {
                using (QLDHP db = new QLDHP())
                {
                    var s = db.SVs.Where(sv => sv.MSSV == svhp.MSSV).Select(sv => sv).FirstOrDefault();
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

                    /*var s2 = db.HPs.Where(p => p.MaHocPhan == svhp.MaHP).Select(hp => hp).FirstOrDefault();
                    s2.MaHocPhan = db.HPs.Where(hp => hp.NameHocPhan == svhp.TenHocPhan).Select(sv => sv.MaHocPhan).FirstOrDefault();
                    s2.NameHocPhan = svhp.TenHocPhan;*/
                    
                }
            }
            else
            {
                bool check = false;
                using (QLDHP db = new QLDHP())
                {
                    foreach(SinhVien i in db.SVs.ToList())
                    {
                        if(i.MSSV == svhp.MSSV)
                        {
                            db.HPSVs.Add(
                                new HocPhanSinhVien
                                {
                                    MSSV = svhp.MSSV,
                                    MaHocPhan = db.HPs.Where(hp => hp.NameHocPhan == svhp.TenHocPhan).Select(sv => sv.MaHocPhan).FirstOrDefault(),
                                    DBT = svhp.DBT,
                                    DGK = svhp.DGK,
                                    DCK = svhp.DCK,
                                    NgayThi = svhp.NgayThi,
                                }
                            );
                            check = true;
                            break;
                        }
                    }
                    if (!check)
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
                                MaHocPhan = db.HPs.Where(hp => hp.NameHocPhan == svhp.TenHocPhan).Select(sv => sv.MaHocPhan).FirstOrDefault(),
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
