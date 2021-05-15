﻿namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init323232323232323232 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Part_office_Column",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                        Type = c.String(),
                        Level = c.String(),
                        Form = c.String(),
                        Size_Out = c.String(),
                        Size_Middle = c.String(),
                        Size_Inside = c.String(),
                        StrokeLength = c.Int(nullable: false),
                        MaxStroke = c.Int(),
                        LowestPosition = c.Int(nullable: false),
                        HighestPosition = c.Int(nullable: false),
                        LoadCapacity = c.Int(nullable: false),
                        MaxLoad = c.Int(),
                        Speed = c.Int(nullable: false),
                        MaxSpeed = c.Int(),
                        Power = c.Int(),
                        StabilityLeave = c.Int(),
                        MotorCode = c.String(),
                        HaveMotor = c.Boolean(nullable: false),
                        Inline = c.Boolean(nullable: false),
                        InsideSlider = c.Boolean(nullable: false),
                        SingleMotor = c.Boolean(nullable: false),
                        HandCranking = c.Boolean(nullable: false),
                        GasSpring = c.Boolean(nullable: false),
                        CanEZ = c.Boolean(nullable: false),
                        CanFold = c.Boolean(nullable: false),
                        CanTurn = c.Boolean(nullable: false),
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
                        ColumnWithFoot = c.String(),
                        ColumnWithFrame = c.String(),
                        HandsetConnect = c.String(),
                        ControlboxConnect = c.String(),
                        AccessoryConnect = c.String(),
                        ColumnWithSideBracket = c.String(),
                        TaxCost = c.Double(),
                        TransferPrice = c.Double(),
                        ReferencePrice = c.Double(),
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
                "dbo.T_Part_office_Foot",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                        MaxLength = c.Int(nullable: false),
                        MinLength = c.Int(nullable: false),
                        StabilityLeave = c.Int(),
                        CanEZ = c.Boolean(nullable: false),
                        CanFold = c.Boolean(nullable: false),
                        CanTurn = c.Boolean(nullable: false),
                        Inline = c.Boolean(nullable: false),
                        InsideSlider = c.Boolean(nullable: false),
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
                        FootWithColumn = c.String(),
                        TaxCost = c.Double(),
                        TransferPrice = c.Double(),
                        ReferencePrice = c.Double(),
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
                "dbo.T_Part_office_Frame",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                        MaxLength = c.Int(nullable: false),
                        MinLength = c.Int(nullable: false),
                        StabilityLeave = c.Int(),
                        CanEZ = c.Boolean(nullable: false),
                        CanFold = c.Boolean(nullable: false),
                        CanTurn = c.Boolean(nullable: false),
                        Inline = c.Boolean(nullable: false),
                        InsideSlider = c.Boolean(nullable: false),
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
                        FrameWithColumn = c.String(),
                        FrameWithSideBracket = c.String(),
                        FrameWithAccessory = c.String(),
                        FrameWithControlBox = c.String(),
                        TaxCost = c.Double(),
                        TransferPrice = c.Double(),
                        ReferencePrice = c.Double(),
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
                "dbo.T_Part_office_SideBracket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                        MaxLength = c.Int(nullable: false),
                        MinLength = c.Int(nullable: false),
                        StabilityLeave = c.Int(),
                        CanEZ = c.Boolean(nullable: false),
                        CanFold = c.Boolean(nullable: false),
                        CanTurn = c.Boolean(nullable: false),
                        Inline = c.Boolean(nullable: false),
                        InsideSlider = c.Boolean(nullable: false),
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
                        DescriptionZH = c.String(),
                        DescriptionEN = c.String(),
                        SideBracketWithFrame = c.String(),
                        TaxCost = c.Double(),
                        TransferPrice = c.Double(),
                        ReferencePrice = c.Double(),
                        Customization = c.String(),
                        SpecialDescriptionZH = c.String(),
                        SpecialDescriptionEN = c.String(),
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
            
            DropColumn("dbo.T_Product_office_desk_detail", "configurationNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Product_office_desk_detail", "configurationNo", c => c.String());
            DropTable("dbo.T_Part_office_SideBracket");
            DropTable("dbo.T_Part_office_Frame");
            DropTable("dbo.T_Part_office_Foot");
            DropTable("dbo.T_Part_office_Column");
        }
    }
}
