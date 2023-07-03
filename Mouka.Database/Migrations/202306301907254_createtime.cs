namespace Mouka.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "CreateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "CreateTime");
        }
    }
}
