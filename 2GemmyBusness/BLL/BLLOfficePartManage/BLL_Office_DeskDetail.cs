using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_DeskDetail:BLLBase
    {
        public List<T_Product_office_desk_detail> getDeskDetailInfo()
        {
            var t = from x in read_db.T_Product_office_desk_detail
                    where x.deleteSign == 0
                    where x.deskGuid != null||x.deskGuid!=""
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

        public List<T_Product_office_desk_detail> getDeskDetailCustomerInfo(string deskguid)
        {
            var t = from x in read_db.T_Product_office_desk_detail
                    where x.deleteSign == 0
                    where x.deskGuid != null || x.deskGuid != ""&&x.deskGuid==deskguid
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
