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
                T_USER_UserInfo t1 = db.T_USER_UserInfo.Where(m => m.Email == t.Email).FirstOrDefault();
                if (t1 != null)
                {
                    t1.Level = t.Level;
                    Update<T_USER_UserInfo>(t1);
                    issuccess = true;
                }
                return issuccess;
            }
               
        }
        public bool UpdateCompanyLevel(T_USER_ApplyOrder t,string user)
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                bool issuccess = false;
                if (t != null)
                {
                    t.passemail = user;
                    t.passtime = DateTime.UtcNow;
                    Update<T_USER_ApplyOrder>(t);
                    issuccess = true;
                    T_USER_UserInfo t1 = db.T_USER_UserInfo.Where(m => m.Email == t.Email).FirstOrDefault();
                    if (t1 != null)
                    {                        
                        t1.CompanyName = t.CompanyName;
                        t1.isorder = t.Pass;

                        Update<T_USER_UserInfo>(t1);
                    }
                }
                return issuccess;
            }

        }
    }
}
