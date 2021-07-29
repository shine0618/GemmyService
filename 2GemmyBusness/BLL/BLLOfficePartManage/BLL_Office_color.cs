using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_color:BLLBase
    {
        public List<T_Office_Color> getColorInfo()
        {
            var t = from x in read_db.T_Office_Color
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
        public bool UpdateColorInfo(T_Office_Color t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Office_Color>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddColorInfo(T_Office_Color t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Office_Color.Any(m=>m.ColorName==t.ColorName);
                    if (entity != true)
                    {
                        db.T_Office_Color.Add(t);
                        db.SaveChanges();
                        issuccess = true;
                    }
                    
                }

            }
            return issuccess;
        }

        public bool DeleteColorInfo(T_Office_Color t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Office_Color.Any(m => m.ColorName == t.ColorName);
                if (entity == true)
                {
                    DeleteEntityByid<T_Office_Color>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }
    }
}
