namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddcolumeGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genders", "NameGender", c => c.String());
            AddColumn("dbo.People", "ConjugatedPerson", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.People", "ConjugatedPerson");
            DropColumn("dbo.Genders", "NameGender");
        }
    }
}
