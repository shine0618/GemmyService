using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
   public class BLL_Office_Color:BLLBase
    {
        public List<T_Office_Color> GetColorList()
        {
            var entity = read_db.T_Office_Color.ToList();
            return entity;
        }
    }
}
