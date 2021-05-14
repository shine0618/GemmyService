﻿using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
  public  class BLL_Office_desk:BLLBase
    {
        public List<T_Product_office_desk> GetT_Product_office_desk(string Type,string langCode,string recommend)
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

            List<T_Product_office_desk> list = new List<T_Product_office_desk>();

            foreach (var  model in query)
            {
                string str = JsonConvert.SerializeObject(model);
                list.Add(JsonToObject<T_Product_office_desk>(str));
            }

            return list;

                       
   

        }


        //public List<T_Product_office_desk> GetT_Product_office_desk(string Type,string Recommend)
        //{
        //    var query = read_db.T_Product_office_desk.Where(m => m.deskNewProduct == true);
            
        //    return query.ToList();
        //}

        
    }
}
