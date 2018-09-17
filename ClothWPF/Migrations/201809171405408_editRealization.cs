namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editRealization : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.RealizationProducts", "Count", c => c.Double());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.RealizationProducts", "Count", c => c.Double(nullable: false));
        }
    }
}
