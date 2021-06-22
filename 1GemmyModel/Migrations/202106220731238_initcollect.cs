namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcollect : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Office_desk_collect",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DeskId = c.Int(nullable: false),
                        collectUser = c.String(),
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
            
            AddColumn("dbo.T_Product_office_desk", "deskCustmoer", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Product_office_desk", "deskCustmoer");
            DropTable("dbo.T_Office_desk_collect");
        }
    }
}
