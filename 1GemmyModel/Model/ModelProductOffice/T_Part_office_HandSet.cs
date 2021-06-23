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
   public class T_Part_office_HandSet : T_Base
    {
        /// <summary>
        /// 手控器型号
        /// </summary>
        public string Mode { get; set; }
        /// <summary>
        /// 是否有显示屏
        /// </summary>
        public bool HaveScreen { get; set; }
        /// <summary>
        /// 显示屏类型
        /// </summary>
        public string ScreenType { get; set; }
        /// <summary>
        /// 是否是触摸
        /// </summary>
        public bool Touch { get; set; }
        /// <summary>
        /// 是否是按键
        /// </summary>
        public bool Button { get; set; }
        /// <summary>
        /// 是否带USB
        /// </summary>
        public bool HaveUsb { get; set; }
        /// <summary>
        /// 是否是嵌入式
        /// </summary>
        public bool Imbedding { get; set; }
        /// <summary>
        /// 是否遥控
        /// </summary>
        public bool Remote { get; set; }
        /// <summary>
        /// 是否带蓝牙
        /// </summary>
        public bool BlueTooth { get; set; }
        /// <summary>
        /// 记忆键数量
        /// </summary>
        public int MemoryKeys { get; set; }
        /// <summary>
        /// 输出电压
        /// </summary>
        public int? OutputVoltage { get; set; }
        /// <summary>
        /// 输入电压
        /// </summary>
        public int? InputVoltage { get; set; }
        /// <summary>
        /// 变压器功率
        /// </summary>
        public int? TransformerPower { get; set; }
        /// <summary>
        /// 额定电压
        /// </summary>
        public int? Voltage { get; set; }
        /// <summary>
        /// 电流
        /// </summary>
        public int? Current { get; set; }
        /// <summary>
        /// 手控器插口
        /// </summary>
        public string HandSetOutLet { get; set; }
        /// <summary>
        /// 是否可配双电机
        /// </summary>
        public bool DoubleMotor { get; set; }
        /// <summary>
        /// 是否可配手摇
        /// </summary>
        public bool HandCranking { get; set; }
        /// <summary>
        /// 是否可配气动
        /// </summary>
        public bool GasSpring { get; set; }
        /// <summary>
        /// 是否可配单电机
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
        public string  PictureNum { get; set; }
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
        /// 手控器连接控制器
        /// </summary>
        public string HandsetWithControlBox { get; set; }
        /// <summary>
        /// 手控器连接配件
        /// </summary>
        public string HandsetWithAccessory { get; set; }
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
        /// 是否带插槽
        /// </summary>
        public bool HaveRabbet { get; set; }
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
