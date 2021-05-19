using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
    /// <summary>
    /// 关键参数描述
    /// </summary>
   public class T_Product_office_description
    {
        [Key]
        public int Id { get; set; }

        [Index]
        public int textKay { get; set; }

        public string langCode { get; set; }

        public string textValue { get; set; }
    }
}
