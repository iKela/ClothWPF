namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _new : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArrivalProducts",
                c => new
                    {
                        IdArrivalProduct = c.String(nullable: false, maxLength: 128),
                        Count = c.Double(),
                        PriceDollar = c.Double(),
                        PriceUah = c.Double(),
                        PriceRetail = c.Double(),
                        PriceWholesale = c.Double(),
                        ManufactureDate = c.DateTime(nullable: false),
                        Idarrival = c.Int(nullable: false),
                        Idproduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdArrivalProduct)
                .ForeignKey("dbo.Arrivals", t => t.Idarrival, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Idproduct, cascadeDelete: true)
                .Index(t => t.Idarrival)
                .Index(t => t.Idproduct);
            
            CreateTable(
                "dbo.Arrivals",
                c => new
                    {
                        IdArrival = c.Int(nullable: false, identity: true),
                        Number = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        SupplierInvoice = c.String(),
                        PaymentType = c.String(),
                        Currency = c.String(),
                        TotalPurchase = c.Double(nullable: false),
                        Comment = c.String(),
                        IdSupplier = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdArrival)
                .ForeignKey("dbo.Suppliers", t => t.IdSupplier, cascadeDelete: true)
                .Index(t => t.IdSupplier);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        IdSupplier = c.Int(nullable: false, identity: true),
                        NameSupplier = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        AdressSupplier = c.String(maxLength: 69),
                        NumberSupplier = c.String(maxLength: 60),
                        Email = c.String(maxLength: 50),
                        Region = c.String(maxLength: 50),
                        Currency = c.String(),
                    })
                .PrimaryKey(t => t.IdSupplier);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        IdProduct = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                        Article = c.String(),
                        Code = c.String(),
                        Count = c.Double(),
                        PriceDollar = c.Double(),
                        PriceUah = c.Double(),
                        PriceRetail = c.Double(),
                        PriceWholesale = c.Double(),
                        Country = c.String(maxLength: 59),
                    })
                .PrimaryKey(t => t.IdProduct);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ArrivalProducts", "Idproduct", "dbo.Products");
            DropForeignKey("dbo.ArrivalProducts", "Idarrival", "dbo.Arrivals");
            DropForeignKey("dbo.Arrivals", "IdSupplier", "dbo.Suppliers");
            DropIndex("dbo.Arrivals", new[] { "IdSupplier" });
            DropIndex("dbo.ArrivalProducts", new[] { "Idproduct" });
            DropIndex("dbo.ArrivalProducts", new[] { "Idarrival" });
            DropTable("dbo.Products");
            DropTable("dbo.Suppliers");
            DropTable("dbo.Arrivals");
            DropTable("dbo.ArrivalProducts");
        }
    }
}
