namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class maxlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 50));
        }
    }
}
