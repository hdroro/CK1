using System;
using System.Data.Entity;
using System.Linq;

namespace CK1
{
    public class QLDHP : DbContext
    {
       
        public QLDHP()
            : base("name=QLDHP")
        {
            Database.SetInitializer<QLDHP>(new DropCreateDatabaseIfModelChanges<QLDHP>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<HocPhan> HPs { get; set; }
        public virtual DbSet<SinhVien> SVs { get; set; }
        public virtual DbSet<HocPhanSinhVien> HPSVs { get; set; }


    }
}