using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
  public  class BLL_Office_desk_customer:BLLBase
    {
        
        public int AddT_Product_office_desk_customer(T_Product_office_desk_customer model)
        {
           return  base.AddEntities<T_Product_office_desk_customer>(model);
        }

    }
}
