namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeManuscript : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Manuscripts", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Manuscripts", new[] { "LanguageId" });
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
                        Name = c.String(),
                        UlrMap = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
            AddColumn("dbo.Manuscripts", "MapId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "StateId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "DescriptionManuscriptId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "RemarkAddId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "FormatId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "RulingId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "RulingColorId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "RulingDetailId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "MaterialId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "PaperColorId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "WritingToolId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "AlignmentTypeId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "ScriptId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "ScriptAddId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "LanguageStageId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "LanguageDetailId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "GenderManuscriptId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "SubGenderManuscriptId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "MetricId", c => c.Int(nullable: false));
            AddColumn("dbo.ProperNouns", "Name", c => c.String());
            CreateIndex("dbo.Manuscripts", "MapId");
            CreateIndex("dbo.Manuscripts", "StateId");
            CreateIndex("dbo.Manuscripts", "DescriptionManuscriptId");
            CreateIndex("dbo.Manuscripts", "RemarkAddId");
            CreateIndex("dbo.Manuscripts", "FormatId");
            CreateIndex("dbo.Manuscripts", "RulingId");
            CreateIndex("dbo.Manuscripts", "RulingColorId");
            CreateIndex("dbo.Manuscripts", "RulingDetailId");
            CreateIndex("dbo.Manuscripts", "MaterialId");
            CreateIndex("dbo.Manuscripts", "PaperColorId");
            CreateIndex("dbo.Manuscripts", "WritingToolId");
            CreateIndex("dbo.Manuscripts", "AlignmentTypeId");
            CreateIndex("dbo.Manuscripts", "ScriptId");
            CreateIndex("dbo.Manuscripts", "ScriptAddId");
            CreateIndex("dbo.Manuscripts", "LanguageStageId");
            CreateIndex("dbo.Manuscripts", "LanguageDetailId");
            CreateIndex("dbo.Manuscripts", "GenderManuscriptId");
            CreateIndex("dbo.Manuscripts", "SubGenderManuscriptId");
            CreateIndex("dbo.Manuscripts", "MetricId");
            AddForeignKey("dbo.Manuscripts", "AlignmentTypeId", "dbo.AlignmentTypes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "DescriptionManuscriptId", "dbo.DescriptionManuscripts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "FormatId", "dbo.Formats", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "GenderManuscriptId", "dbo.GenderManuscripts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "LanguageDetailId", "dbo.LanguageDetails", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "LanguageStageId", "dbo.LanguageStages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "MaterialId", "dbo.Materials", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "MetricId", "dbo.Metrics", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "PaperColorId", "dbo.PaperColors", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "RemarkAddId", "dbo.RemarkAdds", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "RulingId", "dbo.Rulings", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "RulingColorId", "dbo.RulingColors", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "RulingDetailId", "dbo.RulingDetails", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "ScriptId", "dbo.Scripts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "ScriptAddId", "dbo.ScriptAdds", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "StateId", "dbo.States", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "SubGenderManuscriptId", "dbo.SubGenderManuscripts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "WritingToolId", "dbo.WritingTools", "Id", cascadeDelete: false);
            DropColumn("dbo.Manuscripts", "MainFindSpot");
            DropColumn("dbo.Manuscripts", "GeneralState");
            DropColumn("dbo.Manuscripts", "Description");
            DropColumn("dbo.Manuscripts", "Remark");
            DropColumn("dbo.Manuscripts", "Format");
            DropColumn("dbo.Manuscripts", "Ruling");
            DropColumn("dbo.Manuscripts", "RulingColor");
            DropColumn("dbo.Manuscripts", "RulingDetail");
            DropColumn("dbo.Manuscripts", "Material");
            DropColumn("dbo.Manuscripts", "PaperColor");
            DropColumn("dbo.Manuscripts", "WritingTool");
            DropColumn("dbo.Manuscripts", "AlignmentType");
            DropColumn("dbo.Manuscripts", "Script");
            DropColumn("dbo.Manuscripts", "ScriptAdd");
            DropColumn("dbo.Manuscripts", "LanguageStage");
            DropColumn("dbo.Manuscripts", "LanguageDetails");
            DropColumn("dbo.Manuscripts", "TextGenre");
            DropColumn("dbo.Manuscripts", "TextSubGenre");
            DropColumn("dbo.Manuscripts", "MetricForm");
            DropColumn("dbo.Manuscripts", "LanguageId");
            DropColumn("dbo.ProperNouns", "Source");
            DropTable("dbo.ContactMessages");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.ProperNouns", "Source", c => c.String());
            AddColumn("dbo.Manuscripts", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "MetricForm", c => c.String());
            AddColumn("dbo.Manuscripts", "TextSubGenre", c => c.String());
            AddColumn("dbo.Manuscripts", "TextGenre", c => c.String());
            AddColumn("dbo.Manuscripts", "LanguageDetails", c => c.String(maxLength: 40));
            AddColumn("dbo.Manuscripts", "LanguageStage", c => c.String(maxLength: 40));
            AddColumn("dbo.Manuscripts", "ScriptAdd", c => c.String());
            AddColumn("dbo.Manuscripts", "Script", c => c.String());
            AddColumn("dbo.Manuscripts", "AlignmentType", c => c.String());
            AddColumn("dbo.Manuscripts", "WritingTool", c => c.String());
            AddColumn("dbo.Manuscripts", "PaperColor", c => c.String());
            AddColumn("dbo.Manuscripts", "Material", c => c.String());
            AddColumn("dbo.Manuscripts", "RulingDetail", c => c.String());
            AddColumn("dbo.Manuscripts", "RulingColor", c => c.String());
            AddColumn("dbo.Manuscripts", "Ruling", c => c.String());
            AddColumn("dbo.Manuscripts", "Format", c => c.String());
            AddColumn("dbo.Manuscripts", "Remark", c => c.String());
            AddColumn("dbo.Manuscripts", "Description", c => c.String());
            AddColumn("dbo.Manuscripts", "GeneralState", c => c.String());
            AddColumn("dbo.Manuscripts", "MainFindSpot", c => c.String());
            DropForeignKey("dbo.Manuscripts", "WritingToolId", "dbo.WritingTools");
            DropForeignKey("dbo.Manuscripts", "SubGenderManuscriptId", "dbo.SubGenderManuscripts");
            DropForeignKey("dbo.Manuscripts", "StateId", "dbo.States");
            DropForeignKey("dbo.Manuscripts", "ScriptAddId", "dbo.ScriptAdds");
            DropForeignKey("dbo.Manuscripts", "ScriptId", "dbo.Scripts");
            DropForeignKey("dbo.Manuscripts", "RulingDetailId", "dbo.RulingDetails");
            DropForeignKey("dbo.Manuscripts", "RulingColorId", "dbo.RulingColors");
            DropForeignKey("dbo.Manuscripts", "RulingId", "dbo.Rulings");
            DropForeignKey("dbo.Manuscripts", "RemarkAddId", "dbo.RemarkAdds");
            DropForeignKey("dbo.Manuscripts", "PaperColorId", "dbo.PaperColors");
            DropForeignKey("dbo.Manuscripts", "MetricId", "dbo.Metrics");
            DropForeignKey("dbo.Manuscripts", "MaterialId", "dbo.Materials");
            DropForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps");
            DropForeignKey("dbo.Manuscripts", "LanguageStageId", "dbo.LanguageStages");
            DropForeignKey("dbo.Manuscripts", "LanguageDetailId", "dbo.LanguageDetails");
            DropForeignKey("dbo.Manuscripts", "GenderManuscriptId", "dbo.GenderManuscripts");
            DropForeignKey("dbo.Manuscripts", "FormatId", "dbo.Formats");
            DropForeignKey("dbo.Manuscripts", "DescriptionManuscriptId", "dbo.DescriptionManuscripts");
            DropForeignKey("dbo.Manuscripts", "AlignmentTypeId", "dbo.AlignmentTypes");
            DropIndex("dbo.Manuscripts", new[] { "MetricId" });
            DropIndex("dbo.Manuscripts", new[] { "SubGenderManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "GenderManuscriptId" });
            DropIndex("dbo.Manuscripts", new[] { "LanguageDetailId" });
            DropIndex("dbo.Manuscripts", new[] { "LanguageStageId" });
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
            DropColumn("dbo.ProperNouns", "Name");
            DropColumn("dbo.Manuscripts", "MetricId");
            DropColumn("dbo.Manuscripts", "SubGenderManuscriptId");
            DropColumn("dbo.Manuscripts", "GenderManuscriptId");
            DropColumn("dbo.Manuscripts", "LanguageDetailId");
            DropColumn("dbo.Manuscripts", "LanguageStageId");
            DropColumn("dbo.Manuscripts", "ScriptAddId");
            DropColumn("dbo.Manuscripts", "ScriptId");
            DropColumn("dbo.Manuscripts", "AlignmentTypeId");
            DropColumn("dbo.Manuscripts", "WritingToolId");
            DropColumn("dbo.Manuscripts", "PaperColorId");
            DropColumn("dbo.Manuscripts", "MaterialId");
            DropColumn("dbo.Manuscripts", "RulingDetailId");
            DropColumn("dbo.Manuscripts", "RulingColorId");
            DropColumn("dbo.Manuscripts", "RulingId");
            DropColumn("dbo.Manuscripts", "FormatId");
            DropColumn("dbo.Manuscripts", "RemarkAddId");
            DropColumn("dbo.Manuscripts", "DescriptionManuscriptId");
            DropColumn("dbo.Manuscripts", "StateId");
            DropColumn("dbo.Manuscripts", "MapId");
            DropTable("dbo.WritingTools");
            DropTable("dbo.SubGenderManuscripts");
            DropTable("dbo.States");
            DropTable("dbo.ScriptAdds");
            DropTable("dbo.Scripts");
            DropTable("dbo.RulingDetails");
            DropTable("dbo.RulingColors");
            DropTable("dbo.Rulings");
            DropTable("dbo.RemarkAdds");
            DropTable("dbo.PaperColors");
            DropTable("dbo.Metrics");
            DropTable("dbo.Materials");
            DropTable("dbo.Maps");
            DropTable("dbo.LanguageStages");
            DropTable("dbo.LanguageDetails");
            DropTable("dbo.GenderManuscripts");
            DropTable("dbo.Formats");
            DropTable("dbo.DescriptionManuscripts");
            DropTable("dbo.AlignmentTypes");
            CreateIndex("dbo.Manuscripts", "LanguageId");
            AddForeignKey("dbo.Manuscripts", "LanguageId", "dbo.Languages", "Id", cascadeDelete: false);
        }
    }
}
