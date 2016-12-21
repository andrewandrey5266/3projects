namespace SportsStore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserReviewMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Comment = c.String(),
                        Score = c.Int(nullable: false),
                        Product_Id = c.String(maxLength: 128),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.Product_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Product_Id)
                .Index(t => t.User_Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Reviews", "Product_Id", "dbo.Products");
            DropIndex("dbo.Reviews", new[] { "User_Id" });
            DropIndex("dbo.Reviews", new[] { "Product_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Reviews");
        }
    }
}
