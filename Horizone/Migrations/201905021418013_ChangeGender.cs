namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeGender : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnalyseMacroscopics", "GenderId", "dbo.Genders");
            DropIndex("dbo.AnalyseMacroscopics", new[] { "GenderId" });
            AddColumn("dbo.AnalyseMacroscopics", "GenderManuscriptId", c => c.Int(nullable: false));
            AddColumn("dbo.LaidLinesRegularities", "LaidLinesRegularityEn", c => c.String());
            AddColumn("dbo.LaidLinesRegularities", "LaidLinesRegularityFr", c => c.String());
            AddColumn("dbo.LaidLinesRegularities", "LaidLinesRegularityZh", c => c.String());
            CreateIndex("dbo.AnalyseMacroscopics", "GenderManuscriptId");
            AddForeignKey("dbo.AnalyseMacroscopics", "GenderManuscriptId", "dbo.GenderManuscripts", "Id", cascadeDelete: false);
            DropColumn("dbo.AnalyseMacroscopics", "GenderId");
            DropColumn("dbo.LaidLinesRegularities", "RestoreEn");
            DropColumn("dbo.LaidLinesRegularities", "RestoreFr");
            DropColumn("dbo.LaidLinesRegularities", "RestoreZh");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LaidLinesRegularities", "RestoreZh", c => c.String());
            AddColumn("dbo.LaidLinesRegularities", "RestoreFr", c => c.String());
            AddColumn("dbo.LaidLinesRegularities", "RestoreEn", c => c.String());
            AddColumn("dbo.AnalyseMacroscopics", "GenderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.AnalyseMacroscopics", "GenderManuscriptId", "dbo.GenderManuscripts");
            DropIndex("dbo.AnalyseMacroscopics", new[] { "GenderManuscriptId" });
            DropColumn("dbo.LaidLinesRegularities", "LaidLinesRegularityZh");
            DropColumn("dbo.LaidLinesRegularities", "LaidLinesRegularityFr");
            DropColumn("dbo.LaidLinesRegularities", "LaidLinesRegularityEn");
            DropColumn("dbo.AnalyseMacroscopics", "GenderManuscriptId");
            CreateIndex("dbo.AnalyseMacroscopics", "GenderId");
            AddForeignKey("dbo.AnalyseMacroscopics", "GenderId", "dbo.Genders", "Id", cascadeDelete: false);
        }
    }
}
