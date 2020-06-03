using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using CreateCVOnline.Models;
using CreateCVOnline.Code;
using System.IO;
namespace CreateCVOnline.Controllers
{
    public class CandidateController : Controller
    {
        UserProcess user = new UserProcess();
        // GET: Candidate
        public ActionResult Index()
        {
            var account = Session["Account"] as LoginModel;
            DataTable dt=user.getCV(account.Username);
            var model = new CVModel();
            if(dt.Rows.Count==0)
            {
                model.FullName = "0";
                model.Age = 19;
                model.NumberPhone = "0";
                model.Address = "0";
                model.ID_Skills = 1;
                model.Goal = "0";
                model.Email = "0";
                model.Image = "0";
                model.ID_Jobs = 1;
                model.ID_Education = 1;
                model.ID_Activities = 1;
            }
            else
            {
                model.FullName = dt.Rows[0]["Fullname"].ToString();
                model.Age = Convert.ToInt32(dt.Rows[0]["Age"].ToString());
                model.NumberPhone = dt.Rows[0]["Numberphone"].ToString();
                model.Address = dt.Rows[0]["Address"].ToString();
                model.ID_Skills = Convert.ToInt32(dt.Rows[0]["ID_Skills"].ToString());
                model.Goal = dt.Rows[0]["Goal"].ToString();
                model.Email = dt.Rows[0]["Email"].ToString();
                model.Image = dt.Rows[0]["Image"].ToString();
                model.ID_Jobs = Convert.ToInt32(dt.Rows[0]["ID_Jobs"].ToString());
                model.ID_Education = Convert.ToInt32(dt.Rows[0]["ID_Education"].ToString());
                model.ID_Activities = Convert.ToInt32(dt.Rows[0]["ID_Activities"].ToString());
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(string Username)
        {
            /*if (Username == null)
                Username = "phutai001";*/
            DataTable dt = user.getCV(Username);
            var model = new CVModel();
            model.FullName = dt.Rows[0]["Fullname"].ToString();
            model.Age = Convert.ToInt32(dt.Rows[0]["Age"].ToString());
            model.NumberPhone = dt.Rows[0]["Numberphone"].ToString();
            model.Address = dt.Rows[0]["Address"].ToString();
            model.ID_Skills = Convert.ToInt32(dt.Rows[0]["ID_Skills"].ToString());
            model.Goal = dt.Rows[0]["Goal"].ToString();
            model.Email = dt.Rows[0]["Email"].ToString();
            model.Image = dt.Rows[0]["Image"].ToString();
            model.ID_Jobs = Convert.ToInt32(dt.Rows[0]["ID_Jobs"].ToString());
            model.ID_Education = Convert.ToInt32(dt.Rows[0]["ID_Education"].ToString());
            model.ID_Activities = Convert.ToInt32(dt.Rows[0]["ID_Activities"].ToString());
            return View(model);
        }
        public ActionResult EditCV()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditCV(CVModel cv)
        {
            var account = Session["Account"] as LoginModel;
            user.chinhsua(account.Username,cv.FullName,cv.Email,cv.Age, cv.NumberPhone, cv.Address, cv.Goal);
            return Redirect("/Candidate/Index");
        }
        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return Redirect("http://google.com");
            }
            string path = "";
            
            path = Path.Combine(Server.MapPath("~/Assets/images"), file.FileName);
            var account = Session["Account"] as LoginModel;
            file.SaveAs(path);
            LoginModel login = Session["Account"] as LoginModel;
            int ID = user.getID(login.Username.ToString());
            user.uploadImage(ID, @"/Assets/images/"+file.FileName);
            return Redirect("/Candidate/Index");
        }

        public ActionResult EditCVDetail()
        {
            return View();
        }
        
        public ActionResult Skills()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Skills(SkillsModel skill)
        {
            LoginModel login = Session["Account"] as LoginModel;
            skill.IDSk = user.getID(login.Username.ToString());
            user.addNewSkill(skill);
            return View();
        }

        public ActionResult Activities()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Activities(ActivitiesModel activities)
        {
            LoginModel login = Session["Account"] as LoginModel;
            activities.ID = user.getID(login.Username.ToString());
            user.addNewActivities(activities);
            return View();
        }

        public ActionResult Jobs()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Jobs(JobsModel jobs)
        {
            LoginModel login = Session["Account"] as LoginModel;
            jobs.ID_Job = user.getID(login.Username.ToString());
            user.addNewJob(jobs);
            return View();
        }

        public ActionResult Education()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Education(EducationModel edu)
        {
            LoginModel login = Session["Account"] as LoginModel;
            edu.IDEdu = user.getID(login.Username.ToString());
            user.addNewEducation(edu);
            return View();
        }
    }
}