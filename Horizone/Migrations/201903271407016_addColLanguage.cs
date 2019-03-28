namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColLanguage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Publications", "PublicationIndividual", c => c.Boolean(nullable: false));
            AddColumn("dbo.Publications", "PublicationProjet", c => c.Boolean(nullable: false));
            AddColumn("dbo.Presentations", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.VisualAids", "LanguageId", c => c.Int(nullable: false));
            CreateIndex("dbo.Presentations", "LanguageId");
            CreateIndex("dbo.VisualAids", "LanguageId");
            AddForeignKey("dbo.Presentations", "LanguageId", "dbo.Languages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.VisualAids", "LanguageId", "dbo.Languages", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VisualAids", "LanguageId", "dbo.Languages");
            DropForeignKey("dbo.Presentations", "LanguageId", "dbo.Languages");
            DropIndex("dbo.VisualAids", new[] { "LanguageId" });
            DropIndex("dbo.Presentations", new[] { "LanguageId" });
            DropColumn("dbo.VisualAids", "LanguageId");
            DropColumn("dbo.Presentations", "LanguageId");
            DropColumn("dbo.Publications", "PublicationProjet");
            DropColumn("dbo.Publications", "PublicationIndividual");
        }
    }
}
