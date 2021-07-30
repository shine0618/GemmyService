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
        public JsonResult SendRegisterEmail(string emailaddress,string langcode)
        {
            string codestr = CreateVerificationCode();
            sendEmail(emailaddress, registerBody(codestr,langcode), codestr);
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

        private string registerBody(string code,string langcode)
        {
            string emailBody = "";
            if (langcode == "zh")
            {
                emailBody += "<style>*{font - family: 'Microsoft YaHei';color: #2d2c2c;}.body{background-color:#EFF2F6;}.div_emain{ padding:2rem;width:700px;margin:0 auto;}.footText{color: #0F4680;text - align:center;}</style>\r\n" + "<div class=\"div_emain\"> <div><img src=\"https://img201.yun300.cn/img/jcxlogo.png?tenantId=150725&viewType=1&k=1621414521000\"/></div><div><h2>用户注册</h2><p>您的账号正在进行用户注册，以下是您的验证码：</p><h3>" + code + "</h3><p>如果您看过上述信息，请忽略此电子邮件。</p><br/><h4>用户注册须知</h4><p>捷昌产品选型系统,本系统提供的网络服务中包含的任何文本、图片、图形、音频和/或视频资料均受版权、商标和/或其它财产所有权法律的保护。</p><p>除法律另有强制性规定外，未经相关权利人同意，任何单位或个人不得以任何方式非法地全部或部分复制、转载、引用、链接、抓取或以其他方式使用本站的信息内容；否则，本系统所有者有权追究其法律责任。</p><br /><h4>此致</h4><p>捷昌 Configration 团队</p><h4 class=\"footText\"></h4></div></div>";
            }
            else if (langcode == "en")
            {
                emailBody += "<style>*{font - family: 'Microsoft YaHei';color: #2d2c2c;}.body{background-color:#EFF2F6;}.div_emain{ padding:2rem;width:700px;margin:0 auto;}.footText{color: #0F4680;text - align:center;}</style>\r\n" + "<div class=\"div_emain\"> <div><img src=\"https://img201.yun300.cn/img/jcxlogo.png?tenantId=150725&viewType=1&k=1621414521000\"/></div><div><h2>User register</h2><p>Your account is being registered as a user,Here's your verification:</p><h3>"+code+"</h3><p>If you have seen the above information,please ignore this email.</p><br/><h4>User register notice</h4><p>Jiecang configuration system,Any text,pictures,graphics,audio and\\/or video materials contained in the network services provided by the system are protected by copyright,trademark and\\/or other property ownership laws.</p><p>Unless otherwise mandatory by law,without the consent of the relevant right holder,no unit or individual shall in any way illegally copy,reprint, quote,link,grab or otherwise use the information content of this site in whole or in part;Otherwise,the owner of the system has the right to pursue its legal responsibility.</p><br/><h4>Best Regards:</h4><p>Jiecang Configration team</p><h4 class=\"footText\"></h4></div></div>";
            }
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
                Session["level"] = isLogin.Level;
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
        public JsonResult SendResetEmail(string emailaddress,string langcode)
        {
            string codestr = CreateVerificationCode();
            sendEmail(emailaddress, ResetemailBody(codestr,langcode), codestr);

            usermanager.addResetInfo(emailaddress, DateTime.UtcNow.AddMinutes(30), codestr);
            JsonResult jr = Json(codestr, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        //private string ResetemailBody(string code)
        //{
        //    string emailBody = "";
        //    emailBody += "<style>.alignleft{display:inline;float:left;}</style>\r\n" + "<div><img class=\"alignleft\" src=\"https://img01.yun300.cn/img/jcxlogo.png?tenantId=150725&viewType=1&k=1621414521000\" ></div><div><span style=\"color:#0f4c81\"><span style=\"font-family:微软雅黑\"><span style=\"line-height:1.2\"><span style=\"font-size:20px\">股票代码：603583<br>股票名称：捷昌驱动</span></span></span></span></div>" + "\r\n" +
        //        "<hr />\r\n" + "<div><span style=\"font - size:20px\">尊敬的用户：<br>首先感谢您使用GemmyConfiguration，本条邮件是用于重置密码，请通过以下验证码来进行密码的重置<br>" + code + "<br>如有打扰之处，请多谅解!</span></div>";
        //    return emailBody;
        //}

        private string ResetemailBody(string code, string langcode)
        {
            string emailBody = "";
            if (langcode == "zh")
            {
                emailBody += "<style>*{font - family: 'Microsoft YaHei';color: #2d2c2c;}.body{background-color:#EFF2F6;}.div_emain{ padding:2rem;width:700px;margin:0 auto;}.footText{color: #0F4680;text - align:center;}</style>\r\n" + "<div class=\"div_emain\"> <div><img src=\"https://img201.yun300.cn/img/jcxlogo.png?tenantId=150725&viewType=1&k=1621414521000\"/></div><div><h2>重置密码</h2><p>您的账号正在进行密码重置，以下是您的验证码：</p><h3>" + code + "</h3><p>如果您看过上述信息，请忽略此电子邮件。</p><br/><h4>用户注册须知</h4><p>捷昌产品选型系统,本系统提供的网络服务中包含的任何文本、图片、图形、音频和/或视频资料均受版权、商标和/或其它财产所有权法律的保护。</p><p>除法律另有强制性规定外，未经相关权利人同意，任何单位或个人不得以任何方式非法地全部或部分复制、转载、引用、链接、抓取或以其他方式使用本站的信息内容；否则，本系统所有者有权追究其法律责任。</p><br /><h4>此致</h4><p>捷昌 Configration 团队</p><h4 class=\"footText\"></h4></div></div>";
            }
            else if (langcode == "en")
            {
                emailBody += "<style>*{font - family: 'Microsoft YaHei';color: #2d2c2c;}.body{background-color:#EFF2F6;}.div_emain{ padding:2rem;width:700px;margin:0 auto;}.footText{color: #0F4680;text - align:center;}</style>\r\n" + "<div class=\"div_emain\"> <div><img src=\"https://img201.yun300.cn/img/jcxlogo.png?tenantId=150725&viewType=1&k=1621414521000\"/></div><div><h2>User resetpassword</h2><p>Your account is in the process of password reset,Here's your verification:</p><h3>" + code + "</h3><p>If you have seen the above information,please ignore this email.</p><br/><h4>User register notice</h4><p>Jiecang configuration system,Any text,pictures,graphics,audio and\\/or video materials contained in the network services provided by the system are protected by copyright,trademark and\\/or other property ownership laws.</p><p>Unless otherwise mandatory by law,without the consent of the relevant right holder,no unit or individual shall in any way illegally copy,reprint, quote,link,grab or otherwise use the information content of this site in whole or in part;Otherwise,the owner of the system has the right to pursue its legal responsibility.</p><br/><h4>Best Regards:</h4><p>Jiecang Configration team</p><h4 class=\"footText\"></h4></div></div>";
            }
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


        [HttpPost]
        public JsonResult submitOpinion(string emailname, string content, string name)
        {
            bool issuccess = usermanager.addOpinion(emailname, content, name);
            JsonResult jr = Json(issuccess, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
        public JsonResult getOpinion()
        {
            List<T_USER_Opinion> opinion = usermanager.getOpinion();
            JsonResult jr = Json(opinion, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }


    }
}