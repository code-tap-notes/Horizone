namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOtherWord : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NounAdjectiveCases", newName: "CaseNounAdjectives");
            RenameTable(name: "dbo.NumberNounAdjectives", newName: "NounAdjectiveNumbers");
            RenameTable(name: "dbo.PronounGenders", newName: "GenderPronouns");
            RenameTable(name: "dbo.NumberPronouns", newName: "PronounNumbers");
            RenameTable(name: "dbo.PersonVerbs", newName: "VerbPersons");
            DropForeignKey("dbo.DictionaryTocharians", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.Bibliographies", "OtherWord_Id", "dbo.OtherWords");
            DropForeignKey("dbo.OtherWordNumbers", "OtherWord_Id", "dbo.OtherWords");
            DropForeignKey("dbo.OtherWordNumbers", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.OtherWords", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.OtherWords", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.OtherWords", "WordSubClassId", "dbo.WordSubClasses");
            DropIndex("dbo.Bibliographies", new[] { "OtherWord_Id" });
            DropIndex("dbo.DictionaryTocharians", new[] { "Number_Id" });
            DropIndex("dbo.OtherWords", new[] { "TochLanguageId" });
            DropIndex("dbo.OtherWords", new[] { "WordClassId" });
            DropIndex("dbo.OtherWords", new[] { "WordSubClassId" });
            DropIndex("dbo.OtherWordNumbers", new[] { "OtherWord_Id" });
            DropIndex("dbo.OtherWordNumbers", new[] { "Number_Id" });
            DropPrimaryKey("dbo.CaseNounAdjectives");
            DropPrimaryKey("dbo.NounAdjectiveNumbers");
            DropPrimaryKey("dbo.GenderPronouns");
            DropPrimaryKey("dbo.PronounNumbers");
            DropPrimaryKey("dbo.VerbPersons");
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
            
            AddColumn("dbo.DictionaryTocharians", "DerivedFrom", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "RelatedLexemes", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "RootCharacter", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "InternalRootVowel", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "Stem", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "StemClass", c => c.String());
            AddColumn("dbo.OtherWords", "DictionaryId", c => c.Int(nullable: false));
            AddColumn("dbo.OtherWords", "Number_Id", c => c.Int());
            AddPrimaryKey("dbo.CaseNounAdjectives", new[] { "Case_Id", "NounAdjective_Id" });
            AddPrimaryKey("dbo.NounAdjectiveNumbers", new[] { "NounAdjective_Id", "Number_Id" });
            AddPrimaryKey("dbo.GenderPronouns", new[] { "Gender_Id", "Pronoun_Id" });
            AddPrimaryKey("dbo.PronounNumbers", new[] { "Pronoun_Id", "Number_Id" });
            AddPrimaryKey("dbo.VerbPersons", new[] { "Verb_Id", "Person_Id" });
            CreateIndex("dbo.OtherWords", "DictionaryId");
            CreateIndex("dbo.OtherWords", "Number_Id");
            AddForeignKey("dbo.OtherWords", "DictionaryId", "dbo.DictionaryTocharians", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OtherWords", "Number_Id", "dbo.Numbers", "Id");
            DropColumn("dbo.Bibliographies", "OtherWord_Id");
            DropColumn("dbo.DictionaryTocharians", "IdClassSource");
            DropColumn("dbo.DictionaryTocharians", "Number_Id");
            DropColumn("dbo.OtherWords", "TochWord");
            DropColumn("dbo.OtherWords", "Sanskrit");
            DropColumn("dbo.OtherWords", "English");
            DropColumn("dbo.OtherWords", "Francaise");
            DropColumn("dbo.OtherWords", "German");
            DropColumn("dbo.OtherWords", "Latin");
            DropColumn("dbo.OtherWords", "Chinese");
            DropColumn("dbo.OtherWords", "TochLanguageId");
            DropColumn("dbo.OtherWords", "WordClassId");
            DropColumn("dbo.OtherWords", "WordSubClassId");
            DropColumn("dbo.OtherWords", "EquivalentTA");
            DropColumn("dbo.OtherWords", "EquivalentTB");
            DropColumn("dbo.OtherWords", "TochCommon");
            DropColumn("dbo.OtherWords", "TochCorrespondence");
            DropColumn("dbo.OtherWords", "EquivalentInOther");
            DropColumn("dbo.OtherWords", "DerivedFrom");
            DropColumn("dbo.OtherWords", "RelatedLexemes");
            DropColumn("dbo.OtherWords", "RootCharacter");
            DropColumn("dbo.OtherWords", "InternalRootVowel");
            DropColumn("dbo.OtherWords", "Stem");
            DropColumn("dbo.OtherWords", "StemClass");
            DropColumn("dbo.OtherWords", "Visible");
            DropTable("dbo.OtherWordNumbers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OtherWordNumbers",
                c => new
                    {
                        OtherWord_Id = c.Int(nullable: false),
                        Number_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OtherWord_Id, t.Number_Id });
            
            AddColumn("dbo.OtherWords", "Visible", c => c.Boolean(nullable: false));
            AddColumn("dbo.OtherWords", "StemClass", c => c.String());
            AddColumn("dbo.OtherWords", "Stem", c => c.String());
            AddColumn("dbo.OtherWords", "InternalRootVowel", c => c.String());
            AddColumn("dbo.OtherWords", "RootCharacter", c => c.String());
            AddColumn("dbo.OtherWords", "RelatedLexemes", c => c.String());
            AddColumn("dbo.OtherWords", "DerivedFrom", c => c.String());
            AddColumn("dbo.OtherWords", "EquivalentInOther", c => c.String());
            AddColumn("dbo.OtherWords", "TochCorrespondence", c => c.String());
            AddColumn("dbo.OtherWords", "TochCommon", c => c.String());
            AddColumn("dbo.OtherWords", "EquivalentTB", c => c.String());
            AddColumn("dbo.OtherWords", "EquivalentTA", c => c.String());
            AddColumn("dbo.OtherWords", "WordSubClassId", c => c.Int(nullable: false));
            AddColumn("dbo.OtherWords", "WordClassId", c => c.Int(nullable: false));
            AddColumn("dbo.OtherWords", "TochLanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.OtherWords", "Chinese", c => c.String());
            AddColumn("dbo.OtherWords", "Latin", c => c.String());
            AddColumn("dbo.OtherWords", "German", c => c.String());
            AddColumn("dbo.OtherWords", "Francaise", c => c.String());
            AddColumn("dbo.OtherWords", "English", c => c.String());
            AddColumn("dbo.OtherWords", "Sanskrit", c => c.String());
            AddColumn("dbo.OtherWords", "TochWord", c => c.String(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "Number_Id", c => c.Int());
            AddColumn("dbo.DictionaryTocharians", "IdClassSource", c => c.Int(nullable: false));
            AddColumn("dbo.Bibliographies", "OtherWord_Id", c => c.Int());
            DropForeignKey("dbo.OtherWords", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.OtherWords", "DictionaryId", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.NumberDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.NumberDictionaryTocharians", "Number_Id", "dbo.Numbers");
            DropIndex("dbo.NumberDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.NumberDictionaryTocharians", new[] { "Number_Id" });
            DropIndex("dbo.OtherWords", new[] { "Number_Id" });
            DropIndex("dbo.OtherWords", new[] { "DictionaryId" });
            DropPrimaryKey("dbo.VerbPersons");
            DropPrimaryKey("dbo.PronounNumbers");
            DropPrimaryKey("dbo.GenderPronouns");
            DropPrimaryKey("dbo.NounAdjectiveNumbers");
            DropPrimaryKey("dbo.CaseNounAdjectives");
            DropColumn("dbo.OtherWords", "Number_Id");
            DropColumn("dbo.OtherWords", "DictionaryId");
            DropColumn("dbo.DictionaryTocharians", "StemClass");
            DropColumn("dbo.DictionaryTocharians", "Stem");
            DropColumn("dbo.DictionaryTocharians", "InternalRootVowel");
            DropColumn("dbo.DictionaryTocharians", "RootCharacter");
            DropColumn("dbo.DictionaryTocharians", "RelatedLexemes");
            DropColumn("dbo.DictionaryTocharians", "DerivedFrom");
            DropTable("dbo.NumberDictionaryTocharians");
            AddPrimaryKey("dbo.VerbPersons", new[] { "Person_Id", "Verb_Id" });
            AddPrimaryKey("dbo.PronounNumbers", new[] { "Number_Id", "Pronoun_Id" });
            AddPrimaryKey("dbo.GenderPronouns", new[] { "Pronoun_Id", "Gender_Id" });
            AddPrimaryKey("dbo.NounAdjectiveNumbers", new[] { "Number_Id", "NounAdjective_Id" });
            AddPrimaryKey("dbo.CaseNounAdjectives", new[] { "NounAdjective_Id", "Case_Id" });
            CreateIndex("dbo.OtherWordNumbers", "Number_Id");
            CreateIndex("dbo.OtherWordNumbers", "OtherWord_Id");
            CreateIndex("dbo.OtherWords", "WordSubClassId");
            CreateIndex("dbo.OtherWords", "WordClassId");
            CreateIndex("dbo.OtherWords", "TochLanguageId");
            CreateIndex("dbo.DictionaryTocharians", "Number_Id");
            CreateIndex("dbo.Bibliographies", "OtherWord_Id");
            AddForeignKey("dbo.OtherWords", "WordSubClassId", "dbo.WordSubClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OtherWords", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OtherWords", "TochLanguageId", "dbo.TochLanguages", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OtherWordNumbers", "Number_Id", "dbo.Numbers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OtherWordNumbers", "OtherWord_Id", "dbo.OtherWords", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bibliographies", "OtherWord_Id", "dbo.OtherWords", "Id");
            AddForeignKey("dbo.DictionaryTocharians", "Number_Id", "dbo.Numbers", "Id");
            RenameTable(name: "dbo.VerbPersons", newName: "PersonVerbs");
            RenameTable(name: "dbo.PronounNumbers", newName: "NumberPronouns");
            RenameTable(name: "dbo.GenderPronouns", newName: "PronounGenders");
            RenameTable(name: "dbo.NounAdjectiveNumbers", newName: "NumberNounAdjectives");
            RenameTable(name: "dbo.CaseNounAdjectives", newName: "NounAdjectiveCases");
        }
    }
}
