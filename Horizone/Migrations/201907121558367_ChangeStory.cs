namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeStory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.NamePlaceTochStories", "NamePlace_Id", "dbo.NamePlaces");
            DropForeignKey("dbo.NamePlaceTochStories", "TochStory_Id", "dbo.TochStories");
            DropForeignKey("dbo.ProperNounTochStories", "ProperNoun_Id", "dbo.ProperNouns");
            DropForeignKey("dbo.ProperNounTochStories", "TochStory_Id", "dbo.TochStories");
            DropIndex("dbo.NamePlaceTochStories", new[] { "NamePlace_Id" });
            DropIndex("dbo.NamePlaceTochStories", new[] { "TochStory_Id" });
            DropIndex("dbo.ProperNounTochStories", new[] { "ProperNoun_Id" });
            DropIndex("dbo.ProperNounTochStories", new[] { "TochStory_Id" });
            AddColumn("dbo.DictionaryTocharians", "TochComnon", c => c.String());
            AddColumn("dbo.NounAdjectives", "TochComnon", c => c.String());
            AddColumn("dbo.Pronouns", "TochComnon", c => c.String());
            AddColumn("dbo.OtherWords", "TochComnon", c => c.String());
            AddColumn("dbo.Verbs", "TochComnon", c => c.String());
            AddColumn("dbo.NamePlaces", "Place", c => c.String());
            AddColumn("dbo.NamePlaces", "DescriptionEn", c => c.String());
            AddColumn("dbo.NamePlaces", "DescriptionFr", c => c.String());
            AddColumn("dbo.NamePlaces", "DescriptionZh", c => c.String());
            AddColumn("dbo.SourceStories", "SourceEn", c => c.String());
            AddColumn("dbo.SourceStories", "SourceFr", c => c.String());
            AddColumn("dbo.SourceStories", "SourceZh", c => c.String());
            DropColumn("dbo.NamePlaces", "PlaceEn");
            DropColumn("dbo.NamePlaces", "PlaceFr");
            DropColumn("dbo.NamePlaces", "PlaceZh");
            DropColumn("dbo.SourceStories", "Source");
            DropTable("dbo.NamePlaceTochStories");
            DropTable("dbo.ProperNounTochStories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProperNounTochStories",
                c => new
                    {
                        ProperNoun_Id = c.Int(nullable: false),
                        TochStory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProperNoun_Id, t.TochStory_Id });
            
            CreateTable(
                "dbo.NamePlaceTochStories",
                c => new
                    {
                        NamePlace_Id = c.Int(nullable: false),
                        TochStory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NamePlace_Id, t.TochStory_Id });
            
            AddColumn("dbo.SourceStories", "Source", c => c.String());
            AddColumn("dbo.NamePlaces", "PlaceZh", c => c.String());
            AddColumn("dbo.NamePlaces", "PlaceFr", c => c.String());
            AddColumn("dbo.NamePlaces", "PlaceEn", c => c.String());
            DropColumn("dbo.SourceStories", "SourceZh");
            DropColumn("dbo.SourceStories", "SourceFr");
            DropColumn("dbo.SourceStories", "SourceEn");
            DropColumn("dbo.NamePlaces", "DescriptionZh");
            DropColumn("dbo.NamePlaces", "DescriptionFr");
            DropColumn("dbo.NamePlaces", "DescriptionEn");
            DropColumn("dbo.NamePlaces", "Place");
            DropColumn("dbo.Verbs", "TochComnon");
            DropColumn("dbo.OtherWords", "TochComnon");
            DropColumn("dbo.Pronouns", "TochComnon");
            DropColumn("dbo.NounAdjectives", "TochComnon");
            DropColumn("dbo.DictionaryTocharians", "TochComnon");
            CreateIndex("dbo.ProperNounTochStories", "TochStory_Id");
            CreateIndex("dbo.ProperNounTochStories", "ProperNoun_Id");
            CreateIndex("dbo.NamePlaceTochStories", "TochStory_Id");
            CreateIndex("dbo.NamePlaceTochStories", "NamePlace_Id");
            AddForeignKey("dbo.ProperNounTochStories", "TochStory_Id", "dbo.TochStories", "Id", cascadeDelete: false);
            AddForeignKey("dbo.ProperNounTochStories", "ProperNoun_Id", "dbo.ProperNouns", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NamePlaceTochStories", "TochStory_Id", "dbo.TochStories", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NamePlaceTochStories", "NamePlace_Id", "dbo.NamePlaces", "Id", cascadeDelete: false);
        }
    }
}
