using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1GemmyModel;
using _1GemmyModel.Model;

namespace _2GemmyBusness.BLL
{
  public  class LanguageQueryable:BLLBase
    {
        private static DBGemmyService _db;

        public  LanguageQueryable(DBGemmyService db)
        {
            _db = db;
        }

        public static ArrayList getLanguage()
        {
            ArrayList newlist = new ArrayList();
            var entity = _db.LanguageType;
            foreach (var a in entity)
            {
                newlist.Add(a .Language);
            }

            return newlist;
        }
    }
}
