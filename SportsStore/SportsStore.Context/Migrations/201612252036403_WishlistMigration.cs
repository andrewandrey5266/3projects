namespace SportsStore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WishlistMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "InStock", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "InStock");
        }
    }
}
