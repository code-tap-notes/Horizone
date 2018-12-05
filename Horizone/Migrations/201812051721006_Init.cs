namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        FisrtName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 60),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => new { t.Title, t.LastName, t.FisrtName, t.Address }, unique: true, name: "IX_PersonneUnique");
            
            CreateTable(
                "dbo.Colaborateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        FisrtName = c.String(nullable: false, maxLength: 30),
                        Address = c.String(nullable: false, maxLength: 60),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        BirthDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => new { t.Title, t.LastName, t.FisrtName, t.Address }, unique: true, name: "IX_PersonneUnique");
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Summary = c.String(maxLength: 40),
                        ContentEnglish = c.String(maxLength: 40),
                        ContentFrench = c.String(maxLength: 40),
                        ContentChinese = c.String(maxLength: 40),
                        View = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        ColaborateurId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborateurs", t => t.ColaborateurId, cascadeDelete: false)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: false)
                .Index(t => t.TopicId)
                .Index(t => t.ColaborateurId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(maxLength: 40),
                        NewsId = c.Int(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: false)
                .Index(t => t.NewsId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ImageNews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        NewsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: false)
                .Index(t => t.NewsId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameFrench = c.String(nullable: false, maxLength: 40),
                        NameEnglish = c.String(nullable: false, maxLength: 40),
                        TopicChinese = c.String(maxLength: 40),
                        TopicVietnam = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ContactMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        FisrtName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(maxLength: 20),
                        SendDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DictionaryTocharians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(nullable: false, maxLength: 40),
                        English = c.String(nullable: false, maxLength: 40),
                        Francaise = c.String(nullable: false, maxLength: 40),
                        Sanskrit = c.String(maxLength: 40),
                        Chinois = c.String(maxLength: 40),
                        Vietnam = c.String(maxLength: 40),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        DictionaryTocharianId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DictionaryTocharians", t => t.DictionaryTocharianId, cascadeDelete: false)
                .Index(t => t.DictionaryTocharianId);
            
            CreateTable(
                "dbo.ImageManuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        ManuscriptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manuscripts", t => t.ManuscriptId, cascadeDelete: false)
                .Index(t => t.ManuscriptId);
            
            CreateTable(
                "dbo.Manuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.String(nullable: false, maxLength: 40),
                        Language = c.String(nullable: false, maxLength: 40),
                        Script = c.String(maxLength: 40),
                        Repository = c.String(maxLength: 40),
                        Shelfmark = c.String(maxLength: 40),
                        TranslateEnglish = c.String(maxLength: 40),
                        TranslateFrench = c.String(maxLength: 40),
                        TranslateChinese = c.String(maxLength: 40),
                        Description = c.String(),
                        Editor = c.String(maxLength: 40),
                        Bibliography = c.String(maxLength: 40),
                        ProvenienceId = c.Int(nullable: false),
                        TextContentId = c.Int(nullable: false),
                        ObjectManuscriptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ObjectManuscripts", t => t.ObjectManuscriptId, cascadeDelete: true)
                .ForeignKey("dbo.Proveniences", t => t.ProvenienceId, cascadeDelete: false)
                .ForeignKey("dbo.TextContents", t => t.TextContentId, cascadeDelete: false)
                .Index(t => t.ProvenienceId)
                .Index(t => t.TextContentId)
                .Index(t => t.ObjectManuscriptId);
            
            CreateTable(
                "dbo.ObjectManuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Manuscript = c.String(maxLength: 40),
                        LeafNumber = c.String(maxLength: 40),
                        Material = c.String(maxLength: 40),
                        Form = c.String(maxLength: 40),
                        NumberOfLine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Proveniences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MainFindSpot = c.String(maxLength: 40),
                        SpecificFindSpot = c.String(maxLength: 40),
                        ExpeditionCode = c.String(maxLength: 40),
                        Colection = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TextContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TitleOfTheWork = c.String(maxLength: 40),
                        Passage = c.String(maxLength: 40),
                        TextGenre = c.String(maxLength: 40),
                        TextSubgenre = c.String(maxLength: 40),
                        VerseProse = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TochPhrases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.String(nullable: false, maxLength: 40),
                        Name = c.String(nullable: false, maxLength: 40),
                        Content = c.String(nullable: false, maxLength: 40),
                        English = c.String(nullable: false, maxLength: 40),
                        Francaise = c.String(nullable: false, maxLength: 40),
                        Sanskrit = c.String(maxLength: 40),
                        Chinois = c.String(maxLength: 40),
                        Vietnam = c.String(maxLength: 40),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TochStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 40),
                        ContentEnglish = c.String(nullable: false, maxLength: 40),
                        ContentFrancaise = c.String(nullable: false, maxLength: 40),
                        ContentChinese = c.String(maxLength: 40),
                        ContentVietnam = c.String(maxLength: 40),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transcriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(nullable: false, maxLength: 40),
                        TochStoryId = c.Int(nullable: false),
                        TochPhraseId = c.Int(nullable: false),
                        ManuscriptId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Manuscripts", t => t.ManuscriptId, cascadeDelete: false)
                .ForeignKey("dbo.TochPhrases", t => t.TochPhraseId, cascadeDelete: false)
                .ForeignKey("dbo.TochStories", t => t.TochStoryId, cascadeDelete: false)
                .Index(t => t.TochStoryId)
                .Index(t => t.TochPhraseId)
                .Index(t => t.ManuscriptId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transcriptions", "TochStoryId", "dbo.TochStories");
            DropForeignKey("dbo.Transcriptions", "TochPhraseId", "dbo.TochPhrases");
            DropForeignKey("dbo.Transcriptions", "ManuscriptId", "dbo.Manuscripts");
            DropForeignKey("dbo.Manuscripts", "TextContentId", "dbo.TextContents");
            DropForeignKey("dbo.Manuscripts", "ProvenienceId", "dbo.Proveniences");
            DropForeignKey("dbo.Manuscripts", "ObjectManuscriptId", "dbo.ObjectManuscripts");
            DropForeignKey("dbo.ImageManuscripts", "ManuscriptId", "dbo.Manuscripts");
            DropForeignKey("dbo.ImageDictionaries", "DictionaryTocharianId", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.News", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.ImageNews", "NewsId", "dbo.News");
            DropForeignKey("dbo.Comments", "NewsId", "dbo.News");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.News", "ColaborateurId", "dbo.Colaborateurs");
            DropForeignKey("dbo.Colaborateurs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropIndex("dbo.Transcriptions", new[] { "ManuscriptId" });
            DropIndex("dbo.Transcriptions", new[] { "TochPhraseId" });
            DropIndex("dbo.Transcriptions", new[] { "TochStoryId" });
            DropIndex("dbo.Manuscripts", new[] { "ObjectManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "TextContentId" });
            DropIndex("dbo.Manuscripts", new[] { "ProvenienceId" });
            DropIndex("dbo.ImageManuscripts", new[] { "ManuscriptId" });
            DropIndex("dbo.ImageDictionaries", new[] { "DictionaryTocharianId" });
            DropIndex("dbo.ImageNews", new[] { "NewsId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "ColaborateurId" });
            DropIndex("dbo.News", new[] { "TopicId" });
            DropIndex("dbo.Colaborateurs", "IX_PersonneUnique");
            DropIndex("dbo.Colaborateurs", new[] { "UserId" });
            DropIndex("dbo.Clients", "IX_PersonneUnique");
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropTable("dbo.Transcriptions");
            DropTable("dbo.TochStories");
            DropTable("dbo.TochPhrases");
            DropTable("dbo.TextContents");
            DropTable("dbo.Proveniences");
            DropTable("dbo.ObjectManuscripts");
            DropTable("dbo.Manuscripts");
            DropTable("dbo.ImageManuscripts");
            DropTable("dbo.ImageDictionaries");
            DropTable("dbo.DictionaryTocharians");
            DropTable("dbo.ContactMessages");
            DropTable("dbo.Topics");
            DropTable("dbo.ImageNews");
            DropTable("dbo.Comments");
            DropTable("dbo.News");
            DropTable("dbo.Colaborateurs");
            DropTable("dbo.Clients");
        }
    }
}
