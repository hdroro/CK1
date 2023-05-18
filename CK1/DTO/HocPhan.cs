using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK1
{
    public class HocPhan
    {
        [Key]
        public string MaHocPhan { get; set; }
        public string NameHocPhan { get; set; }
        public virtual ICollection<SinhVien> SVs { get; set; }
    }
}
