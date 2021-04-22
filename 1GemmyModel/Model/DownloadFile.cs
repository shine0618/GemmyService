using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class DownloadFile
    {
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 下载者
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 下载时间
        /// </summary>
        public DateTime DownloadTime { get; set; }
    }
}
