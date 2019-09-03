namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DictionaryTocharians", "Sanskrit", c => c.String());
            AddColumn("dbo.NounAdjectives", "Sanskrit", c => c.String());
            AddColumn("dbo.Pronouns", "Sanskrit", c => c.String());
            AddColumn("dbo.OtherWords", "Sanskrit", c => c.String());
            AddColumn("dbo.Verbs", "Sanskrit", c => c.String());
            AddColumn("dbo.VisualAids", "Glosary", c => c.Boolean(nullable: false));
            AddColumn("dbo.VisualAids", "Question", c => c.Boolean(nullable: false));
            DropColumn("dbo.VisualAids", "Map");
        }
        
        public override void Down()
        {
            AddColumn("dbo.VisualAids", "Map", c => c.Boolean(nullable: false));
            DropColumn("dbo.VisualAids", "Question");
            DropColumn("dbo.VisualAids", "Glosary");
            DropColumn("dbo.Verbs", "Sanskrit");
            DropColumn("dbo.OtherWords", "Sanskrit");
            DropColumn("dbo.Pronouns", "Sanskrit");
            DropColumn("dbo.NounAdjectives", "Sanskrit");
            DropColumn("dbo.DictionaryTocharians", "Sanskrit");
        }
    }
}
