namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changDic : DbMigration
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
            DropIndex("dbo.DictionaryTocharians", new[] { "VoiceId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "ValencyId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "TenseAndAspectId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "MoodId" });
            DropIndex("dbo.CaseDictionaryTocharians", new[] { "Case_Id" });
            DropIndex("dbo.CaseDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.GenderDictionaryTocharians", new[] { "Gender_Id" });
            DropIndex("dbo.GenderDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.NumberDictionaryTocharians", new[] { "Number_Id" });
            DropIndex("dbo.NumberDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            DropIndex("dbo.PersonDictionaryTocharians", new[] { "Person_Id" });
            DropIndex("dbo.PersonDictionaryTocharians", new[] { "DictionaryTocharian_Id" });
            AddColumn("dbo.DictionaryTocharians", "IdClassSource", c => c.Int(nullable: false));
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
            CreateIndex("dbo.PersonDictionaryTocharians", "DictionaryTocharian_Id");
            CreateIndex("dbo.PersonDictionaryTocharians", "Person_Id");
            CreateIndex("dbo.NumberDictionaryTocharians", "DictionaryTocharian_Id");
            CreateIndex("dbo.NumberDictionaryTocharians", "Number_Id");
            CreateIndex("dbo.GenderDictionaryTocharians", "DictionaryTocharian_Id");
            CreateIndex("dbo.GenderDictionaryTocharians", "Gender_Id");
            CreateIndex("dbo.CaseDictionaryTocharians", "DictionaryTocharian_Id");
            CreateIndex("dbo.CaseDictionaryTocharians", "Case_Id");
            CreateIndex("dbo.DictionaryTocharians", "MoodId");
            CreateIndex("dbo.DictionaryTocharians", "TenseAndAspectId");
            CreateIndex("dbo.DictionaryTocharians", "ValencyId");
            CreateIndex("dbo.DictionaryTocharians", "VoiceId");
            AddForeignKey("dbo.DictionaryTocharians", "VoiceId", "dbo.Voices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DictionaryTocharians", "ValencyId", "dbo.Valencies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DictionaryTocharians", "TenseAndAspectId", "dbo.TenseAndAspects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DictionaryTocharians", "MoodId", "dbo.Moods", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PersonDictionaryTocharians", "Person_Id", "dbo.People", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NumberDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: true);
            AddForeignKey("dbo.NumberDictionaryTocharians", "Number_Id", "dbo.Numbers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenderDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: true);
            AddForeignKey("dbo.GenderDictionaryTocharians", "Gender_Id", "dbo.Genders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CaseDictionaryTocharians", "DictionaryTocharian_Id", "dbo.DictionaryTocharians", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CaseDictionaryTocharians", "Case_Id", "dbo.Cases", "Id", cascadeDelete: true);
        }
    }
}
