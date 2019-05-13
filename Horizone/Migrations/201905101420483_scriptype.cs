namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scriptype : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ScriptTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameType = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Scripts", "ScriptTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Scripts", "ScriptTypeId");
            AddForeignKey("dbo.Scripts", "ScriptTypeId", "dbo.ScriptTypes", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Scripts", "ScriptTypeId", "dbo.ScriptTypes");
            DropIndex("dbo.Scripts", new[] { "ScriptTypeId" });
            DropColumn("dbo.Scripts", "ScriptTypeId");
            DropTable("dbo.ScriptTypes");
        }
    }
}
