using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class T_Part_office_Column:T_Base
    {
        /// <summary>
        /// 立柱型号
        /// </summary>
       
        public string Mode { get; set; }
        /// <summary>
        /// 正装倒装
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// 立柱节数
        /// </summary>
        public string Level { get; set; }
        /// <summary>
        /// 管形形状
        /// </summary>
        public string Form { get; set; }
        /// <summary>
        /// 内管尺寸
        /// </summary>
        public string Size_Out { get; set; }
        /// <summary>
        /// 中管尺寸
        /// </summary>
        public string Size_Middle { get; set; }
        /// <summary>
        /// 外管尺寸
        /// </summary>
        public string Size_Inside { get; set; }
        /// <summary>
        /// 行程
        /// </summary>
        public int StrokeLength { get; set; }
        /// <summary>
        /// 最大行程
        /// </summary>
        public int? MaxStroke { get; set; }
        /// <summary>
        /// 最低点(安装距)
        /// </summary>
        public int LowestPosition { get; set; }
        /// <summary>
        /// 最高点
        /// </summary>
        public int HighestPosition { get; set; }
        /// <summary>
        /// 额定负载
        /// </summary>
        public int LoadCapacity { get; set; }
        /// <summary>
        /// 最大负载
        /// </summary>
        public int? MaxLoad { get; set; }
        /// <summary>
        /// 额定速度
        /// </summary>
        public int Speed { get; set; }
        /// <summary>
        /// 最大速度
        /// </summary>
        public int? MaxSpeed { get; set; }
        /// <summary>
        /// 额定功率
        /// </summary>
        public int? Power { get; set; }
        /// <summary>
        /// 稳定性等级
        /// </summary>
        public int? StabilityLeave { get; set; }
        /// <summary>
        /// 电机代号
        /// </summary>
        public string MotorCode { get; set; }
        /// <summary>
        /// 是否带双电机
        /// </summary>
        public bool HaveMotor { get; set; }
        /// <summary>
        /// 是否直筒立柱
        /// </summary>
        public bool Inline { get; set; }
        /// <summary>
        /// 是否内磨立柱
        /// </summary>
        public bool InsideSlider { get; set; }
        /// <summary>
        /// 是否适用单电机
        /// </summary>
        public bool SingleMotor { get; set; }
        /// <summary>
        /// 是否适用手摇
        /// </summary>
        public bool HandCranking { get; set; }
        /// <summary>
        /// 是否适用气动
        /// </summary>
        public bool GasSpring { get; set; }
        /// <summary>
        /// 是否能易安装
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
        /// 是否通过GS认证
        /// </summary>
        public bool GS { get; set; }
        /// <summary>
        /// 是否通过EN527认证
        /// </summary>
        public bool EN527 { get; set; }
        /// <summary>
        /// 是否通过CE认证
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
        /// 效果图
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
        /// 立柱和地脚适配
        /// </summary>
        public string ColumnWithFoot { get; set; }
        /// <summary>
        /// 立柱和框架适配
        /// </summary>
        public string ColumnWithFrame { get; set; }
        /// <summary>
        /// 手控器连接
        /// </summary>
        public string HandsetConnect { get; set; }
        /// <summary>
        /// 控制器连接
        /// </summary>
        public string ControlboxConnect { get; set; }
        /// <summary>
        /// 配件连接
        /// </summary>
        public string AccessoryConnect { get; set; }
        /// <summary>
        /// 立柱和侧板适配
        /// </summary>
        public string ColumnWithSideBracket { get; set; }
        /// <summary>
        /// 含税成本
        /// </summary>
        public double? TaxCost { get; set; }
        /// <summary>
        /// 转让价
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

        /// <summary>
        /// 参数的描述  对应表T_Part_office_describe的Id
        /// </summary>
        public int parametricTextIndex { get; set; }


        [NotMapped]
        public List<T_Part_office_describe> T_Part_office_describes { get; set; }
    }
}
