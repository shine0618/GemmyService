using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
   public class BLL_Office_desk_collect:BLLBase
    {

        public List<T_Office_desk_collect> GetT_Office_desk_collect(string pname)
        {
            var q = from x in read_db.T_Office_desk_collect
                    where x.deleteSign != 1
                    where x.collectUser == pname
                    select x;

            return q.ToList();
        }
        public T_Office_desk_collect GetT_Office_desk_collect(int deskId,string pname)
        {

            var q = from x in read_db.T_Office_desk_collect
                    where x.deleteSign != 1
                    where x.DeskId == deskId
                    where x.collectUser == pname
                    select x;

            T_Office_desk_collect m = q.FirstOrDefault();

            return m;


        }
        public int AddT_Office_desk_collect(int deskId,string pname)
        {
            T_Office_desk_collect model = new T_Office_desk_collect();

            model.CreateTime = DateTime.Now;
            model.DeskId = deskId;
            model.collectUser = pname;

            return base.AddEntities<T_Office_desk_collect>(model);
        }

        public int deleteT_Office_desk_collect(int deskId,string pname)
        {
            T_Office_desk_collect model = GetT_Office_desk_collect(deskId, pname);
            if(model!=null&model.Id>0)
            {
                model.deleteSign = 1;

                return base.Update<T_Office_desk_collect>(model);
            }
            return 0;

        }



    }
}
