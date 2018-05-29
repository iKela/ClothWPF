namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class atribute : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.Products", "Country", c => c.String(maxLength: 59));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Country", c => c.String());
            AlterColumn("dbo.Products", "Name", c => c.String());
        }
    }
}
