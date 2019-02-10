namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AboutProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aim = c.String(),
                        Funding = c.String(maxLength: 2000),
                        Programing = c.String(maxLength: 2000),
                        Feedback = c.String(maxLength: 2000),
                        Contact = c.String(maxLength: 1500),
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
                        Symbol = c.String(maxLength: 20),
                        Name = c.String(maxLength: 40),
                        IsDefault = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.Bibliographies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(maxLength: 150),
                        PublicationDate = c.String(maxLength: 10),
                        Title = c.String(maxLength: 500),
                        Journal = c.String(maxLength: 500),
                        UlrBibliography = c.String(maxLength: 500),
                        LanguageId = c.Int(nullable: false),
                        TochPhrase_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .ForeignKey("dbo.TochPhrases", t => t.TochPhrase_Id)
                .Index(t => t.LanguageId)
                .Index(t => t.TochPhrase_Id);
            
            CreateTable(
                "dbo.DictionaryTocharians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(nullable: false, maxLength: 30),
                        English = c.String(maxLength: 200),
                        Francaise = c.String(maxLength: 200),
                        Chinese = c.String(maxLength: 200),
                        ClassOfWord = c.Byte(nullable: false),
                        WordSubClass = c.Byte(nullable: false),
                        Language = c.String(maxLength: 30),
                        EquivalentInTA = c.String(maxLength: 30),
                        EquivalentInOther = c.String(maxLength: 30),
                        DerivedFrom = c.String(maxLength: 30),
                        RelatedLexemes = c.String(maxLength: 30),
                        RootCharacter = c.String(maxLength: 30),
                        InternalRootVowel = c.String(maxLength: 30),
                        Paradigm = c.String(maxLength: 30),
                        Case = c.String(maxLength: 30),
                        WordNumber = c.Byte(nullable: false),
                        WordGender = c.Byte(nullable: false),
                        Stem = c.String(maxLength: 30),
                        StemClass = c.String(maxLength: 30),
                        Voice = c.String(maxLength: 30),
                        Nominate = c.String(maxLength: 30),
                        Oblique = c.String(maxLength: 30),
                        Vocative = c.String(maxLength: 30),
                        Genitive = c.String(maxLength: 30),
                        Locative = c.String(maxLength: 30),
                        Ablative = c.String(maxLength: 30),
                        Allative = c.String(maxLength: 30),
                        Perlative = c.String(maxLength: 30),
                        Instrumental = c.String(maxLength: 30),
                        Comitative = c.String(maxLength: 30),
                        Causative = c.String(maxLength: 30),
                        Conjugation = c.String(),
                        Visible = c.Boolean(nullable: false),
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
                .ForeignKey("dbo.DictionaryTocharians", t => t.DictionaryTocharianId, cascadeDelete: true)
                .Index(t => t.DictionaryTocharianId);
            
            CreateTable(
                "dbo.Manuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.String(nullable: false, maxLength: 40),
                        Transliteration = c.String(),
                        Transcription = c.String(),
                        English = c.String(maxLength: 2000),
                        Francaise = c.String(maxLength: 2000),
                        Chinese = c.String(maxLength: 2000),
                        Editor = c.String(maxLength: 500),
                        References = c.String(maxLength: 2000),
                        PhilologicalCommentary = c.String(),
                        ScriptManuscriptId = c.Int(nullable: false),
                        TextContentId = c.Int(nullable: false),
                        MaterialManuscriptId = c.Int(nullable: false),
                        OverallDescriptionId = c.Int(nullable: false),
                        LayoutManuscriptId = c.Int(nullable: false),
                        TextLanguageId = c.Int(nullable: false),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LayoutManuscripts", t => t.LayoutManuscriptId, cascadeDelete: true)
                .ForeignKey("dbo.MaterialManuscripts", t => t.MaterialManuscriptId, cascadeDelete: true)
                .ForeignKey("dbo.OverallDescriptions", t => t.OverallDescriptionId, cascadeDelete: true)
                .ForeignKey("dbo.ScriptManuscripts", t => t.ScriptManuscriptId, cascadeDelete: true)
                .ForeignKey("dbo.TextContents", t => t.TextContentId, cascadeDelete: true)
                .ForeignKey("dbo.TextLanguages", t => t.TextLanguageId, cascadeDelete: true)
                .Index(t => t.ScriptManuscriptId)
                .Index(t => t.TextContentId)
                .Index(t => t.MaterialManuscriptId)
                .Index(t => t.OverallDescriptionId)
                .Index(t => t.LayoutManuscriptId)
                .Index(t => t.TextLanguageId);
            
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
                "dbo.LayoutManuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SizeHeight = c.String(maxLength: 40),
                        Completeness = c.String(maxLength: 40),
                        SizeWidth = c.String(maxLength: 40),
                        NumberOfLine = c.Int(nullable: false),
                        LineDistance = c.String(maxLength: 40),
                        Format = c.String(maxLength: 40),
                        Ruling = c.String(maxLength: 40),
                        RulingColor = c.String(maxLength: 40),
                        RulingDetail = c.Int(nullable: false),
                        StringholeHeight = c.Int(nullable: false),
                        StringholeWidth = c.Int(nullable: false),
                        DistanceStringholeRight = c.Int(nullable: false),
                        DistanceStringholeLeft = c.Int(nullable: false),
                        InterruptedLine = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MaterialManuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Material = c.String(maxLength: 40),
                        PaperColor = c.String(maxLength: 40),
                        PaperThickness = c.String(maxLength: 40),
                        WritingTool = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OverallDescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Collection = c.String(maxLength: 40),
                        Siglum = c.String(maxLength: 40),
                        Joint = c.String(maxLength: 40),
                        OtherSiglum = c.String(maxLength: 40),
                        ExpeditionCode = c.String(maxLength: 40),
                        MainFindSpot = c.String(maxLength: 40),
                        SpecificFindSpot = c.String(maxLength: 40),
                        GeneralState = c.String(maxLength: 40),
                        Description = c.String(maxLength: 40),
                        Remark = c.String(maxLength: 40),
                        LeafNumber = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScriptManuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlignmentType = c.String(nullable: false, maxLength: 200),
                        ModuleWidth = c.String(nullable: false, maxLength: 200),
                        ModuleHeight = c.String(nullable: false, maxLength: 200),
                        AvCharPerLigne = c.String(nullable: false, maxLength: 200),
                        NibThickness = c.String(nullable: false, maxLength: 200),
                        Script = c.String(nullable: false, maxLength: 200),
                        ScriptAdd = c.String(nullable: false, maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TextContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TextGenre = c.String(maxLength: 40),
                        TextSubGenre = c.String(maxLength: 40),
                        Title = c.String(maxLength: 40),
                        Passage = c.String(maxLength: 40),
                        Parallel = c.String(maxLength: 40),
                        MetricForm = c.String(maxLength: 40),
                        Tune = c.String(maxLength: 40),
                        Bibliography = c.String(maxLength: 40),
                        Cetom = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TextLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Language = c.String(nullable: false, maxLength: 40),
                        LanguageStage = c.String(nullable: false, maxLength: 40),
                        LanguageDetails = c.String(nullable: false, maxLength: 40),
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
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
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
                "dbo.Collaborateurs",
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
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => new { t.Title, t.LastName, t.FirstName }, unique: true, name: "IX_PersonneUnique");
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 40),
                        Summary = c.String(maxLength: 200),
                        Content = c.String(),
                        View = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        ColaborateurId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collaborateurs", t => t.ColaborateurId, cascadeDelete: false)
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
                        TopicName = c.String(nullable: false, maxLength: 40),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Collaborations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        Summary = c.String(maxLength: 500),
                        CV = c.String(maxLength: 500),
                        Email = c.String(),
                        Team = c.Boolean(nullable: false),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageCollaborations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        CollaborationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collaborations", t => t.CollaborationId, cascadeDelete: false)
                .Index(t => t.CollaborationId);
            
            CreateTable(
                "dbo.Publications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PublicationDate = c.String(maxLength: 10),
                        Title = c.String(maxLength: 500),
                        Journal = c.String(maxLength: 500),
                        UlrBibliography = c.String(maxLength: 500),
                        CollaborationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collaborations", t => t.CollaborationId, cascadeDelete: false)
                .Index(t => t.CollaborationId);
            
            CreateTable(
                "dbo.ContactMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        Email = c.String(nullable: false),
                        PhoneNumber = c.String(maxLength: 20),
                        SendDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Message = c.String(),
                        SymbolLanguage = c.String(maxLength: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InThePresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        LinkThePresse = c.String(maxLength: 200),
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
                        Phrase = c.String(nullable: false, maxLength: 200),
                        English = c.String(maxLength: 200),
                        Francaise = c.String(maxLength: 200),
                        Chinese = c.String(maxLength: 200),
                        Language = c.String(maxLength: 30),
                        DerivedFrom = c.String(maxLength: 30),
                        RelatedLexemes = c.String(maxLength: 30),
                        Description = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TochStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        ContentEnglish = c.String(nullable: false, maxLength: 500),
                        ContentFrancaise = c.String(nullable: false, maxLength: 500),
                        ContentChinese = c.String(maxLength: 500),
                        Description = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DictionaryTocharianBibliographies",
                c => new
                    {
                        DictionaryTocharian_Id = c.Int(nullable: false),
                        Bibliography_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DictionaryTocharian_Id, t.Bibliography_Id })
                .ForeignKey("dbo.DictionaryTocharians", t => t.DictionaryTocharian_Id, cascadeDelete: true)
                .ForeignKey("dbo.Bibliographies", t => t.Bibliography_Id, cascadeDelete: false)
                .Index(t => t.DictionaryTocharian_Id)
                .Index(t => t.Bibliography_Id);
            
            CreateTable(
                "dbo.ManuscriptBibliographies",
                c => new
                    {
                        Manuscript_Id = c.Int(nullable: false),
                        Bibliography_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Manuscript_Id, t.Bibliography_Id })
                .ForeignKey("dbo.Manuscripts", t => t.Manuscript_Id, cascadeDelete: false)
                .ForeignKey("dbo.Bibliographies", t => t.Bibliography_Id, cascadeDelete: false)
                .Index(t => t.Manuscript_Id)
                .Index(t => t.Bibliography_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bibliographies", "TochPhrase_Id", "dbo.TochPhrases");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.InThePresses", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Publications", "CollaborationId", "dbo.Collaborations");
            DropForeignKey("dbo.ImageCollaborations", "CollaborationId", "dbo.Collaborations");
            DropForeignKey("dbo.News", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.News", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ImageNews", "NewsId", "dbo.News");
            DropForeignKey("dbo.Comments", "NewsId", "dbo.News");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.News", "ColaborateurId", "dbo.Collaborateurs");
            DropForeignKey("dbo.Collaborateurs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Manuscripts", "TextLanguageId", "dbo.TextLanguages");
            DropForeignKey("dbo.Manuscripts", "TextContentId", "dbo.TextContents");
            DropForeignKey("dbo.Manuscripts", "ScriptManuscriptId", "dbo.ScriptManuscripts");
            DropForeignKey("dbo.Manuscripts", "OverallDescriptionId", "dbo.OverallDescriptions");
            DropForeignKey("dbo.Manuscripts", "MaterialManuscriptId", "dbo.MaterialManuscripts");
            DropForeignKey("dbo.Manuscripts", "LayoutManuscriptId", "dbo.LayoutManuscripts");
            DropForeignKey("dbo.ImageManuscripts", "ManuscriptId", "dbo.Manuscripts");
            DropForeignKey("dbo.ManuscriptBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.ManuscriptBibliographies", "Manuscript_Id", "dbo.Manuscripts");
            DropForeignKey("dbo.Bibliographies", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ImageDictionaries", "DictionaryTocharianId", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.DictionaryTocharianBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.DictionaryTocharianBibliographies", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.Activities", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.AboutProjects", "LanguageId", "dbo.Languages");
            DropIndex("dbo.ManuscriptBibliographies", new[] { "Bibliography_Id" });
            DropIndex("dbo.ManuscriptBibliographies", new[] { "Manuscript_Id" });
            DropIndex("dbo.DictionaryTocharianBibliographies", new[] { "Bibliography_Id" });
            DropIndex("dbo.DictionaryTocharianBibliographies", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.InThePresses", new[] { "LanguageId" });
            DropIndex("dbo.Publications", new[] { "CollaborationId" });
            DropIndex("dbo.ImageCollaborations", new[] { "CollaborationId" });
            DropIndex("dbo.Topics", new[] { "LanguageId" });
            DropIndex("dbo.ImageNews", new[] { "NewsId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "LanguageId" });
            DropIndex("dbo.News", new[] { "ColaborateurId" });
            DropIndex("dbo.News", new[] { "TopicId" });
            DropIndex("dbo.Collaborateurs", "IX_PersonneUnique");
            DropIndex("dbo.Collaborateurs", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Clients", "IX_PersonneUnique");
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropIndex("dbo.ImageManuscripts", new[] { "ManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "TextLanguageId" });
            DropIndex("dbo.Manuscripts", new[] { "LayoutManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "OverallDescriptionId" });
            DropIndex("dbo.Manuscripts", new[] { "MaterialManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "TextContentId" });
            DropIndex("dbo.Manuscripts", new[] { "ScriptManuscriptId" });
            DropIndex("dbo.ImageDictionaries", new[] { "DictionaryTocharianId" });
            DropIndex("dbo.Bibliographies", new[] { "TochPhrase_Id" });
            DropIndex("dbo.Bibliographies", new[] { "LanguageId" });
            DropIndex("dbo.Activities", new[] { "LanguageId" });
            DropIndex("dbo.AboutProjects", new[] { "LanguageId" });
            DropTable("dbo.ManuscriptBibliographies");
            DropTable("dbo.DictionaryTocharianBibliographies");
            DropTable("dbo.TochStories");
            DropTable("dbo.TochPhrases");
            DropTable("dbo.Roles");
            DropTable("dbo.Menus");
            DropTable("dbo.InThePresses");
            DropTable("dbo.ContactMessages");
            DropTable("dbo.Publications");
            DropTable("dbo.ImageCollaborations");
            DropTable("dbo.Collaborations");
            DropTable("dbo.Topics");
            DropTable("dbo.ImageNews");
            DropTable("dbo.Comments");
            DropTable("dbo.News");
            DropTable("dbo.Collaborateurs");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.TextLanguages");
            DropTable("dbo.TextContents");
            DropTable("dbo.ScriptManuscripts");
            DropTable("dbo.OverallDescriptions");
            DropTable("dbo.MaterialManuscripts");
            DropTable("dbo.LayoutManuscripts");
            DropTable("dbo.ImageManuscripts");
            DropTable("dbo.Manuscripts");
            DropTable("dbo.ImageDictionaries");
            DropTable("dbo.DictionaryTocharians");
            DropTable("dbo.Bibliographies");
            DropTable("dbo.Activities");
            DropTable("dbo.Languages");
            DropTable("dbo.AboutProjects");
        }
    }
}
