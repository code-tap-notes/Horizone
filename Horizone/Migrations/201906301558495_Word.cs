namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Word : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NounAdjectives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TochWord = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        German = c.String(),
                        Latin = c.String(),
                        Chinese = c.String(),
                        TochLanguageId = c.Int(nullable: false),
                        EquivalentTA = c.String(),
                        EquivalentTB = c.String(),
                        TochCorrespondence = c.String(),
                        EquivalentInOther = c.String(),
                        DerivedFrom = c.String(),
                        RelatedLexemes = c.String(),
                        RootCharacter = c.String(),
                        InternalRootVowel = c.String(),
                        Stem = c.String(),
                        StemClass = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .Index(t => t.TochLanguageId);
            
            CreateTable(
                "dbo.OtherWords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TochWord = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        German = c.String(),
                        Latin = c.String(),
                        Chinese = c.String(),
                        TochLanguageId = c.Int(nullable: false),
                        EquivalentTA = c.String(),
                        EquivalentTB = c.String(),
                        TochCorrespondence = c.String(),
                        EquivalentInOther = c.String(),
                        DerivedFrom = c.String(),
                        RelatedLexemes = c.String(),
                        RootCharacter = c.String(),
                        InternalRootVowel = c.String(),
                        Stem = c.String(),
                        StemClass = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .Index(t => t.TochLanguageId);
            
            CreateTable(
                "dbo.Pronouns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TochWord = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        German = c.String(),
                        Latin = c.String(),
                        Chinese = c.String(),
                        TochLanguageId = c.Int(nullable: false),
                        EquivalentTA = c.String(),
                        EquivalentTB = c.String(),
                        TochCorrespondence = c.String(),
                        EquivalentInOther = c.String(),
                        DerivedFrom = c.String(),
                        RelatedLexemes = c.String(),
                        RootCharacter = c.String(),
                        InternalRootVowel = c.String(),
                        Stem = c.String(),
                        StemClass = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .Index(t => t.TochLanguageId);
            
            CreateTable(
                "dbo.Verbs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VoiceId = c.Int(nullable: false),
                        ValencyId = c.Int(nullable: false),
                        TenseAndAspectId = c.Int(nullable: false),
                        MoodId = c.Int(nullable: false),
                        PronounSuffix = c.String(),
                        TochWord = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        German = c.String(),
                        Latin = c.String(),
                        Chinese = c.String(),
                        TochLanguageId = c.Int(nullable: false),
                        EquivalentTA = c.String(),
                        EquivalentTB = c.String(),
                        TochCorrespondence = c.String(),
                        EquivalentInOther = c.String(),
                        DerivedFrom = c.String(),
                        RelatedLexemes = c.String(),
                        RootCharacter = c.String(),
                        InternalRootVowel = c.String(),
                        Stem = c.String(),
                        StemClass = c.String(),
                        Visible = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Moods", t => t.MoodId, cascadeDelete: false)
                .ForeignKey("dbo.TenseAndAspects", t => t.TenseAndAspectId, cascadeDelete: false)
                .ForeignKey("dbo.TochLanguages", t => t.TochLanguageId, cascadeDelete: false)
                .ForeignKey("dbo.Valencies", t => t.ValencyId, cascadeDelete: false)
                .ForeignKey("dbo.Voices", t => t.VoiceId, cascadeDelete: false)
                .Index(t => t.VoiceId)
                .Index(t => t.ValencyId)
                .Index(t => t.TenseAndAspectId)
                .Index(t => t.MoodId)
                .Index(t => t.TochLanguageId);
            
            AddColumn("dbo.Bibliographies", "NounAdjective_Id", c => c.Int());
            AddColumn("dbo.Bibliographies", "OtherWord_Id", c => c.Int());
            AddColumn("dbo.Bibliographies", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.Bibliographies", "Verb_Id", c => c.Int());
            AddColumn("dbo.Cases", "NounAdjective_Id", c => c.Int());
            AddColumn("dbo.Cases", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.Genders", "NounAdjective_Id", c => c.Int());
            AddColumn("dbo.Genders", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.Numbers", "NounAdjective_Id", c => c.Int());
            AddColumn("dbo.Numbers", "OtherWord_Id", c => c.Int());
            AddColumn("dbo.Numbers", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.Numbers", "Verb_Id", c => c.Int());
            AddColumn("dbo.People", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.People", "Verb_Id", c => c.Int());
            CreateIndex("dbo.Bibliographies", "NounAdjective_Id");
            CreateIndex("dbo.Bibliographies", "OtherWord_Id");
            CreateIndex("dbo.Bibliographies", "Pronoun_Id");
            CreateIndex("dbo.Bibliographies", "Verb_Id");
            CreateIndex("dbo.Cases", "NounAdjective_Id");
            CreateIndex("dbo.Cases", "Pronoun_Id");
            CreateIndex("dbo.Genders", "NounAdjective_Id");
            CreateIndex("dbo.Genders", "Pronoun_Id");
            CreateIndex("dbo.Numbers", "NounAdjective_Id");
            CreateIndex("dbo.Numbers", "OtherWord_Id");
            CreateIndex("dbo.Numbers", "Pronoun_Id");
            CreateIndex("dbo.Numbers", "Verb_Id");
            CreateIndex("dbo.People", "Pronoun_Id");
            CreateIndex("dbo.People", "Verb_Id");
            AddForeignKey("dbo.Bibliographies", "NounAdjective_Id", "dbo.NounAdjectives", "Id");
            AddForeignKey("dbo.Cases", "NounAdjective_Id", "dbo.NounAdjectives", "Id");
            AddForeignKey("dbo.Genders", "NounAdjective_Id", "dbo.NounAdjectives", "Id");
            AddForeignKey("dbo.Numbers", "NounAdjective_Id", "dbo.NounAdjectives", "Id");
            AddForeignKey("dbo.Bibliographies", "OtherWord_Id", "dbo.OtherWords", "Id");
            AddForeignKey("dbo.Numbers", "OtherWord_Id", "dbo.OtherWords", "Id");
            AddForeignKey("dbo.Bibliographies", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.Cases", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.Genders", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.Numbers", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.People", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.Bibliographies", "Verb_Id", "dbo.Verbs", "Id");
            AddForeignKey("dbo.Numbers", "Verb_Id", "dbo.Verbs", "Id");
            AddForeignKey("dbo.People", "Verb_Id", "dbo.Verbs", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Verbs", "VoiceId", "dbo.Voices");
            DropForeignKey("dbo.Verbs", "ValencyId", "dbo.Valencies");
            DropForeignKey("dbo.Verbs", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.Verbs", "TenseAndAspectId", "dbo.TenseAndAspects");
            DropForeignKey("dbo.People", "Verb_Id", "dbo.Verbs");
            DropForeignKey("dbo.Numbers", "Verb_Id", "dbo.Verbs");
            DropForeignKey("dbo.Verbs", "MoodId", "dbo.Moods");
            DropForeignKey("dbo.Bibliographies", "Verb_Id", "dbo.Verbs");
            DropForeignKey("dbo.Pronouns", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.People", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.Numbers", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.Genders", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.Cases", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.Bibliographies", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.OtherWords", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.Numbers", "OtherWord_Id", "dbo.OtherWords");
            DropForeignKey("dbo.Bibliographies", "OtherWord_Id", "dbo.OtherWords");
            DropForeignKey("dbo.NounAdjectives", "TochLanguageId", "dbo.TochLanguages");
            DropForeignKey("dbo.Numbers", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.Genders", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.Cases", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.Bibliographies", "NounAdjective_Id", "dbo.NounAdjectives");
            DropIndex("dbo.Verbs", new[] { "TochLanguageId" });
            DropIndex("dbo.Verbs", new[] { "MoodId" });
            DropIndex("dbo.Verbs", new[] { "TenseAndAspectId" });
            DropIndex("dbo.Verbs", new[] { "ValencyId" });
            DropIndex("dbo.Verbs", new[] { "VoiceId" });
            DropIndex("dbo.Pronouns", new[] { "TochLanguageId" });
            DropIndex("dbo.OtherWords", new[] { "TochLanguageId" });
            DropIndex("dbo.NounAdjectives", new[] { "TochLanguageId" });
            DropIndex("dbo.People", new[] { "Verb_Id" });
            DropIndex("dbo.People", new[] { "Pronoun_Id" });
            DropIndex("dbo.Numbers", new[] { "Verb_Id" });
            DropIndex("dbo.Numbers", new[] { "Pronoun_Id" });
            DropIndex("dbo.Numbers", new[] { "OtherWord_Id" });
            DropIndex("dbo.Numbers", new[] { "NounAdjective_Id" });
            DropIndex("dbo.Genders", new[] { "Pronoun_Id" });
            DropIndex("dbo.Genders", new[] { "NounAdjective_Id" });
            DropIndex("dbo.Cases", new[] { "Pronoun_Id" });
            DropIndex("dbo.Cases", new[] { "NounAdjective_Id" });
            DropIndex("dbo.Bibliographies", new[] { "Verb_Id" });
            DropIndex("dbo.Bibliographies", new[] { "Pronoun_Id" });
            DropIndex("dbo.Bibliographies", new[] { "OtherWord_Id" });
            DropIndex("dbo.Bibliographies", new[] { "NounAdjective_Id" });
            DropColumn("dbo.People", "Verb_Id");
            DropColumn("dbo.People", "Pronoun_Id");
            DropColumn("dbo.Numbers", "Verb_Id");
            DropColumn("dbo.Numbers", "Pronoun_Id");
            DropColumn("dbo.Numbers", "OtherWord_Id");
            DropColumn("dbo.Numbers", "NounAdjective_Id");
            DropColumn("dbo.Genders", "Pronoun_Id");
            DropColumn("dbo.Genders", "NounAdjective_Id");
            DropColumn("dbo.Cases", "Pronoun_Id");
            DropColumn("dbo.Cases", "NounAdjective_Id");
            DropColumn("dbo.Bibliographies", "Verb_Id");
            DropColumn("dbo.Bibliographies", "Pronoun_Id");
            DropColumn("dbo.Bibliographies", "OtherWord_Id");
            DropColumn("dbo.Bibliographies", "NounAdjective_Id");
            DropTable("dbo.Verbs");
            DropTable("dbo.Pronouns");
            DropTable("dbo.OtherWords");
            DropTable("dbo.NounAdjectives");
        }
    }
}
