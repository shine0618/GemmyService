using _2GemmyBusness.BLL.BLLSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GemmyService
{
    public static class T_webdata
    {

        public static string GetFileSrc(string src)
        {
            //获取路径
            HttpContext context1 = System.Web.HttpContext.Current;
            string path = context1.Server.MapPath(src);
            if(BLL_SYS_language.LangPath==null|| BLL_SYS_language.LangPath=="")
            {
                BLL_SYS_language.LangPath = path;
            }
            return path;
        }
       
    }
}