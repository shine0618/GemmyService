using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelSystem
{
    public class T_SYS_Language:T_Base
    {

        /// <summary>
        /// 语言种类
        /// </summary>
        public string LanguageCode { get; set; }

        /// <summary>
        /// 语言描述
        /// </summary>
        public string LanguageDesript { get; set; }


    }
}
