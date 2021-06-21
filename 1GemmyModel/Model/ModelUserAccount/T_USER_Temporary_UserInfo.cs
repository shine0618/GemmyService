using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class T_USER_Temporary_UserInfo:T_Base
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
        /// 失效时间
        /// </summary>
        public DateTime? FailTime { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 重置密码失效时间
        /// </summary>
        public DateTime? ResetFailTime { get; set; }
        /// <summary>
        /// 重置密码验证码
        /// </summary>
        public string ResetCode { get; set; }
    }
}
