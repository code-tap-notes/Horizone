namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMap : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps");
            DropIndex("dbo.Manuscripts", new[] { "MapId" });
            AddColumn("dbo.Manuscripts", "MainFindSpot", c => c.String());
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
                        Name = c.String(nullable: false, maxLength: 150),
                        ContentType = c.String(nullable: false, maxLength: 20),
                        Content = c.Binary(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Manuscripts", "MapId", c => c.Int(nullable: false));
            DropColumn("dbo.Manuscripts", "MainFindSpot");
            CreateIndex("dbo.Manuscripts", "MapId");
            AddForeignKey("dbo.Manuscripts", "MapId", "dbo.Maps", "Id", cascadeDelete: true);
        }
    }
}
