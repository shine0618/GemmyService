namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1234565432 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Product_office_desk", "deskTagKsy", c => c.Int(nullable: false));
            AddColumn("dbo.T_Product_office_desk", "deskShortDescriptionKey", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Product_office_desk", "deskShortDescriptionKey");
            DropColumn("dbo.T_Product_office_desk", "deskTagKsy");
        }
    }
}
