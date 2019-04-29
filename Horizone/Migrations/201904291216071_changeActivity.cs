namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeActivity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ImageActivities", "ActivityId", "dbo.Activities");
            DropIndex("dbo.ImageActivities", new[] { "ActivityId" });
            DropTable("dbo.ImageActivities");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ImageActivities", "ActivityId");
            AddForeignKey("dbo.ImageActivities", "ActivityId", "dbo.Activities", "Id", cascadeDelete: true);
        }
    }
}
