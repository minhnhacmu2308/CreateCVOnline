using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CreateCVOnline.Code;
using CreateCVOnline.Models;
namespace CreateCVOnline.Controllers
{
    
    public class AdminPageController : Controller
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
        // GET: AdminPage
        public ActionResult Index()
        {
            return View();
        }

        //GET: Account General

        public ActionResult Accounts()
        {
            return View();
        }

        //GET: Add New Account
        public ActionResult NewAccount()
        {
            return View();
        }

        //POST: Add New Account
        [HttpPost]
        public ActionResult NewAccount(AccountModel account)
        {
            account.Password = GetMD5(account.Password);
            user.addNewAccount(account);
            return View();
        }

        //GET: Edit Account
        public ActionResult Edit(int id)
        {
            AdminEditAccountModel account=new AdminEditAccountModel();
            account.ID = id.ToString();
            return View(account);
        }
        //Post: Edit Account
        [HttpPost]
        public ActionResult Edit(AdminEditAccountModel account)
        {
            account.Password = GetMD5(account.Password);
            user.adminEditAccount(account);
            return Redirect("/AdminPage/Accounts");
        }

        public ActionResult deleteAccount(int id)
        {
            user.removeAccount(id);
            return Redirect("/AdminPage/Accounts");
        }
    }
}