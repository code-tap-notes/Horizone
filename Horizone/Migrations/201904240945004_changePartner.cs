namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changePartner : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PartnerAndRelations", "Description", c => c.String());
            AddColumn("dbo.PartnerAndRelations", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.PartnerAndRelations", "Link");
            DropColumn("dbo.PartnerAndRelations", "Description");
        }
    }
}
