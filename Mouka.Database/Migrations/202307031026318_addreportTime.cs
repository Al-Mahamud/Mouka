namespace Mouka.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addreportTime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reports", "ReportTime", c => c.DateTime(nullable: false, precision: 7, storeType: "datetime2"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reports", "ReportTime");
        }
    }
}
