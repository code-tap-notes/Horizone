namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeReserveDict : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReverseDictionaries", "DictionaryTocharianId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReverseDictionaries", "DictionaryTocharianId");
            AddForeignKey("dbo.ReverseDictionaries", "DictionaryTocharianId", "dbo.DictionaryTocharians", "Id", cascadeDelete: true);
            DropColumn("dbo.ReverseDictionaries", "English");
            DropColumn("dbo.ReverseDictionaries", "Francaise");
            DropColumn("dbo.ReverseDictionaries", "German");
            DropColumn("dbo.ReverseDictionaries", "Latin");
            DropColumn("dbo.ReverseDictionaries", "Chinese");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReverseDictionaries", "Chinese", c => c.String());
            AddColumn("dbo.ReverseDictionaries", "Latin", c => c.String());
            AddColumn("dbo.ReverseDictionaries", "German", c => c.String());
            AddColumn("dbo.ReverseDictionaries", "Francaise", c => c.String());
            AddColumn("dbo.ReverseDictionaries", "English", c => c.String());
            DropForeignKey("dbo.ReverseDictionaries", "DictionaryTocharianId", "dbo.DictionaryTocharians");
            DropIndex("dbo.ReverseDictionaries", new[] { "DictionaryTocharianId" });
            DropColumn("dbo.ReverseDictionaries", "DictionaryTocharianId");
        }
    }
}
