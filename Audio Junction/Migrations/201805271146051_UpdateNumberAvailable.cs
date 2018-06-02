namespace Audio_Junction.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateNumberAvailable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "NumberAvailable", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "StockAvailability");

            Sql("UPDATE Movies SET NumberAvailable = NumberInStock");

        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "StockAvailability", c => c.Int(nullable: false));
            DropColumn("dbo.Movies", "NumberAvailable");
        }
    }
}
