using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GemmyService.Models.HomeViewModels
{
    public class ResetPasswordViewModel
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string UserName { get; set; }
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
    }
}