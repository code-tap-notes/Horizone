namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeContactmessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactMessages", "FirstName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.ContactMessages", "FisrtName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactMessages", "FisrtName", c => c.String(nullable: false, maxLength: 30));
            DropColumn("dbo.ContactMessages", "FirstName");
        }
    }
}
