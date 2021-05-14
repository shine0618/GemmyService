namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init5142 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Product_office_desk", "deskGuid", c => c.String());
            AddColumn("dbo.T_Product_office_desk", "deskTagKey", c => c.Int(nullable: false));
            DropColumn("dbo.T_Product_office_desk", "deskTagKsy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Product_office_desk", "deskTagKsy", c => c.Int(nullable: false));
            DropColumn("dbo.T_Product_office_desk", "deskTagKey");
            DropColumn("dbo.T_Product_office_desk", "deskGuid");
        }
    }
}
