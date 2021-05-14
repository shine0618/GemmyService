using _1GemmyModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using _1GemmyModel.Model;
using System.Runtime.Serialization.Json;
using System.IO;

namespace _2GemmyBusness.BLL
{
   public class BLLBase
   {

        public DBGemmyService2 read_db = new DBGemmyService2();


        //添加
        public int  AddEntities<T>(T entity) where T:class
        {
            using (DBGemmyService2 db = new DBGemmyService2())
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
            using (DBGemmyService2 _db= new DBGemmyService2())
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
            using (DBGemmyService2 _db = new DBGemmyService2())
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
            using (DBGemmyService2 dbcontext = new DBGemmyService2())
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


        
        /// <summary>
        /// 查询全部
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public  IQueryable<T> GetAll<T>() where T:class
        {
            using (DBGemmyService2 _db = new DBGemmyService2())
            {
                var entity = _db.Set<T>().AsNoTracking();
                return entity;
            }
        }
        /// <summary>
        /// 查询个体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        public IQueryable<T> GetAllById<T>(int id) where T : T_Base
        {
            using (DBGemmyService2 _db = new DBGemmyService2())
            {
                var entity = _db.Set<T>().Where(m=>m.Id==id);
                return entity;
            }
        }


        public static T JsonToObject<T>(string jsonText)
        {
            try
            {
                DataContractJsonSerializer s = new DataContractJsonSerializer(typeof(T));
                MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonText));
                T obj = (T)s.ReadObject(ms);
                ms.Dispose();
                return obj;
            }
            catch(Exception ex)
            {
                return default(T);
            }
          
        }
        /// <summary>
        /// 两个相同类型的数据赋值 
        /// </summary>
        /// <typeparam name="D"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="s"></param>
        /// <returns></returns>
        public static D Mapper<D, S>(S s)
        {
            D d = Activator.CreateInstance<D>();
            try
            {
                var sType = s.GetType();
                var dType = typeof(D);
                foreach (PropertyInfo sP in sType.GetProperties())
                {
                    foreach (PropertyInfo dP in dType.GetProperties())
                    {
                        if (dP.Name == sP.Name)
                        {
                            dP.SetValue(d, sP.GetValue(s));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return d;
        }


    }
}
