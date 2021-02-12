namespace OgrenciOtomasyonu.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateKullanicilarsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kullanicilars",
                c => new
                    {
                        kullaniciadi = c.String(nullable: false, maxLength: 128),
                        parola = c.String(),
                        guvenliksorusu = c.String(),
                    })
                .PrimaryKey(t => t.kullaniciadi);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Kullanicilars");
        }
    }
}
