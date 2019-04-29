namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeAbre : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Abreviations", "Description", c => c.String());
            DropColumn("dbo.Abreviations", "DescriptionEn");
            DropColumn("dbo.Abreviations", "DescriptionFr");
            DropColumn("dbo.Abreviations", "DescriptionZh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Abreviations", "DescriptionZh", c => c.String());
            AddColumn("dbo.Abreviations", "DescriptionFr", c => c.String());
            AddColumn("dbo.Abreviations", "DescriptionEn", c => c.String());
            DropColumn("dbo.Abreviations", "Description");
        }
    }
}
