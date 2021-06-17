namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init257987654 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Part_office_HandSet", "SingleMotor", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Part_office_HandSet", "SingleMotor");
        }
    }
}
