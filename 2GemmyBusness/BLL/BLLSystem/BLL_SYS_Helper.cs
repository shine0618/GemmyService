using _1GemmyModel;
using _1GemmyModel.Model.ModelSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLSystem
{
   public static class BLL_SYS_Helper
    {
        private static DBGemmyService2 read_db = new DBGemmyService2();
        public static T_SYS_Language GetT_SYS_Language(string code)
        {
            try
            {
                var q = read_db.T_SYS_Language.Where(x => x.deleteSign != 0&&x.LanguageCode==code);
                return q.FirstOrDefault();
            }
            catch(Exception ex
             )
            {
                return GetT_SYS_Language("zh");
            }
           
        }
    }
}
