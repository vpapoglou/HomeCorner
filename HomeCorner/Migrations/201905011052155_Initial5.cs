namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "StartDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Houses", "EndDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Houses", "Availability");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "Availability", c => c.DateTime(nullable: false));
            DropColumn("dbo.Houses", "EndDate");
            DropColumn("dbo.Houses", "StartDate");
        }
    }
}
