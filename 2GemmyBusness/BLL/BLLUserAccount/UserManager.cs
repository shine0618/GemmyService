using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1GemmyModel;
using _1GemmyModel.Model;
using _1GemmyModel.Model.ModelUserAccount;
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
                    password = MD5T.MD5Encrypt(password);
                    db.T_USER_UserInfo.Add(new T_USER_UserInfo()
                    {
                        FirstName=firstname,
                        Password = password,
                        LastName =lastname,
                        Email = email,
                        Level=1
                    });
                   int n =   db.SaveChanges();
                    if(n>0)
                    {
                        issuccess = true;
                    }
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
                    
                    if (entity.Password == pwd&&entity.Lock==false )
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
        public T_USER_UserInfo getUserinfoModel(string email)
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_USER_UserInfo.Where(m => m.Email == email).FirstOrDefault();
                return entity;
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
                    }); 
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

        public bool addCompanyInfo(T_USER_UserCompanyInfo list)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (db.T_USER_UserCompanyInfo.Any(m => m.Email == list.Email)) {

                    Update<T_USER_UserCompanyInfo>(list);
                    issuccess = true;
                    return issuccess;
                }
                else
                {
                    T_USER_UserCompanyInfo t = new T_USER_UserCompanyInfo();
                    t = list;
                    db.T_USER_UserCompanyInfo.Add(t);
                    db.SaveChanges();
                    issuccess = true;
                }
            }
            return issuccess;
        }

        public T_USER_UserCompanyInfo getCompanyInfo(string email,string name)
        {

            using (DBGemmyService2 db = new DBGemmyService2())
            {
                T_USER_UserCompanyInfo t= db.T_USER_UserCompanyInfo.FirstOrDefault(m=>m.Email==email);
                if (t == null)
                {
                    return new T_USER_UserCompanyInfo()
                    {
                        Email = email,
                        Name = name
                    };
                }
                else
                {
                    return t;
                }
            }
        }


        public T_USER_UserInfo getCompanyName(string email)
        {

            using (DBGemmyService2 db = new DBGemmyService2())
            {
                T_USER_UserInfo t = db.T_USER_UserInfo.Where(m => m.Email == email).FirstOrDefault();
                if (t == null)
                {
                    return null;
                }
                else
                {
                    return t;
                }
            }
        }

        public T_USER_UserCompanyInfo getCompanyInfo2(string email)
        {

            using (DBGemmyService2 db = new DBGemmyService2())
            {
                T_USER_UserCompanyInfo t = db.T_USER_UserCompanyInfo.FirstOrDefault(m => m.Email == email);
                if (t == null)
                {
                    return new T_USER_UserCompanyInfo()
                    {
                        Email = email,
                    };
                }
                else
                {
                    return t;
                }
            }
        }

        public List<T_USER_UserInfo> getAllUserInfo()
        {

            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var t = from x in db.T_USER_UserInfo
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

        public List<T_USER_ApplyOrder> getAllUserCompanyApply()
        {

            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var t = from x in db.T_USER_ApplyOrder
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

        public bool addOpinion(string email, string content, string name)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {

                T_USER_Opinion t = db.T_USER_Opinion.FirstOrDefault(m => m.Email == email&&m.Content==content);
                if (t == null)
                {
                    T_USER_Opinion t1 = new T_USER_Opinion()
                    {
                        Email = email,
                        Content = content,
                        Name = name,
                        CreateTime = DateTime.Now
                    };
                    db.T_USER_Opinion.Add(t1);
                    db.SaveChanges();
                    issuccess = true;
                }
                else
                {

                }
            }
            return issuccess;
        }


        public List<T_USER_Opinion> getOpinion()
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {

                var t = from x in read_db.T_USER_Opinion
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

        public List<T_USER_UserCompanyInfo> getAllUserCompanyInfo()
        {
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var t = from x in db.T_USER_UserCompanyInfo
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

        public bool addcompanyapply(T_USER_ApplyOrder t)
        {
            bool isadd = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {

                if (t != null)
                {
                    var entity = db.T_USER_ApplyOrder.Any(m => m.Email == t.Email);
                    if (entity != true)
                    {
                        T_USER_ApplyOrder new_t = new T_USER_ApplyOrder() {
                            Email = t.Email,
                            CompanyName = t.CompanyName,
                            ApplyTime = DateTime.UtcNow,
                            Pass = false
                        };
                        db.T_USER_ApplyOrder.Add(new_t);
                        db.SaveChanges();
                        isadd = true;
                    }

                }
            }
            return isadd;
        }

        public bool getCompanyapply(string email)
        {

            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var t = db.T_USER_ApplyOrder.Any(m => m.Email == email);
                return t;
            }
        }
    }
}
