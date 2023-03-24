namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Narty",
                c => new
                    {
                        IDNarty = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                        Producent = c.String(),
                        Kolor = c.String(),
                        Rozmiar = c.Int(nullable: false),
                        CenaGodzinowa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dostepnosc = c.Boolean(nullable: false),
                        Zdjecie = c.Binary(),
                    })
                .PrimaryKey(t => t.IDNarty);
            
            CreateTable(
                "dbo.Rezerwacje",
                c => new
                    {
                        IDSprzet = c.Int(nullable: false, identity: true),
                        TypSprzetu = c.String(),
                        DataOdbioru = c.DateTime(nullable: false),
                        DataZwrotu = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.IDSprzet);
            
            CreateTable(
                "dbo.ButyNarciarskie",
                c => new
                    {
                        IDButyNarciarskie = c.Int(nullable: false, identity: true),
                        Nazwa = c.String(),
                        Opis = c.String(),
                        Producent = c.String(),
                        Kolor = c.String(),
                        Rozmiar = c.Int(nullable: false),
                        CenaGodzinowa = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Dostepnosc = c.Boolean(nullable: false),
                        Zdjecie = c.Binary(),
                    })
                .PrimaryKey(t => t.IDButyNarciarskie);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ButyNarciarskie");
            DropTable("dbo.Rezerwacje");
            DropTable("dbo.Narty");
        }
    }
}
