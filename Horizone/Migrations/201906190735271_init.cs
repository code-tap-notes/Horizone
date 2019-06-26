namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbbreviationDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        Description = c.String(),
                        OtherAbbreviation = c.Boolean(nullable: false),
                        AbbreviationManuscript = c.Boolean(nullable: false),
                        AbbreviationsLanguage = c.Boolean(nullable: false),
                        GrammaticalAbbreviation = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.ImageProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        AboutProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AboutProjects", t => t.AboutProjectId, cascadeDelete: false)
                .Index(t => t.AboutProjectId);
            
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
                "dbo.Abreviations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        Description = c.String(),
                        Link = c.String(),
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
                        TopicId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .ForeignKey("dbo.Topics", t => t.TopicId, cascadeDelete: false)
                .Index(t => t.TopicId)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TopicEn = c.String(nullable: false, maxLength: 40),
                        TopicFr = c.String(nullable: false, maxLength: 40),
                        TopicZh = c.String(nullable: false, maxLength: 40),
                        Activity = c.Boolean(nullable: false),
                        News = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AlignmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AlignmentTypeEn = c.String(),
                        AlignmentTypeFr = c.String(),
                        AlignmentTypeZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AnalyseMacroscopics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatalogieId = c.Int(nullable: false),
                        Index = c.String(nullable: false),
                        MapId = c.Int(nullable: false),
                        EstimatedDateProduction = c.String(),
                        PlaceProduction = c.String(),
                        Title = c.String(),
                        GenderManuscriptId = c.Int(nullable: false),
                        StateId = c.Int(nullable: false),
                        TochLanguageId = c.Int(nullable: false),
                        FormatId = c.Int(nullable: false),
                        NumberOfHoles = c.Int(nullable: false),
                        Description = c.String(),
                        AverageThickness = c.String(),
                        Correction = c.Boolean(nullable: false),
                        SheetCondition = c.String(),
                        NeedForConservation = c.String(),
                        Observation = c.String(),
                        RestoreId = c.Int(nullable: false),
                        RulingId = c.Int(nullable: false),
                        NumberOfLine = c.Int(nullable: false),
                        ScriptId = c.Int(nullable: false),
                        PageFrame = c.String(),
                        PaperColorId = c.Int(nullable: false),
                        WritingToolId = c.Int(nullable: false),
                        SoftQuality = c.Boolean(nullable: false),
                        RattleQuality = c.Boolean(nullable: false),
                        Transparency = c.Boolean(nullable: false),
                        SurfaceAspect = c.String(),
                        RulingColorId = c.Int(nullable: false),
                        CoatingDecayingCondition = c.String(),
                        ClayOrSandParticules = c.Boolean(nullable: false),
                        SurfaceOnBothSides = c.Boolean(nullable: false),
                        FiberDistributionId = c.Int(nullable: false),
                        NumberLayer = c.String(),
                        SieveMarkId = c.Int(nullable: false),
                        FiberDirectionId = c.Int(nullable: false),
                        LaidLinesRegularityId = c.Int(nullable: false),
                        NumberChainLinePerCm = c.Int(nullable: false),
                        ChainLinesVisibilityId = c.Int(nullable: false),
                        SpaceBetweenLines = c.String(),
                        DryingId = c.Int(nullable: false),
                        PreparationPaperBeforeUsingId = c.Int(nullable: false),
                        ManufaturingDefectId = c.Int(nullable: false),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Catalogies", t => t.CatalogieId, cascadeDelete: false)
                .ForeignKey("dbo.ChainLinesVisibilities", t => t.ChainLinesVisibilityId, cascadeDelete: false)
                .ForeignKey("dbo.Dryings", t => t.DryingId, cascadeDelete: false)
                .ForeignKey("dbo.FiberDirections", t => t.FiberDirectionId, cascadeDelete: false)
                .ForeignKey("dbo.FiberDistributions", t => t.FiberDistributionId, cascadeDelete: false)
                .ForeignKey("dbo.Formats", t => t.FormatId, cascadeDelete: false)
                .ForeignKey("dbo.GenderManuscripts", t => t.GenderManuscriptId, cascadeDelete: false)
                .ForeignKey("dbo.LaidLinesRegularities", t => t.LaidLinesRegularityId, cascadeDelete: false)
                .ForeignKey("dbo.ManufaturingDefects", t => t.ManufaturingDefectId, cascadeDelete: false)
                .ForeignKey("dbo.Maps", t => t.MapId, cascadeDelete: false)
                .ForeignKey("dbo.PaperColors", t => t.PaperColorId, cascadeDelete: false)
                .ForeignKey("dbo.PreparationPaperBeforeUsings", t => t.PreparationPaperBeforeUsingId, cascadeDelete: false)
                .ForeignKey("dbo.Restores", t => t.RestoreId, cascadeDelete: false)
                .ForeignKey("dbo.Rulings", t => t.RulingId, cascadeDelete: false)
                .ForeignKey("dbo.RulingColors", t => t.RulingColorId, cascadeDelete: false)
                .ForeignKey("dbo.Scripts", t => t.ScriptId, cascadeDelete: false)
                .ForeignKey("dbo.SieveMarks", t => t.SieveMarkId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .ForeignKey("dbo.WritingTools", t => t.WritingToolId, cascadeDelete: false)
                .Index(t => t.CatalogieId)
                .Index(t => t.MapId)
                .Index(t => t.GenderManuscriptId)
                .Index(t => t.StateId)
                .Index(t => t.TochLanguageId)
                .Index(t => t.FormatId)
                .Index(t => t.RestoreId)
                .Index(t => t.RulingId)
                .Index(t => t.ScriptId)
                .Index(t => t.PaperColorId)
                .Index(t => t.WritingToolId)
                .Index(t => t.RulingColorId)
                .Index(t => t.FiberDistributionId)
                .Index(t => t.SieveMarkId)
                .Index(t => t.FiberDirectionId)
                .Index(t => t.LaidLinesRegularityId)
                .Index(t => t.ChainLinesVisibilityId)
                .Index(t => t.DryingId)
                .Index(t => t.PreparationPaperBeforeUsingId)
                .Index(t => t.ManufaturingDefectId);
            
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
                        Book = c.Boolean(nullable: false),
                        AnalyseMacroscopic_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnalyseMacroscopics", t => t.AnalyseMacroscopic_Id)
                .Index(t => t.AnalyseMacroscopic_Id);
            
            CreateTable(
                "dbo.DictionaryTocharians",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        German = c.String(),
                        Latin = c.String(),
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
                        NominateNeuterSingular = c.String(),
                        NominateNeuterDual = c.String(),
                        NominateNeuterPlural = c.String(),
                        ObliqueMasculineSingular = c.String(),
                        ObliqueMasculineDual = c.String(),
                        ObliqueMasculinePlural = c.String(),
                        ObliqueFeminineSingular = c.String(),
                        ObliqueFeminineDual = c.String(),
                        ObliqueFemininePlural = c.String(),
                        ObliqueNeuterSingular = c.String(),
                        ObliqueNeuterDual = c.String(),
                        ObliqueNeuterPlural = c.String(),
                        VocativeMasculineSingular = c.String(),
                        VocativeMasculineDual = c.String(),
                        VocativeMasculinePlural = c.String(),
                        VocativeFeminineSingular = c.String(),
                        VocativeFeminineDual = c.String(),
                        VocativeFemininePlural = c.String(),
                        VocativeNeuterSingular = c.String(),
                        VocativeNeuterDual = c.String(),
                        VocativeNeuterPlural = c.String(),
                        GenitiveMasculineSingular = c.String(),
                        GenitiveMasculineDual = c.String(),
                        GenitiveMasculinePlural = c.String(),
                        GenitiveFeminineSingular = c.String(),
                        GenitiveFeminineDual = c.String(),
                        GenitiveFemininePlural = c.String(),
                        GenitiveNeuterSingular = c.String(),
                        GenitiveNeuterDual = c.String(),
                        GenitiveNeuterPlural = c.String(),
                        LocativeMasculineSingular = c.String(),
                        LocativeMasculineDual = c.String(),
                        LocativeMasculinePlural = c.String(),
                        LocativeFeminineSingular = c.String(),
                        LocativeFeminineDual = c.String(),
                        LocativeFemininePlural = c.String(),
                        LocativeNeuterSingular = c.String(),
                        LocativeNeuterDual = c.String(),
                        LocativeNeuterPlural = c.String(),
                        AblativeMasculineSingular = c.String(),
                        AblativeMasculineDual = c.String(),
                        AblativeMasculinePlural = c.String(),
                        AblativeFeminineSingular = c.String(),
                        AblativeFeminineDual = c.String(),
                        AblativeFemininePlural = c.String(),
                        AblativeNeuterSingular = c.String(),
                        AblativeNeuterDual = c.String(),
                        AblativeNeuterPlural = c.String(),
                        AllativeMasculineSingular = c.String(),
                        AllativeMasculineDual = c.String(),
                        AllativeMasculinePlural = c.String(),
                        AllativeFeminineSingular = c.String(),
                        AllativeFeminineDual = c.String(),
                        AllativeFemininePlural = c.String(),
                        AllativeNeuterSingular = c.String(),
                        AllativeNeuterDual = c.String(),
                        AllativeNeuterPlural = c.String(),
                        PerlativeMasculineSingular = c.String(),
                        PerlativeMasculineDual = c.String(),
                        PerlativeMasculinePlural = c.String(),
                        PerlativeFeminineSingular = c.String(),
                        PerlativeFeminineDual = c.String(),
                        PerlativeFemininePlural = c.String(),
                        PerlativeNeuterSingular = c.String(),
                        PerlativeNeuterDual = c.String(),
                        PerlativeNeuterPlural = c.String(),
                        InstrumentalMasculineSingular = c.String(),
                        InstrumentalMasculineDual = c.String(),
                        InstrumentalMasculinePlural = c.String(),
                        InstrumentalFeminineSingular = c.String(),
                        InstrumentalFeminineDual = c.String(),
                        InstrumentalFemininePlural = c.String(),
                        InstrumentalNeuterSingular = c.String(),
                        InstrumentalNeuterDual = c.String(),
                        InstrumentalNeuterPlural = c.String(),
                        ComitativeMasculineSingular = c.String(),
                        ComitativeMasculineDual = c.String(),
                        ComitativeMasculinePlural = c.String(),
                        ComitativeFeminineSingular = c.String(),
                        ComitativeFeminineDual = c.String(),
                        ComitativeFemininePlural = c.String(),
                        ComitativeNeuterSingular = c.String(),
                        ComitativeNeuterDual = c.String(),
                        ComitativeNeuterPlural = c.String(),
                        CausativeMasculineSingular = c.String(),
                        CausativeMasculineDual = c.String(),
                        CausativeMasculinePlural = c.String(),
                        CausativeFeminineSingular = c.String(),
                        CausativeFeminineDual = c.String(),
                        CausativeFemininePlural = c.String(),
                        CausativeNeuterSingular = c.String(),
                        CausativeNeuterDual = c.String(),
                        CausativeNeuterPlural = c.String(),
                        Stem = c.String(),
                        StemClass = c.String(),
                        VoiceId = c.Int(nullable: false),
                        ValencyId = c.Int(nullable: false),
                        TenseAndAspectId = c.Int(nullable: false),
                        MoodId = c.Int(nullable: false),
                        PronounSuffix = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moods", t => t.MoodId, cascadeDelete: false)
                .ForeignKey("dbo.TenseAndAspects", t => t.TenseAndAspectId, cascadeDelete: false)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .ForeignKey("dbo.Valencies", t => t.ValencyId, cascadeDelete: false)
                .ForeignKey("dbo.Voices", t => t.VoiceId, cascadeDelete: false)
                .ForeignKey("dbo.WordClasses", t => t.WordClassId, cascadeDelete: false)
                .ForeignKey("dbo.WordSubClasses", t => t.WordSubClassId, cascadeDelete: false)
                .Index(t => t.WordClassId)
                .Index(t => t.WordSubClassId)
                .Index(t => t.TochLanguageId)
                .Index(t => t.VoiceId)
                .Index(t => t.ValencyId)
                .Index(t => t.TenseAndAspectId)
                .Index(t => t.MoodId);
            
            CreateTable(
                "dbo.Cases",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameCase = c.String(),
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
                        NameGender = c.String(),
                        NameGenderEn = c.String(),
                        NameGenderFr = c.String(),
                        NameGenderZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Moods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbbreviationsMood = c.String(),
                        MoodEn = c.String(),
                        MoodFr = c.String(),
                        MoodZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Numbers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WordNumber = c.String(),
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
                        ConjugatedPerson = c.String(),
                        ConjugatedPersonEn = c.String(),
                        ConjugatedPersonFr = c.String(),
                        ConjugatedPersonZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TenseAndAspects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tense = c.String(),
                        TenseEn = c.String(),
                        TenseFr = c.String(),
                        TenseZh = c.String(),
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
                "dbo.Valencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbbreviationValency = c.String(),
                        ValencyEn = c.String(),
                        ValencyFr = c.String(),
                        ValencyZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbbreviationVoice = c.String(),
                        VoiceEn = c.String(),
                        VoiceFr = c.String(),
                        VoiceZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WordClasses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Class = c.String(),
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
                        SubClass = c.String(),
                        SubClassEn = c.String(nullable: false),
                        SubClassFr = c.String(),
                        SubClassZh = c.String(),
                        WordClassId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.WordClasses", t => t.WordClassId, cascadeDelete: false)
                .Index(t => t.WordClassId);
            
            CreateTable(
                "dbo.ImageBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        BibliographyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bibliographies", t => t.BibliographyId, cascadeDelete: false)
                .Index(t => t.BibliographyId);
            
            CreateTable(
                "dbo.Manuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CatalogieId = c.Int(nullable: false),
                        Index = c.String(nullable: false),
                        Collection = c.String(),
                        Siglum = c.String(),
                        Joint = c.String(),
                        OtherSiglum = c.String(),
                        ExpeditionCode = c.String(),
                        MapId = c.Int(nullable: false),
                        SpecificFindSpot = c.String(),
                        StateId = c.Int(nullable: false),
                        DescriptionManuscriptId = c.Int(nullable: false),
                        RemarkAddId = c.Int(nullable: false),
                        LeafNumber = c.String(),
                        SizeHeight = c.String(),
                        Completeness = c.String(),
                        SizeWidth = c.String(),
                        NumberOfLine = c.Int(nullable: false),
                        LineDistance = c.String(),
                        FormatId = c.Int(nullable: false),
                        RulingId = c.Int(nullable: false),
                        RulingColorId = c.Int(nullable: false),
                        RulingDetailId = c.Int(nullable: false),
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
                        MaterialId = c.Int(nullable: false),
                        PaperColorId = c.Int(nullable: false),
                        PaperThickness = c.String(),
                        WritingToolId = c.Int(nullable: false),
                        AlignmentTypeId = c.Int(nullable: false),
                        ModuleWidth = c.String(),
                        ModuleHeight = c.String(),
                        AvCharPerLigne = c.String(),
                        NibThickness = c.String(),
                        ScriptId = c.Int(nullable: false),
                        ScriptAddId = c.Int(nullable: false),
                        TochLanguageId = c.Int(nullable: false),
                        LanguageStageId = c.Int(nullable: false),
                        LanguageDetailId = c.Int(nullable: false),
                        GenderManuscriptId = c.Int(nullable: false),
                        SubGenderManuscriptId = c.Int(nullable: false),
                        Title = c.String(),
                        Passage = c.String(),
                        Parallel = c.String(),
                        MetricId = c.Int(nullable: false),
                        Tune = c.String(),
                        Cetom = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AlignmentTypes", t => t.AlignmentTypeId, cascadeDelete: false)
                .ForeignKey("dbo.Catalogies", t => t.CatalogieId, cascadeDelete: false)
                .ForeignKey("dbo.DescriptionManuscripts", t => t.DescriptionManuscriptId, cascadeDelete: false)
                .ForeignKey("dbo.Formats", t => t.FormatId, cascadeDelete: false)
                .ForeignKey("dbo.GenderManuscripts", t => t.GenderManuscriptId, cascadeDelete: false)
                .ForeignKey("dbo.LanguageDetails", t => t.LanguageDetailId, cascadeDelete: false)
                .ForeignKey("dbo.LanguageStages", t => t.LanguageStageId, cascadeDelete: false)
                .ForeignKey("dbo.Maps", t => t.MapId, cascadeDelete: false)
                .ForeignKey("dbo.Materials", t => t.MaterialId, cascadeDelete: false)
                .ForeignKey("dbo.Metrics", t => t.MetricId, cascadeDelete: false)
                .ForeignKey("dbo.PaperColors", t => t.PaperColorId, cascadeDelete: false)
                .ForeignKey("dbo.RemarkAdds", t => t.RemarkAddId, cascadeDelete: false)
                .ForeignKey("dbo.Rulings", t => t.RulingId, cascadeDelete: false)
                .ForeignKey("dbo.RulingColors", t => t.RulingColorId, cascadeDelete: false)
                .ForeignKey("dbo.RulingDetails", t => t.RulingDetailId, cascadeDelete: false)
                .ForeignKey("dbo.Scripts", t => t.ScriptId, cascadeDelete: false)
                .ForeignKey("dbo.ScriptAdds", t => t.ScriptAddId, cascadeDelete: false)
                .ForeignKey("dbo.States", t => t.StateId, cascadeDelete: false)
                .ForeignKey("dbo.SubGenderManuscripts", t => t.SubGenderManuscriptId, cascadeDelete: false)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .ForeignKey("dbo.WritingTools", t => t.WritingToolId, cascadeDelete: false)
                .Index(t => t.CatalogieId)
                .Index(t => t.MapId)
                .Index(t => t.StateId)
                .Index(t => t.DescriptionManuscriptId)
                .Index(t => t.RemarkAddId)
                .Index(t => t.FormatId)
                .Index(t => t.RulingId)
                .Index(t => t.RulingColorId)
                .Index(t => t.RulingDetailId)
                .Index(t => t.MaterialId)
                .Index(t => t.PaperColorId)
                .Index(t => t.WritingToolId)
                .Index(t => t.AlignmentTypeId)
                .Index(t => t.ScriptId)
                .Index(t => t.ScriptAddId)
                .Index(t => t.TochLanguageId)
                .Index(t => t.LanguageStageId)
                .Index(t => t.LanguageDetailId)
                .Index(t => t.GenderManuscriptId)
                .Index(t => t.SubGenderManuscriptId)
                .Index(t => t.MetricId);
            
            CreateTable(
                "dbo.Catalogies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DescriptionManuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DescriptionEn = c.String(),
                        DescriptionFr = c.String(),
                        DescriptionZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Formats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FormatEn = c.String(),
                        FormatFr = c.String(),
                        FormatZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GenderManuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameGenderEn = c.String(),
                        NameGenderFr = c.String(),
                        NameGenderZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                "dbo.LanguageDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageDetailEn = c.String(),
                        LanguageDetailFr = c.String(),
                        LanguageDetailZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LanguageStages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LanguageStageEn = c.String(),
                        LanguageStageFr = c.String(),
                        LanguageStageZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamePicture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        MapId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.MapId, cascadeDelete: false)
                .Index(t => t.MapId);
            
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaterialEn = c.String(),
                        MaterialFr = c.String(),
                        MaterialZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Metrics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MetricEn = c.String(),
                        MetricFr = c.String(),
                        MetricZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PaperColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaperColorEn = c.String(),
                        PaperColorFr = c.String(),
                        PaperColorZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RemarkAdds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RemarkEn = c.String(),
                        RemarkFr = c.String(),
                        RemarkZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rulings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RulingEn = c.String(),
                        RulingFr = c.String(),
                        RulingZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RulingColors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RulingColorEn = c.String(),
                        RulingColorFr = c.String(),
                        RulingColorZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RulingDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RulingDetailEn = c.String(),
                        RulingDetailFr = c.String(),
                        RulingDetailZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Scripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScriptEn = c.String(),
                        ScriptFr = c.String(),
                        ScriptZh = c.String(),
                        ScriptTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ScriptTypes", t => t.ScriptTypeId, cascadeDelete: false)
                .Index(t => t.ScriptTypeId);
            
            CreateTable(
                "dbo.ScriptTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ScriptAdds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ScriptAddEn = c.String(),
                        ScriptAddFr = c.String(),
                        ScriptAddZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StateEn = c.String(),
                        StateFr = c.String(),
                        StateZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubGenderManuscripts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubGenderEn = c.String(),
                        NameGenderFr = c.String(),
                        NameGenderZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.WritingTools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        WritingToolEn = c.String(),
                        WritingToolFr = c.String(),
                        WritingToolZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .Index(t => t.TochLanguageId);
            
            CreateTable(
                "dbo.TochStories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        SourceStoryId = c.Int(nullable: false),
                        ThemeStoryId = c.Int(nullable: false),
                        PlasticRepresentation = c.String(),
                        MainFindSpot = c.String(),
                        Content = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        Chinese = c.String(),
                        Description = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SourceStories", t => t.SourceStoryId, cascadeDelete: false)
                .ForeignKey("dbo.ThemeStories", t => t.ThemeStoryId, cascadeDelete: false)
                .Index(t => t.SourceStoryId)
                .Index(t => t.ThemeStoryId);
            
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
                        Name = c.String(),
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
            
            CreateTable(
                "dbo.ChainLinesVisibilities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ChainLinesVisibilityEn = c.String(),
                        ChainLinesVisibilityFr = c.String(),
                        ChainLinesVisibilityZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Dryings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DryingEn = c.String(),
                        DryingFr = c.String(),
                        DryingZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FiberDirections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DirectionEn = c.String(),
                        DirectionFr = c.String(),
                        DirectionZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FiberDistributions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DistributionEn = c.String(),
                        DistributionFr = c.String(),
                        DistributionZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LaidLinesRegularities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LaidLinesRegularityEn = c.String(),
                        LaidLinesRegularityFr = c.String(),
                        LaidLinesRegularityZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ManufaturingDefects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ManufaturingDefectEn = c.String(),
                        ManufaturingDefectFr = c.String(),
                        ManufaturingDefectZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PreparationPaperBeforeUsings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PreparationEn = c.String(),
                        PreparationFr = c.String(),
                        PreparationZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Restores",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RestoreEn = c.String(),
                        RestoreFr = c.String(),
                        RestoreZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SieveMarks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SieveMarkEn = c.String(),
                        SieveMarkFr = c.String(),
                        SieveMarkZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TransmittedLights",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        AnalyseMacroscopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnalyseMacroscopics", t => t.AnalyseMacroscopicId, cascadeDelete: false)
                .Index(t => t.AnalyseMacroscopicId);
            
            CreateTable(
                "dbo.AnalyseMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.String(nullable: false),
                        Description = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageAnalyses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        AnalyseMaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnalyseMaterials", t => t.AnalyseMaterialId, cascadeDelete: false)
                .Index(t => t.AnalyseMaterialId);
            
            CreateTable(
                "dbo.ImageUVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        AnalyseMaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnalyseMaterials", t => t.AnalyseMaterialId, cascadeDelete: false)
                .Index(t => t.AnalyseMaterialId);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 20),
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
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
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
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: false)
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
                        Title = c.String(maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 30),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        FonctionEn = c.String(),
                        FonctionFr = c.String(),
                        FonctionZh = c.String(),
                        AffiliationFr = c.String(),
                        AffiliationEn = c.String(),
                        AffiliationZh = c.String(),
                        CV = c.String(),
                        Email = c.String(),
                        Team = c.Boolean(nullable: false),
                        AssociatedResearcher = c.Boolean(nullable: false),
                        Collaborator = c.Boolean(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
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
                        PublicationIndividual = c.Boolean(nullable: false),
                        PublicationProjet = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Collaborators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        Title = c.String(maxLength: 20),
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
                "dbo.ImagePartners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        PartnerAndRelationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PartnerAndRelations", t => t.PartnerAndRelationId, cascadeDelete: false)
                .Index(t => t.PartnerAndRelationId);
            
            CreateTable(
                "dbo.PartnerAndRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Link = c.String(),
                        Partner = c.Boolean(nullable: false),
                        Relation = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        Visible = c.Boolean(nullable: false),
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
                        Press = c.Boolean(nullable: false),
                        Status = c.Byte(nullable: false),
                        Target = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.Presentations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AboutUs = c.String(),
                        TochPhrase = c.String(),
                        TochStory = c.String(),
                        Manuscript = c.String(),
                        Activity = c.String(),
                        Bibliography = c.String(),
                        DictionaryTocharian = c.String(),
                        VisualAids = c.String(),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .Index(t => t.LanguageId);
            
            CreateTable(
                "dbo.ReverseDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(),
                        ReverseWord = c.String(),
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
                "dbo.VisualAids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aids = c.String(nullable: false),
                        Description = c.String(),
                        Photography = c.Boolean(nullable: false),
                        Map = c.Boolean(nullable: false),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Languages", t => t.LanguageId, cascadeDelete: false)
                .Index(t => t.LanguageId);
            
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
                .ForeignKey("dbo.Cases", t => t.Case_Id, cascadeDelete: false)
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
                .ForeignKey("dbo.Numbers", t => t.Number_Id, cascadeDelete: false)
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
            DropForeignKey("dbo.VisualAids", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Presentations", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.LinkAndPresses", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ImagePartners", "PartnerAndRelationId", "dbo.PartnerAndRelations");
            DropForeignKey("dbo.News", "TopicId", "dbo.Topics");
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
            DropForeignKey("dbo.ImageUVs", "AnalyseMaterialId", "dbo.AnalyseMaterials");
            DropForeignKey("dbo.ImageAnalyses", "AnalyseMaterialId", "dbo.AnalyseMaterials");
            DropForeignKey("dbo.AnalyseMacroscopics", "WritingToolId", "dbo.WritingTools");
            DropForeignKey("dbo.TransmittedLights", "AnalyseMacroscopicId", "dbo.AnalyseMacroscopics");
            DropForeignKey("dbo.AnalyseMacroscopics", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.AnalyseMacroscopics", "StateId", "dbo.States");
            DropForeignKey("dbo.AnalyseMacroscopics", "SieveMarkId", "dbo.SieveMarks");
            DropForeignKey("dbo.AnalyseMacroscopics", "ScriptId", "dbo.Scripts");
            DropForeignKey("dbo.AnalyseMacroscopics", "RulingColorId", "dbo.RulingColors");
            DropForeignKey("dbo.AnalyseMacroscopics", "RulingId", "dbo.Rulings");
            DropForeignKey("dbo.AnalyseMacroscopics", "RestoreId", "dbo.Restores");
            DropForeignKey("dbo.AnalyseMacroscopics", "PreparationPaperBeforeUsingId", "dbo.PreparationPaperBeforeUsings");
            DropForeignKey("dbo.AnalyseMacroscopics", "PaperColorId", "dbo.PaperColors");
            DropForeignKey("dbo.AnalyseMacroscopics", "MapId", "dbo.Maps");
            DropForeignKey("dbo.AnalyseMacroscopics", "ManufaturingDefectId", "dbo.ManufaturingDefects");
            DropForeignKey("dbo.AnalyseMacroscopics", "LaidLinesRegularityId", "dbo.LaidLinesRegularities");
            DropForeignKey("dbo.AnalyseMacroscopics", "GenderManuscriptId", "dbo.GenderManuscripts");
            DropForeignKey("dbo.AnalyseMacroscopics", "FormatId", "dbo.Formats");
            DropForeignKey("dbo.AnalyseMacroscopics", "FiberDistributionId", "dbo.FiberDistributions");
            DropForeignKey("dbo.AnalyseMacroscopics", "FiberDirectionId", "dbo.FiberDirections");
            DropForeignKey("dbo.AnalyseMacroscopics", "DryingId", "dbo.Dryings");
            DropForeignKey("dbo.AnalyseMacroscopics", "ChainLinesVisibilityId", "dbo.ChainLinesVisibilities");
            DropForeignKey("dbo.AnalyseMacroscopics", "CatalogieId", "dbo.Catalogies");
            DropForeignKey("dbo.Bibliographies", "AnalyseMacroscopic_Id", "dbo.AnalyseMacroscopics");
            DropForeignKey("dbo.TochStories", "ThemeStoryId", "dbo.ThemeStories");
            DropForeignKey("dbo.TochStories", "SourceStoryId", "dbo.SourceStories");
            DropForeignKey("dbo.ProperNounTochStories", "TochStory_Id", "dbo.TochStories");
            DropForeignKey("dbo.ProperNounTochStories", "ProperNoun_Id", "dbo.ProperNouns");
            DropForeignKey("dbo.NamePlaceTochStories", "TochStory_Id", "dbo.TochStories");
            DropForeignKey("dbo.NamePlaceTochStories", "NamePlace_Id", "dbo.NamePlaces");
            DropForeignKey("dbo.TochStoryBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.TochStoryBibliographies", "TochStory_Id", "dbo.TochStories");
            DropForeignKey("dbo.TochPhrases", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.TochPhraseBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.TochPhraseBibliographies", "TochPhrase_Id", "dbo.TochPhrases");
            DropForeignKey("dbo.Manuscripts", "WritingToolId", "dbo.WritingTools");
            DropForeignKey("dbo.Manuscripts", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.Manuscripts", "SubGenderManuscriptId", "dbo.SubGenderManuscripts");
            DropForeignKey("dbo.Manuscripts", "StateId", "dbo.States");
            DropForeignKey("dbo.Manuscripts", "ScriptAddId", "dbo.ScriptAdds");
            DropForeignKey("dbo.Manuscripts", "ScriptId", "dbo.Scripts");
            DropForeignKey("dbo.Scripts", "ScriptTypeId", "dbo.ScriptTypes");
            DropForeignKey("dbo.Manuscripts", "RulingDetailId", "dbo.RulingDetails");
            DropForeignKey("dbo.Manuscripts", "RulingColorId", "dbo.RulingColors");
            DropForeignKey("dbo.Manuscripts", "RulingId", "dbo.Rulings");
            DropForeignKey("dbo.Manuscripts", "RemarkAddId", "dbo.RemarkAdds");
            DropForeignKey("dbo.Manuscripts", "PaperColorId", "dbo.PaperColors");
            DropForeignKey("dbo.Manuscripts", "MetricId", "dbo.Metrics");
            DropForeignKey("dbo.Manuscripts", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps");
            DropForeignKey("dbo.ImageMaps", "MapId", "dbo.Maps");
            DropForeignKey("dbo.Manuscripts", "LanguageStageId", "dbo.LanguageStages");
            DropForeignKey("dbo.Manuscripts", "LanguageDetailId", "dbo.LanguageDetails");
            DropForeignKey("dbo.ImageManuscripts", "ManuscriptId", "dbo.Manuscripts");
            DropForeignKey("dbo.Manuscripts", "GenderManuscriptId", "dbo.GenderManuscripts");
            DropForeignKey("dbo.Manuscripts", "FormatId", "dbo.Formats");
            DropForeignKey("dbo.Manuscripts", "DescriptionManuscriptId", "dbo.DescriptionManuscripts");
            DropForeignKey("dbo.Manuscripts", "CatalogieId", "dbo.Catalogies");
            DropForeignKey("dbo.ManuscriptBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.ManuscriptBibliographies", "Manuscript_Id", "dbo.Manuscripts");
            DropForeignKey("dbo.Manuscripts", "AlignmentTypeId", "dbo.AlignmentTypes");
            DropForeignKey("dbo.ImageBooks", "BibliographyId", "dbo.Bibliographies");
            DropForeignKey("dbo.DictionaryTocharians", "WordSubClassId", "dbo.WordSubClasses");
            DropForeignKey("dbo.WordSubClasses", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.DictionaryTocharians", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.DictionaryTocharians", "VoiceId", "dbo.Voices");
            DropForeignKey("dbo.DictionaryTocharians", "ValencyId", "dbo.Valencies");
            DropForeignKey("dbo.DictionaryTocharians", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.DictionaryTocharians", "TenseAndAspectId", "dbo.TenseAndAspects");
            DropForeignKey("dbo.PersonDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.PersonDictionaryTocharians", "Person_Id", "dbo.People");
            DropForeignKey("dbo.NumberDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.NumberDictionaryTocharians", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.DictionaryTocharians", "MoodId", "dbo.Moods");
            DropForeignKey("dbo.GenderDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.GenderDictionaryTocharians", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.CaseDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.CaseDictionaryTocharians", "Case_Id", "dbo.Cases");
            DropForeignKey("dbo.DictionaryTocharianBibliographies", "Bibliography_Id", "dbo.Bibliographies");
            DropForeignKey("dbo.DictionaryTocharianBibliographies", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.Activities", "TopicId", "dbo.Topics");
            DropForeignKey("dbo.Activities", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.AboutProjects", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.ImageProjects", "AboutProjectId", "dbo.AboutProjects");
            DropIndex("dbo.PublicationCollaborations", new[] { "Collaboration_Id" });
            DropIndex("dbo.PublicationCollaborations", new[] { "Publication_Id" });
            DropIndex("dbo.ProperNounTochStories", new[] { "TochStory_Id" });
            DropIndex("dbo.ProperNounTochStories", new[] { "ProperNoun_Id" });
            DropIndex("dbo.NamePlaceTochStories", new[] { "TochStory_Id" });
            DropIndex("dbo.NamePlaceTochStories", new[] { "NamePlace_Id" });
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
            DropIndex("dbo.VisualAids", new[] { "LanguageId" });
            DropIndex("dbo.Roles", "RoleNameIndex");
            DropIndex("dbo.Presentations", new[] { "LanguageId" });
            DropIndex("dbo.LinkAndPresses", new[] { "LanguageId" });
            DropIndex("dbo.ImagePartners", new[] { "PartnerAndRelationId" });
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
            DropIndex("dbo.ImageUVs", new[] { "AnalyseMaterialId" });
            DropIndex("dbo.ImageAnalyses", new[] { "AnalyseMaterialId" });
            DropIndex("dbo.TransmittedLights", new[] { "AnalyseMacroscopicId" });
            DropIndex("dbo.TochStories", new[] { "ThemeStoryId" });
            DropIndex("dbo.TochStories", new[] { "SourceStoryId" });
            DropIndex("dbo.TochPhrases", new[] { "TochLanguageId" });
            DropIndex("dbo.Scripts", new[] { "ScriptTypeId" });
            DropIndex("dbo.ImageMaps", new[] { "MapId" });
            DropIndex("dbo.ImageManuscripts", new[] { "ManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "MetricId" });
            DropIndex("dbo.Manuscripts", new[] { "SubGenderManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "GenderManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "LanguageDetailId" });
            DropIndex("dbo.Manuscripts", new[] { "LanguageStageId" });
            DropIndex("dbo.Manuscripts", new[] { "TochLanguageId" });
            DropIndex("dbo.Manuscripts", new[] { "ScriptAddId" });
            DropIndex("dbo.Manuscripts", new[] { "ScriptId" });
            DropIndex("dbo.Manuscripts", new[] { "AlignmentTypeId" });
            DropIndex("dbo.Manuscripts", new[] { "WritingToolId" });
            DropIndex("dbo.Manuscripts", new[] { "PaperColorId" });
            DropIndex("dbo.Manuscripts", new[] { "MaterialId" });
            DropIndex("dbo.Manuscripts", new[] { "RulingDetailId" });
            DropIndex("dbo.Manuscripts", new[] { "RulingColorId" });
            DropIndex("dbo.Manuscripts", new[] { "RulingId" });
            DropIndex("dbo.Manuscripts", new[] { "FormatId" });
            DropIndex("dbo.Manuscripts", new[] { "RemarkAddId" });
            DropIndex("dbo.Manuscripts", new[] { "DescriptionManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "StateId" });
            DropIndex("dbo.Manuscripts", new[] { "MapId" });
            DropIndex("dbo.Manuscripts", new[] { "CatalogieId" });
            DropIndex("dbo.ImageBooks", new[] { "BibliographyId" });
            DropIndex("dbo.WordSubClasses", new[] { "WordClassId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "MoodId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "TenseAndAspectId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "ValencyId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "VoiceId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "TochLanguageId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "WordSubClassId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "WordClassId" });
            DropIndex("dbo.Bibliographies", new[] { "AnalyseMacroscopic_Id" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "ManufaturingDefectId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "PreparationPaperBeforeUsingId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "DryingId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "ChainLinesVisibilityId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "LaidLinesRegularityId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "FiberDirectionId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "SieveMarkId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "FiberDistributionId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "RulingColorId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "WritingToolId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "PaperColorId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "ScriptId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "RulingId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "RestoreId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "FormatId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "TochLanguageId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "StateId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "GenderManuscriptId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "MapId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "CatalogieId" });
            DropIndex("dbo.Activities", new[] { "LanguageId" });
            DropIndex("dbo.Activities", new[] { "TopicId" });
            DropIndex("dbo.ImageProjects", new[] { "AboutProjectId" });
            DropIndex("dbo.AboutProjects", new[] { "LanguageId" });
            DropTable("dbo.PublicationCollaborations");
            DropTable("dbo.ProperNounTochStories");
            DropTable("dbo.NamePlaceTochStories");
            DropTable("dbo.TochStoryBibliographies");
            DropTable("dbo.TochPhraseBibliographies");
            DropTable("dbo.ManuscriptBibliographies");
            DropTable("dbo.PersonDictionaryTocharians");
            DropTable("dbo.NumberDictionaryTocharians");
            DropTable("dbo.GenderDictionaryTocharians");
            DropTable("dbo.CaseDictionaryTocharians");
            DropTable("dbo.DictionaryTocharianBibliographies");
            DropTable("dbo.VisualAids");
            DropTable("dbo.Roles");
            DropTable("dbo.ReverseDictionaries");
            DropTable("dbo.Presentations");
            DropTable("dbo.LinkAndPresses");
            DropTable("dbo.PartnerAndRelations");
            DropTable("dbo.ImagePartners");
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
            DropTable("dbo.ImageUVs");
            DropTable("dbo.ImageAnalyses");
            DropTable("dbo.AnalyseMaterials");
            DropTable("dbo.TransmittedLights");
            DropTable("dbo.SieveMarks");
            DropTable("dbo.Restores");
            DropTable("dbo.PreparationPaperBeforeUsings");
            DropTable("dbo.ManufaturingDefects");
            DropTable("dbo.LaidLinesRegularities");
            DropTable("dbo.FiberDistributions");
            DropTable("dbo.FiberDirections");
            DropTable("dbo.Dryings");
            DropTable("dbo.ChainLinesVisibilities");
            DropTable("dbo.ThemeStories");
            DropTable("dbo.SourceStories");
            DropTable("dbo.ProperNouns");
            DropTable("dbo.NamePlaces");
            DropTable("dbo.TochStories");
            DropTable("dbo.TochPhrases");
            DropTable("dbo.WritingTools");
            DropTable("dbo.SubGenderManuscripts");
            DropTable("dbo.States");
            DropTable("dbo.ScriptAdds");
            DropTable("dbo.ScriptTypes");
            DropTable("dbo.Scripts");
            DropTable("dbo.RulingDetails");
            DropTable("dbo.RulingColors");
            DropTable("dbo.Rulings");
            DropTable("dbo.RemarkAdds");
            DropTable("dbo.PaperColors");
            DropTable("dbo.Metrics");
            DropTable("dbo.Materials");
            DropTable("dbo.ImageMaps");
            DropTable("dbo.Maps");
            DropTable("dbo.LanguageStages");
            DropTable("dbo.LanguageDetails");
            DropTable("dbo.ImageManuscripts");
            DropTable("dbo.GenderManuscripts");
            DropTable("dbo.Formats");
            DropTable("dbo.DescriptionManuscripts");
            DropTable("dbo.Catalogies");
            DropTable("dbo.Manuscripts");
            DropTable("dbo.ImageBooks");
            DropTable("dbo.WordSubClasses");
            DropTable("dbo.WordClasses");
            DropTable("dbo.Voices");
            DropTable("dbo.Valencies");
            DropTable("dbo.TochLanguages");
            DropTable("dbo.TenseAndAspects");
            DropTable("dbo.People");
            DropTable("dbo.Numbers");
            DropTable("dbo.Moods");
            DropTable("dbo.Genders");
            DropTable("dbo.Cases");
            DropTable("dbo.DictionaryTocharians");
            DropTable("dbo.Bibliographies");
            DropTable("dbo.AnalyseMacroscopics");
            DropTable("dbo.AlignmentTypes");
            DropTable("dbo.Topics");
            DropTable("dbo.Activities");
            DropTable("dbo.Abreviations");
            DropTable("dbo.Languages");
            DropTable("dbo.ImageProjects");
            DropTable("dbo.AboutProjects");
            DropTable("dbo.AbbreviationDictionaries");
        }
    }
}
