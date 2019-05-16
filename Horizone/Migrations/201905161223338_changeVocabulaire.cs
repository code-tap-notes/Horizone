namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeVocabulaire : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DictionaryTocharians", "LanguageId", "dbo.Languages");
            DropIndex("dbo.DictionaryTocharians", new[] { "LanguageId" });
            DropColumn("dbo.DictionaryTocharians", "LanguageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DictionaryTocharians", "LanguageId", c => c.Int(nullable: false));
            CreateIndex("dbo.DictionaryTocharians", "LanguageId");
            AddForeignKey("dbo.DictionaryTocharians", "LanguageId", "dbo.Languages", "Id", cascadeDelete: false);
        }
    }
}
