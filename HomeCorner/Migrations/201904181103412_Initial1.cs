namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Houses", "Name", c => c.String());
            AlterColumn("dbo.Houses", "Region", c => c.String());
            AlterColumn("dbo.Houses", "Address", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Houses", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "Region", c => c.String(nullable: false));
            AlterColumn("dbo.Houses", "Name", c => c.String(nullable: false));
        }
    }
}
