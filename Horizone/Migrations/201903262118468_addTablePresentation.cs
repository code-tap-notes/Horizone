namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addTablePresentation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Presentations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AboutUs = c.String(),
                        TochPhrase = c.String(),
                        TochStory = c.String(),
                        Manuscript = c.String(),
                        Activity = c.String(),
                        Bibliography = c.String(),
                        DictionaryTocharian = c.String(),
                        VisualAids = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Presentations");
        }
    }
}
