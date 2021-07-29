using _1GemmyModel;
using _1GemmyModel.Model;
using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_Part_Powercable:BLLBase
    {
        public List<T_Part_office_Powercable> getPowercableInfo()
        {
            var t = from x in read_db.T_Part_office_Powercable
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
        public bool UpdatePowercableInfo(T_Part_office_Powercable t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Part_office_Powercable>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddPowercableInfo(T_Part_office_Powercable t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Part_office_Powercable.Any(m => m.Mode == t.Mode);
                    if (entity != true)
                    {
                        db.T_Part_office_Powercable.Add(t);
                        db.SaveChanges();
                        issuccess = true;
                    }
                }

            }
            return issuccess;
        }

        public bool DeletePowercableInfo(T_Part_office_Powercable t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Part_office_Powercable.Any(m => m.Mode == t.Mode);
                if (entity == true)
                {
                    DeleteEntityByid<T_Part_office_Powercable>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }
    }
}
