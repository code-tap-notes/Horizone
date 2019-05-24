namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAbreDictionary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AbbreviationDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Symbol = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AbbreviationDictionaries");
        }
    }
}
