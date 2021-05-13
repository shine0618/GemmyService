using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelProductOffice
{
   public class T_Product_office_desk:T_Base
    {

        /// <summary>
        /// TO/TS/TT/TF...
        /// </summary>
        public string deskType { get; set; }
        /// <summary>
        /// 新品 畅销那个标签
        /// </summary>
        public string deskTag { get; set; }

        /// <summary>
        /// 小圆管
        /// </summary>
        public string deskShortDescription { get; set; }

        /// <summary>
        /// 桌子系列名称
        /// </summary>
        public string deskSerialName { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public  string deskImgUrl { get; set; }


        /// <summary>
        /// 销量指数
        /// </summary>
        public double deskSalesVolume { get; set; }

        /// <summary>
        /// 价格指数
        /// </summary>
        public double deskPrice { get; set; }

        
    }
}
