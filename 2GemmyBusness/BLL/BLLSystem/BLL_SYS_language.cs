using _1GemmyModel.Model.ModelSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLSystem
{
   public class BLL_SYS_language:BLLBase
    {

        public List<T_SYS_Language> GetT_SYS_Language()
        {
            var q = read_db.T_SYS_Language.Where(x => x.deleteSign != 0);
            return q.ToList();
        }
    
    }
}
