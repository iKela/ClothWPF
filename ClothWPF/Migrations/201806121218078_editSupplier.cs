namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editSupplier : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "Category", c => c.String());
            AddColumn("dbo.Suppliers", "KindOfPartnership", c => c.String());
            AddColumn("dbo.Suppliers", "KindOfResponsibility", c => c.String());
            AddColumn("dbo.Suppliers", "IdentificationCode", c => c.String());
            AddColumn("dbo.Suppliers", "MaxAmountOfDebt", c => c.Double());
            AddColumn("dbo.Suppliers", "VATPlayerNumber", c => c.String());
            AddColumn("dbo.Suppliers", "ContractNumber", c => c.String());
            AddColumn("dbo.Suppliers", "ContractDate", c => c.DateTime());
            AddColumn("dbo.Suppliers", "IndividualTaxNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Suppliers", "IndividualTaxNumber");
            DropColumn("dbo.Suppliers", "ContractDate");
            DropColumn("dbo.Suppliers", "ContractNumber");
            DropColumn("dbo.Suppliers", "VATPlayerNumber");
            DropColumn("dbo.Suppliers", "MaxAmountOfDebt");
            DropColumn("dbo.Suppliers", "IdentificationCode");
            DropColumn("dbo.Suppliers", "KindOfResponsibility");
            DropColumn("dbo.Suppliers", "KindOfPartnership");
            DropColumn("dbo.Suppliers", "Category");
        }
    }
}
