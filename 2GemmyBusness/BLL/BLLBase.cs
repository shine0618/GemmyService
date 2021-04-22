using _1GemmyModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL
{
    class BLLBase
    {

        //添加
        public int  AddEntities<T>(T entity) where T:class
        {
            using (DBGemmyService db = new DBGemmyService())
            {
                try
                {
                    db.Entry<T>(entity).State = EntityState.Added;
                    return db.SaveChanges();
                }
                catch(Exception ex)
                {
                    return 0;
                }
            
            }
               
        }


        #region 公共删除代码

        public int DeleteEntity<T>(string ids) where T : class
        {
            using (DBGemmyService _db= new DBGemmyService())
            {
                int suc = 0;
                string[] idArr = ids.Split(',');
                foreach (string _id in idArr)
                {
                    if (_id.Trim() == "")
                    {
                        continue;
                    }

                    int intid = Convert.ToInt32(_id);
                    var entity = _db.Set<T>().Find(intid);

                    _db.Set<T>().Remove(entity);
                    suc += _db.SaveChanges();
                }

                return suc;
            }
        }
        public int DeleteEntityByid<T>(int id) where T : class
        {
            using (DBGemmyService _db = new DBGemmyService())
            {

                var entity = _db.Set<T>().Find(id);

                _db.Set<T>().Remove(entity);
                return _db.SaveChanges();


            }
        }

        #endregion


        #region 更新代码

        public int Update<T>(T entity) where T : class
        {
            using (DBGemmyService dbcontext = new DBGemmyService())
            {
                dbcontext.Set<T>().Attach(entity);
                PropertyInfo[] props = entity.GetType().GetProperties();
                foreach (PropertyInfo prop in props)
                {
                    if (prop.GetValue(entity, null) != null)
                    {
                        if (prop.GetValue(entity, null).ToString() == " ")
                            dbcontext.Entry(entity).Property(prop.Name).CurrentValue = null;


                        dbcontext.Entry(entity).Property(prop.Name).IsModified = true;
                    }
                }
                return dbcontext.SaveChanges();

            }

        }





        #endregion





    }
}
