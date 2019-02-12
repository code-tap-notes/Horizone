namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeBibliography : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DictionaryTocharianBibliographies", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.DictionaryTocharianBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.Bibliographies", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ManuscriptBibliographies", "Manuscript_Id", "dbo.Manuscripts");
            DropForeignKey("dbo.ManuscriptBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropIndex("dbo.Bibliographies", new[] { "LanguageId" });
            DropIndex("dbo.DictionaryTocharianBibliographies", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.DictionaryTocharianBibliographies", new[] { "Bibliography_Id" });
            DropIndex("dbo.ManuscriptBibliographies", new[] { "Manuscript_Id" });
            DropIndex("dbo.ManuscriptBibliographies", new[] { "Bibliography_Id" });
            AddColumn("dbo.Bibliographies", "DictionaryTocharian_Id", c => c.Int());
            AddColumn("dbo.Bibliographies", "Manuscript_Id", c => c.Int());
            AddColumn("dbo.Bibliographies", "TochStory_Id", c => c.Int());
            AddColumn("dbo.TochStories", "Content", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.TochStories", "LanguageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bibliographies", "DictionaryTocharian_Id");
            CreateIndex("dbo.Bibliographies", "Manuscript_Id");
            CreateIndex("dbo.Bibliographies", "TochStory_Id");
            CreateIndex("dbo.TochStories", "LanguageId");
            AddForeignKey("dbo.Bibliographies", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id");
            AddForeignKey("dbo.Bibliographies", "Manuscript_Id", "dbo.Manuscripts", "Id");
            AddForeignKey("dbo.Bibliographies", "TochStory_Id", "dbo.TochStories", "Id");
            AddForeignKey("dbo.TochStories", "LanguageId", "dbo.Languages", "Id", cascadeDelete: true);
            DropColumn("dbo.Bibliographies", "LanguageId");
            DropColumn("dbo.TochStories", "ContentEnglish");
            DropColumn("dbo.TochStories", "ContentFrancaise");
            DropColumn("dbo.TochStories", "ContentChinese");
            DropTable("dbo.DictionaryTocharianBibliographies");
            DropTable("dbo.ManuscriptBibliographies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ManuscriptBibliographies",
                c => new
                    {
                        Manuscript_Id = c.Int(nullable: false),
                        Bibliography_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Manuscript_Id, t.Bibliography_Id });
            
            CreateTable(
                "dbo.DictionaryTocharianBibliographies",
                c => new
                    {
                        DictionaryTocharian_Id = c.Int(nullable: false),
                        Bibliography_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DictionaryTocharian_Id, t.Bibliography_Id });
            
            AddColumn("dbo.TochStories", "ContentChinese", c => c.String(maxLength: 500));
            AddColumn("dbo.TochStories", "ContentFrancaise", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.TochStories", "ContentEnglish", c => c.String(nullable: false, maxLength: 500));
            AddColumn("dbo.Bibliographies", "LanguageId", c => c.Int(nullable: false));
            DropForeignKey("dbo.TochStories", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Bibliographies", "TochStory_Id", "dbo.TochStories");
            DropForeignKey("dbo.Bibliographies", "Manuscript_Id", "dbo.Manuscripts");
            DropForeignKey("dbo.Bibliographies", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropIndex("dbo.TochStories", new[] { "LanguageId" });
            DropIndex("dbo.Bibliographies", new[] { "TochStory_Id" });
            DropIndex("dbo.Bibliographies", new[] { "Manuscript_Id" });
            DropIndex("dbo.Bibliographies", new[] { "DictionaryTocharian_Id" });
            DropColumn("dbo.TochStories", "LanguageId");
            DropColumn("dbo.TochStories", "Content");
            DropColumn("dbo.Bibliographies", "TochStory_Id");
            DropColumn("dbo.Bibliographies", "Manuscript_Id");
            DropColumn("dbo.Bibliographies", "DictionaryTocharian_Id");
            CreateIndex("dbo.ManuscriptBibliographies", "Bibliography_Id");
            CreateIndex("dbo.ManuscriptBibliographies", "Manuscript_Id");
            CreateIndex("dbo.DictionaryTocharianBibliographies", "Bibliography_Id");
            CreateIndex("dbo.DictionaryTocharianBibliographies", "DictionaryTocharian_Id");
            CreateIndex("dbo.Bibliographies", "LanguageId");
            AddForeignKey("dbo.ManuscriptBibliographies", "Bibliography_Id", "dbo.Bibliographies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ManuscriptBibliographies", "Manuscript_Id", "dbo.Manuscripts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bibliographies", "LanguageId", "dbo.Languages", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DictionaryTocharianBibliographies", "Bibliography_Id", "dbo.Bibliographies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DictionaryTocharianBibliographies", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: true);
        }
    }
}
