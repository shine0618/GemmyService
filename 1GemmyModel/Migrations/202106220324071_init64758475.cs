namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init64758475 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Part_office_Powercable", "PictureName", c => c.String());
            DropColumn("dbo.T_Part_office_Powercable", "PicName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Part_office_Powercable", "PicName", c => c.String());
            DropColumn("dbo.T_Part_office_Powercable", "PictureName");
        }
    }
}
