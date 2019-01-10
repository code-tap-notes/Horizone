namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeLanguages : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactMessages", "Language", c => c.Int(nullable: false));
            AddColumn("dbo.Languages", "Symbol", c => c.String(maxLength: 2));
            AlterColumn("dbo.Languages", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Languages", "IsDefault", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Languages", "IsDefault", c => c.Int(nullable: false));
            AlterColumn("dbo.Languages", "Name", c => c.String());
            DropColumn("dbo.Languages", "Symbol");
            DropColumn("dbo.ContactMessages", "Language");
        }
    }
}
