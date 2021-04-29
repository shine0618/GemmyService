using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class Accessory:T_Base
    {
        /// <summary>
        /// 配件型号
        /// </summary>
        [Index]
        public string Mode { get; set; }
        /// <summary>
        /// 配件英文名称
        /// </summary>
        public string ProductNameEN { get; set; }
        /// <summary>
        /// 配件中文名称
        /// </summary>
        public string ProductNameZH { get; set; }
        /// <summary>
        /// 是否通过GS
        /// </summary>
        public bool GS { get; set; }
        /// <summary>
        /// 是否通过EN527
        /// </summary>
        public bool EN527 { get; set; }
        /// <summary>
        /// 是否通过CE
        /// </summary>
        public bool CE { get; set; }
        /// <summary>
        /// 是否通过EMC
        /// </summary>
        public bool EMC { get; set; }
        /// <summary>
        /// 是否通过BIFMA
        /// </summary>
        public bool BIFMA { get; set; }
        /// <summary>
        /// 是否通过UL962
        /// </summary>
        public bool UL962 { get; set; }
        /// <summary>
        /// 2D图号
        /// </summary>
        public string DrawingNum2D { get; set; }
        /// <summary>
        /// 3D图号
        /// </summary>
        public string DrawingNum3D { get; set; }
        /// <summary>
        /// 3D图名
        /// </summary>
        public string DrawingName3D { get; set; }
        /// <summary>
        /// 2D图名
        /// </summary>
        public string DrawingName2D { get; set; }
        /// <summary>
        /// 效果图名
        /// </summary>
        public string PictureName { get; set; }
        /// <summary>
        /// 效果图号
        /// </summary>
        public string PictureNum { get; set; }
        /// <summary>
        /// 物料代码
        /// </summary>
        public string PartCode { get; set; }
        /// <summary>
        /// 重量
        /// </summary>
        public double? Weight { get; set; }
        /// <summary>
        /// 中文描述
        /// </summary>
        [Column(TypeName = "ntext")]
        public string DescriptionZH { get; set; }
        /// <summary>
        /// 英文描述
        /// </summary>
        [Column(TypeName = "ntext")]
        public string DescriptionEN { get; set; }
        /// <summary>
        /// 配件适配控制器
        /// </summary>
        public string AccessoryWithControlBox { get; set; }
        /// <summary>
        /// 配件适配手控器
        /// </summary>
        public string AccessoryWithHandSet { get; set; }
        /// <summary>
        /// 额定功率
        /// </summary>
        public double? Power { get; set; }
        /// <summary>
        /// 额定电压
        /// </summary>
        public double? Voltage { get; set; }
        /// <summary>
        /// 额定电流
        /// </summary>
        public double? Current { get; set; }
        /// <summary>
        /// 含税成本
        /// </summary>
        public double? TaxCost { get; set; }
        /// <summary>
        /// 转让价格
        /// </summary>
        public double? TransferPrice { get; set; }
        /// <summary>
        /// 参考价格
        /// </summary>
        public double? ReferencePrice { get; set; }
        /// <summary>
        /// 定制客户
        /// </summary>
        public string Customization { get; set; }
        /// <summary>
        /// 中文特殊说明
        /// </summary>
        [Column(TypeName = "ntext")]
        public string SpecialDescriptionZH { get; set; }
        /// <summary>
        /// 英文特殊说明
        /// </summary>
        [Column(TypeName = "ntext")]
        public string SpecialDescriptionEN { get; set; }
    }
}
