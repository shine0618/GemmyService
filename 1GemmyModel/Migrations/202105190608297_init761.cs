namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init761 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Product_office_description",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        textKay = c.Int(nullable: false),
                        langCode = c.String(),
                        textValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.textKay);
            
            AddColumn("dbo.T_Product_office_desk_detail", "DescriptionIndex", c => c.Int(nullable: false));
            AddColumn("dbo.T_Product_office_desk_detail", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropIndex("dbo.T_Product_office_description", new[] { "textKay" });
            DropColumn("dbo.T_Product_office_desk_detail", "Description");
            DropColumn("dbo.T_Product_office_desk_detail", "DescriptionIndex");
            DropTable("dbo.T_Product_office_description");
        }
    }
}
