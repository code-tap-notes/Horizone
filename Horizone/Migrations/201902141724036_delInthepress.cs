namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delInthepress : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.InThePresses", "LanguageId", "dbo.Languages");
            DropIndex("dbo.InThePresses", new[] { "LanguageId" });
            AlterColumn("dbo.LayoutManuscripts", "RulingDetail", c => c.String(maxLength: 40));
            AlterColumn("dbo.LayoutManuscripts", "StringholeHeight", c => c.String(maxLength: 40));
            AlterColumn("dbo.LayoutManuscripts", "StringholeWidth", c => c.String(maxLength: 40));
            AlterColumn("dbo.LayoutManuscripts", "DistanceStringholeRight", c => c.String(maxLength: 40));
            AlterColumn("dbo.LayoutManuscripts", "DistanceStringholeLeft", c => c.String(maxLength: 40));
            AlterColumn("dbo.LayoutManuscripts", "InterruptedLine", c => c.String(maxLength: 40));
            DropTable("dbo.InThePresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.InThePresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        LinkThePresse = c.String(maxLength: 200),
                        LanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.LayoutManuscripts", "InterruptedLine", c => c.Int(nullable: false));
            AlterColumn("dbo.LayoutManuscripts", "DistanceStringholeLeft", c => c.Int(nullable: false));
            AlterColumn("dbo.LayoutManuscripts", "DistanceStringholeRight", c => c.Int(nullable: false));
            AlterColumn("dbo.LayoutManuscripts", "StringholeWidth", c => c.Int(nullable: false));
            AlterColumn("dbo.LayoutManuscripts", "StringholeHeight", c => c.Int(nullable: false));
            AlterColumn("dbo.LayoutManuscripts", "RulingDetail", c => c.Int(nullable: false));
            CreateIndex("dbo.InThePresses", "LanguageId");
            AddForeignKey("dbo.InThePresses", "LanguageId", "dbo.Languages", "Id", cascadeDelete: true);
        }
    }
}
