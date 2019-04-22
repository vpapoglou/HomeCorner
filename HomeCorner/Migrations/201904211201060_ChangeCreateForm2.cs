namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeCreateForm2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Houses", "OwnerName");
            DropColumn("dbo.Houses", "Email");
            DropColumn("dbo.Houses", "PhoneNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Houses", "Email", c => c.String());
            AddColumn("dbo.Houses", "OwnerName", c => c.String());
        }
    }
}
