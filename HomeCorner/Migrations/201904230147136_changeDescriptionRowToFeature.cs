namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeDescriptionRowToFeature : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Features", "Feature", c => c.String());
            DropColumn("dbo.Features", "Description");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Features", "Description", c => c.String());
            DropColumn("dbo.Features", "Feature");
        }
    }
}
