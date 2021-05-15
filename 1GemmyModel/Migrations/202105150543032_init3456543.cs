namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init3456543 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Product_office_desk_detail", "configurationNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Product_office_desk_detail", "configurationNo");
        }
    }
}
