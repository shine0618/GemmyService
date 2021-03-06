using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
  public  class BLL_Office_Part_Frame:BLLBase
    {
        public List<T_Part_office_Frame> getFrameInfo()
        {
            var t = from x in read_db.T_Part_office_Frame
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
        public bool UpdateFrameInfo(T_Part_office_Frame t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Part_office_Frame>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddFrameInfo(T_Part_office_Frame t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Part_office_Frame.Any(m => m.Mode == t.Mode);
                    if (entity != true)
                    {
                        db.T_Part_office_Frame.Add(t);
                        db.SaveChanges();
                        issuccess = true;
                    }
                }

            }
            return issuccess;
        }

        public bool DeleteFrameInfo(T_Part_office_Frame t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Part_office_Frame.Any(m => m.Mode == t.Mode);
                if (entity == true)
                {
                    DeleteEntityByid<T_Part_office_Frame>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }
    }
}
