namespace CK1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HocPhans",
                c => new
                    {
                        MaHocPhan = c.String(nullable: false, maxLength: 128),
                        NameHocPhan = c.String(),
                    })
                .PrimaryKey(t => t.MaHocPhan);
            
            CreateTable(
                "dbo.SinhViens",
                c => new
                    {
                        MSSV = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        LSH = c.String(),
                        Gender = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.MSSV);
            
            CreateTable(
                "dbo.HocPhanSinhViens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DBT = c.Double(nullable: false),
                        DGK = c.Double(nullable: false),
                        DCK = c.Double(nullable: false),
                        NgayThi = c.DateTime(nullable: false),
                        MaHocPhan = c.String(maxLength: 128),
                        MSSV = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.HocPhans", t => t.MaHocPhan)
                .ForeignKey("dbo.SinhViens", t => t.MSSV)
                .Index(t => t.MaHocPhan)
                .Index(t => t.MSSV);
            
            /*CreateTable(
                "dbo.SinhVienHocPhans",
                c => new
                    {
                        SinhVien_MSSV = c.String(nullable: false, maxLength: 128),
                        HocPhan_MaHocPhan = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SinhVien_MSSV, t.HocPhan_MaHocPhan })
                .ForeignKey("dbo.SinhViens", t => t.SinhVien_MSSV, cascadeDelete: true)
                .ForeignKey("dbo.HocPhans", t => t.HocPhan_MaHocPhan, cascadeDelete: true)
                .Index(t => t.SinhVien_MSSV)
                .Index(t => t.HocPhan_MaHocPhan);*/
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HocPhanSinhViens", "MSSV", "dbo.SinhViens");
            DropForeignKey("dbo.HocPhanSinhViens", "MaHocPhan", "dbo.HocPhans");
            DropForeignKey("dbo.SinhVienHocPhans", "HocPhan_MaHocPhan", "dbo.HocPhans");
            DropForeignKey("dbo.SinhVienHocPhans", "SinhVien_MSSV", "dbo.SinhViens");
            DropIndex("dbo.SinhVienHocPhans", new[] { "HocPhan_MaHocPhan" });
            DropIndex("dbo.SinhVienHocPhans", new[] { "SinhVien_MSSV" });
            DropIndex("dbo.HocPhanSinhViens", new[] { "MSSV" });
            DropIndex("dbo.HocPhanSinhViens", new[] { "MaHocPhan" });
            DropTable("dbo.SinhVienHocPhans");
            DropTable("dbo.HocPhanSinhViens");
            DropTable("dbo.SinhViens");
            DropTable("dbo.HocPhans");
        }
    }
}
