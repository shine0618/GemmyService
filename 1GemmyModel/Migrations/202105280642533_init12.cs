namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Product_office_desk_detail", "introductionIndex", c => c.Int(nullable: false));
            AddColumn("dbo.T_Product_office_desk_detail", "introduction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Product_office_desk_detail", "introduction");
            DropColumn("dbo.T_Product_office_desk_detail", "introductionIndex");
        }
    }
}
