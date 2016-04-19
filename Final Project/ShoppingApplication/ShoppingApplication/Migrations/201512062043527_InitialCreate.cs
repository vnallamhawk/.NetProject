namespace ShoppingApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerId = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        mobile = c.String(),
                        email = c.String(),
                        address = c.String(),
                        city = c.String(),
                    })
                .PrimaryKey(t => t.customerId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        orderId = c.Int(nullable: false, identity: true),
                        orderDate = c.DateTime(nullable: false),
                        Custid = c.Int(nullable: false),
                        OStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.orderId)
                .ForeignKey("dbo.OrderStatus", t => t.OStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.Custid, cascadeDelete: true)
                .Index(t => t.Custid)
                .Index(t => t.OStatusId);
            
            CreateTable(
                "dbo.OrderStatus",
                c => new
                    {
                        OrderStatusId = c.Int(nullable: false, identity: true),
                        status = c.String(),
                    })
                .PrimaryKey(t => t.OrderStatusId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        productId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        type = c.String(),
                        price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.productId);
            
            CreateTable(
                "dbo.OrderProducts ",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Custid", "dbo.Customers");
            DropForeignKey("dbo.OrderProducts ", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderProducts ", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "OStatusId", "dbo.OrderStatus");
            DropIndex("dbo.OrderProducts ", new[] { "ProductId" });
            DropIndex("dbo.OrderProducts ", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "OStatusId" });
            DropIndex("dbo.Orders", new[] { "Custid" });
            DropTable("dbo.OrderProducts ");
            DropTable("dbo.Products");
            DropTable("dbo.OrderStatus");
            DropTable("dbo.Orders");
            DropTable("dbo.Customers");
        }
    }
}
