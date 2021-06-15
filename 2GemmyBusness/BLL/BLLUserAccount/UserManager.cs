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
  public  class UserManager:BLLBase
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



        


        /// <summary>
        /// 获取盐值
        /// </summary>
        /// <returns></returns>
        public string GetSalt()
        {
            return System.Guid.NewGuid().ToString("D");
        }

        public string GetSalt(string userName)
        {
            // var q = read_db.T_USER_UserInfo.Where(x => x.Email == userName).FirstOrDefault();


            return "";

        }
        /// <summary>
        /// 密码生成
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <param name=""></param>
        public string  generateHashPassword(string pwd, string salt)
        {
            string str1 = MD5T.MD5Encrypt(pwd);

            string str2 = MD5T.MD5Encrypt(salt + str1);

            return str2;
        }
    }
}
