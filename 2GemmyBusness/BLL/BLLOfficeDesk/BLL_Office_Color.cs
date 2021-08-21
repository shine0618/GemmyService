using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
   public class BLL_Office_Color:BLLBase
    {
        public List<T_Office_Color> GetColorList()
        {
            var entity = read_db.T_Office_Color.OrderBy(x=>x.HEXValue).ToList();
            return entity;
        }
        

        public List<T_Office_Color> GetSimpleColorList()
        {
            var q = from x in read_db.T_Office_Color
                    select x;
            var entity = new List<T_Office_Color>() { };
            foreach (var item in q)
            {
                if (item.ColorName == "RAL9001")
                {
                    entity.Add(item);
                }
                if (item.ColorName == "RAL9006")
                {
                    entity.Add(item);
                }
                if (item.ColorName == "RAL9016")
                {
                    entity.Add(item);
                }
            }
            return entity;
        }


    }
}
