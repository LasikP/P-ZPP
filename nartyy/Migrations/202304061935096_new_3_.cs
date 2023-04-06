namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_3_ : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Identities", newName: "Idebtiti");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Idebtiti", newName: "Identities");
        }
    }
}
