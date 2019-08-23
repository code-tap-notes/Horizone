namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCommon : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DictionaryTocharians", "TochCommon", c => c.String());
            AddColumn("dbo.NounAdjectives", "TochCommon", c => c.String());
            AddColumn("dbo.Pronouns", "TochCommon", c => c.String());
            AddColumn("dbo.OtherWords", "TochCommon", c => c.String());
            AddColumn("dbo.Verbs", "TochCommon", c => c.String());
            DropColumn("dbo.DictionaryTocharians", "TochComnon");
            DropColumn("dbo.NounAdjectives", "TochComnon");
            DropColumn("dbo.Pronouns", "TochComnon");
            DropColumn("dbo.OtherWords", "TochComnon");
            DropColumn("dbo.Verbs", "TochComnon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Verbs", "TochComnon", c => c.String());
            AddColumn("dbo.OtherWords", "TochComnon", c => c.String());
            AddColumn("dbo.Pronouns", "TochComnon", c => c.String());
            AddColumn("dbo.NounAdjectives", "TochComnon", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "TochComnon", c => c.String());
            DropColumn("dbo.Verbs", "TochCommon");
            DropColumn("dbo.OtherWords", "TochCommon");
            DropColumn("dbo.Pronouns", "TochCommon");
            DropColumn("dbo.NounAdjectives", "TochCommon");
            DropColumn("dbo.DictionaryTocharians", "TochCommon");
        }
    }
}
