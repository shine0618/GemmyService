using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelUserAccount
{
   public class T_USER_DownloadInfo:T_Base
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// 下载文件名称
        /// </summary>
        public string Filename { get; set; }
        /// <summary>
        /// 下载时间
        /// </summary>
        public DateTime? DownloadTime { get; set; }
    }
}
