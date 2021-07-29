using _1GemmyModel;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
    public class BLL_Office_Part_Sidebracket : BLLBase
    {
        public List<T_Part_office_SideBracket> getSidebracketInfo()
        {
            var t = from x in read_db.T_Part_office_SideBracket
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
        public bool UpdateSidebracketInfo(T_Part_office_SideBracket t)
        {
            bool issuccess = false;
            if (t != null)
            {
                Update<T_Part_office_SideBracket>(t);
                issuccess = true;
            }
            return issuccess;
        }

        public bool AddSidebracketInfo(T_Part_office_SideBracket t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Part_office_SideBracket.Any(m => m.Mode == t.Mode);
                    if (entity != true)
                    {
                        db.T_Part_office_SideBracket.Add(t);
                        db.SaveChanges();
                        issuccess = true;
                    }
                }

            }
            return issuccess;
        }

        public bool DeleteSidebracketInfo(T_Part_office_SideBracket t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Part_office_SideBracket.Any(m => m.Mode == t.Mode);
                if (entity == true)
                {
                    DeleteEntityByid<T_Part_office_SideBracket>(t.Id);
                    issuccess = true;
                }

            }
            return issuccess;
        }
    }
}
