namespace Mouka.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addphoneNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "PhoneNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "PhoneNumber");
        }
    }
}
