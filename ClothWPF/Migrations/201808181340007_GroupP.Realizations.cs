namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GroupPRealizations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GroupProducts",
                c => new
                    {
                        IdGroup = c.Int(nullable: false, identity: true),
                        NameGroup = c.String(),
                        RungGroup = c.Int(nullable: false),
                        DescriptionGroup = c.String(),
                    })
                .PrimaryKey(t => t.IdGroup);
            
            CreateTable(
                "dbo.RealizationProducts",
                c => new
                    {
                        IdRealizationProduct = c.Int(nullable: false, identity: true),
                        Count = c.Double(nullable: false),
                        PriceDollar = c.Double(),
                        PriceUah = c.Double(),
                        PriceRetail = c.Double(),
                        PriceWholesale = c.Double(),
                        IdRealization = c.Int(nullable: false),
                        Idproduct = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRealizationProduct)
                .ForeignKey("dbo.Realizations", t => t.IdRealization, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Idproduct, cascadeDelete: true)
                .Index(t => t.IdRealization)
                .Index(t => t.Idproduct);
            
            CreateTable(
                "dbo.Realizations",
                c => new
                    {
                        IdRealization = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        DateRealization = c.DateTime(nullable: false),
                        PaymentType = c.String(),
                        Currency = c.String(),
                        Comment = c.String(),
                        PercentageDiscount = c.Double(),
                        SumDiscount = c.Double(),
                        Prepayment = c.Double(),
                        TotalPurshaise = c.Double(nullable: false),
                        PaymentSum = c.Double(),
                        IdClient = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IdRealization)
                .ForeignKey("dbo.Clients", t => t.IdClient, cascadeDelete: true)
                .Index(t => t.IdClient);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IDClient = c.Int(nullable: false, identity: true),
                        NameClient = c.String(),
                        Comments = c.String(),
                    })
                .PrimaryKey(t => t.IDClient);
            
            AddColumn("dbo.Products", "Idgroup", c => c.Int(nullable: true));
            CreateIndex("dbo.Products", "Idgroup");
            AddForeignKey("dbo.Products", "Idgroup", "dbo.GroupProducts", "IdGroup", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RealizationProducts", "Idproduct", "dbo.Products");
            DropForeignKey("dbo.RealizationProducts", "IdRealization", "dbo.Realizations");
            DropForeignKey("dbo.Realizations", "IdClient", "dbo.Clients");
            DropForeignKey("dbo.Products", "Idgroup", "dbo.GroupProducts");
            DropIndex("dbo.Realizations", new[] { "IdClient" });
            DropIndex("dbo.RealizationProducts", new[] { "Idproduct" });
            DropIndex("dbo.RealizationProducts", new[] { "IdRealization" });
            DropIndex("dbo.Products", new[] { "Idgroup" });
            DropColumn("dbo.Products", "Idgroup");
            DropTable("dbo.Clients");
            DropTable("dbo.Realizations");
            DropTable("dbo.RealizationProducts");
            DropTable("dbo.GroupProducts");
        }
    }
}
