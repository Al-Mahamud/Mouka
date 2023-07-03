namespace Mouka.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ImageURL = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        ImageURL = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                        Category_ID = c.Int(),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Categories", t => t.Category_ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.Category_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                        City = c.String(),
                        Location = c.String(),
                        ImageURL = c.String(),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Categories", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "User_ID" });
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropIndex("dbo.Categories", new[] { "User_ID" });
            DropTable("dbo.Users");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
