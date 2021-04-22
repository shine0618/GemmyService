using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class PowerCable
    {
        /// <summary>
        /// 电源线种类英文名称
        /// </summary>
        [Key]
        public string PowerCableEN { get; set; }
        /// <summary>
        /// 电源线种类中文名称
        /// </summary>
        [Key]
        public string PowerCableZH { get; set; }
        /// <summary>
        /// 电源线长度
        /// </summary>
        public int? PowerCableLength { get; set; }

    }
}
