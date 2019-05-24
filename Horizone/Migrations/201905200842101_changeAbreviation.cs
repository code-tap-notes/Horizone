namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAbreviation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abreviations", "Link", c => c.String());
            AddColumn("dbo.Bibliographies", "Book", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bibliographies", "Book");
            DropColumn("dbo.Abreviations", "Link");
        }
    }
}
