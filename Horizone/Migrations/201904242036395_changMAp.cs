namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changMAp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Manuscripts", "ImageHomeId", "dbo.ImageHomes");
            DropIndex("dbo.Manuscripts", new[] { "ImageHomeId" });
            CreateTable(
                "dbo.Maps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Manuscripts", "MapId", c => c.Int(nullable: false));
            CreateIndex("dbo.Manuscripts", "MapId");
            AddForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps", "Id", cascadeDelete: false);
            DropColumn("dbo.Manuscripts", "ImageHomeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Manuscripts", "ImageHomeId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps");
            DropIndex("dbo.Manuscripts", new[] { "MapId" });
            DropColumn("dbo.Manuscripts", "MapId");
            DropTable("dbo.Maps");
            CreateIndex("dbo.Manuscripts", "ImageHomeId");
            AddForeignKey("dbo.Manuscripts", "ImageHomeId", "dbo.ImageHomes", "Id", cascadeDelete: false);
        }
    }
}
