using _1GemmyModel;
using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_Files:BLLBase
    {
        public List<T_Office_Files> getFileInfo(string mode)
        {
            var t = from x in read_db.T_Office_Files
                    where x.Mode == mode
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
        public bool UpdateFileInfo(T_Office_Files t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Office_Files>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddFileInfo(T_Office_Files t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Office_Files.Any(m => m.Mode==t.Mode&&m.FileName==t.FileName&&m.Type==t.Type);
                    if (entity != true)
                    {
                        db.T_Office_Files.Add(t);
                        db.SaveChanges();
                        issuccess = true;
                    }
                    //db.T_Part_office_describe.Add(t);
                    //db.SaveChanges();
                    //issuccess = true;
                }

            }
            return issuccess;
        }

        public bool DeleteFileInfo(T_Office_Files t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Office_Files.Any(m => m.Mode == t.Mode && m.FileName == t.FileName && m.Type == t.Type);
                if (entity == true)
                {
                    DeleteEntityByid<T_Office_Files>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }
    }
}
