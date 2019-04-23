namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeCollaboration : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Clients", "IX_PersonneUnique");
            DropIndex("dbo.Collaborators", "IX_PersonneUnique");
            AddColumn("dbo.Collaborations", "FonctionEn", c => c.String());
            AddColumn("dbo.Collaborations", "FonctionFr", c => c.String());
            AddColumn("dbo.Collaborations", "FonctionZh", c => c.String());
            AddColumn("dbo.Collaborations", "AffiliationFr", c => c.String());
            AddColumn("dbo.Collaborations", "AffiliationEn", c => c.String());
            AddColumn("dbo.Collaborations", "AffiliationZh", c => c.String());
            AlterColumn("dbo.Clients", "Title", c => c.String(maxLength: 20));
            AlterColumn("dbo.Collaborations", "Title", c => c.String(maxLength: 20));
            AlterColumn("dbo.Collaborators", "Title", c => c.String(maxLength: 20));
            CreateIndex("dbo.Clients", new[] { "Title", "LastName", "FirstName" }, unique: true, name: "IX_PersonneUnique");
            CreateIndex("dbo.Collaborators", new[] { "Title", "LastName", "FirstName" }, unique: true, name: "IX_PersonneUnique");
            DropColumn("dbo.Collaborations", "Fonction");
            DropColumn("dbo.Collaborations", "Affiliation");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Collaborations", "Affiliation", c => c.String());
            AddColumn("dbo.Collaborations", "Fonction", c => c.String());
            DropIndex("dbo.Collaborators", "IX_PersonneUnique");
            DropIndex("dbo.Clients", "IX_PersonneUnique");
            AlterColumn("dbo.Collaborators", "Title", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Collaborations", "Title", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Clients", "Title", c => c.String(nullable: false, maxLength: 20));
            DropColumn("dbo.Collaborations", "AffiliationZh");
            DropColumn("dbo.Collaborations", "AffiliationEn");
            DropColumn("dbo.Collaborations", "AffiliationFr");
            DropColumn("dbo.Collaborations", "FonctionZh");
            DropColumn("dbo.Collaborations", "FonctionFr");
            DropColumn("dbo.Collaborations", "FonctionEn");
            CreateIndex("dbo.Collaborators", new[] { "Title", "LastName", "FirstName" }, unique: true, name: "IX_PersonneUnique");
            CreateIndex("dbo.Clients", new[] { "Title", "LastName", "FirstName" }, unique: true, name: "IX_PersonneUnique");
        }
    }
}
