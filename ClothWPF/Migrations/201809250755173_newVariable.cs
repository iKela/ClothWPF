namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newVariable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealizationProducts", "Profit", c => c.Double());
            DropTable("dbo.ExcelTables");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ExcelTables",
                c => new
                    {
                        UId = c.Long(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        PriceUah = c.Double(),
                        PriceWholesale = c.Double(),
                        Count = c.Int(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.UId);
            
            DropColumn("dbo.RealizationProducts", "Profit");
        }
    }
}
