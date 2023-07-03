namespace Mouka.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "postTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "postTime");
        }
    }
}
