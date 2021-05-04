using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class PowerCable:T_Base
    {
        /// <summary>
        /// 电源线种类英文名称
        /// </summary>
        [Index]
        public string PowerCableEN { get; set; }
        /// <summary>
        /// 电源线种类中文名称
        /// </summary>
        [Index]
        public string PowerCableZH { get; set; }
        /// <summary>
        /// 电源线长度
        /// </summary>
        public int? PowerCableLength { get; set; }

    }
}
