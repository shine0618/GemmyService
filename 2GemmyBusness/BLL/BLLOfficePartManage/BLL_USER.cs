using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_USER:BLLBase
    {
        public bool UpdateUserLevel(T_USER_UserInfo t)
        {
            using (DBGemmyService2 db=new DBGemmyService2())
            {
                bool issuccess = false;
                if (t != null)
                {
                    Update<T_USER_UserInfo>(t);
                    issuccess = true;
                }
                return issuccess;
            }
               
        }
    }
}
