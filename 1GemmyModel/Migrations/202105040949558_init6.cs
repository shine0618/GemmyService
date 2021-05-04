
namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init6 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.T_Base", newName: "T_SYS_Language");
            AddColumn("dbo.T_SYS_Language", "lcode", c => c.Int(nullable: false));
            AddColumn("dbo.T_SYS_Language", "LanguageCode", c => c.String());
            AddColumn("dbo.T_SYS_Language", "LanguageDesript", c => c.String());
            CreateIndex("dbo.T_SYS_Language", "lcode");
        }
        
        public override void Down()
        {
            DropIndex("dbo.T_SYS_Language", new[] { "lcode" });
            DropColumn("dbo.T_SYS_Language", "LanguageDesript");
            DropColumn("dbo.T_SYS_Language", "LanguageCode");
            DropColumn("dbo.T_SYS_Language", "lcode");
            RenameTable(name: "dbo.T_SYS_Language", newName: "T_Base");
        }
    }
}
