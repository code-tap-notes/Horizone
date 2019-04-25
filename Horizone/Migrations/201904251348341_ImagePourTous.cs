namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImagePourTous : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageHomes", "HomeDecorId", "dbo.HomeDecors");
            DropIndex("dbo.ImageHomes", new[] { "HomeDecorId" });
            CreateTable(
                "dbo.ImageProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        AboutProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AboutProjects", t => t.AboutProjectId, cascadeDelete: true)
                .Index(t => t.AboutProjectId);
            
            CreateTable(
                "dbo.ImageActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        ActivityId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Activities", t => t.ActivityId, cascadeDelete: true)
                .Index(t => t.ActivityId);
            
            CreateTable(
                "dbo.ImageMaps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        MapId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Maps", t => t.MapId, cascadeDelete: true)
                .Index(t => t.MapId);
            
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamePicture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ImagePartners",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        PartnerAndRelationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.PartnerAndRelations", t => t.PartnerAndRelationId, cascadeDelete: true)
                .Index(t => t.PartnerAndRelationId);
            
            AddColumn("dbo.Cases", "NameCase", c => c.String());
            AddColumn("dbo.Numbers", "WordNumber", c => c.String());
            AddColumn("dbo.WordClasses", "Class", c => c.String());
            AddColumn("dbo.WordSubClasses", "SubClass", c => c.String());
            DropTable("dbo.HomeDecors");
            DropTable("dbo.ImageHomes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ImageHomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        HomeDecorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.HomeDecors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamePicture = c.String(),
                        Map = c.Boolean(nullable: false),
                        Partner = c.Boolean(nullable: false),
                        Relation = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.ImagePartners", "PartnerAndRelationId", "dbo.PartnerAndRelations");
            DropForeignKey("dbo.ImageMaps", "MapId", "dbo.Maps");
            DropForeignKey("dbo.ImageActivities", "ActivityId", "dbo.Activities");
            DropForeignKey("dbo.ImageProjects", "AboutProjectId", "dbo.AboutProjects");
            DropIndex("dbo.ImagePartners", new[] { "PartnerAndRelationId" });
            DropIndex("dbo.ImageMaps", new[] { "MapId" });
            DropIndex("dbo.ImageActivities", new[] { "ActivityId" });
            DropIndex("dbo.ImageProjects", new[] { "AboutProjectId" });
            DropColumn("dbo.WordSubClasses", "SubClass");
            DropColumn("dbo.WordClasses", "Class");
            DropColumn("dbo.Numbers", "WordNumber");
            DropColumn("dbo.Cases", "NameCase");
            DropTable("dbo.ImagePartners");
            DropTable("dbo.Maps");
            DropTable("dbo.ImageMaps");
            DropTable("dbo.ImageActivities");
            DropTable("dbo.ImageProjects");
            CreateIndex("dbo.ImageHomes", "HomeDecorId");
            AddForeignKey("dbo.ImageHomes", "HomeDecorId", "dbo.HomeDecors", "Id", cascadeDelete: true);
        }
    }
}
