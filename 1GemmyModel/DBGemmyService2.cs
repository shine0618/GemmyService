using _1GemmyModel.Model;
using _1GemmyModel.Model.ModelProductOffice;
using _1GemmyModel.Model.ModelSystem;
using System;
using System.Data.Entity;
using System.Linq;

namespace _1GemmyModel
{
    public class DBGemmyService2 : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DBGemmyService2”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“_1GemmyModel.DBGemmyService2”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DBGemmyService2”
        //连接字符串。
        public DBGemmyService2()
            : base("name=DBGemmyService2")
        {
        }


        public virtual DbSet<T_SYS_Language> T_SYS_Language { get; set; }
        public virtual DbSet<T_USER_UserInfo> T_USER_UserInfo { get; set; }
        public virtual DbSet<T_Product_office_desk> T_Product_office_desk { get; set; }
        public virtual DbSet<T_Product_office_desk_detail> T_Product_office_desk_detail { get; set; }

        public virtual DbSet<T_Product_office_text> T_Product_office_text { get; set; }
        public virtual DbSet<T_Part_office_Column> T_Part_office_Column { get; set; }
        public virtual DbSet<T_Part_office_Foot> T_Part_office_Foot { get; set; }
        public virtual DbSet<T_Part_office_Frame> T_Part_office_Frame { get; set; }
        public virtual DbSet<T_Part_office_SideBracket> T_Part_office_SideBracket { get; set; }
        public virtual DbSet<T_Product_office_description> T_Product_office_description { get; set; }

        public virtual DbSet<T_Office_Files> T_Office_Files { get; set; }
        public virtual DbSet<T_USER_Temporary_UserInfo> T_User_Temporary_UserInfo { get; set; }

        public virtual DbSet<T_Office_Color> T_Office_Color { get; set; }
        public virtual DbSet<T_Part_office_ControlBox> T_Part_office_ControlBox { get; set; }
        public virtual DbSet<T_Part_office_HandSet> T_Part_office_HandSet { get; set; }

        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}