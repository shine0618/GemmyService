namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initsalt : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Part_office_describe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        textKay = c.Int(nullable: false),
                        langCode = c.String(),
                        textValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.textKay);
            
            CreateTable(
                "dbo.T_USER_Salt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        pwdSalt = c.String(),
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
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.T_Part_office_describe", new[] { "textKay" });
            DropTable("dbo.T_USER_Salt");
            DropTable("dbo.T_Part_office_describe");
        }
    }
}
