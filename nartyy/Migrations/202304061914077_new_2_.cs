namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_2_ : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IDClient = c.Int(nullable: false, identity: true),
                        Imie = c.String(),
                        Nazwisko = c.String(),
                        Adres = c.String(),
                        Rezerwacja_IDSprzet = c.Int(),
                    })
                .PrimaryKey(t => t.IDClient)
                .ForeignKey("dbo.Rezerwacje", t => t.Rezerwacja_IDSprzet)
                .Index(t => t.Rezerwacja_IDSprzet);
            
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        IDIdentity = c.Int(nullable: false, identity: true),
                        Usename = c.String(),
                        Password = c.String(),
                        Client_IDClient = c.Int(),
                    })
                .PrimaryKey(t => t.IDIdentity)
                .ForeignKey("dbo.Clients", t => t.Client_IDClient)
                .Index(t => t.Client_IDClient);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "Rezerwacja_IDSprzet", "dbo.Rezerwacje");
            DropForeignKey("dbo.Identities", "Client_IDClient", "dbo.Clients");
            DropIndex("dbo.Identities", new[] { "Client_IDClient" });
            DropIndex("dbo.Clients", new[] { "Rezerwacja_IDSprzet" });
            DropTable("dbo.Identities");
            DropTable("dbo.Clients");
        }
    }
}
