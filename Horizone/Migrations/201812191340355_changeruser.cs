namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeruser : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clients", "IX_PersonneUnique");
            DropIndex("dbo.Colaborateurs", "IX_PersonneUnique");
            CreateIndex("dbo.Clients", new[] { "Title", "LastName", "FisrtName" }, unique: true, name: "IX_PersonneUnique");
            CreateIndex("dbo.Colaborateurs", new[] { "Title", "LastName", "FisrtName" }, unique: true, name: "IX_PersonneUnique");
            DropColumn("dbo.Clients", "Address");
            DropColumn("dbo.Clients", "BirthDate");
            DropColumn("dbo.Colaborateurs", "Address");
            DropColumn("dbo.Colaborateurs", "BirthDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Colaborateurs", "BirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Colaborateurs", "Address", c => c.String(nullable: false, maxLength: 60));
            AddColumn("dbo.Clients", "BirthDate", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
            AddColumn("dbo.Clients", "Address", c => c.String(nullable: false, maxLength: 60));
            DropIndex("dbo.Colaborateurs", "IX_PersonneUnique");
            DropIndex("dbo.Clients", "IX_PersonneUnique");
            CreateIndex("dbo.Colaborateurs", new[] { "Title", "LastName", "FisrtName", "Address" }, unique: true, name: "IX_PersonneUnique");
            CreateIndex("dbo.Clients", new[] { "Title", "LastName", "FisrtName", "Address" }, unique: true, name: "IX_PersonneUnique");
        }
    }
}
