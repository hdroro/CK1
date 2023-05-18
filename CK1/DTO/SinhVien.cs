using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK1
{
    public class SinhVien
    {
        [Key]
        public string MSSV { get; set; }
        public string Name { set; get; }
        public string LSH { get; set; }
        public bool Gender { get; set; }

        public virtual ICollection<HocPhan> HPs { get; set; }
    }
}
