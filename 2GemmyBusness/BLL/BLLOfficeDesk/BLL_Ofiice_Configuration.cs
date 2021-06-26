using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _1GemmyModel.Model.ModelProductOffice;

namespace _2GemmyBusness.BLL.BLLOfficeDesk
{
   public class BLL_Ofiice_Configuration:BLLBase
    {
        #region 配置号的生成
        private static BLL_Office_desk bll_desk = new BLL_Office_desk();
        public static string CreateConfigurationCode(string guid, bool isStandard, string username,string Type, string Mode)
        {
            string standard = "";
            standard = isStandard == true ? (standard = "S") : (standard = "C");
            string code = null;
            DateTime dt = getTime();
            string strdate = dt.ToString("yyyyMMdd");
         //   T_Product_office_desk _T_Product_office_desk = bll_desk.GetT_Product_office_desk(guid);
          //  T_Product_office_desk_detail _T_Product_office_desk_detail = bll_desk.GetT_Product_office_desk_detail(_T_Product_office_desk.Id,"");



            string ser = 
            code += "JCP" + strdate + standard + GetSerialNo() + Type + Mode.Substring(0, 1) + Mode.Substring(3, 1);



            return code;
        }

        public static long GetSerialNo()
        {
             byte[] buffer = Guid.NewGuid().ToByteArray();

            return BitConverter.ToInt64(buffer, 0);

        }

       
        #region 时间转化成东八区
        /// <summary>
        /// 得到日期的字符串
        /// </summary>
        /// <returns></returns>
        public static DateTime getTime()
        {
            DateTime utcNow = DateTime.Now.ToUniversalTime();

            double utc = ConvertDateTimeInt(utcNow);

            DateTime dtime = ConvertIntDatetime(utc);
            return dtime;
        }
        /// <summary>
        /// 转化为格林尼治时间
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int ConvertDateTimeInt(System.DateTime time)

        {

            double intResult = 0;

            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));

            intResult = (time - startTime).TotalSeconds;

            return (int)intResult;

        }
        /// <summary>
        /// 转化为东八区时间
        /// </summary>
        /// <param name="utc"></param>
        /// <returns></returns>
        public static DateTime ConvertIntDatetime(double utc)

        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            startTime = startTime.AddSeconds(utc);
            startTime = startTime.AddHours(8);//转化为北京时间(北京时间=UTC时间+8小时 )            
            return startTime;
        }

        #endregion


        #endregion
    }
}
