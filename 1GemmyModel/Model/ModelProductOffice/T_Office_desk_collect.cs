using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelProductOffice
{
   public class T_Office_desk_collect:T_Base
    {
        /// <summary>
        /// 桌子ID
        /// </summary>
        public int DeskId { get; set; }


        /// <summary>
        /// 收藏者
        /// </summary>
        public string collectUser { get; set; }
    }
}
