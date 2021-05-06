using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1GemmyModel;
using _1GemmyModel.Model;
using _4GemmyTools;

namespace _2GemmyBusness.BLL.BLLUserAccount
{
  public  class UserManager
    {
        //public void Register(string username, string password, string question, string answer, string email)
        //{
        //    using (DBGemmyService db=new DBGemmyService())
        //    {
        //        var entity = db.UserInfo.Where(m => m.UserName == username).ToList();
        //        if (entity.Count==0)
        //        {
        //            db.UserInfo.Add(new UserInfo()
        //            {
        //                UserName = username,
        //                Password = MD5T.MD5Encrypt(password),
        //                Question = question,
        //                Answer = answer,
        //                Email = email
        //            });
        //            db.SaveChanges();
                    
        //        }
        //    }
            
        //}

        //public bool Login(string username, string password)
        //{
        //    using (DBGemmyService db = new DBGemmyService())
        //    {
        //        var entity = db.UserInfo.FirstOrDefault(m => m.UserName == username&&m.Password==password);
                
        //        if (entity.Id!=0)
        //        {
        //            return true;

        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }

        //}
    }
}
