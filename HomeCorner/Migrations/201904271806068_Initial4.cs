namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Regions",
                c => new
                    {
                        RegionId = c.Byte(nullable: false),
                        RegionName = c.String(),
                    })
                .PrimaryKey(t => t.RegionId);
            
            AddColumn("dbo.Houses", "RegionId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Houses", "RegionId");
            AddForeignKey("dbo.Houses", "RegionId", "dbo.Regions", "RegionId", cascadeDelete: true);
            DropColumn("dbo.Houses", "Region");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Houses", "Region", c => c.String());
            DropForeignKey("dbo.Houses", "RegionId", "dbo.Regions");
            DropIndex("dbo.Houses", new[] { "RegionId" });
            DropColumn("dbo.Houses", "RegionId");
            DropTable("dbo.Regions");
        }
    }
}
