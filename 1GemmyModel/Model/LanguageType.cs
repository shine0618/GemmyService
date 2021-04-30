using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class LanguageType:T_Base
    {
        /// <summary>
        /// 语言种类
        /// </summary>
        [Index]
        public string Language { get; set; }
    }
}
