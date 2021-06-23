using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelProductOffice
{
   public class T_Part_office_Powercable:T_Base
    {
        public string Mode { get; set; }
        public double? PowercableLength { get; set; }
        public int HeadPlug { get; set; }
        public string TailPlug { get; set; }
        public string PictureName { get; set; }


        /// <summary>
        /// 参数的描述  对应表T_Part_office_describe的Id
        /// </summary>
        public int parametricTextIndex { get; set; }


        [NotMapped]
        public List<T_Part_office_describe> T_Part_office_describes { get; set; }
    }
}
