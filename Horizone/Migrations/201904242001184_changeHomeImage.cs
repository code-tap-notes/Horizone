namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeHomeImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PartnerAndRelations", "ImageHomeId", "dbo.ImageHomes");
            DropIndex("dbo.PartnerAndRelations", new[] { "ImageHomeId" });
            CreateTable(
                "dbo.HomeDecors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NamePicture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.ImageHomes", "HomeDecorId", c => c.Int(nullable: false));
            CreateIndex("dbo.ImageHomes", "HomeDecorId");
            AddForeignKey("dbo.ImageHomes", "HomeDecorId", "dbo.HomeDecors", "Id", cascadeDelete: false);
            DropColumn("dbo.ImageHomes", "Projet");
            DropColumn("dbo.ImageHomes", "Map");
            DropColumn("dbo.ImageHomes", "PartnerAndRelation");
            DropColumn("dbo.ImageHomes", "Activity");
            DropColumn("dbo.PartnerAndRelations", "ImageHomeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PartnerAndRelations", "ImageHomeId", c => c.Int(nullable: false));
            AddColumn("dbo.ImageHomes", "Activity", c => c.Boolean(nullable: false));
            AddColumn("dbo.ImageHomes", "PartnerAndRelation", c => c.Boolean(nullable: false));
            AddColumn("dbo.ImageHomes", "Map", c => c.Boolean(nullable: false));
            AddColumn("dbo.ImageHomes", "Projet", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.ImageHomes", "HomeDecorId", "dbo.HomeDecors");
            DropIndex("dbo.ImageHomes", new[] { "HomeDecorId" });
            DropColumn("dbo.ImageHomes", "HomeDecorId");
            DropTable("dbo.HomeDecors");
            CreateIndex("dbo.PartnerAndRelations", "ImageHomeId");
            AddForeignKey("dbo.PartnerAndRelations", "ImageHomeId", "dbo.ImageHomes", "Id", cascadeDelete: false);
        }
    }
}
