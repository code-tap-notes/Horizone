namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTypeImage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AllPictures", "TypePictureId", "dbo.TypePictures");
            DropForeignKey("dbo.Manuscripts", "AllPictureId", "dbo.AllPictures");
            DropForeignKey("dbo.PartnerAndRelations", "AllPictureId", "dbo.AllPictures");
            DropIndex("dbo.AllPictures", new[] { "TypePictureId" });
            DropIndex("dbo.Manuscripts", new[] { "AllPictureId" });
            DropIndex("dbo.PartnerAndRelations", new[] { "AllPictureId" });
            CreateTable(
                "dbo.ImageHomes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                        Projet = c.Boolean(nullable: false),
                        Map = c.Boolean(nullable: false),
                        PartnerAndRelation = c.Boolean(nullable: false),
                        Activity = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Manuscripts", "ImageHomeId", c => c.Int(nullable: false));
            AddColumn("dbo.LinkAndPresses", "Press", c => c.Boolean(nullable: false));
            AddColumn("dbo.PartnerAndRelations", "ImageHomeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Manuscripts", "ImageHomeId");
            CreateIndex("dbo.PartnerAndRelations", "ImageHomeId");
            AddForeignKey("dbo.Manuscripts", "ImageHomeId", "dbo.ImageHomes", "Id", cascadeDelete: false);
            AddForeignKey("dbo.PartnerAndRelations", "ImageHomeId", "dbo.ImageHomes", "Id", cascadeDelete: false);
            DropColumn("dbo.Manuscripts", "AllPictureId");
            DropColumn("dbo.PartnerAndRelations", "AllPictureId");
            DropTable("dbo.AllPictures");
            DropTable("dbo.TypePictures");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TypePictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TypeEn = c.String(),
                        TypeFr = c.String(),
                        TypeZh = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AllPictures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UlrPicture = c.String(),
                        Description = c.String(),
                        TypePictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.PartnerAndRelations", "AllPictureId", c => c.Int(nullable: false));
            AddColumn("dbo.Manuscripts", "AllPictureId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PartnerAndRelations", "ImageHomeId", "dbo.ImageHomes");
            DropForeignKey("dbo.Manuscripts", "ImageHomeId", "dbo.ImageHomes");
            DropIndex("dbo.PartnerAndRelations", new[] { "ImageHomeId" });
            DropIndex("dbo.Manuscripts", new[] { "ImageHomeId" });
            DropColumn("dbo.PartnerAndRelations", "ImageHomeId");
            DropColumn("dbo.LinkAndPresses", "Press");
            DropColumn("dbo.Manuscripts", "ImageHomeId");
            DropTable("dbo.ImageHomes");
            CreateIndex("dbo.PartnerAndRelations", "AllPictureId");
            CreateIndex("dbo.Manuscripts", "AllPictureId");
            CreateIndex("dbo.AllPictures", "TypePictureId");
            AddForeignKey("dbo.PartnerAndRelations", "AllPictureId", "dbo.AllPictures", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Manuscripts", "AllPictureId", "dbo.AllPictures", "Id", cascadeDelete: false);
            AddForeignKey("dbo.AllPictures", "TypePictureId", "dbo.TypePictures", "Id", cascadeDelete: false);
        }
    }
}
