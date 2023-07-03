namespace Mouka.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createtime2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CreateTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CreateTime", c => c.DateTime(nullable: false));
        }
    }
}
