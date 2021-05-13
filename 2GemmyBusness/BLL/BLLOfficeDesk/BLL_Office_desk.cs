using _1GemmyModel.Model.ModelProductOffice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
  public  class BLL_Office_desk:BLLBase
    {
        public List<T_Product_office_desk>  GetT_Product_office_desk(string Type)
        {


            var query = from x in read_db.T_Product_office_desk
                        where x.deskType == Type
                        where x.deleteSign != 1
                        select x;
            return query.ToList();

        }
        public List<T_Product_office_desk> GetT_Product_office_desk(string Type,string Recommend)
        {
            var query = read_db.T_Product_office_desk.Where(m => m.deskNewProduct == true);
            
            return query.ToList();
        }

        public static D Mapper<D, S>(S s)
        {
            D d = Activator.CreateInstance<D>();
            try
            {
                var sType = s.GetType();
                var dType = typeof(D);
                foreach (PropertyInfo sP in sType.GetProperties())
                {
                    foreach (PropertyInfo dP in dType.GetProperties())
                    {
                        if (dP.Name == sP.Name)
                        {
                            dP.SetValue(d, sP.GetValue(s));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return d;
        }

    }
}
