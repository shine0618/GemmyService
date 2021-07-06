namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init4532456869 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Part_office_Column", "UseTO", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Column", "UseTS", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Column", "UseTT", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Column", "UseTF", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Column", "UseBench", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_ControlBox", "UseTO", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_ControlBox", "UseTS", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_ControlBox", "UseTT", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_ControlBox", "UseTF", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_ControlBox", "UseBench", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Foot", "UseTO", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Foot", "UseTS", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Foot", "UseTT", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Foot", "UseTF", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Foot", "UseBench", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Frame", "UseTO", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Frame", "UseTS", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Frame", "UseTT", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Frame", "UseTF", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_Frame", "UseBench", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_HandSet", "UseTO", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_HandSet", "UseTS", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_HandSet", "UseTT", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_HandSet", "UseTF", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_HandSet", "UseBench", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_SideBracket", "UseTO", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_SideBracket", "UseTS", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_SideBracket", "UseTT", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_SideBracket", "UseTF", c => c.Boolean(nullable: false));
            AddColumn("dbo.T_Part_office_SideBracket", "UseBench", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Part_office_SideBracket", "UseBench");
            DropColumn("dbo.T_Part_office_SideBracket", "UseTF");
            DropColumn("dbo.T_Part_office_SideBracket", "UseTT");
            DropColumn("dbo.T_Part_office_SideBracket", "UseTS");
            DropColumn("dbo.T_Part_office_SideBracket", "UseTO");
            DropColumn("dbo.T_Part_office_HandSet", "UseBench");
            DropColumn("dbo.T_Part_office_HandSet", "UseTF");
            DropColumn("dbo.T_Part_office_HandSet", "UseTT");
            DropColumn("dbo.T_Part_office_HandSet", "UseTS");
            DropColumn("dbo.T_Part_office_HandSet", "UseTO");
            DropColumn("dbo.T_Part_office_Frame", "UseBench");
            DropColumn("dbo.T_Part_office_Frame", "UseTF");
            DropColumn("dbo.T_Part_office_Frame", "UseTT");
            DropColumn("dbo.T_Part_office_Frame", "UseTS");
            DropColumn("dbo.T_Part_office_Frame", "UseTO");
            DropColumn("dbo.T_Part_office_Foot", "UseBench");
            DropColumn("dbo.T_Part_office_Foot", "UseTF");
            DropColumn("dbo.T_Part_office_Foot", "UseTT");
            DropColumn("dbo.T_Part_office_Foot", "UseTS");
            DropColumn("dbo.T_Part_office_Foot", "UseTO");
            DropColumn("dbo.T_Part_office_ControlBox", "UseBench");
            DropColumn("dbo.T_Part_office_ControlBox", "UseTF");
            DropColumn("dbo.T_Part_office_ControlBox", "UseTT");
            DropColumn("dbo.T_Part_office_ControlBox", "UseTS");
            DropColumn("dbo.T_Part_office_ControlBox", "UseTO");
            DropColumn("dbo.T_Part_office_Column", "UseBench");
            DropColumn("dbo.T_Part_office_Column", "UseTF");
            DropColumn("dbo.T_Part_office_Column", "UseTT");
            DropColumn("dbo.T_Part_office_Column", "UseTS");
            DropColumn("dbo.T_Part_office_Column", "UseTO");
        }
    }
}
