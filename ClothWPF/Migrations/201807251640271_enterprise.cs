namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enterprise : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Enterprises", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Enterprises", "City");
        }
    }
}
