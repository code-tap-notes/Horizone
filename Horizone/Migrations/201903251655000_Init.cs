namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Topics", "LanguageId", "dbo.Languages");
            DropIndex("dbo.Topics", new[] { "LanguageId" });
            AddColumn("dbo.Activities", "TopicId", c => c.Int(nullable: false));
            AddColumn("dbo.Topics", "TopicEn", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Topics", "TopicFr", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Topics", "TopicZh", c => c.String(nullable: false, maxLength: 40));
            AddColumn("dbo.Topics", "Activity", c => c.Boolean(nullable: false));
            AddColumn("dbo.Topics", "News", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Activities", "TopicId");
            AddForeignKey("dbo.Activities", "TopicId", "dbo.Topics", "Id", cascadeDelete: false);
            DropColumn("dbo.Topics", "TopicName");
            DropColumn("dbo.Topics", "LanguageId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Topics", "LanguageId", c => c.Int(nullable: false));
            AddColumn("dbo.Topics", "TopicName", c => c.String(nullable: false, maxLength: 40));
            DropForeignKey("dbo.Activities", "TopicId", "dbo.Topics");
            DropIndex("dbo.Activities", new[] { "TopicId" });
            DropColumn("dbo.Topics", "News");
            DropColumn("dbo.Topics", "Activity");
            DropColumn("dbo.Topics", "TopicZh");
            DropColumn("dbo.Topics", "TopicFr");
            DropColumn("dbo.Topics", "TopicEn");
            DropColumn("dbo.Activities", "TopicId");
            CreateIndex("dbo.Topics", "LanguageId");
            AddForeignKey("dbo.Topics", "LanguageId", "dbo.Languages", "Id", cascadeDelete: false);
        }
    }
}
