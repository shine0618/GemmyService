using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelUserAccount
{
    /// <summary>
    /// 用户权限
    /// </summary>
   public class T_USER_Permission:T_Base
    {

        public string userName { get; set; }

        public bool isAllow { get; set; }

        /// <summary>
        /// 权限对象ID
        /// </summary>
        public int PermissionId { get; set; }

    }
}
