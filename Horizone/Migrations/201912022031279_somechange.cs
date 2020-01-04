namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somechange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CaseDictionaryTocharians", "Case_Id", "dbo.Cases");
            DropForeignKey("dbo.CaseDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.GenderDictionaryTocharians", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.GenderDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.NumberDictionaryTocharians", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.NumberDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.PersonDictionaryTocharians", "Person_Id", "dbo.People");
            DropForeignKey("dbo.PersonDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians");
            DropForeignKey("dbo.DictionaryTocharians", "MoodId", "dbo.Moods");
            DropForeignKey("dbo.DictionaryTocharians", "TenseAndAspectId", "dbo.TenseAndAspects");
            DropForeignKey("dbo.DictionaryTocharians", "ValencyId", "dbo.Valencies");
            DropForeignKey("dbo.DictionaryTocharians", "VoiceId", "dbo.Voices");
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.DictionaryTocharians", new[] { "VoiceId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "ValencyId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "TenseAndAspectId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "MoodId" });
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.CaseDictionaryTocharians", new[] { "Case_Id" });
            DropIndex("dbo.CaseDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.GenderDictionaryTocharians", new[] { "Gender_Id" });
            DropIndex("dbo.GenderDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.NumberDictionaryTocharians", new[] { "Number_Id" });
            DropIndex("dbo.NumberDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.PersonDictionaryTocharians", new[] { "Person_Id" });
            DropIndex("dbo.PersonDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            CreateTable(
                "dbo.SearchResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameTable = c.String(),
                        IdResult = c.Int(nullable: false),
                        Summary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DictionaryTocharians", "IdClassSource", c => c.Int(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "Case_Id", c => c.Int());
            AddColumn("dbo.DictionaryTocharians", "Gender_Id", c => c.Int());
            AddColumn("dbo.DictionaryTocharians", "Number_Id", c => c.Int());
            AddColumn("dbo.DictionaryTocharians", "Person_Id", c => c.Int());
            AddColumn("dbo.Comments", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comments", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.NamePlaces", "InStory", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProperNouns", "DescriptionEn", c => c.String());
            AddColumn("dbo.ProperNouns", "DescriptionFr", c => c.String());
            AddColumn("dbo.ProperNouns", "DescriptionZh", c => c.String());
            AddColumn("dbo.ProperNouns", "InStory", c => c.Boolean(nullable: false));
            CreateIndex("dbo.DictionaryTocharians", "Case_Id");
            CreateIndex("dbo.DictionaryTocharians", "Gender_Id");
            CreateIndex("dbo.DictionaryTocharians", "Number_Id");
            CreateIndex("dbo.DictionaryTocharians", "Person_Id");
            CreateIndex("dbo.Comments", "ClientId");
            AddForeignKey("dbo.DictionaryTocharians", "Case_Id", "dbo.Cases", "Id");
            AddForeignKey("dbo.DictionaryTocharians", "Gender_Id", "dbo.Genders", "Id");
            AddForeignKey("dbo.DictionaryTocharians", "Number_Id", "dbo.Numbers", "Id");
            AddForeignKey("dbo.DictionaryTocharians", "Person_Id", "dbo.People", "Id");
            AddForeignKey("dbo.Comments", "ClientId", "dbo.Clients", "Id", cascadeDelete: false);
            DropColumn("dbo.DictionaryTocharians", "DerivedFrom");
            DropColumn("dbo.DictionaryTocharians", "RelatedLexemes");
            DropColumn("dbo.DictionaryTocharians", "RootCharacter");
            DropColumn("dbo.DictionaryTocharians", "InternalRootVowel");
            DropColumn("dbo.DictionaryTocharians", "Stem");
            DropColumn("dbo.DictionaryTocharians", "StemClass");
            DropColumn("dbo.DictionaryTocharians", "VoiceId");
            DropColumn("dbo.DictionaryTocharians", "ValencyId");
            DropColumn("dbo.DictionaryTocharians", "TenseAndAspectId");
            DropColumn("dbo.DictionaryTocharians", "MoodId");
            DropColumn("dbo.DictionaryTocharians", "PronounSuffix");
            DropColumn("dbo.Comments", "UserId");
            DropTable("dbo.CaseDictionaryTocharians");
            DropTable("dbo.GenderDictionaryTocharians");
            DropTable("dbo.NumberDictionaryTocharians");
            DropTable("dbo.PersonDictionaryTocharians");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PersonDictionaryTocharians",
                c => new
                    {
                        Person_Id = c.Int(nullable: false),
                        DictionaryTocharian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Person_Id, t.DictionaryTocharian_Id });
            
            CreateTable(
                "dbo.NumberDictionaryTocharians",
                c => new
                    {
                        Number_Id = c.Int(nullable: false),
                        DictionaryTocharian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Number_Id, t.DictionaryTocharian_Id });
            
            CreateTable(
                "dbo.GenderDictionaryTocharians",
                c => new
                    {
                        Gender_Id = c.Int(nullable: false),
                        DictionaryTocharian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Gender_Id, t.DictionaryTocharian_Id });
            
            CreateTable(
                "dbo.CaseDictionaryTocharians",
                c => new
                    {
                        Case_Id = c.Int(nullable: false),
                        DictionaryTocharian_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Case_Id, t.DictionaryTocharian_Id });
            
            AddColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            AddColumn("dbo.DictionaryTocharians", "PronounSuffix", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "MoodId", c => c.Int(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "TenseAndAspectId", c => c.Int(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "ValencyId", c => c.Int(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "VoiceId", c => c.Int(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "StemClass", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "Stem", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "InternalRootVowel", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "RootCharacter", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "RelatedLexemes", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "DerivedFrom", c => c.String());
            DropForeignKey("dbo.Comments", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.DictionaryTocharians", "Person_Id", "dbo.People");
            DropForeignKey("dbo.DictionaryTocharians", "Number_Id", "dbo.Numbers");
            DropForeignKey("dbo.DictionaryTocharians", "Gender_Id", "dbo.Genders");
            DropForeignKey("dbo.DictionaryTocharians", "Case_Id", "dbo.Cases");
            DropIndex("dbo.Comments", new[] { "ClientId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "Person_Id" });
            DropIndex("dbo.DictionaryTocharians", new[] { "Number_Id" });
            DropIndex("dbo.DictionaryTocharians", new[] { "Gender_Id" });
            DropIndex("dbo.DictionaryTocharians", new[] { "Case_Id" });
            DropColumn("dbo.ProperNouns", "InStory");
            DropColumn("dbo.ProperNouns", "DescriptionZh");
            DropColumn("dbo.ProperNouns", "DescriptionFr");
            DropColumn("dbo.ProperNouns", "DescriptionEn");
            DropColumn("dbo.NamePlaces", "InStory");
            DropColumn("dbo.Comments", "ClientId");
            DropColumn("dbo.Comments", "Date");
            DropColumn("dbo.DictionaryTocharians", "Person_Id");
            DropColumn("dbo.DictionaryTocharians", "Number_Id");
            DropColumn("dbo.DictionaryTocharians", "Gender_Id");
            DropColumn("dbo.DictionaryTocharians", "Case_Id");
            DropColumn("dbo.DictionaryTocharians", "IdClassSource");
            DropTable("dbo.SearchResults");
            CreateIndex("dbo.PersonDictionaryTocharians", "DictionaryTocharian_Id");
            CreateIndex("dbo.PersonDictionaryTocharians", "Person_Id");
            CreateIndex("dbo.NumberDictionaryTocharians", "DictionaryTocharian_Id");
            CreateIndex("dbo.NumberDictionaryTocharians", "Number_Id");
            CreateIndex("dbo.GenderDictionaryTocharians", "DictionaryTocharian_Id");
            CreateIndex("dbo.GenderDictionaryTocharians", "Gender_Id");
            CreateIndex("dbo.CaseDictionaryTocharians", "DictionaryTocharian_Id");
            CreateIndex("dbo.CaseDictionaryTocharians", "Case_Id");
            CreateIndex("dbo.Comments", "UserId");
            CreateIndex("dbo.DictionaryTocharians", "MoodId");
            CreateIndex("dbo.DictionaryTocharians", "TenseAndAspectId");
            CreateIndex("dbo.DictionaryTocharians", "ValencyId");
            CreateIndex("dbo.DictionaryTocharians", "VoiceId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.DictionaryTocharians", "VoiceId", "dbo.Voices", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DictionaryTocharians", "ValencyId", "dbo.Valencies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DictionaryTocharians", "TenseAndAspectId", "dbo.TenseAndAspects", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DictionaryTocharians", "MoodId", "dbo.Moods", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PersonDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PersonDictionaryTocharians", "Person_Id", "dbo.People", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NumberDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NumberDictionaryTocharians", "Number_Id", "dbo.Numbers", "Id", cascadeDelete: false);
            AddForeignKey("dbo.GenderDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: false);
            AddForeignKey("dbo.GenderDictionaryTocharians", "Gender_Id", "dbo.Genders", "Id", cascadeDelete: false);
            AddForeignKey("dbo.CaseDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: false);
            AddForeignKey("dbo.CaseDictionaryTocharians", "Case_Id", "dbo.Cases", "Id", cascadeDelete: false);
        }
    }
}
