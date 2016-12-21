namespace SportsStore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteAddressMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Deliveries", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropIndex("dbo.Deliveries", new[] { "Address_Id" });
            DropIndex("dbo.Products", new[] { "Category_Id" });
            AddColumn("dbo.Deliveries", "DeliveryPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Deliveries", "City", c => c.String());
            AddColumn("dbo.Deliveries", "Street", c => c.String());
            AddColumn("dbo.Deliveries", "HomeNumber", c => c.String());
            AddColumn("dbo.Deliveries", "Appartment", c => c.String());
            AddColumn("dbo.Deliveries", "PostIndex", c => c.String());
            AddColumn("dbo.Deliveries", "Cart_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.Products", "Description", c => c.String());
            AlterColumn("dbo.Products", "Category_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Deliveries", "Cart_Id");
            CreateIndex("dbo.Products", "Category_Id");
            AddForeignKey("dbo.Deliveries", "Cart_Id", "dbo.Carts", "Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id");
            DropColumn("dbo.Deliveries", "Price");
            DropColumn("dbo.Deliveries", "Address_Id");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Country = c.String(),
                        City = c.String(),
                        LocalDepartment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Deliveries", "Address_Id", c => c.String(maxLength: 128));
            AddColumn("dbo.Deliveries", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropForeignKey("dbo.Products", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Deliveries", "Cart_Id", "dbo.Carts");
            DropIndex("dbo.Products", new[] { "Category_Id" });
            DropIndex("dbo.Deliveries", new[] { "Cart_Id" });
            AlterColumn("dbo.Products", "Category_Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Products", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Deliveries", "Cart_Id");
            DropColumn("dbo.Deliveries", "PostIndex");
            DropColumn("dbo.Deliveries", "Appartment");
            DropColumn("dbo.Deliveries", "HomeNumber");
            DropColumn("dbo.Deliveries", "Street");
            DropColumn("dbo.Deliveries", "City");
            DropColumn("dbo.Deliveries", "DeliveryPrice");
            CreateIndex("dbo.Products", "Category_Id");
            CreateIndex("dbo.Deliveries", "Address_Id");
            AddForeignKey("dbo.Products", "Category_Id", "dbo.Categories", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Deliveries", "Address_Id", "dbo.Addresses", "Id");
        }
    }
}
