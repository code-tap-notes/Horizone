namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeHomeDecor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HomeDecors", "Map", c => c.Boolean(nullable: false));
            AddColumn("dbo.HomeDecors", "Partner", c => c.Boolean(nullable: false));
            AddColumn("dbo.HomeDecors", "Relation", c => c.Boolean(nullable: false));
            AddColumn("dbo.HomeDecors", "Order", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.HomeDecors", "Order");
            DropColumn("dbo.HomeDecors", "Relation");
            DropColumn("dbo.HomeDecors", "Partner");
            DropColumn("dbo.HomeDecors", "Map");
        }
    }
}
