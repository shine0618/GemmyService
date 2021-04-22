namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init222 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Base", "verificationCode", c => c.String());
            AddColumn("dbo.T_Base", "deleteSign", c => c.Int(nullable: false));
            AddColumn("dbo.T_Base", "UpdateTime", c => c.DateTime());
            AddColumn("dbo.T_Base", "deletePerson", c => c.String());
            AddColumn("dbo.T_Base", "CreatePerson", c => c.String());
            AddColumn("dbo.T_Base", "UpdatePerson", c => c.String());
            AddColumn("dbo.T_Base", "Remark", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Base", "Remark");
            DropColumn("dbo.T_Base", "UpdatePerson");
            DropColumn("dbo.T_Base", "CreatePerson");
            DropColumn("dbo.T_Base", "deletePerson");
            DropColumn("dbo.T_Base", "UpdateTime");
            DropColumn("dbo.T_Base", "deleteSign");
            DropColumn("dbo.T_Base", "verificationCode");
        }
    }
}
