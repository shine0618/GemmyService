using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_Part_Column:BLLBase
   {
        public List<T_Part_office_Column> getColumnInfo()
        {
            var t = from x in read_db.T_Part_office_Column
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
