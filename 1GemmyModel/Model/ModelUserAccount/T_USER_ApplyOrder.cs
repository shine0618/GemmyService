using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelUserAccount
{
   public class T_USER_ApplyOrder: T_Base
    {
        /// <summary>
        /// 申请邮箱
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 申请时间
        /// </summary>
        public DateTime? ApplyTime { get; set; }
        /// <summary>
        /// 申请是否通过
        /// </summary>
        public bool Pass { get; set; }
        /// <summary>
        /// 审核人
        /// </summary>
        public string passemail { get; set; }
        /// <summary>
        /// 审核时间
        /// </summary>
        public DateTime? passtime { get; set; }
    }
}
