namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Nowa_7 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Identity", newName: "Identities");
            AddColumn("dbo.Clients", "Adress", c => c.String());
            DropColumn("dbo.Clients", "Adres");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Adres", c => c.String());
            DropColumn("dbo.Clients", "Adress");
            RenameTable(name: "dbo.Identities", newName: "Identity");
        }
    }
}
