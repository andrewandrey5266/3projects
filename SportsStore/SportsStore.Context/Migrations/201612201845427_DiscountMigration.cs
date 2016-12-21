namespace SportsStore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DiscountMigration : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.Products", "Discount_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Products", "Discount_Id");
            AddForeignKey("dbo.Products", "Discount_Id", "dbo.Discounts", "Id");
            DropColumn("dbo.Products", "DiscountID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "DiscountID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Products", "Discount_Id", "dbo.Discounts");
            DropIndex("dbo.Products", new[] { "Discount_Id" });
            DropColumn("dbo.Products", "Discount_Id");
            DropTable("dbo.Discounts");
        }
    }
}
