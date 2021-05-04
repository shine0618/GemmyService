using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using _1GemmyModel;
using _1GemmyModel.Model;

namespace _2GemmyBusness.BLL
{
   public class AccessoryQueryable<T>:BLLBase where T:Accessory,new()
   {
       private readonly DBGemmyService _db;

       public AccessoryQueryable(DBGemmyService db)
       {
           _db = db;
       }
       //public IQueryable<T> SelOneByMode(string mode)
       //{
       //     var entity= _db.Set<T>().Where(m => m.Mode == mode).Select(m=>new {m.CE,m.Mode});
       //     return (IQueryable<T>)entity;
       //}
       public IQueryable<T> Get(Expression<Func<T,bool>> lambdaString)
       {
           return _db.Set<T>().Where(lambdaString);
       }

       public List<Accessory> GetAllMode()
       {
            var q = from x in _db.Accessory
                    where x.deleteSign == 0
                    select x;

            return q.ToList();        
       }





       

   }
}
