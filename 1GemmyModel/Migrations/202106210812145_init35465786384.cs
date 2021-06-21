namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init35465786384 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_USER_UserCompanyInfo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Sex = c.String(),
                        Telephone = c.String(),
                        CompanyName = c.String(),
                        CompanyStreet = c.String(),
                        CompanyLocation = c.String(),
                        CompanyNation = c.String(),
                        CompanyWebsite = c.String(),
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
            DropTable("dbo.T_USER_UserCompanyInfo");
        }
    }
}
