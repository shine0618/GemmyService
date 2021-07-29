using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_Part_Column:BLLBase
   {
        public List<T_Part_office_Column> getColumnInfo()
        {
            var t = from x in read_db.T_Part_office_Column
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

        public bool UpdateColumnInfo(T_Part_office_Column t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Part_office_Column>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddColumnInfo(T_Part_office_Column t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Part_office_Column.Any(m=>m.Mode==t.Mode);
                    if (entity != true)
                    {
                        db.T_Part_office_Column.Add(t);
                        db.SaveChanges();
                        issuccess = true;
                    }
                    
                }
               
            }
            return issuccess;
        }

        public bool DeleteColumnInfo(T_Part_office_Column t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Part_office_Column.Any(m => m.Mode == t.Mode);
                if (entity == true)
                {
                    DeleteEntityByid<T_Part_office_Column>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }
    }
}
