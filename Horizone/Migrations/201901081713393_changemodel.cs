namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changemodel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.MainContents", "Contact", c => c.String(maxLength: 1500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MainContents", "Contact", c => c.String(maxLength: 250));
            AlterColumn("dbo.Comments", "Content", c => c.String(maxLength: 40));
        }
    }
}
