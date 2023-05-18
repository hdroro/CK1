using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK1
{
    public class HocPhanSinhVien
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public double DBT { get; set; }
        public double DGK { get; set; }
        public double DCK { get; set; }
        public DateTime NgayThi { get; set; }

        public string MaHocPhan { get; set; }
        [ForeignKey("MaHocPhan")]
        public virtual HocPhan HPs { get; set; }

        public string MSSV { get; set; }
        [ForeignKey("MSSV")]

        public virtual SinhVien SVs { get; set; }
    }

}
