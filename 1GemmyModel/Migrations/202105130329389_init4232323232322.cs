namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4232323232322 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Product_office_desk", "deskNewProductNumber", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Product_office_desk", "deskNewProductNumber");
        }
    }
}
