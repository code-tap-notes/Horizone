namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTableVisualAid : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VisualAids",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Aids = c.String(nullable: false),
                        Description = c.String(),
                        Photography = c.Boolean(nullable: false),
                        Map = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.DictionaryTocharians", "German", c => c.String());
            AddColumn("dbo.DictionaryTocharians", "Latin", c => c.String());
            AddColumn("dbo.Collaborations", "AssociatedResearcher", c => c.Boolean(nullable: false));
            AddColumn("dbo.Collaborations", "Collaborator", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Collaborations", "Summary", c => c.String());
            AlterColumn("dbo.Collaborations", "CV", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Collaborations", "CV", c => c.String(maxLength: 500));
            AlterColumn("dbo.Collaborations", "Summary", c => c.String(maxLength: 500));
            DropColumn("dbo.Collaborations", "Collaborator");
            DropColumn("dbo.Collaborations", "AssociatedResearcher");
            DropColumn("dbo.DictionaryTocharians", "Latin");
            DropColumn("dbo.DictionaryTocharians", "German");
            DropTable("dbo.VisualAids");
        }
    }
}
