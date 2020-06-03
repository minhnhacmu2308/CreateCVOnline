using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreateCVOnline.Models;
using CreateCVOnline.Code;
using CaptchaMvc.HtmlHelpers;
namespace CreateCVOnline.Controllers
{
    public class AccountController : Controller
    {
        private String GetMD5(string txt)
        {
            String str = "";
            Byte[] buffer = System.Text.Encoding.UTF8.GetBytes(txt);
            System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            buffer = md5.ComputeHash(buffer);
            foreach (Byte b in buffer)
            {
                str += b.ToString("X2");
            }
            return str;
        }
        UserProcess user = new UserProcess();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        //Post: Login
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if(!this.IsCaptchaValid(""))
            {
                return Redirect("/Account/Login");
            }
            login.Password = GetMD5(login.Password);
            if (user.checkLogin(login))
            {
                Session.Add("Account", login);
                int k = user.getRole(login.Username);
                int firsttime = user.getIsFirstTime(login.Username);
                if (k == 1)
                    if (firsttime == 0)
                        return Redirect("/Candidate/Index");
                    else
                        return Redirect("/Candidate/EditCV");
                else if (k == 0)
                    return Redirect("/Business/Index");
                else
                    return Redirect("/AdminPage/Index");
            }
            return View();
        }
       //Get: Register
        public  ActionResult Register()
        {
            return View();
        }

        //Post: Register
        [HttpPost]
        public ActionResult Register(RegisterModel register)
        {

            register.Password = GetMD5(register.Password);
            if (user.register(register))
                return Redirect("/Account/Login");
            return View();
        }

        //Get: ChangePassword
        public ActionResult ChangePassword()
        {
            return View();
        }

        //Post: ChangePassword
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel changePassword)
        {
            changePassword.Password = GetMD5(changePassword.Password);
            user.changepassword(changePassword);
            return View();
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            return Redirect("/LandingPage/Index");
        }

        //GET: Edit CV Detail
        public ActionResult EditCVDetail()
        {
            return View();
        }
        public ActionResult contact()
        {
            return View();
        }
    }
}