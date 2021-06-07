namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init234232324 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_USER_Temporary_UserInfo", "ResetFailTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.T_USER_Temporary_UserInfo", "ResetCode", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_USER_Temporary_UserInfo", "ResetCode");
            DropColumn("dbo.T_USER_Temporary_UserInfo", "ResetFailTime");
        }
    }
}
