namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class faraf : DbMigration
    {
        public override void Up()
        {
            
            
        }
        
        public override void Down()
        {
            AddColumn("dbo.Realizations", "GetClient_IdSupplier", c => c.Int());
            AddColumn("dbo.Realizations", "IdClient", c => c.Int(nullable: false));
            CreateIndex("dbo.Realizations", "GetClient_IdSupplier");
            AddForeignKey("dbo.Realizations", "GetClient_IdSupplier", "dbo.Suppliers", "IdSupplier");
        }
    }
}
