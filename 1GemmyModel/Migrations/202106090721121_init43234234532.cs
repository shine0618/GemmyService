namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init43234234532 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Office_Color",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ColorName = c.String(),
                        ColorStandard = c.String(),
                        JCStandard = c.Boolean(nullable: false),
                        RALStandard = c.Boolean(nullable: false),
                        Customization = c.Boolean(nullable: false),
                        ColorNumber = c.String(),
                        Customers = c.String(),
                        RValueRGB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        GValueRGB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BValueRGB = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HEXValue = c.String(),
                        LValueLab = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AValueLab = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BValueLab = c.Decimal(nullable: false, precision: 18, scale: 2),
                        verificationCode = c.String(),
                        deleteSign = c.Int(),
                        UpdateTime = c.DateTime(),
                        CreateTime = c.DateTime(),
                        deletePerson = c.String(),
                        CreatePerson = c.String(),
                        UpdatePerson = c.String(),
                        Remark = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.T_Office_Color");
        }
    }
}
