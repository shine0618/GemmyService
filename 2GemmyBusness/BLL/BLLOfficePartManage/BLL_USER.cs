using _1GemmyModel;
using _1GemmyModel.Model;
using _1GemmyModel.Model.ModelUserAccount;
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
        public bool UpdateCompanyLevel(T_USER_UserInfo t,string user)
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                bool issuccess = false;
                if (t != null)
                {
                    Update<T_USER_UserInfo>(t);
                    issuccess = true;
                    T_USER_ApplyOrder t1 = db.T_USER_ApplyOrder.Where(m => m.Email == t.Email).FirstOrDefault();
                    if (t1 != null)
                    {                        
                        t1.Pass = t.isorder;
                        t1.passemail = user;
                        t1.passtime = DateTime.UtcNow;
                        Update<T_USER_ApplyOrder>(t1);
                    }
                }
                return issuccess;
            }

        }
    }
}
