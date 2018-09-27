namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class discount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Suppliers", "TotalClientPurshaise", c => c.Double());
            AddColumn("dbo.Realizations", "Profit", c => c.Double());
            DropColumn("dbo.RealizationProducts", "Profit");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RealizationProducts", "Profit", c => c.Double());
            DropColumn("dbo.Realizations", "Profit");
            DropColumn("dbo.Suppliers", "TotalClientPurshaise");
        }
    }
}
