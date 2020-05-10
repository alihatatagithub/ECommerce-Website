namespace ECommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsa : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.OrderDetails", name: "ProductID", newName: "ProID");
            RenameIndex(table: "dbo.OrderDetails", name: "IX_ProductID", newName: "IX_ProID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.OrderDetails", name: "IX_ProID", newName: "IX_ProductID");
            RenameColumn(table: "dbo.OrderDetails", name: "ProID", newName: "ProductID");
        }
    }
}
