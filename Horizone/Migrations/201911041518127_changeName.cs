namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NamePlaces", "InStory", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProperNouns", "DescriptionEn", c => c.String());
            AddColumn("dbo.ProperNouns", "DescriptionFr", c => c.String());
            AddColumn("dbo.ProperNouns", "DescriptionZh", c => c.String());
            AddColumn("dbo.ProperNouns", "InStory", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProperNouns", "InStory");
            DropColumn("dbo.ProperNouns", "DescriptionZh");
            DropColumn("dbo.ProperNouns", "DescriptionFr");
            DropColumn("dbo.ProperNouns", "DescriptionEn");
            DropColumn("dbo.NamePlaces", "InStory");
        }
    }
}
