namespace SportsStore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StartMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        OrderDate = c.DateTime(),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Delivery_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Deliveries", t => t.Delivery_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Delivery_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Deliveries",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DeliveryPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        City = c.String(),
                        Street = c.String(),
                        HomeNumber = c.String(),
                        Appartment = c.String(),
                        PostIndex = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Surname = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Logname = c.String(),
                        IsAdmin = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Percentage = c.Int(nullable: false),
                        BeginDate = c.DateTime(),
                        EndDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Source = c.String(),
                        Product_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Product_Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Category_Id = c.String(maxLength: 128),
                        Discount_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .ForeignKey("dbo.Discounts", t => t.Discount_Id)
                .Index(t => t.Category_Id)
                .Index(t => t.Discount_Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Comment = c.String(),
                        Score = c.Int(nullable: false),
                        DateTime = c.String(),
                        Product_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UnitCarts",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Quantity = c.Int(nullable: false),
                        Cart_Id = c.String(maxLength: 128),
                        Product_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Carts", t => t.Cart_Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .Index(t => t.Cart_Id)
                .Index(t => t.Product_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UnitCarts", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.UnitCarts", "Cart_Id", "dbo.Carts");
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Images", "Product_Id", "dbo.Products");
            DropForeignKey("dbo.Products", "Discount_Id", "dbo.Discounts");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Carts", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Carts", "Delivery_Id", "dbo.Deliveries");
            DropIndex("dbo.UnitCarts", new[] { "Product_Id" });
            DropIndex("dbo.UnitCarts", new[] { "Cart_Id" });
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropIndex("dbo.Reviews", new[] { "Product_Id" });
            DropIndex("dbo.Products", new[] { "Discount_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Images", new[] { "Product_Id" });
            DropIndex("dbo.Carts", new[] { "User_Id" });
            DropIndex("dbo.Carts", new[] { "Delivery_Id" });
            DropTable("dbo.UnitCarts");
            DropTable("dbo.Reviews");
            DropTable("dbo.Products");
            DropTable("dbo.Images");
            DropTable("dbo.Discounts");
            DropTable("dbo.Categories");
            DropTable("dbo.Users");
            DropTable("dbo.Deliveries");
            DropTable("dbo.Carts");
        }
    }
}
