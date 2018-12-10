namespace Horizone.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changencoreBibliography : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bibliographies", "Author", c => c.String(maxLength: 150));
            AlterColumn("dbo.Bibliographies", "Title", c => c.String(maxLength: 500));
            AlterColumn("dbo.Bibliographies", "Journal", c => c.String(maxLength: 500));
            AlterColumn("dbo.Bibliographies", "UlrBibliography", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bibliographies", "UlrBibliography", c => c.String(maxLength: 250));
            AlterColumn("dbo.Bibliographies", "Journal", c => c.String(maxLength: 250));
            AlterColumn("dbo.Bibliographies", "Title", c => c.String(maxLength: 250));
            AlterColumn("dbo.Bibliographies", "Author", c => c.String(maxLength: 50));
        }
    }
}
