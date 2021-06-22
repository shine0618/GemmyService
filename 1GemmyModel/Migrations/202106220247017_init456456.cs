namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init456456 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Part_office_Powercable",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                        PowercableLength = c.Double(),
                        HeadPlug = c.Int(nullable: false),
                        TailPlug = c.String(),
                        PicName = c.String(),
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
            DropTable("dbo.T_Part_office_Powercable");
        }
    }
}
