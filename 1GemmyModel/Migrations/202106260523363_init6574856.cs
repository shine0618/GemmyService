namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6574856 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Product_office_desk_customer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        deskGuid = c.String(),
                        langCode = c.String(),
                        configurationName = c.String(),
                        customerUserName = c.String(),
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
            
            CreateTable(
                "dbo.T_USER_Permission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        isAllow = c.Boolean(nullable: false),
                        PermissionId = c.Int(nullable: false),
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
            
            CreateTable(
                "dbo.T_USER_Permission_menus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        action = c.String(),
                        desription = c.String(),
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
            
            AddColumn("dbo.T_Product_office_desk_detail", "select_ColorMode", c => c.String());
            AddColumn("dbo.T_Product_office_desk_detail", "select_PowercableMode", c => c.String());
            AddColumn("dbo.T_Product_office_desk_detail", "frameWidth", c => c.String());
            AddColumn("dbo.T_Product_office_desk_detail", "frameHeight", c => c.String());
            AddColumn("dbo.T_Product_office_desk_detail", "configurationName", c => c.String());
            AddColumn("dbo.T_Product_office_desk_detail", "deskGuid", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Product_office_desk_detail", "deskGuid");
            DropColumn("dbo.T_Product_office_desk_detail", "configurationName");
            DropColumn("dbo.T_Product_office_desk_detail", "frameHeight");
            DropColumn("dbo.T_Product_office_desk_detail", "frameWidth");
            DropColumn("dbo.T_Product_office_desk_detail", "select_PowercableMode");
            DropColumn("dbo.T_Product_office_desk_detail", "select_ColorMode");
            DropTable("dbo.T_USER_Permission_menus");
            DropTable("dbo.T_USER_Permission");
            DropTable("dbo.T_Product_office_desk_customer");
        }
    }
}
