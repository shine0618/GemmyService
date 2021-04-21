namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Base",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_Base");
        }
    }
}
