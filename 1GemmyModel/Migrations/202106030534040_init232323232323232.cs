namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init232323232323232 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_USER_Temporary_UserInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Password = c.String(),
                        Email = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PicPath = c.String(),
                        FailTime = c.DateTime(nullable: false),
                        Code = c.String(),
                        verificationCode = c.String(),
                        deleteSign = c.Int(),
                        UpdateTime = c.DateTime(),
                        CreateTime = c.DateTime(),
                        deletePerson = c.String(),
                        CreatePerson = c.String(),
                        UpdatePerson = c.String(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.T_USER_UserInfo", "FirstName", c => c.String());
            AddColumn("dbo.T_USER_UserInfo", "LastName", c => c.String());
            AddColumn("dbo.T_USER_UserInfo", "PicPath", c => c.String());
            AddColumn("dbo.T_USER_UserInfo", "Lock", c => c.Boolean(nullable: false));
            DropColumn("dbo.T_USER_UserInfo", "UserName");
            DropColumn("dbo.T_USER_UserInfo", "Question");
            DropColumn("dbo.T_USER_UserInfo", "Answer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_USER_UserInfo", "Answer", c => c.String());
            AddColumn("dbo.T_USER_UserInfo", "Question", c => c.String());
            AddColumn("dbo.T_USER_UserInfo", "UserName", c => c.String());
            DropColumn("dbo.T_USER_UserInfo", "Lock");
            DropColumn("dbo.T_USER_UserInfo", "PicPath");
            DropColumn("dbo.T_USER_UserInfo", "LastName");
            DropColumn("dbo.T_USER_UserInfo", "FirstName");
            DropTable("dbo.T_USER_Temporary_UserInfo");
        }
    }
}
