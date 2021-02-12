namespace OgrenciOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bolumlers",
                c => new
                    {
                        bolumid = c.Int(nullable: false, identity: true),
                        bolumad = c.String(),
                    })
                .PrimaryKey(t => t.bolumid);
            
            CreateTable(
                "dbo.Siniflars",
                c => new
                    {
                        sinifid = c.Int(nullable: false, identity: true),
                        sinifad = c.String(),
                        Bolumler_bolumid = c.Int(),
                    })
                .PrimaryKey(t => t.sinifid)
                .ForeignKey("dbo.Bolumlers", t => t.Bolumler_bolumid)
                .Index(t => t.Bolumler_bolumid);
            
            CreateTable(
                "dbo.Ogrencilers",
                c => new
                    {
                        ogrid = c.Int(nullable: false, identity: true),
                        ograd = c.String(),
                        ogrsoyad = c.String(),
                        Siniflar_sinifid = c.Int(),
                    })
                .PrimaryKey(t => t.ogrid)
                .ForeignKey("dbo.Siniflars", t => t.Siniflar_sinifid)
                .Index(t => t.Siniflar_sinifid);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ogrencilers", "Siniflar_sinifid", "dbo.Siniflars");
            DropForeignKey("dbo.Siniflars", "Bolumler_bolumid", "dbo.Bolumlers");
            DropIndex("dbo.Ogrencilers", new[] { "Siniflar_sinifid" });
            DropIndex("dbo.Siniflars", new[] { "Bolumler_bolumid" });
            DropTable("dbo.Ogrencilers");
            DropTable("dbo.Siniflars");
            DropTable("dbo.Bolumlers");
        }
    }
}
