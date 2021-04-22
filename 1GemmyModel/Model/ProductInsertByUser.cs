using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class ProductInsertByUser
    {
        /// <summary>
        /// 添加者用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 添加产品名
        /// </summary>
        public string InsertProduct { get; set; }
        /// <summary>
        /// 立柱编号
        /// </summary>
        public string ColumnNo { get; set; }
        /// <summary>
        /// 框架编号
        /// </summary>
        public string FrameNo { get; set; }
        /// <summary>
        /// 地脚编号
        /// </summary>
        public string FootNo { get; set; }
        /// <summary>
        /// 侧板编号
        /// </summary>
        public string SideBracketNo { get; set; }
        /// <summary>
        /// 控制器编号
        /// </summary>
        public string ControlNo { get; set; }
        /// <summary>
        /// 手控器编号
        /// </summary>
        public string HandSetNo { get; set; }
        /// <summary>
        /// 配件编号
        /// </summary>
        public string AccessoryNo { get; set; }
        /// <summary>
        /// 新建时间
        /// </summary>
        public DateTime CreateTime { get; set; }
    }
}
