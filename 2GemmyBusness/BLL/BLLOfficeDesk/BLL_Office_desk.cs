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

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
  public  class BLL_Office_desk:BLLBase
    {

        #region Add desk

        public int AddT_Product_office_desk_detail(T_Product_office_desk desk, T_Product_office_desk_detail detail)
        {
            int i = base.AddEntities<T_Product_office_desk_detail>(detail);

            return base.AddEntities<T_Product_office_desk>(desk);




        }

        #endregion


        public T_Product_office_desk GetT_Product_office_desk(string Guid)
        {
           return  read_db.T_Product_office_desk.Where(x => x.deskGuid == Guid).FirstOrDefault();
        }

        public List<T_Product_office_desk> GetT_Product_office_desk(string Type,string langCode,string recommend,string searchText)
        {


           var query= from x in read_db.T_Product_office_desk
                        join Tag in read_db.T_Product_office_text on x.deskTagKey equals Tag.textKay
                        join ShortDes in read_db.T_Product_office_text on x.deskShortDescriptionKey equals ShortDes.textKay 
                        where Tag.langCode==langCode
                        where ShortDes.langCode ==langCode
                        where x.deskType == Type
                        where x.deleteSign != 1
                        select new 
                        {
                            //---t_base
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

                            deskTag = Tag.textValue,
                            deskShortDescription = ShortDes.textValue

                        };


            switch (recommend)
            {
                case "newProduct":query = query.Where(x => x.deskNewProduct == true);break;
                case "jiecangProduct": query = query.Where(x => x.deskJCRecommend == true); break;


                //补充我的定制
                default:
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
                list.Add(JsonToObject<T_Product_office_desk>(str));
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
                if (model.ControlboxType != null && model.ControlboxType != "")
                {
                    model.T_Part_office_ControlBox = GetT_Part_office_ControlBox(model.ControlboxType, langCode);
                }
                if (model.HandsetType != null && model.HandsetType != "")
                {
                    model.T_Part_office_HandSet = GetT_Part_office_HandSet(model.HandsetType, langCode);
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
            List<T_Part_office_describe> des = new List<T_Part_office_describe>();

            switch (partType)
            {

                case "column":
                    T_Part_office_Column q4 = GetT_Part_office_Column(Mode, langCode);
                    imgurl = q4.PictureName;
                    parametricTextIndex = q4.parametricTextIndex;
                    des = q4.T_Part_office_describes;
                    break;
                case "frame":
                    T_Part_office_Frame q5 = GetT_Part_office_Frame(Mode, langCode);
                    imgurl = q5.PictureName;
                    parametricTextIndex = q5.parametricTextIndex;
                    des = q5.T_Part_office_describes;
                    break;

                case "foot":
                    T_Part_office_Foot q6 = GetT_Part_office_Foot(Mode, langCode);
                    imgurl = q6.PictureName;
                    parametricTextIndex = q6.parametricTextIndex;
                    des = q6.T_Part_office_describes;
                    break;

                case "SideBracket":
                    T_Part_office_SideBracket q7 = GetT_Part_office_SideBracket(Mode, langCode);
                    imgurl = q7.PictureName;
                    parametricTextIndex = q7.parametricTextIndex;
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
                parametricTextIndex = parametricTextIndex

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

            if (model != null && model.Id > 0)
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

            if (model != null && model.Id > 0)
            {
                model.T_Part_office_describes = GetT_Part_office_describe(model.parametricTextIndex, langCode);
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
       
        /// <summary>
        /// 获取所有的
        /// </summary>
        /// <returns></returns>
        public List<T_Part_office_Column> GetT_Part_office_Column()
        {
            var query = from x in read_db.T_Part_office_Column
                        select x;

            return query.ToList();
        }

        public List<T_Part_office_Frame> GetT_Part_office_Frame()
        {
            var query = from x in read_db.T_Part_office_Frame
                        select x;

            return query.ToList();
        }
        public List<T_Part_office_Foot> GetT_Part_office_Foot()
        {
            var query = from x in read_db.T_Part_office_Foot
                        select x;

            return query.ToList();
        }
        public List<T_Part_office_SideBracket> GetT_Part_office_SideBracket()
        {
            var query = from x in read_db.T_Part_office_SideBracket
                        select x;

            return query.ToList();
        }
        public List<T_Part_office_ControlBox> GetT_Part_office_ControlBox()
        {
            var query = from x in read_db.T_Part_office_ControlBox
                        select x;

            return query.ToList();
        }


        public List<T_Part_office_HandSet> GetT_Part_office_HandSet()
        {
            var query = from x in read_db.T_Part_office_HandSet
                        select x;

            return query.ToList();
        }
        public List<T_Part_office_Powercable> GetT_Part_office_Powercable()
        {
            var query = from x in read_db.T_Part_office_Powercable
                        select x;

            return query.ToList();
        }

        

        #endregion
    }
}
