using _1GemmyModel.Model;
using System;
using System.Data.Entity;
using System.Linq;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace _1GemmyModel
{
    public class DBGemmyService : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“DBGemmyService”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“_1GemmyModel.DBGemmyService”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“DBGemmyService”
        //连接字符串。
        public DBGemmyService()
            : base("name=DBGemmyService")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
        }


        //为您要在模型中包含的每种实体类型都添加 DbSet。有关配置和使用 Code First  模型
        //的详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=390109。

        public virtual DbSet<T_Base> T_Base { get; set; }
        public virtual DbSet<Accessory> Accessory { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Column> Column { get; set; }
        public virtual DbSet<ControlBox> ControlBox { get; set; }
        public virtual DbSet<DownloadFile> DownloadFile { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<Foot> Foot { get; set; }
        public virtual DbSet<Frame> Frame { get; set; }
        public virtual DbSet<HandSet> HandSet { get; set; }
        public virtual DbSet<OfficeTOList> OfficeTOList { get; set; }
        public virtual DbSet<OfficeTSList> OfficeTsList { get; set; }
        public virtual DbSet<OfficeTTList>OfficeTTList { get; set; }
        public virtual DbSet<OfficeTFList> OfficeTFList { get; set; }
        public virtual DbSet<PowerCable> PowerCable { get; set; }
        public virtual DbSet<ProductInsertByUser> ProductInsertByUser { get; set; }
        public virtual DbSet<ProductView> ProductView { get; set; }
        public virtual DbSet<SideBracket> SideBracket { get; set; }
        public virtual DbSet<LanguageType> LanguageType { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}