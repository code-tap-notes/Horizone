namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeTableMap : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps");
            DropIndex("dbo.Manuscripts", new[] { "MapId" });
            CreateTable(
                "dbo.Abreviations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        DescriptionEn = c.String(),
                        DescriptionFr = c.String(),
                        DescriptionZh = c.String(),
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
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TypePictures", t => t.TypePictureId, cascadeDelete: false)
                .Index(t => t.TypePictureId);
            
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
                "dbo.PartnerAndRelations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Partner = c.Boolean(nullable: false),
                        Relation = c.Boolean(nullable: false),
                        Order = c.Int(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        AllPictureId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AllPictures", t => t.AllPictureId, cascadeDelete: false)
                .Index(t => t.AllPictureId);
            
            AddColumn("dbo.Manuscripts", "AllPictureId", c => c.Int(nullable: false));
            CreateIndex("dbo.Manuscripts", "AllPictureId");
            AddForeignKey("dbo.Manuscripts", "AllPictureId", "dbo.AllPictures", "Id", cascadeDelete: false);
            DropColumn("dbo.Manuscripts", "MapId");
            DropTable("dbo.Maps");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        UlrMap = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Manuscripts", "MapId", c => c.Int(nullable: false));
            DropForeignKey("dbo.PartnerAndRelations", "AllPictureId", "dbo.AllPictures");
            DropForeignKey("dbo.Manuscripts", "AllPictureId", "dbo.AllPictures");
            DropForeignKey("dbo.AllPictures", "TypePictureId", "dbo.TypePictures");
            DropIndex("dbo.PartnerAndRelations", new[] { "AllPictureId" });
            DropIndex("dbo.Manuscripts", new[] { "AllPictureId" });
            DropIndex("dbo.AllPictures", new[] { "TypePictureId" });
            DropColumn("dbo.Manuscripts", "AllPictureId");
            DropTable("dbo.PartnerAndRelations");
            DropTable("dbo.TypePictures");
            DropTable("dbo.AllPictures");
            DropTable("dbo.Abreviations");
            CreateIndex("dbo.Manuscripts", "MapId");
            AddForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps", "Id", cascadeDelete: false);
        }
    }
}
