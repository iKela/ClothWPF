namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clients", "Town", c => c.String());
            AddColumn("dbo.Clients", "Adress", c => c.String());
            AddColumn("dbo.Clients", "Number", c => c.String());
            AddColumn("dbo.Clients", "Email", c => c.String());
            AddColumn("dbo.Clients", "Region", c => c.String());
            AddColumn("dbo.Clients", "Discount", c => c.Double());
            AddColumn("dbo.Clients", "DiscountCardNumber", c => c.String());
            AddColumn("dbo.Clients", "Currency", c => c.String());
            AddColumn("dbo.Clients", "Category", c => c.String());
            AddColumn("dbo.Clients", "FullName", c => c.String());
            AddColumn("dbo.Clients", "Legaladress", c => c.String());
            AddColumn("dbo.Clients", "MaxAmountOfDebt", c => c.Double());
            AddColumn("dbo.Clients", "VATPlayerNumber", c => c.String());
            AddColumn("dbo.Clients", "ContractNumber", c => c.String());
            AddColumn("dbo.Clients", "ContractDate", c => c.DateTime());
            AddColumn("dbo.Clients", "IndividualTaxNumber", c => c.String());
            AddColumn("dbo.Clients", "KindOfResponsibility", c => c.String());
            DropColumn("dbo.Clients", "Comments");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "Comments", c => c.String());
            DropColumn("dbo.Clients", "KindOfResponsibility");
            DropColumn("dbo.Clients", "IndividualTaxNumber");
            DropColumn("dbo.Clients", "ContractDate");
            DropColumn("dbo.Clients", "ContractNumber");
            DropColumn("dbo.Clients", "VATPlayerNumber");
            DropColumn("dbo.Clients", "MaxAmountOfDebt");
            DropColumn("dbo.Clients", "Legaladress");
            DropColumn("dbo.Clients", "FullName");
            DropColumn("dbo.Clients", "Category");
            DropColumn("dbo.Clients", "Currency");
            DropColumn("dbo.Clients", "DiscountCardNumber");
            DropColumn("dbo.Clients", "Discount");
            DropColumn("dbo.Clients", "Region");
            DropColumn("dbo.Clients", "Email");
            DropColumn("dbo.Clients", "Number");
            DropColumn("dbo.Clients", "Adress");
            DropColumn("dbo.Clients", "Town");
        }
    }
}
