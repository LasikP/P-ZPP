namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class kurdee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Identities", "Client_IDClient", "dbo.Clients");
            DropIndex("dbo.Identities", new[] { "Client_IDClient" });
            DropTable("dbo.Identities");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Identities",
                c => new
                    {
                        IDIdentity = c.Int(nullable: false, identity: true),
                        Usename = c.String(),
                        Password = c.String(),
                        Client_IDClient = c.Int(),
                    })
                .PrimaryKey(t => t.IDIdentity);
            
            CreateIndex("dbo.Identities", "Client_IDClient");
            AddForeignKey("dbo.Identities", "Client_IDClient", "dbo.Clients", "IDClient");
        }
    }
}
