using _2GemmyBusness.BLL.BLLUserAccount;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using _4GemmyTools;
using _1GemmyModel.Model.ModelUserAccount;
using Newtonsoft.Json;

namespace GemmyService.Controllers
{
    public class JCAccountController : Controller
    {
        private UserManager usermanager = new UserManager();

        // GET: JCAccount
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult reass()
        {
            return View();
        }

        public ActionResult reass_english()
        {
            return View();
        }
        #region 发送邮件


        public bool sendEmail(string emailaddress,string emailBodyText,string codestr)
        {
           
            try
            {
                //设置要调用的发送邮件的服务器
                SmtpClient smtp = new SmtpClient("smtphz.qiye.163.com ");
                //创建发件人对象
                MailAddress from = new MailAddress("tangwj@jiecang.com");
                //创建收件人对象
                MailAddress to = new MailAddress(emailaddress);
                //要发送的邮件对象，包含四个内容要填充
                MailMessage mail = new MailMessage(from, to);
                //设置邮件的标题
                mail.Subject = "Test";
                mail.IsBodyHtml = true;
                //设置邮件的主题正文格式
                mail.Body = emailBodyText;
                //创建发件人身份验证凭证
                NetworkCredential cred = new NetworkCredential("tangwj@jiecang.com", "Jc#^35*.&Qtw");
                smtp.Credentials = cred;
                //此服务器对象执行发送邮件功能
                smtp.Send(mail);
               
                return true;
            }
            catch(Exception ex )
            {

            }
            return false;



        }

        public string CreateVerificationCode()
        {
            Random rd = new Random();
            string codestr = "";
            for (int i = 0; i < 5; i++)
            {
                int num = rd.Next(0, 9);
                codestr += num;
            }
            return codestr;
        }

        [HttpGet]
        public JsonResult SendRegisterEmail(string emailaddress)
        {
            string codestr = CreateVerificationCode();
            sendEmail(emailaddress, emailBody(codestr), codestr);
            usermanager.addRegisterInfo(emailaddress, DateTime.UtcNow.AddMinutes(30), codestr);
            JsonResult jr = Json(codestr, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        private string emailBody(string code)
        {
            string emailBody = "";
            emailBody += "<style>.alignleft{display:inline;float:left;}</style>\r\n" + "<div><img class=\"alignleft\" src=\"https://img01.yun300.cn/img/jcxlogo.png?tenantId=150725&viewType=1&k=1621414521000\" ></div><div><span style=\"color:#0f4c81\"><span style=\"font-family:微软雅黑\"><span style=\"line-height:1.2\"><span style=\"font-size:20px\">股票代码：603583<br>股票名称：捷昌驱动</span></span></span></span></div>" + "\r\n" +
                "<hr />\r\n" + "<div><span style=\"font - size:20px\">尊敬的用户：<br>首先感谢您使用GemmyConfiguration，本条邮件是用于激活您所注册的账号，请通过以下验证码来进行账号的激活<br>" + code + "<br>如有打扰之处，请多谅解!</span></div>";
            return emailBody;
        }


        #endregion
        [HttpPost]
        public JsonResult Register(string email, string password, string firstname, string lastname,string code)
        {
            bool isRegister = false;
            string msg = string.Empty;
            List<T_USER_Temporary_UserInfo> t_temporary = usermanager.getTempinfo(email);
            if (t_temporary.Count != 0)
            {
                foreach (var item in t_temporary)
                {
                    if (item.FailTime >= DateTime.UtcNow)
                    {
                        if (code == item.Code)
                        {
                           bool issuccess= usermanager.Register(email, password, firstname, lastname);
                           isRegister = issuccess;
                        }
                    }
                    else
                    {
                        msg = "验证码已经失效,请重试";
                    }
                }               
            }
            else
            {
                msg = "请先发送邮件获取验证码";
            }           
            var param = new
            {
                isRegister = isRegister,
                msg = msg
            };
            JsonResult jr = Json(param, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpGet]
        public JsonResult Login(string email,string password)
        {
            T_USER_UserInfo isLogin = usermanager.Login(email, password);

           
            if(isLogin!=null&&isLogin.CanLogin==true)
            {
                Session["configurationPerson"] = isLogin.FirstName+" "+isLogin.LastName;
                Session["picName"] = isLogin.FirstName.Substring(0,1)+ isLogin.LastName.Substring(0,1);
                Session["emailName"] = isLogin.Email;
                Session.Timeout = 9600;
            }

            JsonResult jr = Json(isLogin, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpPost]
        public JsonResult Resetpassword(string email,string newpassword,string code)
        {
            bool isReset = false;
            List<T_USER_Temporary_UserInfo> t_temporary_reset = usermanager.getTempinfo(email);
            if (t_temporary_reset.Count != 0)
            {
                foreach (var item in t_temporary_reset)
                {
                    if (item.ResetFailTime >= DateTime.UtcNow)
                    {
                        if (code == item.ResetCode)
                        {
                            usermanager.Reset(email, newpassword);
                            isReset = true;
                        }
                    }
                }
            }
            JsonResult jr = Json(isReset, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        public JsonResult ResetpasswordLogin(string email, string oldpassword, string newpassword)
        {
            bool isReset = false;
            List<T_USER_UserInfo> t_user_reset = usermanager.getUserinfoLoginReset(email,oldpassword);
            if (t_user_reset.Count != 0)
            {
                foreach (var item in t_user_reset)
                {
                    usermanager.Reset(email, newpassword);
                    isReset = true;
                }
            }
            JsonResult jr = Json(isReset, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


        [HttpGet]
        public JsonResult SendResetEmail(string emailaddress)
        {
            string codestr = CreateVerificationCode();
            sendEmail(emailaddress, ResetemailBody(codestr), codestr);

            usermanager.addResetInfo(emailaddress, DateTime.UtcNow.AddMinutes(30), codestr);
            JsonResult jr = Json(codestr, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        private string ResetemailBody(string code)
        {
            string emailBody = "";
            emailBody += "<style>.alignleft{display:inline;float:left;}</style>\r\n" + "<div><img class=\"alignleft\" src=\"https://img01.yun300.cn/img/jcxlogo.png?tenantId=150725&viewType=1&k=1621414521000\" ></div><div><span style=\"color:#0f4c81\"><span style=\"font-family:微软雅黑\"><span style=\"line-height:1.2\"><span style=\"font-size:20px\">股票代码：603583<br>股票名称：捷昌驱动</span></span></span></span></div>" + "\r\n" +
                "<hr />\r\n" + "<div><span style=\"font - size:20px\">尊敬的用户：<br>首先感谢您使用GemmyConfiguration，本条邮件是用于重置密码，请通过以下验证码来进行密码的重置<br>" + code + "<br>如有打扰之处，请多谅解!</span></div>";
            return emailBody;
        }




        [HttpGet]
        public JsonResult LoginOut(string emailaddress)
        {
            Session.Clear();
            var param =
            new {
                LoginOut=true,
            };
            JsonResult jr = Json(param, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpPost]
        public JsonResult AddCompanyInfo(string forminfo)
        {
            bool isadd = false;
            T_USER_UserCompanyInfo t_USER_UserCompanyInfos = JsonConvert.DeserializeObject<T_USER_UserCompanyInfo>(forminfo);
            isadd=usermanager.addCompanyInfo(t_USER_UserCompanyInfos);
            JsonResult jr = Json(isadd, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetCompanyInfo(string email,string name)
        {
            T_USER_UserCompanyInfo t = usermanager.getCompanyInfo(email, name);
            JsonResult jr = Json(t, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult GetCompanyInfo2(string email)
        {
            T_USER_UserCompanyInfo t = usermanager.getCompanyInfo2(email);
            var param = new
            {
                Email=t.Email,
                Name=t.Name,
                Sex=t.Sex,
                Telephone=t.Telephone,
                CompanyName=t.CompanyName,
                CompanyStreet=t.CompanyStreet,
                CompanyLocation=t.CompanyLocation,
                CompanyNation=t.CompanyNation,
                CompanyWebsite=t.CompanyWebsite
            };
            JsonResult jr = Json(param, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


    }
}