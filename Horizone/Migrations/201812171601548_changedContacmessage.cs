namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedContacmessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainContents", "Presentation", c => c.String(maxLength: 250));
            DropColumn("dbo.MainContents", "Title");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MainContents", "Title", c => c.String(maxLength: 250));
            DropColumn("dbo.MainContents", "Presentation");
        }
    }
}
