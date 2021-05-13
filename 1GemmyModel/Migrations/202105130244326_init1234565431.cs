namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1234565431 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.T_Product_office_desk",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        deskType = c.String(),
                        deskTag = c.String(),
                        deskShortDescription = c.String(),
                        deskSerialName = c.String(),
                        deskImgUrl = c.String(),
                        deskSalesVolume = c.Double(nullable: false),
                        deskPrice = c.Double(nullable: false),
                        deskStabilityLeave = c.Double(nullable: false),
                        deskMaxLoad = c.Double(nullable: false),
                        deskNewProduct = c.Boolean(nullable: false),
                        deskJCRecommend = c.Boolean(nullable: false),
                        deskCreateByUser = c.String(),
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
                "dbo.T_Product_office_desk_detail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Mode = c.String(),
                        Type = c.String(),
                        Level = c.Int(nullable: false),
                        Form = c.String(),
                        Size_Out = c.String(),
                        Size_Middle = c.String(),
                        Size_Inside = c.String(),
                        StrokeLength = c.Int(nullable: false),
                        LowestPosition = c.Int(nullable: false),
                        HighestPosition = c.Int(nullable: false),
                        Width = c.Int(),
                        LoadCapacity = c.Int(),
                        MaxLoad = c.Int(),
                        Speed = c.Int(),
                        MaxSpeed = c.Int(),
                        Power = c.Double(),
                        StabilityLevel = c.Int(),
                        MotorCode = c.String(),
                        PowerType = c.String(),
                        Special = c.String(),
                        Certification = c.String(),
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
                        ColumnType = c.String(),
                        ColumnInfo = c.String(),
                        FootType = c.String(),
                        FootInfo = c.String(),
                        FrameType = c.String(),
                        FrameInfo = c.String(),
                        HandsetType = c.String(),
                        HandsetInfo = c.String(),
                        ControlboxType = c.String(),
                        ControlboxInfo = c.String(),
                        Accessorys = c.String(),
                        AccessoryInfo = c.String(),
                        SideBracketType = c.String(),
                        SideBracketInfo = c.String(),
                        TaxCost = c.Double(),
                        TransferPrice = c.Double(),
                        ReferencePrice = c.Double(),
                        Customization = c.String(),
                        SelledPerYear = c.Double(),
                        StartDate = c.DateTime(),
                        NoiseLevel = c.Int(),
                        PackageSize = c.Double(),
                        ColumnCount = c.Int(),
                        FrameCount = c.Int(),
                        SideBracketCount = c.Int(),
                        FootCount = c.Int(),
                        ControlBoxCount = c.Int(),
                        HandSetCount = c.Int(),
                        AccessorysCount = c.Int(),
                        ColumnUnitPrice = c.Int(),
                        FrameUnitPrice = c.Int(),
                        SideBracketUnitPrice = c.Int(),
                        ControlBoxUnitPrice = c.Int(),
                        HandSetUnitPrice = c.Int(),
                        FootUnitPrice = c.Int(),
                        AccessoryUnitPrice = c.Int(),
                        AddUserName = c.String(),
                        T_Product_office_desk_Id = c.Int(nullable: false),
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
            DropTable("dbo.T_Product_office_desk_detail");
            DropTable("dbo.T_Product_office_desk");
        }
    }
}
