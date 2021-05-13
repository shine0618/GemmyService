namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init423232323232 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Product_office_text",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        textKay = c.Int(nullable: false),
                        langCode = c.String(),
                        textValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.textKay);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.T_Product_office_text", new[] { "textKay" });
            DropTable("dbo.T_Product_office_text");
        }
    }
}
