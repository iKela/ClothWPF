namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditRealizationProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RealizationProducts", "NDS", c => c.Double());
            AddColumn("dbo.RealizationProducts", "DiscountProduct", c => c.Double());
            AddColumn("dbo.RealizationProducts", "TotalProductSum", c => c.Double());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RealizationProducts", "TotalProductSum");
            DropColumn("dbo.RealizationProducts", "DiscountProduct");
            DropColumn("dbo.RealizationProducts", "NDS");
        }
    }
}
