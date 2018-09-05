namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "Uid", c => c.Long());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "Uid");
        }
    }
}
