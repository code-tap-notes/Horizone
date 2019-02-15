namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changerequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ScriptManuscripts", "AlignmentType", c => c.String(maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "ModuleWidth", c => c.String(maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "ModuleHeight", c => c.String(maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "AvCharPerLigne", c => c.String(maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "NibThickness", c => c.String(maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "Script", c => c.String(maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "ScriptAdd", c => c.String(maxLength: 200));
            AlterColumn("dbo.TextLanguages", "LanguageStage", c => c.String(maxLength: 40));
            AlterColumn("dbo.TextLanguages", "LanguageDetails", c => c.String(maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TextLanguages", "LanguageDetails", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.TextLanguages", "LanguageStage", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.ScriptManuscripts", "ScriptAdd", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "Script", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "NibThickness", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "AvCharPerLigne", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "ModuleHeight", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "ModuleWidth", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.ScriptManuscripts", "AlignmentType", c => c.String(nullable: false, maxLength: 200));
        }
    }
}
