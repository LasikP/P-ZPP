namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nowa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Narty", "Rozmiar", c => c.Int());
            AlterColumn("dbo.Narty", "CenaGodzinowa", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Narty", "Dostepnosc", c => c.Boolean());
            AlterColumn("dbo.Rezerwacje", "DataOdbioru", c => c.DateTime());
            AlterColumn("dbo.Rezerwacje", "DataZwrotu", c => c.DateTime());
            AlterColumn("dbo.ButyNarciarskie", "Rozmiar", c => c.Int());
            AlterColumn("dbo.ButyNarciarskie", "CenaGodzinowa", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.ButyNarciarskie", "Dostepnosc", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ButyNarciarskie", "Dostepnosc", c => c.Boolean(nullable: false));
            AlterColumn("dbo.ButyNarciarskie", "CenaGodzinowa", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.ButyNarciarskie", "Rozmiar", c => c.Int(nullable: false));
            AlterColumn("dbo.Rezerwacje", "DataZwrotu", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Rezerwacje", "DataOdbioru", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Narty", "Dostepnosc", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Narty", "CenaGodzinowa", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Narty", "Rozmiar", c => c.Int(nullable: false));
        }
    }
}
