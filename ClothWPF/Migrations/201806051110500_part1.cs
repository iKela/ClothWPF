namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class part1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ArrivalProducts",
                c => new
                    {
                        IdArrivalProduct = c.Int(nullable: false, identity:true),
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
                        TotalPurchase = c.Double(nullable: false),
                        Sender = c.String(),
                        Receiver = c.String(),
                        WholeSale = c.Double(),
                        Enterprice = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.IdArrival);
            
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
            DropIndex("dbo.ArrivalProducts", new[] { "Idproduct" });
            DropIndex("dbo.ArrivalProducts", new[] { "Idarrival" });
            DropTable("dbo.Products");
            DropTable("dbo.Arrivals");
            DropTable("dbo.ArrivalProducts");
        }
    }
}
