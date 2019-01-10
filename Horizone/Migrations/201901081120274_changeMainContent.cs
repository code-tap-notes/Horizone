namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMainContent : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MainContents", "AboutUs", c => c.String(maxLength: 1500));
            AlterColumn("dbo.MainContents", "Contact", c => c.String(maxLength: 250));
            AlterColumn("dbo.MainContents", "Presentation", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MainContents", "Presentation", c => c.String(maxLength: 250));
            AlterColumn("dbo.MainContents", "Contact", c => c.String(maxLength: 50));
            AlterColumn("dbo.MainContents", "AboutUs", c => c.String(maxLength: 250));
        }
    }
}
