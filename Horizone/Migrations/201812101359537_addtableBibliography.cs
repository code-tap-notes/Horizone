namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableBibliography : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bibliographies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Author = c.String(maxLength: 40),
                        PublicationDate = c.String(maxLength: 10),
                        Title = c.String(maxLength: 100),
                        UlrBibliography = c.String(maxLength: 40),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AboutUs = c.String(maxLength: 250),
                        Contact = c.String(maxLength: 50),
                        Title = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MainContents");
            DropTable("dbo.Bibliographies");
        }
    }
}
