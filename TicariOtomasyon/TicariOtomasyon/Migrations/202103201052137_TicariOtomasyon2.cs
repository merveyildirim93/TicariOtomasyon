namespace TicariOtomasyon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TicariOtomasyon2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SatisHareketleris", "Personel_PersonalId", "dbo.Personels");
            DropIndex("dbo.SatisHareketleris", new[] { "Personel_PersonalId" });
            RenameColumn(table: "dbo.SatisHareketleris", name: "Personel_PersonalId", newName: "PersonalId");
            AlterColumn("dbo.SatisHareketleris", "PersonalId", c => c.Int(nullable: false));
            CreateIndex("dbo.SatisHareketleris", "PersonalId");
            AddForeignKey("dbo.SatisHareketleris", "PersonalId", "dbo.Personels", "PersonalId", cascadeDelete: true);
            DropColumn("dbo.SatisHareketleris", "PersonelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SatisHareketleris", "PersonelId", c => c.Int(nullable: false));
            DropForeignKey("dbo.SatisHareketleris", "PersonalId", "dbo.Personels");
            DropIndex("dbo.SatisHareketleris", new[] { "PersonalId" });
            AlterColumn("dbo.SatisHareketleris", "PersonalId", c => c.Int());
            RenameColumn(table: "dbo.SatisHareketleris", name: "PersonalId", newName: "Personel_PersonalId");
            CreateIndex("dbo.SatisHareketleris", "Personel_PersonalId");
            AddForeignKey("dbo.SatisHareketleris", "Personel_PersonalId", "dbo.Personels", "PersonalId");
        }
    }
}
