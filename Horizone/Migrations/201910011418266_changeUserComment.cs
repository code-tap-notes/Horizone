namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeUserComment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "UserId", "dbo.Users");
            DropIndex("dbo.Comments", new[] { "UserId" });
            AddColumn("dbo.Comments", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "ClientId");
            AddForeignKey("dbo.Comments", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
            DropColumn("dbo.Comments", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.Comments", "ClientId", "dbo.Clients");
            DropIndex("dbo.Comments", new[] { "ClientId" });
            DropColumn("dbo.Comments", "ClientId");
            CreateIndex("dbo.Comments", "UserId");
            AddForeignKey("dbo.Comments", "UserId", "dbo.Users", "Id");
        }
    }
}
