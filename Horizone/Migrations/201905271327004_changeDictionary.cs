namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDictionary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Moods",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbbreviationsMood = c.String(),
                        MoodEn = c.String(),
                        MoodFr = c.String(),
                        MoodZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TenseAndAspects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Tense = c.String(),
                        TenseEn = c.String(),
                        TenseFr = c.String(),
                        TenseZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Valencies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbbreviationValency = c.String(),
                        ValencyEn = c.String(),
                        ValenceFr = c.String(),
                        ValencyZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Voices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AbbreviationVoice = c.String(),
                        VoiceEn = c.String(),
                        VoiceFr = c.String(),
                        VoiceZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DictionaryTocharians", "NominateNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "NominateNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "NominateNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "ObliqueNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "ObliqueNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "ObliqueNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "VocativeNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "VocativeNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "VocativeNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "GenitiveNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "GenitiveNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "GenitiveNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "LocativeNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "LocativeNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "LocativeNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "AblativeNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "AblativeNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "AblativeNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "AllativeNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "AllativeNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "AllativeNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "PerlativeNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "PerlativeNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "PerlativeNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "InstrumentalNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "InstrumentalNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "InstrumentalNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "ComitativeNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "ComitativeNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "ComitativeNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "CausativeNeuterSingular", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "CausativeNeuterDual", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "CausativeNeuterPlural", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "VoiceId", c => c.Int(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "ValencyId", c => c.Int(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "TenseAndAspectId", c => c.Int(nullable: false));
            AddColumn("dbo.DictionaryTocharians", "MoodId", c => c.Int(nullable: false));
            CreateIndex("dbo.DictionaryTocharians", "VoiceId");
            CreateIndex("dbo.DictionaryTocharians", "ValencyId");
            CreateIndex("dbo.DictionaryTocharians", "TenseAndAspectId");
            CreateIndex("dbo.DictionaryTocharians", "MoodId");
            AddForeignKey("dbo.DictionaryTocharians", "MoodId", "dbo.Moods", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DictionaryTocharians", "TenseAndAspectId", "dbo.TenseAndAspects", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DictionaryTocharians", "ValencyId", "dbo.Valencies", "Id", cascadeDelete: false);
            AddForeignKey("dbo.DictionaryTocharians", "VoiceId", "dbo.Voices", "Id", cascadeDelete: false);
            DropColumn("dbo.DictionaryTocharians", "Voice");
            DropColumn("dbo.DictionaryTocharians", "Valency");
            DropColumn("dbo.DictionaryTocharians", "TenseMood");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DictionaryTocharians", "TenseMood", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "Valency", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "Voice", c => c.String());
            DropForeignKey("dbo.DictionaryTocharians", "VoiceId", "dbo.Voices");
            DropForeignKey("dbo.DictionaryTocharians", "ValencyId", "dbo.Valencies");
            DropForeignKey("dbo.DictionaryTocharians", "TenseAndAspectId", "dbo.TenseAndAspects");
            DropForeignKey("dbo.DictionaryTocharians", "MoodId", "dbo.Moods");
            DropIndex("dbo.DictionaryTocharians", new[] { "MoodId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "TenseAndAspectId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "ValencyId" });
            DropIndex("dbo.DictionaryTocharians", new[] { "VoiceId" });
            DropColumn("dbo.DictionaryTocharians", "MoodId");
            DropColumn("dbo.DictionaryTocharians", "TenseAndAspectId");
            DropColumn("dbo.DictionaryTocharians", "ValencyId");
            DropColumn("dbo.DictionaryTocharians", "VoiceId");
            DropColumn("dbo.DictionaryTocharians", "CausativeNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "CausativeNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "CausativeNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "ComitativeNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "ComitativeNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "ComitativeNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "InstrumentalNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "InstrumentalNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "InstrumentalNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "PerlativeNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "PerlativeNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "PerlativeNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "AllativeNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "AllativeNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "AllativeNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "AblativeNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "AblativeNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "AblativeNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "LocativeNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "LocativeNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "LocativeNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "GenitiveNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "GenitiveNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "GenitiveNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "VocativeNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "VocativeNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "VocativeNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "ObliqueNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "ObliqueNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "ObliqueNeuterSingular");
            DropColumn("dbo.DictionaryTocharians", "NominateNeuterPlural");
            DropColumn("dbo.DictionaryTocharians", "NominateNeuterDual");
            DropColumn("dbo.DictionaryTocharians", "NominateNeuterSingular");
            DropTable("dbo.Voices");
            DropTable("dbo.Valencies");
            DropTable("dbo.TenseAndAspects");
            DropTable("dbo.Moods");
        }
    }
}
