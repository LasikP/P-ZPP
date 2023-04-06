namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ButyNarciarskie", "Rezerwacja_IDSprzet", c => c.Int());
            AddColumn("dbo.Narty", "Rezerwacja_IDSprzet", c => c.Int());
            CreateIndex("dbo.ButyNarciarskie", "Rezerwacja_IDSprzet");
            CreateIndex("dbo.Narty", "Rezerwacja_IDSprzet");
            AddForeignKey("dbo.ButyNarciarskie", "Rezerwacja_IDSprzet", "dbo.Rezerwacje", "IDSprzet");
            AddForeignKey("dbo.Narty", "Rezerwacja_IDSprzet", "dbo.Rezerwacje", "IDSprzet");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Narty", "Rezerwacja_IDSprzet", "dbo.Rezerwacje");
            DropForeignKey("dbo.ButyNarciarskie", "Rezerwacja_IDSprzet", "dbo.Rezerwacje");
            DropIndex("dbo.Narty", new[] { "Rezerwacja_IDSprzet" });
            DropIndex("dbo.ButyNarciarskie", new[] { "Rezerwacja_IDSprzet" });
            DropColumn("dbo.Narty", "Rezerwacja_IDSprzet");
            DropColumn("dbo.ButyNarciarskie", "Rezerwacja_IDSprzet");
        }
    }
}
