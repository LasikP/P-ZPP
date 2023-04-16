namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Username", c => c.String());
            AddColumn("dbo.Clients", "Password", c => c.String());
            AddColumn("dbo.Clients", "Roles", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clients", "Roles");
            DropColumn("dbo.Clients", "Password");
            DropColumn("dbo.Clients", "Username");
        }
    }
}
