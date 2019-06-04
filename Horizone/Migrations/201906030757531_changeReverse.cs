namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeReverse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReverseDictionaries", "DictionaryTocharianId", "dbo.DictionaryTocharians");
            DropIndex("dbo.ReverseDictionaries", new[] { "DictionaryTocharianId" });
            DropColumn("dbo.ReverseDictionaries", "DictionaryTocharianId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReverseDictionaries", "DictionaryTocharianId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReverseDictionaries", "DictionaryTocharianId");
            AddForeignKey("dbo.ReverseDictionaries", "DictionaryTocharianId", "dbo.DictionaryTocharians", "Id", cascadeDelete: true);
        }
    }
}
