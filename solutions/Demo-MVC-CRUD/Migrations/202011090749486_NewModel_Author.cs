namespace Demo_MVC_CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModel_Author : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "AuthorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            DropColumn("dbo.Books", "Author");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false));
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropColumn("dbo.Books", "AuthorId");
            DropTable("dbo.Authors");
        }
    }
}
