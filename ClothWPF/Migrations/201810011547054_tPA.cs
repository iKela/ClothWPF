namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tPA : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ArrivalProducts", "TotalPurshaise", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ArrivalProducts", "TotalPurshaise");
        }
    }
}
