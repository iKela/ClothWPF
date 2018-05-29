namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddArrival : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Arrivals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Count = c.Double(),
                        PriceDollar = c.Double(),
                        PriceUah = c.Double(),
                        PriceRetail = c.Double(),
                        PriceWholesale = c.Double(),
                        ManufactureDate = c.DateTime(nullable: false),
                        IdProduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.IdProduct, cascadeDelete: true)
                .Index(t => t.IdProduct);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arrivals", "IdProduct", "dbo.Products");
            DropIndex("dbo.Arrivals", new[] { "IdProduct" });
            DropTable("dbo.Arrivals");
        }
    }
}
