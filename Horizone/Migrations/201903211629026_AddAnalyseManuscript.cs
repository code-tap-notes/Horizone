namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAnalyseManuscript : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnalyseMaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Index = c.String(nullable: false),
                        Description = c.String(),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImageAnalyses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        AnalyseMaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnalyseMaterials", t => t.AnalyseMaterialId, cascadeDelete: false)
                .Index(t => t.AnalyseMaterialId);
            
            CreateTable(
                "dbo.ImageUVs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        AnalyseMaterialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AnalyseMaterials", t => t.AnalyseMaterialId, cascadeDelete: false)
                .Index(t => t.AnalyseMaterialId);
            
            AddColumn("dbo.Collaborations", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ImageUVs", "AnalyseMaterialId", "dbo.AnalyseMaterials");
            DropForeignKey("dbo.ImageAnalyses", "AnalyseMaterialId", "dbo.AnalyseMaterials");
            DropIndex("dbo.ImageUVs", new[] { "AnalyseMaterialId" });
            DropIndex("dbo.ImageAnalyses", new[] { "AnalyseMaterialId" });
            DropColumn("dbo.Collaborations", "Order");
            DropTable("dbo.ImageUVs");
            DropTable("dbo.ImageAnalyses");
            DropTable("dbo.AnalyseMaterials");
        }
    }
}
