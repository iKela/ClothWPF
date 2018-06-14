namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qw : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Arrivals", "EnterpriseId", "dbo.Enterprises");
            DropIndex("dbo.Arrivals", new[] { "EnterpriseId" });
            AlterColumn("dbo.Arrivals", "EnterpriseId", c => c.Int());
            CreateIndex("dbo.Arrivals", "EnterpriseId");
            AddForeignKey("dbo.Arrivals", "EnterpriseId", "dbo.Enterprises", "IdEnterprise");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Arrivals", "EnterpriseId", "dbo.Enterprises");
            DropIndex("dbo.Arrivals", new[] { "EnterpriseId" });
            AlterColumn("dbo.Arrivals", "EnterpriseId", c => c.Int(nullable: false));
            CreateIndex("dbo.Arrivals", "EnterpriseId");
            AddForeignKey("dbo.Arrivals", "EnterpriseId", "dbo.Enterprises", "IdEnterprise", cascadeDelete: true);
        }
    }
}
