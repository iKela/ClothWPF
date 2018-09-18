namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class preReliz : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Realizations", "TotalSum", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Realizations", "TotalSum");
        }
    }
}
