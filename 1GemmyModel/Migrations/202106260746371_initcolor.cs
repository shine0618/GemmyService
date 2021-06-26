namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initcolor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Office_Color", "parametricTextIndex", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_Office_Color", "parametricTextIndex");
        }
    }
}
