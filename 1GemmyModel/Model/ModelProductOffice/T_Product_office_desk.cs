using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelProductOffice
{
   public class T_Product_office_desk:T_Base
    {
        public T_Product_office_desk()
        {
            deskTag = "";
            deskGuid = System.Guid.NewGuid().ToString("N");
        }
        public string deskGuid { get; set; }

        /// <summary>
        /// TO/TS/TT/TF...
        /// </summary>
        public string deskType { get; set; }

        public int deskTagKey { get; set; }
        /// <summary>
        /// 新品 畅销那个标签
        /// </summary>
        public string deskTag { get; set; }


        public int deskShortDescriptionKey { get; set; }
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

        /// <summary>
        /// 稳定性指数
        /// </summary>
        public double deskStabilityLeave { get; set; }

        /// <summary>
        /// 负责指数
        /// </summary>
        public double deskMaxLoad { get; set; }


        /// <summary>
        /// 新品指数
        /// </summary>
        public double deskNewProductNumber { get; set; }
        /// <summary>
        /// 是否为新品推荐
        /// </summary>
        public bool deskNewProduct{ get; set; }

        /// <summary>
        /// 是否为捷昌推荐
        /// </summary>
        public bool deskJCRecommend { get; set; }

        /// <summary>
        /// 当前账户定制的产品
        /// </summary>
        public string deskCreateByUser { get; set; }


    }
}
