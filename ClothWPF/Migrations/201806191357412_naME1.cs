namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class naME1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ArrivalProducts", "ManufactureDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ArrivalProducts", "ManufactureDate", c => c.DateTime(nullable: false));
        }
    }
}
