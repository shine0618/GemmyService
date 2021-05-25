namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initajsgas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Office_Files",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        partType = c.String(),
                        Mode = c.String(),
                        FileName = c.String(),
                        Nature = c.String(),
                        Information = c.String(),
                        Path = c.String(),
                        Size = c.Long(nullable: false),
                        Createdate = c.DateTime(nullable: false),
                        Modifydate = c.DateTime(),
                        Outdate = c.DateTime(),
                        Person = c.String(),
                        Type = c.String(),
                        Permission = c.String(),
                        Products = c.String(),
                        Lock = c.Boolean(nullable: false),
                        Language = c.String(),
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
            DropTable("dbo.T_Office_Files");
        }
    }
}
