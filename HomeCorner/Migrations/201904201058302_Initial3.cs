namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Houses", "OwnerId");
            AddForeignKey("dbo.Houses", "OwnerId", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Houses", "OwnerId", "dbo.Customers");
            DropIndex("dbo.Houses", new[] { "OwnerId" });
        }
    }
}
