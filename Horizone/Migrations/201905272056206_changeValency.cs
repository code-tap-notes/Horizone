namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeValency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Valencies", "ValencyFr", c => c.String());
            DropColumn("dbo.Valencies", "ValenceFr");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Valencies", "ValenceFr", c => c.String());
            DropColumn("dbo.Valencies", "ValencyFr");
        }
    }
}
