using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelUserAccount
{
   public class T_USER_Click:T_Base
    {
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// TO点击次数
        /// </summary>
        public int TOClick { get; set; }
        /// <summary>
        /// TS点击次数
        /// </summary>
        public int TSClick { get; set; }
        /// <summary>
        /// TT点击次数
        /// </summary>
        public int TTClick { get; set; }
        /// <summary>
        /// TF点击次数
        /// </summary>
        public int TFClick { get; set; }
        /// <summary>
        /// Bench点击次数
        /// </summary>
        public int BenchClick { get; set; }
    }
}
