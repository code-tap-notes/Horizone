namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeResearch : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SearchResults", "Summary", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SearchResults", "Summary");
        }
    }
}
