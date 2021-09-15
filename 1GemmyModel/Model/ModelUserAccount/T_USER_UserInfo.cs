using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class T_USER_UserInfo : T_Base
    {
        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        public string Email { get; set; }

       
        /// <summary>
        /// 名
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 姓
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 头像路径
        /// </summary>
        public string PicPath { get; set; }
        /// <summary>
        /// 账号封禁
        /// </summary>
        public bool Lock { get; set; }
        /// <summary>
        /// 权限等级
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 能否查询订单
        /// </summary>
        public bool isorder { get; set; }

        [NotMapped]
        public bool CanLogin { get; set; }

        [NotMapped]
        public bool NoUsername { get; set; }

        [NotMapped]
        public bool NoPassword { get; set; }

    }
}
