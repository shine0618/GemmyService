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

        public List<T_Product_office_desk_customer> GetT_Product_office_desk_customer(string langCode, string userName)
        {
            var query = from x in read_db.T_Product_office_desk_customer
                        where x.deleteSign != 1
                        where x.customerUserName == userName
                        select x;

            return query.ToList();

        }

        public int AddT_Product_office_desk_customer(T_Product_office_desk_customer model)
        {
           return  base.AddEntities<T_Product_office_desk_customer>(model);
        }

    }
}
