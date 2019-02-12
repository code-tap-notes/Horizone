namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changetablePublication : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Collaborateurs", newName: "Collaborators");
            DropForeignKey("dbo.Publications", "CollaborationId", "dbo.Collaborations");
            DropIndex("dbo.Publications", new[] { "CollaborationId" });
            CreateTable(
                "dbo.PublicationCollaborations",
                c => new
                    {
                        Publication_Id = c.Int(nullable: false),
                        Collaboration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publication_Id, t.Collaboration_Id })
                .ForeignKey("dbo.Publications", t => t.Publication_Id, cascadeDelete: true)
                .ForeignKey("dbo.Collaborations", t => t.Collaboration_Id, cascadeDelete: true)
                .Index(t => t.Publication_Id)
                .Index(t => t.Collaboration_Id);
            
            AlterColumn("dbo.AboutProjects", "Funding", c => c.String());
            AlterColumn("dbo.AboutProjects", "Programing", c => c.String());
            AlterColumn("dbo.AboutProjects", "Feedback", c => c.String());
            AlterColumn("dbo.AboutProjects", "Contact", c => c.String());
            DropColumn("dbo.Publications", "CollaborationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Publications", "CollaborationId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PublicationCollaborations", "Collaboration_Id", "dbo.Collaborations");
            DropForeignKey("dbo.PublicationCollaborations", "Publication_Id", "dbo.Publications");
            DropIndex("dbo.PublicationCollaborations", new[] { "Collaboration_Id" });
            DropIndex("dbo.PublicationCollaborations", new[] { "Publication_Id" });
            AlterColumn("dbo.AboutProjects", "Contact", c => c.String(maxLength: 1500));
            AlterColumn("dbo.AboutProjects", "Feedback", c => c.String(maxLength: 2000));
            AlterColumn("dbo.AboutProjects", "Programing", c => c.String(maxLength: 2000));
            AlterColumn("dbo.AboutProjects", "Funding", c => c.String(maxLength: 2000));
            DropTable("dbo.PublicationCollaborations");
            CreateIndex("dbo.Publications", "CollaborationId");
            AddForeignKey("dbo.Publications", "CollaborationId", "dbo.Collaborations", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.Collaborators", newName: "Collaborateurs");
        }
    }
}
