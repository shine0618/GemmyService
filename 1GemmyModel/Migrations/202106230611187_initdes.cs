namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Part_office_Column", "parametricTextIndex", c => c.Int(nullable: false));
            AddColumn("dbo.T_Part_office_ControlBox", "parametricTextIndex", c => c.Int(nullable: false));
            AddColumn("dbo.T_Part_office_Foot", "parametricTextIndex", c => c.Int(nullable: false));
            AddColumn("dbo.T_Part_office_Frame", "parametricTextIndex", c => c.Int(nullable: false));
            AddColumn("dbo.T_Part_office_HandSet", "parametricTextIndex", c => c.Int(nullable: false));
            AddColumn("dbo.T_Part_office_Powercable", "parametricTextIndex", c => c.Int(nullable: false));
            AddColumn("dbo.T_Part_office_SideBracket", "parametricTextIndex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Part_office_SideBracket", "parametricTextIndex");
            DropColumn("dbo.T_Part_office_Powercable", "parametricTextIndex");
            DropColumn("dbo.T_Part_office_HandSet", "parametricTextIndex");
            DropColumn("dbo.T_Part_office_Frame", "parametricTextIndex");
            DropColumn("dbo.T_Part_office_Foot", "parametricTextIndex");
            DropColumn("dbo.T_Part_office_ControlBox", "parametricTextIndex");
            DropColumn("dbo.T_Part_office_Column", "parametricTextIndex");
        }
    }
}
