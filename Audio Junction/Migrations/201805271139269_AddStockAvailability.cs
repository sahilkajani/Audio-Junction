namespace Audio_Junction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStockAvailability : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "StockAvailability", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "StockAvailability");
        }
    }
}
