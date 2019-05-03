namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageBytes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Images", "byteImage", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Images", "byteImage");
        }
    }
}
