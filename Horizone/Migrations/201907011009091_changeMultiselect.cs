namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMultiselect : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Cases", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.Genders", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.Numbers", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.Numbers", "OtherWord_Id", "dbo.OtherWords");
            DropForeignKey("dbo.Cases", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.Genders", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.Numbers", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.People", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.Numbers", "Verb_Id", "dbo.Verbs");
            DropForeignKey("dbo.People", "Verb_Id", "dbo.Verbs");
            DropIndex("dbo.Cases", new[] { "NounAdjective_Id" });
            DropIndex("dbo.Cases", new[] { "Pronoun_Id" });
            DropIndex("dbo.Genders", new[] { "NounAdjective_Id" });
            DropIndex("dbo.Genders", new[] { "Pronoun_Id" });
            DropIndex("dbo.Numbers", new[] { "NounAdjective_Id" });
            DropIndex("dbo.Numbers", new[] { "OtherWord_Id" });
            DropIndex("dbo.Numbers", new[] { "Pronoun_Id" });
            DropIndex("dbo.Numbers", new[] { "Verb_Id" });
            DropIndex("dbo.People", new[] { "Pronoun_Id" });
            DropIndex("dbo.People", new[] { "Verb_Id" });
            CreateTable(
                "dbo.NounAdjectiveCases",
                c => new
                    {
                        NounAdjective_Id = c.Int(nullable: false),
                        Case_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.NounAdjective_Id, t.Case_Id })
                .ForeignKey("dbo.NounAdjectives", t => t.NounAdjective_Id, cascadeDelete: false)
                .ForeignKey("dbo.Cases", t => t.Case_Id, cascadeDelete: false)
                .Index(t => t.NounAdjective_Id)
                .Index(t => t.Case_Id);
            
            CreateTable(
                "dbo.GenderNounAdjectives",
                c => new
                    {
                        Gender_Id = c.Int(nullable: false),
                        NounAdjective_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gender_Id, t.NounAdjective_Id })
                .ForeignKey("dbo.Genders", t => t.Gender_Id, cascadeDelete: false)
                .ForeignKey("dbo.NounAdjectives", t => t.NounAdjective_Id, cascadeDelete: false)
                .Index(t => t.Gender_Id)
                .Index(t => t.NounAdjective_Id);
            
            CreateTable(
                "dbo.PronounCases",
                c => new
                    {
                        Pronoun_Id = c.Int(nullable: false),
                        Case_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pronoun_Id, t.Case_Id })
                .ForeignKey("dbo.Pronouns", t => t.Pronoun_Id, cascadeDelete: false)
                .ForeignKey("dbo.Cases", t => t.Case_Id, cascadeDelete: false)
                .Index(t => t.Pronoun_Id)
                .Index(t => t.Case_Id);
            
            CreateTable(
                "dbo.PronounGenders",
                c => new
                    {
                        Pronoun_Id = c.Int(nullable: false),
                        Gender_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pronoun_Id, t.Gender_Id })
                .ForeignKey("dbo.Pronouns", t => t.Pronoun_Id, cascadeDelete: false)
                .ForeignKey("dbo.Genders", t => t.Gender_Id, cascadeDelete: false)
                .Index(t => t.Pronoun_Id)
                .Index(t => t.Gender_Id);
            
            CreateTable(
                "dbo.NumberNounAdjectives",
                c => new
                    {
                        Number_Id = c.Int(nullable: false),
                        NounAdjective_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Number_Id, t.NounAdjective_Id })
                .ForeignKey("dbo.Numbers", t => t.Number_Id, cascadeDelete: false)
                .ForeignKey("dbo.NounAdjectives", t => t.NounAdjective_Id, cascadeDelete: false)
                .Index(t => t.Number_Id)
                .Index(t => t.NounAdjective_Id);
            
            CreateTable(
                "dbo.OtherWordNumbers",
                c => new
                    {
                        OtherWord_Id = c.Int(nullable: false),
                        Number_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OtherWord_Id, t.Number_Id })
                .ForeignKey("dbo.OtherWords", t => t.OtherWord_Id, cascadeDelete: false)
                .ForeignKey("dbo.Numbers", t => t.Number_Id, cascadeDelete: false)
                .Index(t => t.OtherWord_Id)
                .Index(t => t.Number_Id);
            
            CreateTable(
                "dbo.NumberPronouns",
                c => new
                    {
                        Number_Id = c.Int(nullable: false),
                        Pronoun_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Number_Id, t.Pronoun_Id })
                .ForeignKey("dbo.Numbers", t => t.Number_Id, cascadeDelete: false)
                .ForeignKey("dbo.Pronouns", t => t.Pronoun_Id, cascadeDelete: false)
                .Index(t => t.Number_Id)
                .Index(t => t.Pronoun_Id);
            
            CreateTable(
                "dbo.VerbNumbers",
                c => new
                    {
                        Verb_Id = c.Int(nullable: false),
                        Number_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Verb_Id, t.Number_Id })
                .ForeignKey("dbo.Verbs", t => t.Verb_Id, cascadeDelete: false)
                .ForeignKey("dbo.Numbers", t => t.Number_Id, cascadeDelete: false)
                .Index(t => t.Verb_Id)
                .Index(t => t.Number_Id);
            
            CreateTable(
                "dbo.PersonPronouns",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Pronoun_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Pronoun_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: false)
                .ForeignKey("dbo.Pronouns", t => t.Pronoun_Id, cascadeDelete: false)
                .Index(t => t.Person_Id)
                .Index(t => t.Pronoun_Id);
            
            CreateTable(
                "dbo.PersonVerbs",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        Verb_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.Verb_Id })
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: false)
                .ForeignKey("dbo.Verbs", t => t.Verb_Id, cascadeDelete: false)
                .Index(t => t.Person_Id)
                .Index(t => t.Verb_Id);
            
            DropColumn("dbo.Cases", "NounAdjective_Id");
            DropColumn("dbo.Cases", "Pronoun_Id");
            DropColumn("dbo.Genders", "NounAdjective_Id");
            DropColumn("dbo.Genders", "Pronoun_Id");
            DropColumn("dbo.Numbers", "NounAdjective_Id");
            DropColumn("dbo.Numbers", "OtherWord_Id");
            DropColumn("dbo.Numbers", "Pronoun_Id");
            DropColumn("dbo.Numbers", "Verb_Id");
            DropColumn("dbo.People", "Pronoun_Id");
            DropColumn("dbo.People", "Verb_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.People", "Verb_Id", c => c.Int());
            AddColumn("dbo.People", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.Numbers", "Verb_Id", c => c.Int());
            AddColumn("dbo.Numbers", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.Numbers", "OtherWord_Id", c => c.Int());
            AddColumn("dbo.Numbers", "NounAdjective_Id", c => c.Int());
            AddColumn("dbo.Genders", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.Genders", "NounAdjective_Id", c => c.Int());
            AddColumn("dbo.Cases", "Pronoun_Id", c => c.Int());
            AddColumn("dbo.Cases", "NounAdjective_Id", c => c.Int());
            DropForeignKey("dbo.PersonVerbs", "Verb_Id", "dbo.Verbs");
            DropForeignKey("dbo.PersonVerbs", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PersonPronouns", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.PersonPronouns", "Person_Id", "dbo.People");
            DropForeignKey("dbo.VerbNumbers", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.VerbNumbers", "Verb_Id", "dbo.Verbs");
            DropForeignKey("dbo.NumberPronouns", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.NumberPronouns", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.OtherWordNumbers", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.OtherWordNumbers", "OtherWord_Id", "dbo.OtherWords");
            DropForeignKey("dbo.NumberNounAdjectives", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.NumberNounAdjectives", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.PronounGenders", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.PronounGenders", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.PronounCases", "Case_Id", "dbo.Cases");
            DropForeignKey("dbo.PronounCases", "Pronoun_Id", "dbo.Pronouns");
            DropForeignKey("dbo.GenderNounAdjectives", "NounAdjective_Id", "dbo.NounAdjectives");
            DropForeignKey("dbo.GenderNounAdjectives", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.NounAdjectiveCases", "Case_Id", "dbo.Cases");
            DropForeignKey("dbo.NounAdjectiveCases", "NounAdjective_Id", "dbo.NounAdjectives");
            DropIndex("dbo.PersonVerbs", new[] { "Verb_Id" });
            DropIndex("dbo.PersonVerbs", new[] { "Person_Id" });
            DropIndex("dbo.PersonPronouns", new[] { "Pronoun_Id" });
            DropIndex("dbo.PersonPronouns", new[] { "Person_Id" });
            DropIndex("dbo.VerbNumbers", new[] { "Number_Id" });
            DropIndex("dbo.VerbNumbers", new[] { "Verb_Id" });
            DropIndex("dbo.NumberPronouns", new[] { "Pronoun_Id" });
            DropIndex("dbo.NumberPronouns", new[] { "Number_Id" });
            DropIndex("dbo.OtherWordNumbers", new[] { "Number_Id" });
            DropIndex("dbo.OtherWordNumbers", new[] { "OtherWord_Id" });
            DropIndex("dbo.NumberNounAdjectives", new[] { "NounAdjective_Id" });
            DropIndex("dbo.NumberNounAdjectives", new[] { "Number_Id" });
            DropIndex("dbo.PronounGenders", new[] { "Gender_Id" });
            DropIndex("dbo.PronounGenders", new[] { "Pronoun_Id" });
            DropIndex("dbo.PronounCases", new[] { "Case_Id" });
            DropIndex("dbo.PronounCases", new[] { "Pronoun_Id" });
            DropIndex("dbo.GenderNounAdjectives", new[] { "NounAdjective_Id" });
            DropIndex("dbo.GenderNounAdjectives", new[] { "Gender_Id" });
            DropIndex("dbo.NounAdjectiveCases", new[] { "Case_Id" });
            DropIndex("dbo.NounAdjectiveCases", new[] { "NounAdjective_Id" });
            DropTable("dbo.PersonVerbs");
            DropTable("dbo.PersonPronouns");
            DropTable("dbo.VerbNumbers");
            DropTable("dbo.NumberPronouns");
            DropTable("dbo.OtherWordNumbers");
            DropTable("dbo.NumberNounAdjectives");
            DropTable("dbo.PronounGenders");
            DropTable("dbo.PronounCases");
            DropTable("dbo.GenderNounAdjectives");
            DropTable("dbo.NounAdjectiveCases");
            CreateIndex("dbo.People", "Verb_Id");
            CreateIndex("dbo.People", "Pronoun_Id");
            CreateIndex("dbo.Numbers", "Verb_Id");
            CreateIndex("dbo.Numbers", "Pronoun_Id");
            CreateIndex("dbo.Numbers", "OtherWord_Id");
            CreateIndex("dbo.Numbers", "NounAdjective_Id");
            CreateIndex("dbo.Genders", "Pronoun_Id");
            CreateIndex("dbo.Genders", "NounAdjective_Id");
            CreateIndex("dbo.Cases", "Pronoun_Id");
            CreateIndex("dbo.Cases", "NounAdjective_Id");
            AddForeignKey("dbo.People", "Verb_Id", "dbo.Verbs", "Id");
            AddForeignKey("dbo.Numbers", "Verb_Id", "dbo.Verbs", "Id");
            AddForeignKey("dbo.People", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.Numbers", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.Genders", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.Cases", "Pronoun_Id", "dbo.Pronouns", "Id");
            AddForeignKey("dbo.Numbers", "OtherWord_Id", "dbo.OtherWords", "Id");
            AddForeignKey("dbo.Numbers", "NounAdjective_Id", "dbo.NounAdjectives", "Id");
            AddForeignKey("dbo.Genders", "NounAdjective_Id", "dbo.NounAdjectives", "Id");
            AddForeignKey("dbo.Cases", "NounAdjective_Id", "dbo.NounAdjectives", "Id");
        }
    }
}
