namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePronoun : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bibliographies", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.PronounNumbers", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.PronounNumbers", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.Pronouns", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.Pronouns", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.Pronouns", "WordSubClassId", "dbo.WordSubClasses");
            DropIndex("dbo.Bibliographies", new[] { "Pronoun_Id" });
            DropIndex("dbo.Pronouns", new[] { "TochLanguageId" });
            DropIndex("dbo.Pronouns", new[] { "WordClassId" });
            DropIndex("dbo.Pronouns", new[] { "WordSubClassId" });
            DropIndex("dbo.PronounNumbers", new[] { "Pronoun_Id" });
            DropIndex("dbo.PronounNumbers", new[] { "Number_Id" });
            AddColumn("dbo.Pronouns", "DictionaryId", c => c.Int(nullable: false));
            AddColumn("dbo.Pronouns", "Number_Id", c => c.Int());
            CreateIndex("dbo.Pronouns", "DictionaryId");
            CreateIndex("dbo.Pronouns", "Number_Id");
            AddForeignKey("dbo.Pronouns", "DictionaryId", "dbo.DictionaryTocharians", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Pronouns", "Number_Id", "dbo.Numbers", "Id");
            DropColumn("dbo.Bibliographies", "Pronoun_Id");
            DropColumn("dbo.Pronouns", "TochWord");
            DropColumn("dbo.Pronouns", "Sanskrit");
            DropColumn("dbo.Pronouns", "English");
            DropColumn("dbo.Pronouns", "Francaise");
            DropColumn("dbo.Pronouns", "German");
            DropColumn("dbo.Pronouns", "Latin");
            DropColumn("dbo.Pronouns", "Chinese");
            DropColumn("dbo.Pronouns", "TochLanguageId");
            DropColumn("dbo.Pronouns", "WordClassId");
            DropColumn("dbo.Pronouns", "WordSubClassId");
            DropColumn("dbo.Pronouns", "EquivalentTA");
            DropColumn("dbo.Pronouns", "EquivalentTB");
            DropColumn("dbo.Pronouns", "TochCommon");
            DropColumn("dbo.Pronouns", "TochCorrespondence");
            DropColumn("dbo.Pronouns", "EquivalentInOther");
            DropColumn("dbo.Pronouns", "DerivedFrom");
            DropColumn("dbo.Pronouns", "RelatedLexemes");
            DropColumn("dbo.Pronouns", "RootCharacter");
            DropColumn("dbo.Pronouns", "InternalRootVowel");
            DropColumn("dbo.Pronouns", "Stem");
            DropColumn("dbo.Pronouns", "StemClass");
            DropColumn("dbo.Pronouns", "Visible");
            DropTable("dbo.PronounNumbers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PronounNumbers",
                c => new
                    {
                        Pronoun_Id = c.Int(nullable: false),
                        Number_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pronoun_Id, t.Number_Id });
            
            AddColumn("dbo.Pronouns", "Visible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Pronouns", "StemClass", c => c.String());
            AddColumn("dbo.Pronouns", "Stem", c => c.String());
            AddColumn("dbo.Pronouns", "InternalRootVowel", c => c.String());
            AddColumn("dbo.Pronouns", "RootCharacter", c => c.String());
            AddColumn("dbo.Pronouns", "RelatedLexemes", c => c.String());
            AddColumn("dbo.Pronouns", "DerivedFrom", c => c.String());
            AddColumn("dbo.Pronouns", "EquivalentInOther", c => c.String());
            AddColumn("dbo.Pronouns", "TochCorrespondence", c => c.String());
            AddColumn("dbo.Pronouns", "TochCommon", c => c.String());
            AddColumn("dbo.Pronouns", "EquivalentTB", c => c.String());
            AddColumn("dbo.Pronouns", "EquivalentTA", c => c.String());
            AddColumn("dbo.Pronouns", "WordSubClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Pronouns", "WordClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Pronouns", "TochLanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.Pronouns", "Chinese", c => c.String());
            AddColumn("dbo.Pronouns", "Latin", c => c.String());
            AddColumn("dbo.Pronouns", "German", c => c.String());
            AddColumn("dbo.Pronouns", "Francaise", c => c.String());
            AddColumn("dbo.Pronouns", "English", c => c.String());
            AddColumn("dbo.Pronouns", "Sanskrit", c => c.String());
            AddColumn("dbo.Pronouns", "TochWord", c => c.String(nullable: false));
            AddColumn("dbo.Bibliographies", "Pronoun_Id", c => c.Int());
            DropForeignKey("dbo.Pronouns", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.Pronouns", "DictionaryId", "dbo.DictionaryTocharians");
            DropIndex("dbo.Pronouns", new[] { "Number_Id" });
            DropIndex("dbo.Pronouns", new[] { "DictionaryId" });
            DropColumn("dbo.Pronouns", "Number_Id");
            DropColumn("dbo.Pronouns", "DictionaryId");
            CreateIndex("dbo.PronounNumbers", "Number_Id");
            CreateIndex("dbo.PronounNumbers", "Pronoun_Id");
            CreateIndex("dbo.Pronouns", "WordSubClassId");
            CreateIndex("dbo.Pronouns", "WordClassId");
            CreateIndex("dbo.Pronouns", "TochLanguageId");
            CreateIndex("dbo.Bibliographies", "Pronoun_Id");
            AddForeignKey("dbo.Pronouns", "WordSubClassId", "dbo.WordSubClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Pronouns", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Pronouns", "TochLanguageId", "dbo.TochLanguages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PronounNumbers", "Number_Id", "dbo.Numbers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PronounNumbers", "Pronoun_Id", "dbo.Pronouns", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Bibliographies", "Pronoun_Id", "dbo.Pronouns", "Id");
        }
    }
}
