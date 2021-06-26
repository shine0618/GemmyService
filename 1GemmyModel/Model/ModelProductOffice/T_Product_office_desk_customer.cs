using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelProductOffice
{
   public class T_Product_office_desk_customer:T_Base
    {
        public string deskGuid { get; set; }

        public string langCode { get; set; }
        public string configurationName { get; set; }

        public string customerUserName { get; set; }
    }
}
