using _1GemmyModel;
using _1GemmyModel.Model;
using _1GemmyModel.Model.ModelProductOffice;
using _2GemmyBusness.BLL.BLLOfficeDesk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2GemmyBusness.BLL.BLLOfficePartManage
{
   public class BLL_Office_Desk:BLLBase
    {
        public List<T_Product_office_desk> getDeskInfo()
        {
            var t = from x in read_db.T_Product_office_desk
                    where x.deleteSign==0
                    where x.deskCustmoer != true
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
        public bool UpdateDeskInfo(T_Product_office_desk t)
        {
            bool issuccess = false;
            if (t != null)
            {
                using (DBGemmyService2 db=new DBGemmyService2())
                {
                    var entity = db.T_Product_office_desk.Any(m=>m.verificationCode==t.verificationCode||m.deskGuid==t.deskGuid);
                    if (entity == true)
                    {
                        t.UpdateTime = DateTime.Now;
                        
                        Update<T_Product_office_desk>(t);
                        issuccess = true;
                    }
                    
                }
                    
            }
            return issuccess;
        }

        public bool AddDeskInfo(T_Product_office_desk t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                if (t != null)
                {
                    var entity = db.T_Product_office_desk.Any(m=>m.verificationCode==t.verificationCode||m.deskGuid==t.deskGuid);
                    if (entity != true)
                    {
                        T_Product_office_desk t_desk = new T_Product_office_desk();
                        t_desk = t;
                        t_desk.UpdateTime = DateTime.Now;
                        string mode = t_desk.deskSerialName.Split('-')[1].ToString();
                        t_desk.verificationCode= BLL_Ofiice_Configuration.CreateConfigurationCode(t_desk.deskGuid, true, "admin", t_desk.deskType, mode);
                        t_desk.deskShortDescriptionKey = 0;
                        t_desk.deskNewProductNumber = 0;
                        t_desk.deskTagKey = 0;
                        db.T_Product_office_desk.Add(t_desk);
                        db.SaveChanges();
                        issuccess = true;
                    }
                    
                }
            }
            return issuccess;
        }

        public bool DeleteDeskInfo(T_Product_office_desk t)
        {
            bool issuccess = false;
            using (DBGemmyService2 db = new DBGemmyService2())
            {
                var entity = db.T_Product_office_desk.Any(m => m.deskGuid == t.deskGuid||m.verificationCode==m.verificationCode);
                if (entity == true)
                {
                    t.deskCustmoer = false;
                    t.deleteSign = 1;
                    Update<T_Product_office_desk>(t);
                    issuccess = true;
                }

            }
            return issuccess;
        }

        public List<T_Product_office_desk> getDeskCustomerInfo(string customername)
        {
            var t = from x in read_db.T_Product_office_desk
                    where x.deleteSign == 0
                    where x.deskCustmoer != true
                    where x.deskCustomerName.ToLower()==customername.ToLower()
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
    }
}
