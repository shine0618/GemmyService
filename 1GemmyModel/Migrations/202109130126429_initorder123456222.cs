namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initorder123456222 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_USER_ApplyOrder",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        CompanyName = c.String(),
                        ApplyTime = c.DateTime(),
                        Pass = c.Boolean(nullable: false),
                        passemail = c.String(),
                        passtime = c.DateTime(),
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
            
            AddColumn("dbo.T_USER_UserInfo", "CompanyName", c => c.String());
            AddColumn("dbo.T_USER_UserInfo", "isorder", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_USER_UserInfo", "isorder");
            DropColumn("dbo.T_USER_UserInfo", "CompanyName");
            DropTable("dbo.T_USER_ApplyOrder");
        }
    }
}
