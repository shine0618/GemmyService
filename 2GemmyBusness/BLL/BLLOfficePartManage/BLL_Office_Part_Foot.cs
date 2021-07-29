using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_Part_Foot:BLLBase
    {
        public List<T_Part_office_Foot> getFootInfo()
        {
            var t = from x in read_db.T_Part_office_Foot
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
        public bool UpdateFootInfo(T_Part_office_Foot t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Part_office_Foot>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddFootInfo(T_Part_office_Foot t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Part_office_Foot.Any(m => m.Mode == t.Mode);
                    if (entity != true)
                    {
                        db.T_Part_office_Foot.Add(t);
                        db.SaveChanges();
                        issuccess = true;
                    }
                }

            }
            return issuccess;
        }

        public bool DeleteFootInfo(T_Part_office_Foot t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Part_office_Foot.Any(m => m.Mode == t.Mode);
                if (entity == true)
                {
                    DeleteEntityByid<T_Part_office_Foot>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }
    }
}
