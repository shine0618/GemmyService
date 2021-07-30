namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init85746684738549 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_USER_UserInfo", "Level", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_USER_UserInfo", "Level");
        }
    }
}
