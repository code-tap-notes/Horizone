namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeContacmessage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ContactMessages", "SymbolLanguage", c => c.String(maxLength: 2));
            DropColumn("dbo.ContactMessages", "Language");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ContactMessages", "Language", c => c.Int(nullable: false));
            DropColumn("dbo.ContactMessages", "SymbolLanguage");
        }
    }
}
