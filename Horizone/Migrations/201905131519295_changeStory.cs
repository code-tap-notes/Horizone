namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeStory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TochPhrases", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.TochStories", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.TochStories", "NamePlaceId", "dbo.NamePlaces");
            DropForeignKey("dbo.TochStories", "SourceStoryId", "dbo.ProperNouns");
            DropIndex("dbo.TochPhrases", new[] { "LanguageId" });
            DropIndex("dbo.TochStories", new[] { "NamePlaceId" });
            DropIndex("dbo.TochStories", new[] { "LanguageId" });
            CreateTable(
                "dbo.NamePlaceTochStories",
                c => new
                    {
                        NamePlace_Id = c.Int(nullable: false),
                        TochStory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NamePlace_Id, t.TochStory_Id })
                .ForeignKey("dbo.NamePlaces", t => t.NamePlace_Id, cascadeDelete: false)
                .ForeignKey("dbo.TochStories", t => t.TochStory_Id, cascadeDelete: false)
                .Index(t => t.NamePlace_Id)
                .Index(t => t.TochStory_Id);
            
            CreateTable(
                "dbo.ProperNounTochStories",
                c => new
                    {
                        ProperNoun_Id = c.Int(nullable: false),
                        TochStory_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProperNoun_Id, t.TochStory_Id })
                .ForeignKey("dbo.ProperNouns", t => t.ProperNoun_Id, cascadeDelete: false)
                .ForeignKey("dbo.TochStories", t => t.TochStory_Id, cascadeDelete: false)
                .Index(t => t.ProperNoun_Id)
                .Index(t => t.TochStory_Id);
            
            DropColumn("dbo.TochPhrases", "LanguageId");
            DropColumn("dbo.TochStories", "ProperNounId");
            DropColumn("dbo.TochStories", "NamePlaceId");
            DropColumn("dbo.TochStories", "LanguageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TochStories", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.TochStories", "NamePlaceId", c => c.Int(nullable: false));
            AddColumn("dbo.TochStories", "ProperNounId", c => c.Int(nullable: false));
            AddColumn("dbo.TochPhrases", "LanguageId", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProperNounTochStories", "TochStory_Id", "dbo.TochStories");
            DropForeignKey("dbo.ProperNounTochStories", "ProperNoun_Id", "dbo.ProperNouns");
            DropForeignKey("dbo.NamePlaceTochStories", "TochStory_Id", "dbo.TochStories");
            DropForeignKey("dbo.NamePlaceTochStories", "NamePlace_Id", "dbo.NamePlaces");
            DropIndex("dbo.ProperNounTochStories", new[] { "TochStory_Id" });
            DropIndex("dbo.ProperNounTochStories", new[] { "ProperNoun_Id" });
            DropIndex("dbo.NamePlaceTochStories", new[] { "TochStory_Id" });
            DropIndex("dbo.NamePlaceTochStories", new[] { "NamePlace_Id" });
            DropTable("dbo.ProperNounTochStories");
            DropTable("dbo.NamePlaceTochStories");
            CreateIndex("dbo.TochStories", "LanguageId");
            CreateIndex("dbo.TochStories", "NamePlaceId");
            CreateIndex("dbo.TochPhrases", "LanguageId");
            AddForeignKey("dbo.TochStories", "SourceStoryId", "dbo.ProperNouns", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TochStories", "NamePlaceId", "dbo.NamePlaces", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TochStories", "LanguageId", "dbo.Languages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.TochPhrases", "LanguageId", "dbo.Languages", "Id", cascadeDelete: false);
        }
    }
}
