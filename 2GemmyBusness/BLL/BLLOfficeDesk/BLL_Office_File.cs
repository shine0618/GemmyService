﻿using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
   public class BLL_Office_File:BLLBase
    {

        public BLL_Office_File()
        {
            bll_desk = new BLL_Office_desk();

        }
        public BLL_Office_desk bll_desk = null;

        /// <summary>
        /// 根据桌子查找所有的资料
        /// </summary>
        /// <param name="deskid"></param>
        /// <returns></returns>
        public List<T_Office_Files> GetT_Office_Files(int deskid)
        {
            //先获取桌子
            T_Product_office_desk_detail desk = bll_desk.GetT_Product_office_desk_detail(deskid);

            //再获取这个桌子的所有文件
            var query = from x in read_db.T_Office_Files
                        where x.Mode == desk.Mode || x.Mode == desk.ColumnType || x.Mode == desk.FootType || x.Mode == desk.SideBracketType || x.Mode == desk.FrameType
                        select x;



            return query.ToList();
        }
    }
}
