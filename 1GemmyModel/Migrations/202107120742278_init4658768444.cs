namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4658768444 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_USER_Opinion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Content = c.String(),
                        Name = c.String(),
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
            DropTable("dbo.T_USER_Opinion");
        }
    }
}
