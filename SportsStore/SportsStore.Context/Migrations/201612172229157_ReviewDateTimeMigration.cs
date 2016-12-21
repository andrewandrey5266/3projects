namespace SportsStore.Context.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReviewDateTimeMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reviews", "DateTime", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reviews", "DateTime");
        }
    }
}
