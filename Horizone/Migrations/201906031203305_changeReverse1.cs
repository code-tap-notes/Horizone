namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeReverse1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReverseDictionaries", "ReverseWord", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReverseDictionaries", "ReverseWord");
        }
    }
}
