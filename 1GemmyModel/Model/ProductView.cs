using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
  public  class ProductView:T_Base
    {
        /// <summary>
        /// 查看产品的用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 产品名
        /// </summary>
        public string ProductName { get; set; }
        /// <summary>
        /// 查看时间
        /// </summary>
        public DateTime ViewTime { get; set; }
        /// <summary>
        /// 持续时间
        /// </summary>
        public DateTime IntervalTime { get; set; }
    }
}
