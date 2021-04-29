using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public  class File:T_Base
    {
        /// <summary>
        /// 文件名
        /// </summary>
        [Index]
        public string FileName { get; set; }
        /// <summary>
        /// 文件种类
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
        /// 创建日期
        /// </summary>
        public DateTime Createdate { get; set; }
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? Modifydate { get; set; }
        /// <summary>
        /// 失效日期
        /// </summary>
        public DateTime? Outdate { get; set; }
        /// <summary>
        /// 添加者名称
        /// </summary>
        public string Person { get; set; }
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
