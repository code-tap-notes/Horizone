namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changesWordSubclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WordSubClasses", "WordClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.WordSubClasses", "WordClassId");
            AddForeignKey("dbo.WordSubClasses", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WordSubClasses", "WordClassId", "dbo.WordClasses");
            DropIndex("dbo.WordSubClasses", new[] { "WordClassId" });
            DropColumn("dbo.WordSubClasses", "WordClassId");
        }
    }
}
