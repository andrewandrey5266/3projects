namespace SportsStore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        CartID = c.Int(nullable: false, identity: true),
                        OrderDate = c.DateTime(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserID = c.Int(nullable: false),
                        DeliveryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CartID);
            
            CreateTable(
                "dbo.UnitCarts",
                c => new
                    {
                        ProductID = c.Int(nullable: false),
                        CartID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductID, t.CartID })
                .ForeignKey("dbo.Carts", t => t.CartID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID)
                .Index(t => t.CartID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnitCarts", "ProductID", "dbo.Products");
            DropForeignKey("dbo.UnitCarts", "CartID", "dbo.Carts");
            DropIndex("dbo.UnitCarts", new[] { "CartID" });
            DropIndex("dbo.UnitCarts", new[] { "ProductID" });
            DropTable("dbo.UnitCarts");
            DropTable("dbo.Carts");
        }
    }
}
