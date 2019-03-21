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
                        Funding = c.String(),
                        Programing = c.String(),
                        Feedback = c.String(),
                        Contact = c.String(),
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
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete:  false)
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DictionaryTocharians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        Chinese = c.String(),
                        WordClassId = c.Int(nullable: false),
                        WordSubClassId = c.Int(nullable: false),
                        TochLanguageId = c.Int(nullable: false),
                        EquivalentTA = c.String(),
                        EquivalentTB = c.String(),
                        EquivalentInOther = c.String(),
                        DerivedFrom = c.String(),
                        RelatedLexemes = c.String(),
                        RootCharacter = c.String(),
                        InternalRootVowel = c.String(),
                        NominateMasculineSingular = c.String(),
                        NominateMasculineDual = c.String(),
                        NominateMasculinePlural = c.String(),
                        NominateFeminineSingular = c.String(),
                        NominateFeminineDual = c.String(),
                        NominateFemininePlural = c.String(),
                        ObliqueMasculineSingular = c.String(),
                        ObliqueMasculineDual = c.String(),
                        ObliqueMasculinePlural = c.String(),
                        ObliqueFeminineSingular = c.String(),
                        ObliqueFeminineDual = c.String(),
                        ObliqueFemininePlural = c.String(),
                        VocativeMasculineSingular = c.String(),
                        VocativeMasculineDual = c.String(),
                        VocativeMasculinePlural = c.String(),
                        VocativeFeminineSingular = c.String(),
                        VocativeFeminineDual = c.String(),
                        VocativeFemininePlural = c.String(),
                        GenitiveMasculineSingular = c.String(),
                        GenitiveMasculineDual = c.String(),
                        GenitiveMasculinePlural = c.String(),
                        GenitiveFeminineSingular = c.String(),
                        GenitiveFeminineDual = c.String(),
                        GenitiveFemininePlural = c.String(),
                        LocativeMasculineSingular = c.String(),
                        LocativeMasculineDual = c.String(),
                        LocativeMasculinePlural = c.String(),
                        LocativeFeminineSingular = c.String(),
                        LocativeFeminineDual = c.String(),
                        LocativeFemininePlural = c.String(),
                        AblativeMasculineSingular = c.String(),
                        AblativeMasculineDual = c.String(),
                        AblativeMasculinePlural = c.String(),
                        AblativeFeminineSingular = c.String(),
                        AblativeFeminineDual = c.String(),
                        AblativeFemininePlural = c.String(),
                        AllativeMasculineSingular = c.String(),
                        AllativeMasculineDual = c.String(),
                        AllativeMasculinePlural = c.String(),
                        AllativeFeminineSingular = c.String(),
                        AllativeFeminineDual = c.String(),
                        AllativeFemininePlural = c.String(),
                        PerlativeMasculineSingular = c.String(),
                        PerlativeMasculineDual = c.String(),
                        PerlativeMasculinePlural = c.String(),
                        PerlativeFeminineSingular = c.String(),
                        PerlativeFeminineDual = c.String(),
                        PerlativeFemininePlural = c.String(),
                        InstrumentalMasculineSingular = c.String(),
                        InstrumentalMasculineDual = c.String(),
                        InstrumentalMasculinePlural = c.String(),
                        InstrumentalFeminineSingular = c.String(),
                        InstrumentalFeminineDual = c.String(),
                        InstrumentalFemininePlural = c.String(),
                        ComitativeMasculineSingular = c.String(),
                        ComitativeMasculineDual = c.String(),
                        ComitativeMasculinePlural = c.String(),
                        ComitativeFeminineSingular = c.String(),
                        ComitativeFeminineDual = c.String(),
                        ComitativeFemininePlural = c.String(),
                        CausativeMasculineSingular = c.String(),
                        CausativeMasculineDual = c.String(),
                        CausativeMasculinePlural = c.String(),
                        CausativeFeminineSingular = c.String(),
                        CausativeFeminineDual = c.String(),
                        CausativeFemininePlural = c.String(),
                        Stem = c.String(),
                        StemClass = c.String(),
                        Voice = c.String(),
                        Valency = c.String(),
                        PronounSuffix = c.String(),
                        TenseMood = c.String(),
                        Visible = c.Boolean(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .ForeignKey("dbo.WordClasses", t => t.WordClassId, cascadeDelete: false)
                .ForeignKey("dbo.WordSubClasses", t => t.WordSubClassId, cascadeDelete: false)
                .Index(t => t.WordClassId)
                .Index(t => t.WordSubClassId)
                .Index(t => t.TochLanguageId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCaseEn = c.String(),
                        NameCaseFr = c.String(),
                        NameCaseZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameGenderEn = c.String(),
                        NameGenderFr = c.String(),
                        NameGenderZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Numbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WordNumberEn = c.String(),
                        WordNumberFr = c.String(),
                        WordNumberZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConjugatedPersonEn = c.String(),
                        ConjugatedPersonFr = c.String(),
                        ConjugatedPersonZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TochLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Language = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClassEn = c.String(nullable: false),
                        ClassFr = c.String(),
                        ClassZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordSubClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubClassEn = c.String(nullable: false),
                        SubClassFr = c.String(),
                        SubClassZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Manuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.String(nullable: false),
                        Collection = c.String(),
                        Siglum = c.String(),
                        Joint = c.String(),
                        OtherSiglum = c.String(),
                        ExpeditionCode = c.String(),
                        MainFindSpot = c.String(),
                        SpecificFindSpot = c.String(),
                        GeneralState = c.String(),
                        Description = c.String(),
                        Remark = c.String(),
                        LeafNumber = c.String(),
                        SizeHeight = c.String(),
                        Completeness = c.String(),
                        SizeWidth = c.String(),
                        NumberOfLine = c.Int(nullable: false),
                        LineDistance = c.String(),
                        Format = c.String(),
                        Ruling = c.String(),
                        RulingColor = c.String(),
                        RulingDetail = c.String(),
                        StringholeHeight = c.String(),
                        StringholeWidth = c.String(),
                        DistanceStringholeRight = c.String(),
                        DistanceStringholeLeft = c.String(),
                        InterruptedLine = c.String(),
                        Transliteration = c.String(),
                        Transcription = c.String(),
                        English = c.String(),
                        Francaise = c.String(),
                        Chinese = c.String(),
                        Editor = c.String(),
                        References = c.String(),
                        PhilologicalCommentary = c.String(),
                        Material = c.String(),
                        PaperColor = c.String(),
                        PaperThickness = c.String(),
                        WritingTool = c.String(),
                        AlignmentType = c.String(),
                        ModuleWidth = c.String(),
                        ModuleHeight = c.String(),
                        AvCharPerLigne = c.String(),
                        NibThickness = c.String(),
                        Script = c.String(),
                        ScriptAdd = c.String(),
                        TochLanguageId = c.Int(nullable: false),
                        LanguageStage = c.String(maxLength: 40),
                        LanguageDetails = c.String(maxLength: 40),
                        TextGenre = c.String(),
                        TextSubGenre = c.String(),
                        Title = c.String(),
                        Passage = c.String(),
                        Parallel = c.String(),
                        MetricForm = c.String(),
                        Tune = c.String(),
                        Cetom = c.String(),
                        Visible = c.Boolean(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .Index(t => t.TochLanguageId)
                .Index(t => t.LanguageId);
            
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
                "dbo.TochPhrases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Phrase = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        Chinese = c.String(),
                        TochLanguageId = c.Int(nullable: false),
                        DerivedFrom = c.String(),
                        RelatedLexemes = c.String(),
                        Description = c.String(),
                        Visible = c.Boolean(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .Index(t => t.TochLanguageId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.TochStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        TochLanguageId = c.Int(nullable: false),
                        Content = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        Chinese = c.String(),
                        Description = c.String(),
                        Visible = c.Boolean(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .Index(t => t.TochLanguageId)
                .Index(t => t.LanguageId);
            
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Collaborators",
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
                        Title = c.String(nullable: false),
                        Summary = c.String(),
                        Content = c.String(),
                        View = c.Int(nullable: false),
                        TopicId = c.Int(nullable: false),
                        CollaboratorId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Collaborators", t => t.CollaboratorId, cascadeDelete: false)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: false)
                .Index(t => t.TopicId)
                .Index(t => t.CollaboratorId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        NewsId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
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
                "dbo.LinkAndPresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Link = c.String(),
                        Order = c.Int(nullable: false),
                        Status = c.Byte(nullable: false),
                        Target = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .Index(t => t.LanguageId);
            
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
                "dbo.DictionaryTocharianBibliographies",
                c => new
                    {
                        DictionaryTocharian_Id = c.Int(nullable: false),
                        Bibliography_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.DictionaryTocharian_Id, t.Bibliography_Id })
                .ForeignKey("dbo.DictionaryTocharians", t => t.DictionaryTocharian_Id, cascadeDelete: false)
                .ForeignKey("dbo.Bibliographies", t => t.Bibliography_Id, cascadeDelete: false)
                .Index(t => t.DictionaryTocharian_Id)
                .Index(t => t.Bibliography_Id);
            
            CreateTable(
                "dbo.CaseDictionaryTocharians",
                c => new
                    {
                        Case_Id = c.Int(nullable: false),
                        DictionaryTocharian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Case_Id, t.DictionaryTocharian_Id })
                .ForeignKey("dbo.Cases", t => t.Case_Id, cascadeDelete: true)
                .ForeignKey("dbo.DictionaryTocharians", t => t.DictionaryTocharian_Id, cascadeDelete: false)
                .Index(t => t.Case_Id)
                .Index(t => t.DictionaryTocharian_Id);
            
            CreateTable(
                "dbo.GenderDictionaryTocharians",
                c => new
                    {
                        Gender_Id = c.Int(nullable: false),
                        DictionaryTocharian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gender_Id, t.DictionaryTocharian_Id })
                .ForeignKey("dbo.Genders", t => t.Gender_Id, cascadeDelete: false)
                .ForeignKey("dbo.DictionaryTocharians", t => t.DictionaryTocharian_Id, cascadeDelete: false)
                .Index(t => t.Gender_Id)
                .Index(t => t.DictionaryTocharian_Id);
            
            CreateTable(
                "dbo.NumberDictionaryTocharians",
                c => new
                    {
                        Number_Id = c.Int(nullable: false),
                        DictionaryTocharian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Number_Id, t.DictionaryTocharian_Id })
                .ForeignKey("dbo.Numbers", t => t.Number_Id, cascadeDelete: true)
                .ForeignKey("dbo.DictionaryTocharians", t => t.DictionaryTocharian_Id, cascadeDelete: false)
                .Index(t => t.Number_Id)
                .Index(t => t.DictionaryTocharian_Id);
            
            CreateTable(
                "dbo.PersonDictionaryTocharians",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        DictionaryTocharian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.DictionaryTocharian_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: false)
                .ForeignKey("dbo.DictionaryTocharians", t => t.DictionaryTocharian_Id, cascadeDelete: false)
                .Index(t => t.Person_Id)
                .Index(t => t.DictionaryTocharian_Id);
            
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
            
            CreateTable(
                "dbo.TochPhraseBibliographies",
                c => new
                    {
                        TochPhrase_Id = c.Int(nullable: false),
                        Bibliography_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TochPhrase_Id, t.Bibliography_Id })
                .ForeignKey("dbo.TochPhrases", t => t.TochPhrase_Id, cascadeDelete: false)
                .ForeignKey("dbo.Bibliographies", t => t.Bibliography_Id, cascadeDelete: false)
                .Index(t => t.TochPhrase_Id)
                .Index(t => t.Bibliography_Id);
            
            CreateTable(
                "dbo.TochStoryBibliographies",
                c => new
                    {
                        TochStory_Id = c.Int(nullable: false),
                        Bibliography_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TochStory_Id, t.Bibliography_Id })
                .ForeignKey("dbo.TochStories", t => t.TochStory_Id, cascadeDelete: false)
                .ForeignKey("dbo.Bibliographies", t => t.Bibliography_Id, cascadeDelete: false)
                .Index(t => t.TochStory_Id)
                .Index(t => t.Bibliography_Id);
            
            CreateTable(
                "dbo.PublicationCollaborations",
                c => new
                    {
                        Publication_Id = c.Int(nullable: false),
                        Collaboration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publication_Id, t.Collaboration_Id })
                .ForeignKey("dbo.Publications", t => t.Publication_Id, cascadeDelete: false)
                .ForeignKey("dbo.Collaborations", t => t.Collaboration_Id, cascadeDelete: false)
                .Index(t => t.Publication_Id)
                .Index(t => t.Collaboration_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.LinkAndPresses", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.News", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.News", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ImageNews", "NewsId", "dbo.News");
            DropForeignKey("dbo.Comments", "NewsId", "dbo.News");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropForeignKey("dbo.News", "CollaboratorId", "dbo.Collaborators");
            DropForeignKey("dbo.Collaborators", "UserId", "dbo.Users");
            DropForeignKey("dbo.PublicationCollaborations", "Collaboration_Id", "dbo.Collaborations");
            DropForeignKey("dbo.PublicationCollaborations", "Publication_Id", "dbo.Publications");
            DropForeignKey("dbo.ImageCollaborations", "CollaborationId", "dbo.Collaborations");
            DropForeignKey("dbo.Clients", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.TochStories", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.TochStories", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.TochStoryBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.TochStoryBibliographies", "TochStory_Id", "dbo.TochStories");
            DropForeignKey("dbo.TochPhrases", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.TochPhrases", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.TochPhraseBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.TochPhraseBibliographies", "TochPhrase_Id", "dbo.TochPhrases");
            DropForeignKey("dbo.Manuscripts", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.Manuscripts", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ImageManuscripts", "ManuscriptId", "dbo.Manuscripts");
            DropForeignKey("dbo.ManuscriptBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.ManuscriptBibliographies", "Manuscript_Id", "dbo.Manuscripts");
            DropForeignKey("dbo.DictionaryTocharians", "WordSubClassId", "dbo.WordSubClasses");
            DropForeignKey("dbo.DictionaryTocharians", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.DictionaryTocharians", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.PersonDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.PersonDictionaryTocharians", "Person_Id", "dbo.People");
            DropForeignKey("dbo.NumberDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.NumberDictionaryTocharians", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.DictionaryTocharians", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.GenderDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.GenderDictionaryTocharians", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.CaseDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.CaseDictionaryTocharians", "Case_Id", "dbo.Cases");
            DropForeignKey("dbo.DictionaryTocharianBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.DictionaryTocharianBibliographies", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.Activities", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.AboutProjects", "LanguageId", "dbo.Languages");
            DropIndex("dbo.PublicationCollaborations", new[] { "Collaboration_Id" });
            DropIndex("dbo.PublicationCollaborations", new[] { "Publication_Id" });
            DropIndex("dbo.TochStoryBibliographies", new[] { "Bibliography_Id" });
            DropIndex("dbo.TochStoryBibliographies", new[] { "TochStory_Id" });
            DropIndex("dbo.TochPhraseBibliographies", new[] { "Bibliography_Id" });
            DropIndex("dbo.TochPhraseBibliographies", new[] { "TochPhrase_Id" });
            DropIndex("dbo.ManuscriptBibliographies", new[] { "Bibliography_Id" });
            DropIndex("dbo.ManuscriptBibliographies", new[] { "Manuscript_Id" });
            DropIndex("dbo.PersonDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.PersonDictionaryTocharians", new[] { "Person_Id" });
            DropIndex("dbo.NumberDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.NumberDictionaryTocharians", new[] { "Number_Id" });
            DropIndex("dbo.GenderDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.GenderDictionaryTocharians", new[] { "Gender_Id" });
            DropIndex("dbo.CaseDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.CaseDictionaryTocharians", new[] { "Case_Id" });
            DropIndex("dbo.DictionaryTocharianBibliographies", new[] { "Bibliography_Id" });
            DropIndex("dbo.DictionaryTocharianBibliographies", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.LinkAndPresses", new[] { "LanguageId" });
            DropIndex("dbo.Topics", new[] { "LanguageId" });
            DropIndex("dbo.ImageNews", new[] { "NewsId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "NewsId" });
            DropIndex("dbo.News", new[] { "LanguageId" });
            DropIndex("dbo.News", new[] { "CollaboratorId" });
            DropIndex("dbo.News", new[] { "TopicId" });
            DropIndex("dbo.Collaborators", "IX_PersonneUnique");
            DropIndex("dbo.Collaborators", new[] { "UserId" });
            DropIndex("dbo.ImageCollaborations", new[] { "CollaborationId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Users", "UserNameIndex");
            DropIndex("dbo.Clients", "IX_PersonneUnique");
            DropIndex("dbo.Clients", new[] { "UserId" });
            DropIndex("dbo.TochStories", new[] { "LanguageId" });
            DropIndex("dbo.TochStories", new[] { "TochLanguageId" });
            DropIndex("dbo.TochPhrases", new[] { "LanguageId" });
            DropIndex("dbo.TochPhrases", new[] { "TochLanguageId" });
            DropIndex("dbo.ImageManuscripts", new[] { "ManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "LanguageId" });
            DropIndex("dbo.Manuscripts", new[] { "TochLanguageId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "LanguageId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "TochLanguageId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "WordSubClassId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "WordClassId" });
            DropIndex("dbo.Activities", new[] { "LanguageId" });
            DropIndex("dbo.AboutProjects", new[] { "LanguageId" });
            DropTable("dbo.PublicationCollaborations");
            DropTable("dbo.TochStoryBibliographies");
            DropTable("dbo.TochPhraseBibliographies");
            DropTable("dbo.ManuscriptBibliographies");
            DropTable("dbo.PersonDictionaryTocharians");
            DropTable("dbo.NumberDictionaryTocharians");
            DropTable("dbo.GenderDictionaryTocharians");
            DropTable("dbo.CaseDictionaryTocharians");
            DropTable("dbo.DictionaryTocharianBibliographies");
            DropTable("dbo.Roles");
            DropTable("dbo.LinkAndPresses");
            DropTable("dbo.ContactMessages");
            DropTable("dbo.Topics");
            DropTable("dbo.ImageNews");
            DropTable("dbo.Comments");
            DropTable("dbo.News");
            DropTable("dbo.Collaborators");
            DropTable("dbo.Publications");
            DropTable("dbo.ImageCollaborations");
            DropTable("dbo.Collaborations");
            DropTable("dbo.UserRoles");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Users");
            DropTable("dbo.Clients");
            DropTable("dbo.TochStories");
            DropTable("dbo.TochPhrases");
            DropTable("dbo.ImageManuscripts");
            DropTable("dbo.Manuscripts");
            DropTable("dbo.WordSubClasses");
            DropTable("dbo.WordClasses");
            DropTable("dbo.TochLanguages");
            DropTable("dbo.People");
            DropTable("dbo.Numbers");
            DropTable("dbo.Genders");
            DropTable("dbo.Cases");
            DropTable("dbo.DictionaryTocharians");
            DropTable("dbo.Bibliographies");
            DropTable("dbo.Activities");
            DropTable("dbo.Languages");
            DropTable("dbo.AboutProjects");
        }
    }
}
