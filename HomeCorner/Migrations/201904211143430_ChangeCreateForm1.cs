namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCreateForm1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Houses", "Title", c => c.String());
            AddColumn("dbo.Houses", "Description", c => c.String());
            AddColumn("dbo.Houses", "PostalCode", c => c.Int(nullable: false));
            AddColumn("dbo.Houses", "Occupancy", c => c.Int(nullable: false));
            AddColumn("dbo.Houses", "Availability", c => c.DateTime(nullable: false));
            AddColumn("dbo.Houses", "OwnerName", c => c.String());
            AddColumn("dbo.Houses", "Email", c => c.String());
            AddColumn("dbo.Houses", "PhoneNumber", c => c.Int(nullable: false));
            DropColumn("dbo.Houses", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "Name", c => c.String());
            DropColumn("dbo.Houses", "PhoneNumber");
            DropColumn("dbo.Houses", "Email");
            DropColumn("dbo.Houses", "OwnerName");
            DropColumn("dbo.Houses", "Availability");
            DropColumn("dbo.Houses", "Occupancy");
            DropColumn("dbo.Houses", "PostalCode");
            DropColumn("dbo.Houses", "Description");
            DropColumn("dbo.Houses", "Title");
        }
    }
}
