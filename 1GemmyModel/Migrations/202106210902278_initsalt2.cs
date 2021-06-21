namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initsalt2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.T_USER_Temporary_UserInfo", "FailTime", c => c.DateTime());
            AlterColumn("dbo.T_USER_Temporary_UserInfo", "ResetFailTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.T_USER_Temporary_UserInfo", "ResetFailTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.T_USER_Temporary_UserInfo", "FailTime", c => c.DateTime(nullable: false));
        }
    }
}
