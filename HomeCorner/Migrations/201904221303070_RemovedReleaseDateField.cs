namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovedReleaseDateField : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Houses", "ReleaseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
