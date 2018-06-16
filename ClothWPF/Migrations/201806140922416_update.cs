namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Arrivals", "IdSupplier", "dbo.Suppliers");
            DropIndex("dbo.Arrivals", new[] { "IdSupplier" });
            CreateTable(
                "dbo.Enterprises",
                c => new
                    {
                        IdEnterprise = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Adress = c.String(),
                        KodEDRPOU = c.String(),
                        Ownership = c.String(),
                        CreatingWay = c.String(),
                        LegalForm = c.String(),
                        Activity = c.String(),
                        IdentificationCode = c.String(),
                        Director = c.String(),
                        Email = c.String(),
                        Fax = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.IdEnterprise);
            
            AddColumn("dbo.Arrivals", "ComesTo", c => c.String(maxLength: 50));
            AddColumn("dbo.Arrivals", "EnterpriseId", c => c.Int(nullable: false));
            AlterColumn("dbo.Arrivals", "Number", c => c.String());
            AlterColumn("dbo.Arrivals", "IdSupplier", c => c.Int());
            CreateIndex("dbo.Arrivals", "IdSupplier");
            CreateIndex("dbo.Arrivals", "EnterpriseId");
            AddForeignKey("dbo.Arrivals", "EnterpriseId", "dbo.Enterprises", "IdEnterprise", cascadeDelete: true);
            AddForeignKey("dbo.Arrivals", "IdSupplier", "dbo.Suppliers", "IdSupplier");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arrivals", "IdSupplier", "dbo.Suppliers");
            DropForeignKey("dbo.Arrivals", "EnterpriseId", "dbo.Enterprises");
            DropIndex("dbo.Arrivals", new[] { "EnterpriseId" });
            DropIndex("dbo.Arrivals", new[] { "IdSupplier" });
            AlterColumn("dbo.Arrivals", "IdSupplier", c => c.Int(nullable: false));
            AlterColumn("dbo.Arrivals", "Number", c => c.Int(nullable: false));
            DropColumn("dbo.Arrivals", "EnterpriseId");
            DropColumn("dbo.Arrivals", "ComesTo");
            DropTable("dbo.Enterprises");
            CreateIndex("dbo.Arrivals", "IdSupplier");
            AddForeignKey("dbo.Arrivals", "IdSupplier", "dbo.Suppliers", "IdSupplier", cascadeDelete: true);
        }
    }
}
