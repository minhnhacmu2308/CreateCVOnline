using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CreateCVOnline.Models;
using System.Data;
namespace CreateCVOnline.Code
{
    public class UserProcess
    {
        KETNOIDULIEU ketnoi = new KETNOIDULIEU();
        public int totalUser()
        {
            string sql = "SELECT COUNT(*) FROM tblAccount";
            int total = ketnoi.thucthiScalar(sql);
            return total;
        }
        public bool checkLogin(LoginModel login)
        {
            string sql = "SELECT * FROM tblAccount WHERE Username='" + login.Username + "' AND Password='" + login.Password + "'";
            DataTable dt = ketnoi.getDuLieu(sql);
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }

        public bool register(RegisterModel register)
        {
            int isF = 1;
            string sql = "INSERT INTO tblAccount(Username,Password,Email,Role,IsFirstTime) VALUES('" + register.Username + "','" + register.Password + "','" + register.Email + "','" + register.Role + "','"+isF+"')";
            int k = ketnoi.thucthiNonQuery(sql);
            int l = getID(register.Username);
            if (k > 0)
                return true;
            else
                return false;
        }
        public int getID(String username)
        {
            string sql = "SELECT ID FROM tblAccount WHERE Username='" + username + "'";
            int k = Convert.ToInt32(ketnoi.getDuLieu(sql).Rows[0]["ID"].ToString());
            return k;
        }

        public int getIsFirstTime(String username)
        {
            string sql = "SELECT IsFirstTime FROM tblAccount WHERE Username='" + username + "'";
            int firsttime = Convert.ToInt32(ketnoi.getDuLieu(sql).Rows[0]["IsFirstTime"].ToString());
            return firsttime;
        }
        //Admin Add New Account
        public bool addNewAccount(AccountModel account)
        {
            string sql = "INSERT INTO tblAccount(Username,Password,Email,Role) VALUES('" + account.Username + "','" + account.Password + "','" + account.Email + "','" + account.Role + "')";
            int k = ketnoi.thucthiNonQuery(sql);
            if (k > 0)
                return true;
            else
                return false;
        }
        public bool changepassword(ChangePasswordModel changepassword)
        {
            string sql = "UPDATE tblAccount SET Password='" + changepassword.Password + "' WHERE Username='" + changepassword.Username + "'";
            int k = ketnoi.thucthiNonQuery(sql);
            if (k > 0)
                return true;
            return false;
        }

        public int getRole(string username)
        {
            
            string sql = "SELECT Role FROM tblAccount WHERE Username='" + username + "'";
            int role = Convert.ToInt32(ketnoi.getDuLieu(sql).Rows[0]["Role"].ToString());
            return role;
        }

        public DataTable getCV(string username)
        {
            string sql = "SELECT * FROM tblAccount,tblAccountDetail WHERE tblAccount.ID=tblAccountDetail.ID AND tblAccount.Username='"+username+"' ";
            return ketnoi.getDuLieu(sql);
        }

        public DataTable getSkills(int ID_Skills)
        {
            string sql="SELECT * FROM tblSkills WHERE ID_Skills='"+ID_Skills+"'";
            return ketnoi.getDuLieu(sql);
        }

        public DataTable getJobs(int ID_Jobs)
        {
            string sql = "SELECT * FROM tblJobs WHERE ID_Jobs='" + ID_Jobs + "'";
            return ketnoi.getDuLieu(sql);
        }

        public DataTable getEducation(int ID_Education)
        {
            string sql = "SELECT * FROM tblEducation WHERE ID_Education='" + ID_Education + "'";
            return ketnoi.getDuLieu(sql);
        }

        public DataTable getActivities(int ID_Activities)
        {
            string sql = "SELECT * FROM tblActivities WHERE ID_Activities='" + ID_Activities + "'";
            return ketnoi.getDuLieu(sql);
        }

        public int chinhsua(string username,string fullname, string email,int age,string numberphone,string address, string goal)
        {
            string sql1;
            if (getIsFirstTime(username)==0)
            {
                string sql = "UPDATE tblAccount SET Email='" + email + "' WHERE Username='" + username + "'";
                ketnoi.thucthiNonQuery(sql);
                int id = Convert.ToInt32(ketnoi.getDuLieu("SELECT ID FROM tblAccount WHERE Username='" + username + "'").Rows[0]["ID"].ToString());
                sql1 = "UPDATE tblAccountDetail SET Fullname=N'" + fullname + "', Age='" + age + "', Numberphone='" + numberphone + "',Address=N'" + address + "',Goal=N'" + goal + "' WHERE ID='" + id + "' ";
            }
            else
            {
                int f = 0;
                string sql = "UPDATE tblAccount SET Email='" + email + "',isFirstTime='" + f + "' WHERE Username='" + username + "'";
                ketnoi.thucthiNonQuery(sql);
                int id = getID(username);
                sql1 = "INSERT INTO tblAccountDetail(ID,Fullname,Age,Numberphone,Address,Goal,ID_Jobs,ID_Education,ID_Skills,ID_Activities) VALUES('" + id + "',N'" + fullname + "','" + age + "','" + numberphone + "',N'" + address + "',N'" + goal + "','" + id + "','" + id + "','" + id + "','" + id + "')";
            }
           
            return ketnoi.thucthiNonQuery(sql1);
        }
        public int uploadImage(int id, string url)
        {
            string sql = "UPDATE tblAccountDetail SET Image='" + url + "' WHERE ID='" + id + "'";
            return ketnoi.thucthiNonQuery(sql);
        }
        public DataTable getCandidate()
        {
            string sql = "SELECT Username,Fullname,Age,Image FROM tblAccount,tblAccountDetail WHERE tblAccount.ID=tblAccountDetail.ID AND Role='1'";
            return ketnoi.getDuLieu(sql);
        }
        public DataTable getAccount()
        {
            string sql = "SELECT ID,Username,Password,Role,Email FROM tblAccount";
            return ketnoi.getDuLieu(sql);
        }

        public DataTable getAccount(int ID)
        {
            string sql = "SELECT ID,Username,Password,Role,Email FROM tblAccount WHERE ID='"+ID+"'";
            return ketnoi.getDuLieu(sql);
        }

        public int adminEditAccount(AdminEditAccountModel account)
        {
            string sql = "UPDATE tblAccount SET Username='" + account.Username + "', Password='" + account.Password + "',Role='" + Convert.ToInt32(account.Role) + "'," +
                "Email='" + account.Email + "' WHERE ID='" + Convert.ToInt32(account.ID) + "'";
            return ketnoi.thucthiNonQuery(sql);
        }

        public int removeAccount(int id)
        {
            string sql = "DELETE FROM tblAccount WHERE ID='" + id + "'";
            return ketnoi.thucthiNonQuery(sql);
        }

        public int addNewSkill(SkillsModel skills)
        {
            string sql="INSERT INTO tblSkills VALUES('"+skills.IDSk+"','"+skills.SkillsName+"','"+skills.Percent+"')";
            return ketnoi.thucthiNonQuery(sql);
        }

        public int addNewJob(JobsModel job)
        {
            string sql = "INSERT INTO tblJobs VALUES('" + job.ID_Job + "','" + job.JobsDetail + "','" + job.Name + "','" + job.Time + "','" + job.Type + "')";
            return ketnoi.thucthiNonQuery(sql);
        }

        public int addNewEducation(EducationModel edu)
        {
            string sql = "INSERT INTO tblEducation VALUES('" + edu.IDEdu + "','" + edu.EducationDetail + "','" + edu.Time + "','" + edu.Type + "','" + edu.Time + "')";
            return ketnoi.thucthiNonQuery(sql);
        }

        public int addNewActivities(ActivitiesModel act)
        {
            string sql = "INSERT INTO tblActivities VALUES('" + act.ID + "','" + act.ActivitiesDetail + "')";
            return ketnoi.thucthiNonQuery(sql);
        }
    }
}