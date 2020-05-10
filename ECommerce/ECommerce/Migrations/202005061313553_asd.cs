namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "ShoppingDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "Gender", c => c.Int(nullable: false));
            DropColumn("dbo.OrderDetails", "ShoppingDate");
        }
    }
}