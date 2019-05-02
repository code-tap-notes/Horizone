namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnalyseMacroscopic : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Catalogies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
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
                        RestoreEn = c.String(),
                        RestoreFr = c.String(),
                        RestoreZh = c.String(),
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
            
            AddColumn("dbo.Bibliographies", "AnalyseMacroscopic_Id", c => c.Int());
            AddColumn("dbo.Manuscripts", "CatalogieId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "MapId", c => c.Int(nullable: false));
            CreateIndex("dbo.Bibliographies", "AnalyseMacroscopic_Id");
            CreateIndex("dbo.Manuscripts", "CatalogieId");
            CreateIndex("dbo.Manuscripts", "MapId");
            AddForeignKey("dbo.Manuscripts", "CatalogieId", "dbo.Catalogies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Bibliographies", "AnalyseMacroscopic_Id", "dbo.AnalyseMacroscopics", "Id");
            DropColumn("dbo.Manuscripts", "MainFindSpot");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Manuscripts", "MainFindSpot", c => c.String());
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
            DropForeignKey("dbo.AnalyseMacroscopics", "FormatId", "dbo.Formats");
            DropForeignKey("dbo.AnalyseMacroscopics", "FiberDistributionId", "dbo.FiberDistributions");
            DropForeignKey("dbo.AnalyseMacroscopics", "FiberDirectionId", "dbo.FiberDirections");
            DropForeignKey("dbo.AnalyseMacroscopics", "DryingId", "dbo.Dryings");
            DropForeignKey("dbo.AnalyseMacroscopics", "ChainLinesVisibilityId", "dbo.ChainLinesVisibilities");
            DropForeignKey("dbo.AnalyseMacroscopics", "CatalogieId", "dbo.Catalogies");
            DropForeignKey("dbo.Bibliographies", "AnalyseMacroscopic_Id", "dbo.AnalyseMacroscopics");
            DropForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps");
            DropForeignKey("dbo.Manuscripts", "CatalogieId", "dbo.Catalogies");
            DropIndex("dbo.TransmittedLights", new[] { "AnalyseMacroscopicId" });
            DropIndex("dbo.Manuscripts", new[] { "MapId" });
            DropIndex("dbo.Manuscripts", new[] { "CatalogieId" });
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
            DropIndex("dbo.AnalyseMacroscopics", new[] { "MapId" });
            DropIndex("dbo.AnalyseMacroscopics", new[] { "CatalogieId" });
            DropColumn("dbo.Manuscripts", "MapId");
            DropColumn("dbo.Manuscripts", "CatalogieId");
            DropColumn("dbo.Bibliographies", "AnalyseMacroscopic_Id");
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
            DropTable("dbo.Catalogies");
            DropTable("dbo.AnalyseMacroscopics");
        }
    }
}
