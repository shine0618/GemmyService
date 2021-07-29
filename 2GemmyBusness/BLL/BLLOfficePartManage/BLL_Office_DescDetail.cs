using _1GemmyModel;
using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
  public  class BLL_Office_DescDetail:BLLBase
    {
        public List<T_Part_office_describe> getDeskDescInfo(int textkey)
        {
            var t = from x in read_db.T_Part_office_describe
                    where x.textKay==textkey
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

        public bool UpdateDeskDescInfo(T_Part_office_describe t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Part_office_describe>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddDeskDescInfo(T_Part_office_describe t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Part_office_describe.Any(m => m.textKay == t.textKay && m.langCode == t.langCode && m.textValue == t.textValue);
                    if (entity != true)
                    {
                        db.T_Part_office_describe.Add(t);
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

        public bool DeleteDeskDescInfo(T_Part_office_describe t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Part_office_describe.Any(m => m.textKay == t.textKay && m.langCode == t.langCode && m.textValue == t.textValue);
                if (entity == true)
                {
                    DeleteEntityByid<T_Part_office_describe>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }
    }
}
