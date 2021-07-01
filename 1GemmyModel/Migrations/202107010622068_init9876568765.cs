namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init9876568765 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Product_office_desk", "deskCustomerName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Product_office_desk", "deskCustomerName");
        }
    }
}
