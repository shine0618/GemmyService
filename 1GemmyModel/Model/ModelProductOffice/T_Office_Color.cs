using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class T_Office_Color : T_Base
    {
        /// <summary>
        /// 颜色名称
        /// </summary>
        public string ColorName { get; set; }
        /// <summary>
        /// 颜色标准
        /// </summary>
        public string ColorStandard { get; set; }
        /// <summary>
        /// 是否JC标准
        /// </summary>
        public bool JCStandard { get; set; }
        /// <summary>
        /// 是否RAL标准
        /// </summary>
        public bool RALStandard { get; set; }
        /// <summary>
        /// 是否定制
        /// </summary>
        public bool Customization { get; set; }
        /// <summary>
        /// 颜色简称
        /// </summary>
        public string ColorNumber { get; set; }        
        /// <summary>
        /// 定制者名称
        /// </summary>
        public string Customers { get; set; }
        /// <summary>
        /// RGB的R值
        /// </summary>
        public decimal RValueRGB { get; set; }
        /// <summary>
        /// RGB的G值
        /// </summary>
        public decimal GValueRGB { get; set; }
        /// <summary>
        /// RGB的B值
        /// </summary>
        public decimal BValueRGB { get; set; }
        /// <summary>
        /// 十六进制数值
        /// </summary>
        public string HEXValue { get; set; }
        /// <summary>
        /// Lab的L值
        /// </summary>
        public decimal LValueLab { get; set; }
        /// <summary>
        /// Lab的A值
        /// </summary>
        public decimal AValueLab { get; set; }
        /// <summary>
        /// Lab的B值
        /// </summary>
        public decimal BValueLab { get; set; }
    }
}
