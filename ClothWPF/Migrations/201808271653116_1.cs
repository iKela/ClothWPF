namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "Idgroup", "dbo.GroupProducts");
            DropIndex("dbo.Products", new[] { "Idgroup" });
            AlterColumn("dbo.Products", "Idgroup", c => c.Int(nullable:true));
            //CreateIndex("dbo.Products", "Idgroup");
            AddForeignKey("dbo.Products", "Idgroup", "dbo.GroupProducts", "IdGroup");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Idgroup", "dbo.GroupProducts");
            DropIndex("dbo.Products", new[] { "Idgroup" });
            AlterColumn("dbo.Products", "Idgroup", c => c.Int(nullable: false));
            CreateIndex("dbo.Products", "Idgroup");
            AddForeignKey("dbo.Products", "Idgroup", "dbo.GroupProducts", "IdGroup", cascadeDelete: true);
        }
    }
}
