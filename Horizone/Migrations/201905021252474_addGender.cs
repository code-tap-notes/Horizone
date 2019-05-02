namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AnalyseMacroscopics", "GenderId", c => c.Int(nullable: false));
            CreateIndex("dbo.AnalyseMacroscopics", "GenderId");
            AddForeignKey("dbo.AnalyseMacroscopics", "GenderId", "dbo.Genders", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnalyseMacroscopics", "GenderId", "dbo.Genders");
            DropIndex("dbo.AnalyseMacroscopics", new[] { "GenderId" });
            DropColumn("dbo.AnalyseMacroscopics", "GenderId");
        }
    }
}
