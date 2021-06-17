namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init232346789857 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Part_office_ControlBox",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                        ControlColumnNo = c.Int(nullable: false),
                        OutputVoltage = c.Double(),
                        InputVoltage = c.Double(),
                        TransformerPower = c.Double(),
                        Current = c.Double(),
                        MaxSpeed = c.Int(nullable: false),
                        MaxLoad = c.Int(nullable: false),
                        PowerOutLet = c.String(),
                        ColumnOutLet = c.String(),
                        HandSetOutLet = c.String(),
                        ProgramOutLet = c.String(),
                        DoubleMotor = c.Boolean(nullable: false),
                        HandCranking = c.Boolean(nullable: false),
                        GasSpring = c.Boolean(nullable: false),
                        SingleMotor = c.Boolean(nullable: false),
                        GS = c.Boolean(nullable: false),
                        EN527 = c.Boolean(nullable: false),
                        CE = c.Boolean(nullable: false),
                        EMC = c.Boolean(nullable: false),
                        BIFMA = c.Boolean(nullable: false),
                        UL962 = c.Boolean(nullable: false),
                        DrawingNum2D = c.String(),
                        DrawingNum3D = c.String(),
                        DrawingName3D = c.String(),
                        DrawingName2D = c.String(),
                        PictureName = c.String(),
                        PictureNum = c.String(),
                        PartCode = c.String(),
                        Weight = c.Double(),
                        DescriptionZH = c.String(storeType: "ntext"),
                        DescriptionEN = c.String(storeType: "ntext"),
                        ControlBoxWithHandSet = c.String(),
                        ControlBoxWithColumn = c.String(),
                        ControlBoxWithAccessory = c.String(),
                        TaxCost = c.Double(),
                        TransferPrice = c.Double(),
                        ReferencePrice = c.Double(),
                        HaveRabbt = c.Boolean(nullable: false),
                        Customization = c.String(),
                        SpecialDescriptionZH = c.String(storeType: "ntext"),
                        SpecialDescriptionEN = c.String(storeType: "ntext"),
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
            
            CreateTable(
                "dbo.T_Part_office_HandSet",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                        HaveScreen = c.Boolean(nullable: false),
                        ScreenType = c.String(),
                        Touch = c.Boolean(nullable: false),
                        Button = c.Boolean(nullable: false),
                        HaveUsb = c.Boolean(nullable: false),
                        Imbedding = c.Boolean(nullable: false),
                        Remote = c.Boolean(nullable: false),
                        BlueTooth = c.Boolean(nullable: false),
                        MemoryKeys = c.Int(nullable: false),
                        OutputVoltage = c.Int(),
                        InputVoltage = c.Int(),
                        TransformerPower = c.Int(),
                        Voltage = c.Int(),
                        Current = c.Int(),
                        HandSetOutLet = c.String(),
                        DoubleMotor = c.Boolean(nullable: false),
                        HandCranking = c.Boolean(nullable: false),
                        GasSpring = c.Boolean(nullable: false),
                        GS = c.Boolean(nullable: false),
                        EN527 = c.Boolean(nullable: false),
                        CE = c.Boolean(nullable: false),
                        EMC = c.Boolean(nullable: false),
                        BIFMA = c.Boolean(nullable: false),
                        UL962 = c.Boolean(nullable: false),
                        DrawingNum2D = c.String(),
                        DrawingNum3D = c.String(),
                        DrawingName3D = c.String(),
                        DrawingName2D = c.String(),
                        PictureName = c.String(),
                        PictureNum = c.String(),
                        PartCode = c.String(),
                        Weight = c.Double(),
                        DescriptionZH = c.String(storeType: "ntext"),
                        DescriptionEN = c.String(storeType: "ntext"),
                        HandsetWithControlBox = c.String(),
                        HandsetWithAccessory = c.String(),
                        TaxCost = c.Double(),
                        TransferPrice = c.Double(),
                        ReferencePrice = c.Double(),
                        HaveRabbet = c.Boolean(nullable: false),
                        Customization = c.String(),
                        SpecialDescriptionZH = c.String(storeType: "ntext"),
                        SpecialDescriptionEN = c.String(storeType: "ntext"),
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
            DropTable("dbo.T_Part_office_HandSet");
            DropTable("dbo.T_Part_office_ControlBox");
        }
    }
}
