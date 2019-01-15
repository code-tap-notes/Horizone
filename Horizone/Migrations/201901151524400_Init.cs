namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateofActivity = c.String(nullable: false),
                        Place = c.String(nullable: false),
                        NameActivity = c.String(nullable: false),
                        Description = c.String(),
                        UlrActivity = c.String(),
                        Picture = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Languages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(maxLength: 2),
                        Name = c.String(maxLength: 50),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bibliographies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(maxLength: 150),
                        PublicationDate = c.String(maxLength: 10),
                        Title = c.String(maxLength: 500),
                        Journal = c.String(maxLength: 500),
                        UlrBibliography = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => new { t.Title, t.LastName, t.FirstName }, unique: true, name: "IX_PersonneUnique");
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Colaborateurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
                .Index(t => t.UserId)
                .Index(t => new { t.Title, t.LastName, t.FirstName }, unique: true, name: "IX_PersonneUnique");
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Summary = c.String(maxLength: 40),
                        ContentFrench = c.String(maxLength: 40),
                        ContentEnglish = c.String(maxLength: 40),
                        ContentChinese = c.String(maxLength: 40),
                        View = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        ColaborateurId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Colaborateurs", t => t.ColaborateurId, cascadeDelete: false)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: false)
                .Index(t => t.TopicId)
                .Index(t => t.ColaborateurId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false, maxLength: 500),
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
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .Index(t => t.LanguageId);
            
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
                        SymbolLanguage = c.String(maxLength: 2),
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
                .ForeignKey("dbo.ObjectManuscripts", t => t.ObjectManuscriptId, cascadeDelete: false)
                .ForeignKey("dbo.Proveniences", t => t.ProvenienceId, cascadeDelete: true)
                .ForeignKey("dbo.TextContents", t => t.TextContentId, cascadeDelete: true)
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
                "dbo.MainContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AboutUs = c.String(maxLength: 1500),
                        Contact = c.String(maxLength: 1500),
                        Presentation = c.String(maxLength: 1500),
                        Picture = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        Status = c.Byte(nullable: false),
                        Target = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.MainContents", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Manuscripts", "TextContentId", "dbo.TextContents");
            DropForeignKey("dbo.Manuscripts", "ProvenienceId", "dbo.Proveniences");
            DropForeignKey("dbo.Manuscripts", "ObjectManuscriptId", "dbo.ObjectManuscripts");
            DropForeignKey("dbo.ImageManuscripts", "ManuscriptId", "dbo.Manuscripts");
            DropForeignKey("dbo.ImageDictionaries", "DictionaryTocharianId", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.News", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.News", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ImageNews", "NewsId", "dbo.News");
            DropForeignKey("dbo.Comments", "NewsId", "dbo.News");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.News", "ColaborateurId", "dbo.Colaborateurs");
            DropForeignKey("dbo.Colaborateurs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Activities", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Transcriptions", new[] { "ManuscriptId" });
            DropIndex("dbo.Transcriptions", new[] { "TochPhraseId" });
            DropIndex("dbo.Transcriptions", new[] { "TochStoryId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.MainContents", new[] { "LanguageId" });
            DropIndex("dbo.Manuscripts", new[] { "ObjectManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "TextContentId" });
            DropIndex("dbo.Manuscripts", new[] { "ProvenienceId" });
            DropIndex("dbo.ImageManuscripts", new[] { "ManuscriptId" });
            DropIndex("dbo.ImageDictionaries", new[] { "DictionaryTocharianId" });
            DropIndex("dbo.Topics", new[] { "LanguageId" });
            DropIndex("dbo.ImageNews", new[] { "NewsId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "LanguageId" });
            DropIndex("dbo.News", new[] { "ColaborateurId" });
            DropIndex("dbo.News", new[] { "TopicId" });
            DropIndex("dbo.Colaborateurs", "IX_PersonneUnique");
            DropIndex("dbo.Colaborateurs", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Clients", "IX_PersonneUnique");
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropIndex("dbo.Activities", new[] { "LanguageId" });
            DropTable("dbo.Transcriptions");
            DropTable("dbo.TochStories");
            DropTable("dbo.TochPhrases");
            DropTable("dbo.Roles");
            DropTable("dbo.Menus");
            DropTable("dbo.MainContents");
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
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.Bibliographies");
            DropTable("dbo.Languages");
            DropTable("dbo.Activities");
        }
    }
}
