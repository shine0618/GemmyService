using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelProductOffice
{
   public class T_Office_Files:T_Base
    {


        /// <summary>
        /// 关联的类型 比如说是地脚的Mode  还是框架的Mode
        /// </summary>
        public string partType { get; set; }


        public string Mode { get; set; }
         
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }

        public string thumbnailImg { get; set; }
        /// <summary>
        /// 文件种类 产品介绍 尺寸图2D 尺寸图3D  认证 文件资料
        /// </summary>
        public string Nature { get; set; }
        /// <summary>
        /// 文件信息
        /// </summary>
        public string Information { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime? Outdate { get; set; }
        /// <summary>
        /// 文件后缀名
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 允许查看
        /// </summary>
        public string Permission { get; set; }
        /// <summary>
        /// 关联产品
        /// </summary>
        public string Products { get; set; }
        /// <summary>
        /// 是否被锁定
        /// </summary>
        public bool Lock { get; set; }
        /// <summary>
        /// 语言版本
        /// </summary>
        public string Language { get; set; }
    }
}
