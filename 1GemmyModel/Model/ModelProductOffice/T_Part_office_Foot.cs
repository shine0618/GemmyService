using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
  public  class T_Part_office_Foot:T_Base
    {
        /// <summary>
        /// 地脚类型
        /// </summary>
        /// 
        public string Mode { get; set; }
        /// <summary>
        /// 最大长度
        /// </summary>
        public int MaxLength { get; set; }
        /// <summary>
        /// 最小长度
        /// </summary>
        public int MinLength { get; set; }
        /// <summary>
        /// 稳定性等级
        /// </summary>
        public int? StabilityLeave { get; set; }
        /// <summary>
        /// 是否用于易安装
        /// </summary>
        public bool CanEZ { get; set; }
        /// <summary>
        /// 是否用于折叠桌
        /// </summary>
        public bool CanFold { get; set; }
        /// <summary>
        /// 是否用于翻转桌
        /// </summary>
        public bool CanTurn { get; set; }
        /// <summary>
        /// 是否用于直筒立柱
        /// </summary>
        public bool Inline { get; set; }
        /// <summary>
        /// 是否用于内磨立柱
        /// </summary>
        public bool InsideSlider { get; set; }
        /// <summary>
        /// 是否适用于双电机
        /// </summary>
        public bool DoubleMotor { get; set; }
        /// <summary>
        /// 是否适用于手摇
        /// </summary>
        public bool HandCranking { get; set; }
        /// <summary>
        /// 是否适用于气动
        /// </summary>
        public bool GasSpring { get; set; }
        /// <summary>
        /// 是否适用于单电机
        /// </summary>
        public bool SingleMotor { get; set; }
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
        /// 地脚和立柱适配
        /// </summary>

        public string FootWithColumn { get; set; }
        /// <summary>
        /// 含税成本
        /// </summary>
        public double? TaxCost { get; set; }
        /// <summary>
        /// 转让成本
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
