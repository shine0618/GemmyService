namespace _1GemmyModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initfile2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.T_Office_Files", "thumbnailImg", c => c.String());
            DropColumn("dbo.T_Office_Files", "Createdate");
            DropColumn("dbo.T_Office_Files", "Modifydate");
            DropColumn("dbo.T_Office_Files", "Person");
        }
        
        public override void Down()
        {
            AddColumn("dbo.T_Office_Files", "Person", c => c.String());
            AddColumn("dbo.T_Office_Files", "Modifydate", c => c.DateTime());
            AddColumn("dbo.T_Office_Files", "Createdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.T_Office_Files", "thumbnailImg");
        }
    }
}
