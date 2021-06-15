using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1GemmyModel.Model.ModelUserAccount
{
  public  class T_USER_Salt:T_Base
    {
        public string userName { get; set; }
        public string pwdSalt { get; set; }
    }
}
