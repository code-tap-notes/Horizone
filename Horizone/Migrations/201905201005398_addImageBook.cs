namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addImageBook : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ImageBooks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        BibliographyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bibliographies", t => t.BibliographyId, cascadeDelete: false)
                .Index(t => t.BibliographyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageBooks", "BibliographyId", "dbo.Bibliographies");
            DropIndex("dbo.ImageBooks", new[] { "BibliographyId" });
            DropTable("dbo.ImageBooks");
        }
    }
}
