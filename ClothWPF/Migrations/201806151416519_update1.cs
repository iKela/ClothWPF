namespace ClothWPF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.ArrivalProducts");
            AlterColumn("dbo.ArrivalProducts", "IdArrivalProduct", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.ArrivalProducts", "IdArrivalProduct");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ArrivalProducts");
            AlterColumn("dbo.ArrivalProducts", "IdArrivalProduct", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ArrivalProducts", "IdArrivalProduct");
        }
    }
}
