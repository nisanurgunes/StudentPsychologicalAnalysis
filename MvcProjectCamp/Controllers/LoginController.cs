using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProjectCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Login
        AdminManagerBL adminManager = new AdminManagerBL(new EfAdminDAL());
        TeacherLoginManagerBL wm = new TeacherLoginManagerBL(new EfTeacherDAL());
        StudentManagerBL sm = new StudentManagerBL(new EfStudentDAL());
        // GET: Login
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context c = new Context();
            var adminuserinfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminuserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(adminuserinfo.AdminUserName, false);
                Session["AdminUserName"] = adminuserinfo.AdminUserName;
                return RedirectToAction("Index", "AdminSchoolClass");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public ActionResult TeacherLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TeacherLogin(Teacher p)
        {
            Context c = new Context();
            var teacheruserinfo = c.Teachers.FirstOrDefault(x => x.TeacherMail == p.TeacherMail && x.TeacherPassword == p.TeacherPassword);
            if (teacheruserinfo != null)
            {
                FormsAuthentication.SetAuthCookie(teacheruserinfo.TeacherMail, false);
                Session["TeacherMail"] = teacheruserinfo.TeacherMail;
                return RedirectToAction("MyHeading", "TeacherPanel");
            }
            else
            {
                return RedirectToAction("TeacherLogin");
            }
        }

        [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(Student p)
        {
            Context c = new Context();
            var studentUserInfo = c.Students.FirstOrDefault(x => x.StudentUserName == p.StudentUserName && x.StudentPassword == p.StudentPassword);
            if (studentUserInfo != null)
            {
                FormsAuthentication.SetAuthCookie(studentUserInfo.StudentUserName, false);
                Session["StudentUserName"] = studentUserInfo.StudentUserName;
                Session["StudentID"] = studentUserInfo.StudentID; // Store the StudentID in the session
                return RedirectToAction("NewStudentText", "StudentPanel");
            }
            else
            {
                return RedirectToAction("StudentLogin");
            }
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default");
        }
    }
}