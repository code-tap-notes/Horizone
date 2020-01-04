namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeVerbNounAdj : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bibliographies", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.Bibliographies", "Verb_Id", "dbo.Verbs");
            DropForeignKey("dbo.VerbNumbers", "Verb_Id", "dbo.Verbs");
            DropForeignKey("dbo.VerbNumbers", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.Verbs", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.Verbs", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.Verbs", "WordSubClassId", "dbo.WordSubClasses");
            DropForeignKey("dbo.NounAdjectiveNumbers", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.NounAdjectiveNumbers", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.NounAdjectives", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.NounAdjectives", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.NounAdjectives", "WordSubClassId", "dbo.WordSubClasses");
            DropIndex("dbo.Bibliographies", new[] { "NounAdjective_Id" });
            DropIndex("dbo.Bibliographies", new[] { "Verb_Id" });
            DropIndex("dbo.NounAdjectives", new[] { "TochLanguageId" });
            DropIndex("dbo.NounAdjectives", new[] { "WordClassId" });
            DropIndex("dbo.NounAdjectives", new[] { "WordSubClassId" });
            DropIndex("dbo.Verbs", new[] { "TochLanguageId" });
            DropIndex("dbo.Verbs", new[] { "WordClassId" });
            DropIndex("dbo.Verbs", new[] { "WordSubClassId" });
            DropIndex("dbo.VerbNumbers", new[] { "Verb_Id" });
            DropIndex("dbo.VerbNumbers", new[] { "Number_Id" });
            DropIndex("dbo.NounAdjectiveNumbers", new[] { "NounAdjective_Id" });
            DropIndex("dbo.NounAdjectiveNumbers", new[] { "Number_Id" });
            AddColumn("dbo.NounAdjectives", "DictionaryId", c => c.Int(nullable: false));
            AddColumn("dbo.NounAdjectives", "Number_Id", c => c.Int());
            AddColumn("dbo.Verbs", "DictionaryId", c => c.Int(nullable: false));
            AddColumn("dbo.Verbs", "Number_Id", c => c.Int());
            CreateIndex("dbo.NounAdjectives", "DictionaryId");
            CreateIndex("dbo.NounAdjectives", "Number_Id");
            CreateIndex("dbo.Verbs", "DictionaryId");
            CreateIndex("dbo.Verbs", "Number_Id");
            AddForeignKey("dbo.Verbs", "DictionaryId", "dbo.DictionaryTocharians", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NounAdjectives", "DictionaryId", "dbo.DictionaryTocharians", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NounAdjectives", "Number_Id", "dbo.Numbers", "Id");
            AddForeignKey("dbo.Verbs", "Number_Id", "dbo.Numbers", "Id");
            DropColumn("dbo.Bibliographies", "NounAdjective_Id");
            DropColumn("dbo.Bibliographies", "Verb_Id");
            DropColumn("dbo.NounAdjectives", "TochWord");
            DropColumn("dbo.NounAdjectives", "Sanskrit");
            DropColumn("dbo.NounAdjectives", "English");
            DropColumn("dbo.NounAdjectives", "Francaise");
            DropColumn("dbo.NounAdjectives", "German");
            DropColumn("dbo.NounAdjectives", "Latin");
            DropColumn("dbo.NounAdjectives", "Chinese");
            DropColumn("dbo.NounAdjectives", "TochLanguageId");
            DropColumn("dbo.NounAdjectives", "WordClassId");
            DropColumn("dbo.NounAdjectives", "WordSubClassId");
            DropColumn("dbo.NounAdjectives", "EquivalentTA");
            DropColumn("dbo.NounAdjectives", "EquivalentTB");
            DropColumn("dbo.NounAdjectives", "TochCommon");
            DropColumn("dbo.NounAdjectives", "TochCorrespondence");
            DropColumn("dbo.NounAdjectives", "EquivalentInOther");
            DropColumn("dbo.NounAdjectives", "DerivedFrom");
            DropColumn("dbo.NounAdjectives", "RelatedLexemes");
            DropColumn("dbo.NounAdjectives", "RootCharacter");
            DropColumn("dbo.NounAdjectives", "InternalRootVowel");
            DropColumn("dbo.NounAdjectives", "Stem");
            DropColumn("dbo.NounAdjectives", "StemClass");
            DropColumn("dbo.NounAdjectives", "Visible");
            DropColumn("dbo.Verbs", "TochWord");
            DropColumn("dbo.Verbs", "Sanskrit");
            DropColumn("dbo.Verbs", "English");
            DropColumn("dbo.Verbs", "Francaise");
            DropColumn("dbo.Verbs", "German");
            DropColumn("dbo.Verbs", "Latin");
            DropColumn("dbo.Verbs", "Chinese");
            DropColumn("dbo.Verbs", "TochLanguageId");
            DropColumn("dbo.Verbs", "WordClassId");
            DropColumn("dbo.Verbs", "WordSubClassId");
            DropColumn("dbo.Verbs", "EquivalentTA");
            DropColumn("dbo.Verbs", "EquivalentTB");
            DropColumn("dbo.Verbs", "TochCommon");
            DropColumn("dbo.Verbs", "TochCorrespondence");
            DropColumn("dbo.Verbs", "EquivalentInOther");
            DropColumn("dbo.Verbs", "DerivedFrom");
            DropColumn("dbo.Verbs", "RelatedLexemes");
            DropColumn("dbo.Verbs", "RootCharacter");
            DropColumn("dbo.Verbs", "InternalRootVowel");
            DropColumn("dbo.Verbs", "Stem");
            DropColumn("dbo.Verbs", "StemClass");
            DropColumn("dbo.Verbs", "Visible");
            DropTable("dbo.VerbNumbers");
            DropTable("dbo.NounAdjectiveNumbers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.NounAdjectiveNumbers",
                c => new
                    {
                        NounAdjective_Id = c.Int(nullable: false),
                        Number_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NounAdjective_Id, t.Number_Id });
            
            CreateTable(
                "dbo.VerbNumbers",
                c => new
                    {
                        Verb_Id = c.Int(nullable: false),
                        Number_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Verb_Id, t.Number_Id });
            
            AddColumn("dbo.Verbs", "Visible", c => c.Boolean(nullable: false));
            AddColumn("dbo.Verbs", "StemClass", c => c.String());
            AddColumn("dbo.Verbs", "Stem", c => c.String());
            AddColumn("dbo.Verbs", "InternalRootVowel", c => c.String());
            AddColumn("dbo.Verbs", "RootCharacter", c => c.String());
            AddColumn("dbo.Verbs", "RelatedLexemes", c => c.String());
            AddColumn("dbo.Verbs", "DerivedFrom", c => c.String());
            AddColumn("dbo.Verbs", "EquivalentInOther", c => c.String());
            AddColumn("dbo.Verbs", "TochCorrespondence", c => c.String());
            AddColumn("dbo.Verbs", "TochCommon", c => c.String());
            AddColumn("dbo.Verbs", "EquivalentTB", c => c.String());
            AddColumn("dbo.Verbs", "EquivalentTA", c => c.String());
            AddColumn("dbo.Verbs", "WordSubClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Verbs", "WordClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Verbs", "TochLanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.Verbs", "Chinese", c => c.String());
            AddColumn("dbo.Verbs", "Latin", c => c.String());
            AddColumn("dbo.Verbs", "German", c => c.String());
            AddColumn("dbo.Verbs", "Francaise", c => c.String());
            AddColumn("dbo.Verbs", "English", c => c.String());
            AddColumn("dbo.Verbs", "Sanskrit", c => c.String());
            AddColumn("dbo.Verbs", "TochWord", c => c.String(nullable: false));
            AddColumn("dbo.NounAdjectives", "Visible", c => c.Boolean(nullable: false));
            AddColumn("dbo.NounAdjectives", "StemClass", c => c.String());
            AddColumn("dbo.NounAdjectives", "Stem", c => c.String());
            AddColumn("dbo.NounAdjectives", "InternalRootVowel", c => c.String());
            AddColumn("dbo.NounAdjectives", "RootCharacter", c => c.String());
            AddColumn("dbo.NounAdjectives", "RelatedLexemes", c => c.String());
            AddColumn("dbo.NounAdjectives", "DerivedFrom", c => c.String());
            AddColumn("dbo.NounAdjectives", "EquivalentInOther", c => c.String());
            AddColumn("dbo.NounAdjectives", "TochCorrespondence", c => c.String());
            AddColumn("dbo.NounAdjectives", "TochCommon", c => c.String());
            AddColumn("dbo.NounAdjectives", "EquivalentTB", c => c.String());
            AddColumn("dbo.NounAdjectives", "EquivalentTA", c => c.String());
            AddColumn("dbo.NounAdjectives", "WordSubClassId", c => c.Int(nullable: false));
            AddColumn("dbo.NounAdjectives", "WordClassId", c => c.Int(nullable: false));
            AddColumn("dbo.NounAdjectives", "TochLanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.NounAdjectives", "Chinese", c => c.String());
            AddColumn("dbo.NounAdjectives", "Latin", c => c.String());
            AddColumn("dbo.NounAdjectives", "German", c => c.String());
            AddColumn("dbo.NounAdjectives", "Francaise", c => c.String());
            AddColumn("dbo.NounAdjectives", "English", c => c.String());
            AddColumn("dbo.NounAdjectives", "Sanskrit", c => c.String());
            AddColumn("dbo.NounAdjectives", "TochWord", c => c.String(nullable: false));
            AddColumn("dbo.Bibliographies", "Verb_Id", c => c.Int());
            AddColumn("dbo.Bibliographies", "NounAdjective_Id", c => c.Int());
            DropForeignKey("dbo.Verbs", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.NounAdjectives", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.NounAdjectives", "DictionaryId", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.Verbs", "DictionaryId", "dbo.DictionaryTocharians");
            DropIndex("dbo.Verbs", new[] { "Number_Id" });
            DropIndex("dbo.Verbs", new[] { "DictionaryId" });
            DropIndex("dbo.NounAdjectives", new[] { "Number_Id" });
            DropIndex("dbo.NounAdjectives", new[] { "DictionaryId" });
            DropColumn("dbo.Verbs", "Number_Id");
            DropColumn("dbo.Verbs", "DictionaryId");
            DropColumn("dbo.NounAdjectives", "Number_Id");
            DropColumn("dbo.NounAdjectives", "DictionaryId");
            CreateIndex("dbo.NounAdjectiveNumbers", "Number_Id");
            CreateIndex("dbo.NounAdjectiveNumbers", "NounAdjective_Id");
            CreateIndex("dbo.VerbNumbers", "Number_Id");
            CreateIndex("dbo.VerbNumbers", "Verb_Id");
            CreateIndex("dbo.Verbs", "WordSubClassId");
            CreateIndex("dbo.Verbs", "WordClassId");
            CreateIndex("dbo.Verbs", "TochLanguageId");
            CreateIndex("dbo.NounAdjectives", "WordSubClassId");
            CreateIndex("dbo.NounAdjectives", "WordClassId");
            CreateIndex("dbo.NounAdjectives", "TochLanguageId");
            CreateIndex("dbo.Bibliographies", "Verb_Id");
            CreateIndex("dbo.Bibliographies", "NounAdjective_Id");
            AddForeignKey("dbo.NounAdjectives", "WordSubClassId", "dbo.WordSubClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NounAdjectives", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NounAdjectives", "TochLanguageId", "dbo.TochLanguages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NounAdjectiveNumbers", "Number_Id", "dbo.Numbers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NounAdjectiveNumbers", "NounAdjective_Id", "dbo.NounAdjectives", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Verbs", "WordSubClassId", "dbo.WordSubClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Verbs", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Verbs", "TochLanguageId", "dbo.TochLanguages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.VerbNumbers", "Number_Id", "dbo.Numbers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.VerbNumbers", "Verb_Id", "dbo.Verbs", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Bibliographies", "Verb_Id", "dbo.Verbs", "Id");
            AddForeignKey("dbo.Bibliographies", "NounAdjective_Id", "dbo.NounAdjectives", "Id");
        }
    }
}
