namespace SportsStore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateTimeMigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Carts", name: "OrderDate", newName: "datetime2");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Carts", name: "datetime2", newName: "OrderDate");
        }
    }
}
