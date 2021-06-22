namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init45637 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_USER_UserCompanyInfo", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_USER_UserCompanyInfo", "Name");
        }
    }
}
