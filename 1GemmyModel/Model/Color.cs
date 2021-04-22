using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class Color
    {
        /// <summary>
        /// 颜色名称
        /// </summary>
        [Key]
        public string ColorName { get; set; }
        /// <summary>
        /// 颜色标准
        /// </summary>
        public string ColorStandard { get; set; }
        /// <summary>
        /// 是否JC标准
        /// </summary>
        public string JCStandard { get; set; }
        /// <summary>
        /// 是否RAL标准
        /// </summary>
        public string RALStandard { get; set; }
        /// <summary>
        /// 是否定制
        /// </summary>
        public string Customization { get; set; }
        /// <summary>
        /// 颜色简称
        /// </summary>
        public string ColorNumber { get; set; }
        
        /// <summary>
        /// 定制者名称
        /// </summary>
        public string Customers { get; set; }
    }
}
