namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fara : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "Discount", c => c.Double());
            AddColumn("dbo.Suppliers", "DiscountCardNumber", c => c.String());
            AddColumn("dbo.Suppliers", "FullName", c => c.String());
            AddColumn("dbo.Suppliers", "LegalAddress", c => c.String());
            AddColumn("dbo.GroupProducts", "CodeGroup", c => c.String());
            AddColumn("dbo.GroupProducts", "Nds", c => c.Double());
            AddColumn("dbo.GroupProducts", "IdSubGrop", c => c.Int());
            AddColumn("dbo.GroupProducts", "GetGroupProduct_IdGroup", c => c.Int());
            AlterColumn("dbo.Suppliers", "NameSupplier", c => c.String());
            AlterColumn("dbo.Suppliers", "City", c => c.String());
            AlterColumn("dbo.Suppliers", "AdressSupplier", c => c.String());
            AlterColumn("dbo.Suppliers", "NumberSupplier", c => c.String());
            AlterColumn("dbo.Suppliers", "Email", c => c.String());
            AlterColumn("dbo.Suppliers", "Region", c => c.String());
            CreateIndex("dbo.GroupProducts", "GetGroupProduct_IdGroup");
            AddForeignKey("dbo.GroupProducts", "GetGroupProduct_IdGroup", "dbo.GroupProducts", "IdGroup");
            DropColumn("dbo.Suppliers", "KindOfPartnership");
            DropColumn("dbo.Suppliers", "IdentificationCode");
            DropColumn("dbo.GroupProducts", "RungGroup");
            DropTable("dbo.Clients");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        IDClient = c.Int(nullable: false, identity: true),
                        NameClient = c.String(),
                        Town = c.String(),
                        Adress = c.String(),
                        Number = c.String(),
                        Email = c.String(),
                        Region = c.String(),
                        Discount = c.Double(),
                        DiscountCardNumber = c.String(),
                        Currency = c.String(),
                        Category = c.String(),
                        FullName = c.String(),
                        Legaladress = c.String(),
                        MaxAmountOfDebt = c.Double(),
                        VATPlayerNumber = c.String(),
                        ContractNumber = c.String(),
                        ContractDate = c.DateTime(),
                        IndividualTaxNumber = c.String(),
                        KindOfResponsibility = c.String(),
                    })
                .PrimaryKey(t => t.IDClient);
            
            AddColumn("dbo.GroupProducts", "RungGroup", c => c.Int(nullable: false));
            AddColumn("dbo.Suppliers", "IdentificationCode", c => c.String());
            AddColumn("dbo.Suppliers", "KindOfPartnership", c => c.String());
            DropForeignKey("dbo.GroupProducts", "GetGroupProduct_IdGroup", "dbo.GroupProducts");
            DropIndex("dbo.GroupProducts", new[] { "GetGroupProduct_IdGroup" });
            AlterColumn("dbo.Suppliers", "Region", c => c.String(maxLength: 50));
            AlterColumn("dbo.Suppliers", "Email", c => c.String(maxLength: 50));
            AlterColumn("dbo.Suppliers", "NumberSupplier", c => c.String(maxLength: 60));
            AlterColumn("dbo.Suppliers", "AdressSupplier", c => c.String(maxLength: 69));
            AlterColumn("dbo.Suppliers", "City", c => c.String(maxLength: 50));
            AlterColumn("dbo.Suppliers", "NameSupplier", c => c.String(maxLength: 50));
            DropColumn("dbo.GroupProducts", "GetGroupProduct_IdGroup");
            DropColumn("dbo.GroupProducts", "IdSubGrop");
            DropColumn("dbo.GroupProducts", "Nds");
            DropColumn("dbo.GroupProducts", "CodeGroup");
            DropColumn("dbo.Suppliers", "LegalAddress");
            DropColumn("dbo.Suppliers", "FullName");
            DropColumn("dbo.Suppliers", "DiscountCardNumber");
            DropColumn("dbo.Suppliers", "Discount");
        }
    }
}
