namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Excel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExcelTables",
                c => new
                    {
                        UId = c.Long(nullable: false),
                        Code = c.String(),
                        Name = c.String(),
                        PriceUah = c.Double(),
                        PriceWholesale = c.Double(),
                        Count = c.Int(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.UId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExcelTables");
        }
    }
}
