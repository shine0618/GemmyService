using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model
{
   public class OfficeTOList:T_Base
    {
        /// <summary>
        /// 单腿桌型号
        /// </summary>
        [Key]
        public string Mode { get; set; }
        /// <summary>
        /// 单腿桌名称
        /// </summary>
        [Key]
        public string Type { get; set; }
        /// <summary>
        /// 立柱节数
        /// </summary>
        public int Level { get; set; }
        /// <summary>
        /// 立柱管形
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
        /// 安装距
        /// </summary>
        public int StokeLength { get; set; }
        /// <summary>
        /// 最低点
        /// </summary>
        public int LowestPosition { get; set; }
        /// <summary>
        /// 最高点
        /// </summary>
        public int HighestPosition { get; set; }
        /// <summary>
        /// 框架宽度
        /// </summary>
        public int? Width { get; set; }
        /// <summary>
        /// 额定负载
        /// </summary>
        public int? LoadCapacity { get; set; }
        /// <summary>
        /// 最大负载
        /// </summary>
        public int? MaxLoad { get; set; }
        /// <summary>
        /// 额定功率
        /// </summary>
        public int? Power { get; set; }
        /// <summary>
        /// 稳定性等级
        /// </summary>
        public int? StabilityLeave { get; set; }
        /// <summary>
        /// 电机代码
        /// </summary>
        public string MotorCode { get; set; }
        /// <summary>
        /// 驱动方式
        /// </summary>
        public string PowerType { get; set; }
        /// <summary>
        /// 特殊
        /// </summary>
        public string Special { get; set; }
        /// <summary>
        /// 认证
        /// </summary>
        public string Certification { get; set; }
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
        /// 立柱型号
        /// </summary>
        public string ColumnType { get; set; }
        /// <summary>
        /// 立柱信息
        /// </summary>
        public string ColumnInfo { get; set; }
        /// <summary>
        /// 地脚型号
        /// </summary>
        public string FootType { get; set; }
        /// <summary>
        /// 地脚信息
        /// </summary>
        public string FootInfo { get; set; }
        /// <summary>
        /// 框架型号
        /// </summary>
        public string FrameType { get; set; }
        /// <summary>
        /// 框架信息
        /// </summary>
        public string FrameInfo { get; set; }
        /// <summary>
        /// 手控器型号
        /// </summary>
        public string HandsetType { get; set; }
        /// <summary>
        /// 手控器信息
        /// </summary>
        public string HandsetInfo { get; set; }
        /// <summary>
        /// 控制器型号
        /// </summary>
        public string ControlboxType { get; set; }
        /// <summary>
        /// 控制器信息
        /// </summary>
        public string ControlboxInfo { get; set; }
        /// <summary>
        /// 配件型号
        /// </summary>
        public string Accessorys { get; set; }
        /// <summary>
        /// 配件信息
        /// </summary>
        public string AccessoryInfo { get; set; }
        /// <summary>
        /// 侧板型号
        /// </summary>
        public string SideBracketType { get; set; }
        /// <summary>
        /// 侧板信息
        /// </summary>
        public string SideBracketInfo { get; set; }
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
        /// 年销量
        /// </summary>
        public int? SelledPerYear { get; set; }
        /// <summary>
        /// 更新日期
        /// </summary>
        public DateTime? StartDate { get; set; }
        /// <summary>
        /// 噪音等级
        /// </summary>
        public int? NoiseLeavel { get; set; }
        /// <summary>
        /// 包裹尺寸
        /// </summary>
        public string PackageSize { get; set; }
        /// <summary>
        /// 立柱数量
        /// </summary>
        public int? ColumnCount { get; set; }
        /// <summary>
        /// 框架数量
        /// </summary>
        public int? FrameCount { get; set; }
        /// <summary>
        /// 侧板数量
        /// </summary>
        public int? SideBracketCount { get; set; }
        /// <summary>
        /// 地脚数量
        /// </summary>
        public int? FootCount { get; set; }
        /// <summary>
        /// 控制器数量
        /// </summary>
        public int? ControlBoxCount { get; set; }
        /// <summary>
        /// 手控器数量
        /// </summary>
        public int? HandSetCount { get; set; }
        /// <summary>
        /// 配件数量
        /// </summary>
        public int? AccessorysCount { get; set; }
        /// <summary>
        /// 立柱单价
        /// </summary>
        public int? ColumnUnitPrice { get; set; }
        /// <summary>
        /// 框架单价
        /// </summary>
        public int? FrameUnitPrice { get; set; }
        /// <summary>
        /// 侧板单价
        /// </summary>
        public int? SideBracketUnitPrice { get; set; }
        /// <summary>
        /// 控制器单价
        /// </summary>
        public int? ControlBoxUnitPrice { get; set; }
        /// <summary>
        /// 手控器单价
        /// </summary>
        public int? HandSetUnitPrice { get; set; }
        /// <summary>
        /// 地脚单价
        /// </summary>
        public int? FootUnitPrice { get; set; }
        /// <summary>
        /// 配件单价
        /// </summary>
        public int? AccessoryUnitPrice { get; set; }
        /// <summary>
        /// 添加者名称
        /// </summary>
        public string AddUserName { get; set; }
    }
}
