namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class connectingFeaturesHouses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FeaturesHouses",
                c => new
                    {
                        Features_Id = c.Byte(nullable: false),
                        House_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Features_Id, t.House_Id })
                .ForeignKey("dbo.Features", t => t.Features_Id, cascadeDelete: true)
                .ForeignKey("dbo.Houses", t => t.House_Id, cascadeDelete: true)
                .Index(t => t.Features_Id)
                .Index(t => t.House_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FeaturesHouses", "House_Id", "dbo.Houses");
            DropForeignKey("dbo.FeaturesHouses", "Features_Id", "dbo.Features");
            DropIndex("dbo.FeaturesHouses", new[] { "House_Id" });
            DropIndex("dbo.FeaturesHouses", new[] { "Features_Id" });
            DropTable("dbo.FeaturesHouses");
            DropTable("dbo.Features");
        }
    }
}
