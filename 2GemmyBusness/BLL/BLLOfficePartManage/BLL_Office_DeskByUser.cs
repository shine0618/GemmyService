using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_DeskByUser:BLLBase
    {
        public List<T_Product_office_desk> getDeskByUserInfo()
        {
            var t = from x in read_db.T_Product_office_desk
                    where x.deleteSign == 0
                    where x.deskCustmoer == true
                    select x;
            if (t != null)
            {
                return t.ToList();
            }
            else
            {
                return null;
            }
        }
    }
}
