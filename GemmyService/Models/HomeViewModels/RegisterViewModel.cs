using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemmyService.Models.HomeViewModels
{
    public class RegisterViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [StringLength(20,MinimumLength = 6)]
        public string Password { get; set; }
        /// <summary>
        /// 确认密码
        /// </summary>
        [Required]
        [Compare(nameof(Password))]
        public string ConfirmPwd { get; set; }
        /// <summary>
        /// 密保问题
        /// </summary>
        [Required]
        public string Question { get; set; }
        /// <summary>
        /// 密保答案
        /// </summary>
        [Required]
        public string Answer { get; set; }
        /// <summary>
        /// 电子邮箱
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }

    }
}