using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using _1GemmyModel.Model;
using _2GemmyBusness.BLL.BLLSystem;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
  public  class BLL_Office_desk:BLLBase
    {
        #region 

        BLL_Office_desk_collect bll_collect = null;

        public BLL_Office_desk()
        {
            bll_collect = new BLL_Office_desk_collect();
        }
        #endregion

        #region Add desk

        public int AddT_Product_office_desk_detail(T_Product_office_desk_detail detail)
        {
            int i = base.AddEntities<T_Product_office_desk_detail>(detail);


            return i;

        }

        /// <summary>
        /// 添加桌子并返回桌子的ID
        /// </summary>
        /// <param name="desk"></param>
        /// <returns></returns>
        public int AddT_Product_office_desk(T_Product_office_desk desk)
        {
            string guid = desk.deskGuid;
            if (string.IsNullOrEmpty(guid))
            {
                return -2;
            }
            int suc = base.AddEntities<T_Product_office_desk>(desk);
            if(suc>0)
            {
                var q = read_db.T_Product_office_desk.Where(x => x.deskGuid == guid).FirstOrDefault();
                return q.Id;

                    
            }
            return 0;

        }
        #endregion


        public T_Product_office_desk GetT_Product_office_desk(string Guid)
        {
           return  read_db.T_Product_office_desk.Where(x => x.deskGuid == Guid).FirstOrDefault();
        }


       

        public List<T_Product_office_desk> GetT_Product_office_desk(string Type,string langCode,string recommend,string searchText,string userName)
        {


           var query= from x in read_db.T_Product_office_desk
                        join Tag in read_db.T_Product_office_text  on x.deskTagKey equals Tag.textKay into dc
                        from dci  in dc.DefaultIfEmpty()
                        join ShortDes in read_db.T_Product_office_text on x.deskShortDescriptionKey equals ShortDes.textKay  into dd
                        from ddi in dd.DefaultIfEmpty()
                        
                        where dci.langCode==langCode
                        where ddi.langCode ==langCode
                        where x.deskType == Type
                        where x.deleteSign != 1
                        where (x.deskCustmoer ==true && x.deskCreateByUser ==userName ) || (x.deskCustmoer == false)
                      select new 
                        {
                            //---t_base //查找原因后发现是UpdateTime和JSON转换的原因
                            Id = x.Id,
                            verificationCode = x.verificationCode,
                            UpdateTime = x.UpdateTime,
                            CreateTime = x.CreateTime,
                            deletePerson = x.deletePerson,
                            CreatePerson = x.CreatePerson,
                            UpdatePerson = x.UpdatePerson,
                            Remark = x.Remark,
                            //----end of t_base
                            deskGuid = x.deskGuid,
                            deskType = x.deskType,
                            deskTagKey = x.deskTagKey,
                            deskShortDescriptionKey = x.deskShortDescriptionKey,
                            deskSerialName = x.deskSerialName,
                            deskImgUrl = x.deskImgUrl,
                            deskSalesVolume = x.deskSalesVolume,
                            deskPrice = x.deskPrice,
                            deskStabilityLeave = x.deskStabilityLeave,
                            deskMaxLoad = x.deskMaxLoad,
                            deskNewProductNumber = x.deskNewProductNumber,
                            deskNewProduct = x.deskNewProduct,
                            deskJCRecommend = x.deskJCRecommend,
                            deskCreateByUser = x.deskCreateByUser,
                           deskCustomerName = x.deskCustomerName,
                            deskTag = dci.textValue,
                            deskShortDescription = ddi.textValue,
                            deskCustmoer = x.deskCustmoer,

                        };




            switch (recommend)
            {
                case "newProduct":query = query.Where(x => x.deskNewProduct == true);break;
                case "jiecangProduct": query = query.Where(x => x.deskJCRecommend == true); break;
                case "customer": query = query.Where(x => x.deskCustmoer == true && x.deskCreateByUser == userName);break;
                case "myCollect":
                    //去看收藏表

                    List<T_Office_desk_collect> list_collect = bll_collect.GetT_Office_desk_collect(userName);
                    List<int> str_collect = new List<int>();
                    foreach(T_Office_desk_collect item in list_collect)
                    {
                        str_collect.Add(item.DeskId);
                    }
                   
                    query = query.Where(x => str_collect.Contains(x.Id));




                    break;
                case "all": break;
                //补充我的定制
                default:
                    query = null;
                    break;
            }

            if (searchText.Trim() != "")
            {
                query = query.Where(x => x.deskSerialName.Contains(searchText.Trim()));
            }


            List<T_Product_office_desk> list = new List<T_Product_office_desk>();

            foreach (var  model in query)
            {
                string str = JsonConvert.SerializeObject(model);
                //    T_Product_office_desk mmm = JsonToObject<T_Product_office_desk>(str);

                T_Product_office_desk mmm = JsonConvert.DeserializeObject<T_Product_office_desk>(str);

                if (mmm.deskTag==null)
                {
                    mmm.deskTag = "";
                }
                if(mmm.deskShortDescription==null)
                {
                    mmm.deskShortDescription = "";
                }
                if(mmm.deskCustmoer)
                {
                    mmm.deskShortDescription = mmm.deskCustomerName;
                }
                list.Add(mmm);
            }

            return list;

                       
   

        }


    public T_Product_office_desk_detail GetT_Product_office_desk_detail(int desk_id,string langCode)
        {
            T_Product_office_desk_detail model =  read_db.T_Product_office_desk_detail.Where(x => x.T_Product_office_desk_Id == desk_id).FirstOrDefault();
            if(model!=null)
            {
                //立柱
                if(model.ColumnType!=null&&model.ColumnType!="")
                {
                    model.T_Part_office_Column = GetT_Part_office_Column(model.ColumnType,langCode);
                }
                //框架
                if (model.FrameType != null && model.FrameType != "")
                {
                    model.T_Part_office_Frame = GetT_Part_office_Frame(model.FrameType, langCode);
                }
                //地脚
                if (model.FootType != null && model.FootType != "")
                {
                    model.T_Part_office_Foot = GetT_Part_office_Foot(model.FootType, langCode);
                }
                //侧板
                if (model.SideBracketType != null && model.SideBracketType != "")
                {
                    model.T_Part_office_SideBracket = GetT_Part_office_SideBracket(model.SideBracketType, langCode);
                }
                //控制器
                if (model.ControlboxType != null && model.ControlboxType != "")
                {
                    model.T_Part_office_ControlBox = GetT_Part_office_ControlBox(model.ControlboxType, langCode);
                }
                //手控器
                if (model.HandsetType != null && model.HandsetType != "")
                {
                    model.T_Part_office_HandSet = GetT_Part_office_HandSet(model.HandsetType, langCode);
                }

                //电源线
                if (model.select_PowercableMode != null && model.select_PowercableMode != "")
                {
                    model.T_Part_office_Powercable = GetT_Part_office_Powercable(model.select_PowercableMode, langCode);
                }

                //颜色
                if (model.select_ColorMode != null && model.select_ColorMode != "")
                {
                    model.T_Office_Color = GetT_Office_Color(model.select_ColorMode, langCode);
                }
                return model;
            }
            else
            {
                return null;
            }
        }

        public T_Product_office_description GetT_Product_office_description_first(int index, string lang)
        {
            var query = from x in read_db.T_Product_office_description
                        where x.langCode == lang
                        where x.textKay == index
                        select x;

            return query.FirstOrDefault();
        }
        public List<T_Product_office_description> GetT_Product_office_description(int index,string lang)
        {
            var query = from x in read_db.T_Product_office_description
                        where x.langCode == lang
                        where x.textKay == index
                        select x;

            return query.ToList();
        }

        //public List<T_Product_office_desk> GetT_Product_office_desk(string Type,string Recommend)
        //{
        //    var query = read_db.T_Product_office_desk.Where(m => m.deskNewProduct == true);

        //    return query.ToList();
        //}



        #region 部件表操作

        /// <summary>
        /// 获取部件的关键参数
        /// </summary>
        /// <param name="index"></param>
        /// <param name="lang">空代表全部</param>
        /// <returns></returns>
        public List<T_Part_office_describe> GetT_Part_office_describe(int index,string lang)
        {
            if(lang.Trim()=="")
            {
                var q = from x in read_db.T_Part_office_describe
                        where x.textKay == index
                        select x;

                return q.ToList();
            }
            else
            {
                var q = from x in read_db.T_Part_office_describe
                        where x.textKay == index
                        where x.langCode == lang
                        select x;

                return q.ToList();
            }
            
         

        }

        #region 获取部件详情

        public object GetPartDetail(string partType,string Mode,string langCode)
        {

            string imgurl = string.Empty;
            int parametricTextIndex = 0;
            string ColumnWithFoot = "";
            string ColumnWithFrame = "";
            string FrameWithSideBracket = "";
            List<T_Part_office_describe> des = new List<T_Part_office_describe>();

            switch (partType)
            {

                case "column":
                    T_Part_office_Column q4 = GetT_Part_office_Column(Mode, langCode);
                    imgurl = q4.PictureName;
                    ColumnWithFoot = q4.ColumnWithFoot;
                    ColumnWithFrame = q4.ColumnWithFrame;

                    parametricTextIndex = q4.parametricTextIndex;
                    des = q4.T_Part_office_describes;
                    break;
                case "frame":
                    T_Part_office_Frame q5 = GetT_Part_office_Frame(Mode, langCode);
                    imgurl = q5.PictureName;
                    parametricTextIndex = q5.parametricTextIndex;
                    ColumnWithFrame = q5.FrameWithColumn;
                    FrameWithSideBracket = q5.FrameWithSideBracket;
                    des = q5.T_Part_office_describes;
                    break;

                case "foot":
                    T_Part_office_Foot q6 = GetT_Part_office_Foot(Mode, langCode);
                    imgurl = q6.PictureName;
                    parametricTextIndex = q6.parametricTextIndex;
                    ColumnWithFoot = q6.FootWithColumn;

                    des = q6.T_Part_office_describes;

                    break;

                case "SideBracket":
                    T_Part_office_SideBracket q7 = GetT_Part_office_SideBracket(Mode, langCode);
                    imgurl = q7.PictureName;
                    parametricTextIndex = q7.parametricTextIndex;
                    FrameWithSideBracket = q7.SideBracketWithFrame;
                    des = q7.T_Part_office_describes;
                    break;

                case "ControlBox":
                    T_Part_office_ControlBox q = GetT_Part_office_ControlBox(Mode, langCode);
                    imgurl = q.PictureName;
                    parametricTextIndex = q.parametricTextIndex;
                    des = q.T_Part_office_describes;
                    break;

                case "HandSet":
                    T_Part_office_HandSet q2 = GetT_Part_office_HandSet(Mode, langCode);
                    imgurl = q2.PictureName;
                    parametricTextIndex = q2.parametricTextIndex;
                    des = q2.T_Part_office_describes;
                    break;

                case "Powercable":
                    T_Part_office_Powercable q3 = GetT_Part_office_Powercable(Mode, langCode);
                    imgurl = q3.PictureName;
                    parametricTextIndex = q3.parametricTextIndex;
                    des = q3.T_Part_office_describes;
                    break;

                default:
                    break;
            }

            var param = new
            {
                imgurl = imgurl,
                mode = Mode,
                des = des,
                parametricTextIndex = parametricTextIndex,
                ColumnWithFoot = ColumnWithFoot,
                ColumnWithFrame = ColumnWithFrame,
                FrameWithSideBracket = FrameWithSideBracket,

            };

            return param;
        }



        #endregion

        /// <summary>
        /// 根据mode获取
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>

        public T_Part_office_Column GetT_Part_office_Column(string mode,string langCode)
        {
            var query = from x in read_db.T_Part_office_Column
                        where x.Mode== mode
                        select x;


            T_Part_office_Column model = query.FirstOrDefault();

            if (model != null && model.Id > 0&&langCode!="")
            {
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);
            }

            return model;


        }

        public T_Part_office_Frame GetT_Part_office_Frame(string mode, string langCode)
        {
            var query = from x in read_db.T_Part_office_Frame
                        where x.Mode == mode
                        select x;

            T_Part_office_Frame model = query.FirstOrDefault();

            if (model != null && model.Id > 0&&langCode!="")
            {
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);

                if (model.MinLength != 0)
                {
                    string t = BLL_SYS_language.GetTextByKey(langCode, "text_part_description_1");//最小长度
                    model.T_Part_office_describes.Add(new T_Part_office_describe(langCode, t + ":" + model.MinLength.ToString()));
                }
                if (model.MaxLength != 0)
                {
                    string t = BLL_SYS_language.GetTextByKey(langCode, "text_part_description_2");//最小长度
                    model.T_Part_office_describes.Add(new T_Part_office_describe(langCode, t + ":" + model.MaxLength.ToString()));
                }
            }

            return model;
        }
        public T_Part_office_Foot GetT_Part_office_Foot(string mode, string langCode)
        {
            var query = from x in read_db.T_Part_office_Foot
                        where x.Mode == mode
                        select x;

            T_Part_office_Foot model = query.FirstOrDefault();

            if (model != null && model.Id > 0)
            {
             
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);
                
                   
                if (model.MinLength != 0)
                {
                    string t = BLL_SYS_language.GetTextByKey(langCode, "text_part_description_1");//最小长度
                    model.T_Part_office_describes.Add( new T_Part_office_describe(langCode,t+":"+ model.MinLength.ToString()));
                }
                if (model.MaxLength != 0)
                {
                    string t = BLL_SYS_language.GetTextByKey(langCode, "text_part_description_2");//最小长度
                    model.T_Part_office_describes.Add(new T_Part_office_describe(langCode, t + ":" + model.MaxLength.ToString()));
                }
            }

            return model;
        }
        public T_Part_office_SideBracket GetT_Part_office_SideBracket(string mode, string langCode)
        {
            var query = from x in read_db.T_Part_office_SideBracket
                        where x.Mode == mode
                        select x;

            T_Part_office_SideBracket model = query.FirstOrDefault();

            if (model != null && model.Id > 0)
            {
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);


                if (model.MinLength != 0)
                {
                    string t = BLL_SYS_language.GetTextByKey(langCode, "text_part_description_1");//最小长度
                    model.T_Part_office_describes.Add(new T_Part_office_describe(langCode, t + ":" + model.MinLength.ToString()));
                }
                if (model.MaxLength != 0)
                {
                    string t = BLL_SYS_language.GetTextByKey(langCode, "text_part_description_2");//最小长度
                    model.T_Part_office_describes.Add(new T_Part_office_describe(langCode, t + ":" + model.MaxLength.ToString()));
                }
            }

            return model;
        }


        public T_Part_office_ControlBox GetT_Part_office_ControlBox(string mode,string langCode)
        {
            var query = from x in read_db.T_Part_office_ControlBox
                        where x.Mode == mode
                        select x;

            T_Part_office_ControlBox model = query.FirstOrDefault();

            if(model!=null&&model.Id>0)
            {
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);
            }

            return model;
        }
        public T_Part_office_HandSet GetT_Part_office_HandSet(string mode,string langCode)
        {
            var query = from x in read_db.T_Part_office_HandSet
                        where x.Mode == mode
                        select x;
            T_Part_office_HandSet model = query.FirstOrDefault();
            if (model != null && model.Id > 0)
            {
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);
            }

            return model ;
        }
        public T_Part_office_Powercable GetT_Part_office_Powercable(string mode,string langCode)
        {
            var query = from x in read_db.T_Part_office_Powercable
                        where x.Mode == mode
                        select x;

            T_Part_office_Powercable model = query.FirstOrDefault();

            if (model != null && model.Id > 0)
            {
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);
            }

            return model;
        }

        public T_Office_Color GetT_Office_Color(string mode, string langCode)
        {
            var query = from x in read_db.T_Office_Color
                        where x.ColorName == mode
                        select x;

            T_Office_Color model = query.FirstOrDefault();

            if (model != null && model.Id > 0)
            {
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);
            }

            return model;
        }

        /// <summary>
        /// 获取所有的
        /// </summary>
        /// <returns></returns>
        public List<T_Part_office_Column> GetT_Part_office_Column(string columnType)
        {
            var query = from x in read_db.T_Part_office_Column
                        where x.deleteSign != 1
                        select x;


            switch (columnType)
            {
                case "column_2_s":
                    query = query.Where(x => x.Type == "S" && x.Level == "2");
                    break;
                case "column_2_r":
                    query = query.Where(x => x.Type == "R" && x.Level == "2");
                    break;
                case "column_3_s":
                    query = query.Where(x => x.Type == "S" && x.Level == "3");
                    break;
                case "column_3_r":
                    query = query.Where(x => x.Type == "R" && x.Level == "3");
                    break;
                default:
                    break;
            }

            return query.ToList();
        }

        public List<T_Part_office_Frame> GetT_Part_office_Frame(string select_columnMode)
        {
            var query = from x in read_db.T_Part_office_Frame
                        where x.deleteSign!=1
                        select x;

            List<T_Part_office_Frame> list = query.ToList();
            if (select_columnMode != null && select_columnMode != "")
            {
                //检查FOOT和Column的适配性
                //1.孔位
                T_Part_office_Column column = GetT_Part_office_Column(select_columnMode, "");
                if (column != null)
                {
                    list = list.Where(x => x.FrameWithColumn == column.ColumnWithFrame).ToList();
                }
            }
            return list;
        }
        public List<T_Part_office_Foot> GetT_Part_office_Foot(string select_columnMode)
        {
            var query = from x in read_db.T_Part_office_Foot
                        where x.deleteSign != 1
                        select x;


            List<T_Part_office_Foot> list =  query.ToList();
            if(select_columnMode!=null && select_columnMode!="")
            {
                //检查FOOT和Column的适配性
                //1.孔位
                T_Part_office_Column column = GetT_Part_office_Column(select_columnMode, "");
                if(column!=null)
                {
                    list = list.Where(x => x.FootWithColumn == column.ColumnWithFoot).ToList();
                }
            }
            return list;
        }
        public List<T_Part_office_SideBracket> GetT_Part_office_SideBracket(string select_frame)
        {
            var query = from x in read_db.T_Part_office_SideBracket
                        where x.deleteSign != 1
                        select x;

            List<T_Part_office_SideBracket> list = query.ToList();
            if (select_frame != null && select_frame != "")
            {
                //检查FOOT和Column的适配性
                //1.孔位
                T_Part_office_Frame column = GetT_Part_office_Frame(select_frame, "");
                if (column != null)
                {
                    list = list.Where(x => x.SideBracketWithFrame == column.FrameWithSideBracket).ToList();
                }
            }
            return list;
        }
        public List<T_Part_office_ControlBox> GetT_Part_office_ControlBox()
        {
            var query = from x in read_db.T_Part_office_ControlBox
                        where x.deleteSign != 1
                        select x;

            return query.ToList();
        }


        public List<T_Part_office_HandSet> GetT_Part_office_HandSet()
        {
            var query = from x in read_db.T_Part_office_HandSet
                        where x.deleteSign != 1
                        select x;

            return query.ToList();
        }
        public List<T_Part_office_Powercable> GetT_Part_office_Powercable()
        {
            var query = from x in read_db.T_Part_office_Powercable
                        where x.deleteSign != 1
                        select x;

            return query.ToList();
        }

        

        #endregion
    }
}
