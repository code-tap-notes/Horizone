namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeWord : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.NounAdjectives", "WordClassId", c => c.Int(nullable: false));
            AddColumn("dbo.NounAdjectives", "WordSubClassId", c => c.Int(nullable: false));
            AddColumn("dbo.OtherWords", "WordClassId", c => c.Int(nullable: false));
            AddColumn("dbo.OtherWords", "WordSubClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Pronouns", "WordClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Pronouns", "WordSubClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Verbs", "WordClassId", c => c.Int(nullable: false));
            AddColumn("dbo.Verbs", "WordSubClassId", c => c.Int(nullable: false));
            CreateIndex("dbo.NounAdjectives", "WordClassId");
            CreateIndex("dbo.NounAdjectives", "WordSubClassId");
            CreateIndex("dbo.OtherWords", "WordClassId");
            CreateIndex("dbo.OtherWords", "WordSubClassId");
            CreateIndex("dbo.Pronouns", "WordClassId");
            CreateIndex("dbo.Pronouns", "WordSubClassId");
            CreateIndex("dbo.Verbs", "WordClassId");
            CreateIndex("dbo.Verbs", "WordSubClassId");
            AddForeignKey("dbo.NounAdjectives", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.NounAdjectives", "WordSubClassId", "dbo.WordSubClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OtherWords", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.OtherWords", "WordSubClassId", "dbo.WordSubClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Pronouns", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Pronouns", "WordSubClassId", "dbo.WordSubClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Verbs", "WordClassId", "dbo.WordClasses", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Verbs", "WordSubClassId", "dbo.WordSubClasses", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Verbs", "WordSubClassId", "dbo.WordSubClasses");
            DropForeignKey("dbo.Verbs", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.Pronouns", "WordSubClassId", "dbo.WordSubClasses");
            DropForeignKey("dbo.Pronouns", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.OtherWords", "WordSubClassId", "dbo.WordSubClasses");
            DropForeignKey("dbo.OtherWords", "WordClassId", "dbo.WordClasses");
            DropForeignKey("dbo.NounAdjectives", "WordSubClassId", "dbo.WordSubClasses");
            DropForeignKey("dbo.NounAdjectives", "WordClassId", "dbo.WordClasses");
            DropIndex("dbo.Verbs", new[] { "WordSubClassId" });
            DropIndex("dbo.Verbs", new[] { "WordClassId" });
            DropIndex("dbo.Pronouns", new[] { "WordSubClassId" });
            DropIndex("dbo.Pronouns", new[] { "WordClassId" });
            DropIndex("dbo.OtherWords", new[] { "WordSubClassId" });
            DropIndex("dbo.OtherWords", new[] { "WordClassId" });
            DropIndex("dbo.NounAdjectives", new[] { "WordSubClassId" });
            DropIndex("dbo.NounAdjectives", new[] { "WordClassId" });
            DropColumn("dbo.Verbs", "WordSubClassId");
            DropColumn("dbo.Verbs", "WordClassId");
            DropColumn("dbo.Pronouns", "WordSubClassId");
            DropColumn("dbo.Pronouns", "WordClassId");
            DropColumn("dbo.OtherWords", "WordSubClassId");
            DropColumn("dbo.OtherWords", "WordClassId");
            DropColumn("dbo.NounAdjectives", "WordSubClassId");
            DropColumn("dbo.NounAdjectives", "WordClassId");
        }
    }
}
