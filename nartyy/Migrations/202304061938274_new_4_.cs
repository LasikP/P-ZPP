namespace nartyy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_4_ : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Idebtiti", newName: "Identity");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Identity", newName: "Idebtiti");
        }
    }
}
