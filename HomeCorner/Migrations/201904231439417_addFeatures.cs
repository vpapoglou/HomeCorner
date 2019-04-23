namespace HomeCorner.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFeatures : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Features (Id, Feature) VALUES (0, 'Garden')");
            Sql("INSERT INTO Features (Id, Feature) VALUES (1, 'Pool')");
            Sql("INSERT INTO Features (Id, Feature) VALUES (2, 'Parking')");
            Sql("INSERT INTO Features (Id, Feature) VALUES (4, 'View')");
        }
        
        public override void Down()
        {
        }
    }
}
