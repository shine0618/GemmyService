namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updayelangu : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_SYS_Language", "LanguageShortDesript", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.T_SYS_Language", "LanguageShortDesript");
        }
    }
}
