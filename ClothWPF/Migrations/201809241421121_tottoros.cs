namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tottoros : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Realizations", name: "IdClient", newName: "IdSupplier");
            RenameIndex(table: "dbo.Realizations", name: "IX_IdClient", newName: "IX_IdSupplier");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Realizations", name: "IX_IdSupplier", newName: "IX_IdClient");
            RenameColumn(table: "dbo.Realizations", name: "IdSupplier", newName: "IdClient");
        }
    }
}
