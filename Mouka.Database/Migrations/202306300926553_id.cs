﻿namespace Mouka.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class id : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Category_ID", "dbo.Categories");
            DropForeignKey("dbo.Products", "User_ID", "dbo.Users");
            DropIndex("dbo.Products", new[] { "Category_ID" });
            DropIndex("dbo.Products", new[] { "User_ID" });
            RenameColumn(table: "dbo.Products", name: "Category_ID", newName: "CategoryId");
            RenameColumn(table: "dbo.Products", name: "User_ID", newName: "UserId");
            AlterColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "CategoryId");
            CreateIndex("dbo.Products", "UserId");
            AddForeignKey("dbo.Products", "CategoryId", "dbo.Categories", "ID", cascadeDelete: true);
            AddForeignKey("dbo.Products", "UserId", "dbo.Users", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.Products", new[] { "UserId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            AlterColumn("dbo.Products", "UserId", c => c.Int());
            AlterColumn("dbo.Products", "CategoryId", c => c.Int());
            RenameColumn(table: "dbo.Products", name: "UserId", newName: "User_ID");
            RenameColumn(table: "dbo.Products", name: "CategoryId", newName: "Category_ID");
            CreateIndex("dbo.Products", "User_ID");
            CreateIndex("dbo.Products", "Category_ID");
            AddForeignKey("dbo.Products", "User_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Products", "Category_ID", "dbo.Categories", "ID");
        }
    }
}
