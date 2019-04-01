namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTochStory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TochStories", "TochLanguageId", "dbo.TochLanguages");
            DropIndex("dbo.TochStories", new[] { "TochLanguageId" });
            CreateTable(
                "dbo.NamePlaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlaceEn = c.String(),
                        PlaceFr = c.String(),
                        PlaceZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProperNouns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SourceStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Source = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ThemeStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ThemeEn = c.String(),
                        ThemeFr = c.String(),
                        ThemeZn = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.TochStories", "SourceStoryId", c => c.Int(nullable: false));
            AddColumn("dbo.TochStories", "ProperNounId", c => c.Int(nullable: false));
            AddColumn("dbo.TochStories", "ThemeStoryId", c => c.Int(nullable: false));
            AddColumn("dbo.TochStories", "NamePlaceId", c => c.Int(nullable: false));
            AddColumn("dbo.TochStories", "PlasticRepresentation", c => c.String());
            AddColumn("dbo.TochStories", "MainFindSpot", c => c.String());
            AddColumn("dbo.Collaborations", "Fonction", c => c.String());
            AddColumn("dbo.Collaborations", "Affiliation", c => c.String());
            CreateIndex("dbo.TochStories", "SourceStoryId");
            CreateIndex("dbo.TochStories", "ThemeStoryId");
            CreateIndex("dbo.TochStories", "NamePlaceId");
            AddForeignKey("dbo.TochStories", "NamePlaceId", "dbo.NamePlaces", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TochStories", "SourceStoryId", "dbo.ProperNouns", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TochStories", "SourceStoryId", "dbo.SourceStories", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TochStories", "ThemeStoryId", "dbo.ThemeStories", "Id", cascadeDelete: false);
            DropColumn("dbo.TochStories", "TochLanguageId");
            DropColumn("dbo.Collaborations", "Summary");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Collaborations", "Summary", c => c.String());
            AddColumn("dbo.TochStories", "TochLanguageId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TochStories", "ThemeStoryId", "dbo.ThemeStories");
            DropForeignKey("dbo.TochStories", "SourceStoryId", "dbo.SourceStories");
            DropForeignKey("dbo.TochStories", "SourceStoryId", "dbo.ProperNouns");
            DropForeignKey("dbo.TochStories", "NamePlaceId", "dbo.NamePlaces");
            DropIndex("dbo.TochStories", new[] { "NamePlaceId" });
            DropIndex("dbo.TochStories", new[] { "ThemeStoryId" });
            DropIndex("dbo.TochStories", new[] { "SourceStoryId" });
            DropColumn("dbo.Collaborations", "Affiliation");
            DropColumn("dbo.Collaborations", "Fonction");
            DropColumn("dbo.TochStories", "MainFindSpot");
            DropColumn("dbo.TochStories", "PlasticRepresentation");
            DropColumn("dbo.TochStories", "NamePlaceId");
            DropColumn("dbo.TochStories", "ThemeStoryId");
            DropColumn("dbo.TochStories", "ProperNounId");
            DropColumn("dbo.TochStories", "SourceStoryId");
            DropTable("dbo.ThemeStories");
            DropTable("dbo.SourceStories");
            DropTable("dbo.ProperNouns");
            DropTable("dbo.NamePlaces");
            CreateIndex("dbo.TochStories", "TochLanguageId");
            AddForeignKey("dbo.TochStories", "TochLanguageId", "dbo.TochLanguages", "Id", cascadeDelete: false);
        }
    }
}
