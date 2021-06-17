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
        public bool Register(string email,string password, string firstname, string lastname)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_USER_UserInfo.Where(m => m.Email ==email).ToList();
                if (entity.Count == 0)
                {
                    db.T_USER_UserInfo.Add(new T_USER_UserInfo()
                    {
                        FirstName=firstname,
                        Password = MD5T.MD5Encrypt(password),
                        LastName=lastname,
                        Email = email
                    });
                    db.SaveChanges();
                    issuccess = true;
                }
                
            }
            return issuccess;
        }


        public T_USER_UserInfo Login(string email, string password)
        {

            string pwd = MD5T.MD5Encrypt(password);
            using (DBGemmyService2 db = new DBGemmyService2())
            {               
                var entity = db.T_USER_UserInfo.Where(m => m.Email == email).FirstOrDefault();                
                if (entity != null)
                {
                    //判断是否允许登录 
                    
                    if (entity.Password == pwd)
                    {
                        entity.CanLogin = true;
                    }
                    else
                    {
                        entity.NoPassword = true;
                    }
                    return entity;                   
                }
                else
                {
                    
                }
            }
            return null;
        }

        public void Reset(string email, string password)
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_USER_UserInfo.Where(m => m.Email == email).ToList();
                if (entity.Count != 0)
                {
                    foreach (var item in entity)
                    {
                        item.Password = MD5T.MD5Encrypt(password);
                    }
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                }
            }
        }

        #region MyRegion
        /// <summary>
        /// 临时数据的操作
        /// </summary>
        /// <param name="email"></param>
        /// <param name="code"></param>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="dt1"></param>
        /// <param name="password"></param>
        //public void TempSave(string email, string code, string firstname, string lastname, DateTime dt1, string password)
        //{
        //    var entity = read_db.T_User_Temporary_UserInfo.Where(m => m.Email == email);
        //    if (entity.Count == 0)
        //    {
        //        read_db.T_User_Temporary_UserInfo.Add(new T_USER_Temporary_UserInfo
        //        {
        //            Email = email,
        //            Code = code,
        //            FirstName = firstname,
        //            LastName = lastname,
        //            FailTime = dt1,
        //            Password = password
        //        });
        //        read_db.SaveChanges();
        //    }
        //    else
        //    {
        //        int num = Update(entity);
        //    }
        //}
        #endregion


        public List<T_USER_Temporary_UserInfo> getTempinfo(string email)
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_User_Temporary_UserInfo.Where(m=>m.Email==email);
                return entity.ToList();
            }            
        }


        public List<T_USER_UserInfo> getUserinfo(string email)
        {
            using (DBGemmyService2 db=new DBGemmyService2())
            {
                var entity = db.T_USER_UserInfo.Where(m => m.Email == email);
                return entity.ToList();
            }
        }
        public List<T_USER_UserInfo> getUserinfoLoginReset(string email,string password)
        {
            string pwd= MD5T.MD5Encrypt(password);
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_USER_UserInfo.Where(m => m.Email == email&&m.Password== pwd);
                return entity.ToList();
            }
        }

        public void addRegisterInfo(string email,DateTime dt,string code)
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_User_Temporary_UserInfo.Where(m => m.Email == email).ToList();
                if (entity.Count == 0)
                {
                    db.T_User_Temporary_UserInfo.Add(new T_USER_Temporary_UserInfo
                    {
                        Email = email,                     
                        FailTime = dt,
                        Code = code
                    }); ;
                    db.SaveChanges();
                }
                else
                {
                    foreach (var item in entity)
                    {
                        item.Code = code;
                        item.FailTime = dt;
                    }
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                }
            }
        }

        public void addResetInfo(string email, DateTime dt, string code)
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_User_Temporary_UserInfo.Where(m => m.Email == email).ToList();
                if (entity.Count == 0)
                {
                    db.T_User_Temporary_UserInfo.Add(new T_USER_Temporary_UserInfo
                    {
                        Email = email,
                        ResetFailTime = dt,
                        ResetCode = code
                    });
                    db.SaveChanges();
                }
                else
                {
                    foreach (var item in entity)
                    {
                        item.ResetCode = code;
                        item.ResetFailTime = dt;
                    }
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.SaveChanges();
                    db.Configuration.ValidateOnSaveEnabled = true;
                }
            }
        }

        /// <summary>
        /// 获取盐值
        /// </summary>
        /// <returns></returns>
        public string GetSalt()
        {
            return System.Guid.NewGuid().ToString("D");
        }
    }
}
