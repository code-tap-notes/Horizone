namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class searchResult : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTable = c.String(),
                        IdResult = c.Int(nullable: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SearchResults");
        }
    }
}
