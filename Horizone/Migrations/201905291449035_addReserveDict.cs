namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReserveDict : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReverseDictionaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Word = c.String(nullable: false),
                        English = c.String(),
                        Francaise = c.String(),
                        German = c.String(),
                        Latin = c.String(),
                        Chinese = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ReverseDictionaries");
        }
    }
}
