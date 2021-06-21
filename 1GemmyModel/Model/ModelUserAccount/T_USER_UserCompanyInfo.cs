using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelUserAccount
{
   public class T_USER_UserCompanyInfo:T_Base
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Telephone { get; set; }
        /// <summary>
        /// 公司名称
        /// </summary>
        public string CompanyName { get; set; }
        /// <summary>
        /// 公司所在街道
        /// </summary>
        public string CompanyStreet { get; set; }
        /// <summary>
        /// 公司所在详细地址
        /// </summary>
        public string CompanyLocation { get; set; }
        /// <summary>
        /// 公司所在国家
        /// </summary>
        public string CompanyNation { get; set; }
        /// <summary>
        /// 公司官网
        /// </summary>
        public string CompanyWebsite { get; set; }
    }
}
