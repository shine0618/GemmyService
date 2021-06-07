using _2GemmyBusness.BLL.BLLUserAccount;
using _1GemmyModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

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
        [HttpGet]
        public JsonResult SendRegisterEmail(string emailaddress)
        {
            Random rd = new Random();
            string codestr = "";
            for (int i = 0; i < 5; i++)
            {
                int num = rd.Next(0, 9);
                codestr += num;
            }
            //设置要调用的发送邮件的服务器
            SmtpClient smtp = new SmtpClient("smtp.qq.com");
            //创建发件人对象
            MailAddress from = new MailAddress("1194778796@qq.com");
            //创建收件人对象
            MailAddress to = new MailAddress(emailaddress);
            //要发送的邮件对象，包含四个内容要填充
            MailMessage mail = new MailMessage(from, to);
            //设置邮件的标题
            mail.Subject = "Test";
            mail.IsBodyHtml = true;
            //设置邮件的主题正文格式
            mail.Body = emailBody(codestr);
            //创建发件人身份验证凭证
            NetworkCredential cred = new NetworkCredential("1194778796@qq.com", "vjmyuabouewyghgc");
            smtp.Credentials = cred;
            //此服务器对象执行发送邮件功能
            smtp.Send(mail);
            usermanager.addRegisterInfo(emailaddress,DateTime.UtcNow.AddMinutes(30),codestr);
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
        [HttpGet]
        public JsonResult Register(string email, string password, string firstname, string lastname,string code)
        {
            bool isRegister = false;
            List<T_USER_Temporary_UserInfo> t_temporary = usermanager.getTempinfo(email);
            if (t_temporary.Count != 0)
            {
                foreach (var item in t_temporary)
                {
                    if (item.FailTime >= DateTime.UtcNow)
                    {
                        if (code == item.Code)
                        {
                            usermanager.Register(email, password, firstname, lastname);
                            isRegister = true;
                        }
                    }
                }
            }
            JsonResult jr = Json(isRegister, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }
        [HttpGet]
        public JsonResult Login(string email,string password)
        {
            bool isLogin = usermanager.Login(email, password);
            JsonResult jr = Json(isLogin, JsonRequestBehavior.AllowGet);
            jr.MaxJsonLength = int.MaxValue;
            return jr;
        }

        [HttpGet]
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
        [HttpGet]
        public JsonResult SendResetEmail(string emailaddress)
        {
            Random rd = new Random();
            string codestr = "";
            for (int i = 0; i < 5; i++)
            {
                int num = rd.Next(0, 9);
                codestr += num;
            }
            //设置要调用的发送邮件的服务器
            SmtpClient smtp = new SmtpClient("smtp.qq.com");
            //创建发件人对象
            MailAddress from = new MailAddress("1194778796@qq.com");
            //创建收件人对象
            MailAddress to = new MailAddress(emailaddress);
            //要发送的邮件对象，包含四个内容要填充
            MailMessage mail = new MailMessage(from, to);
            //设置邮件的标题
            mail.Subject = "Test";
            mail.IsBodyHtml = true;
            //设置邮件的主题正文格式
            mail.Body = ResetemailBody(codestr);
            //创建发件人身份验证凭证
            NetworkCredential cred = new NetworkCredential("1194778796@qq.com", "vjmyuabouewyghgc");
            smtp.Credentials = cred;
            //此服务器对象执行发送邮件功能
            smtp.Send(mail);
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
    }
}