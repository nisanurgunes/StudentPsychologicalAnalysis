using DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HomeController : Controller
    {
        public Context _context;

        public HomeController(Context context)
        {
            _context = context;
        }
        public HomeController()
        {
            _context = new Context();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult HomePage()
        {
            var studentCount = _context.Students.Count();
            var teacherCount = _context.Teachers.Count();
            

            var teacherClassCount = _context.Teachers
               .Count(t => !string.IsNullOrEmpty(t.TeacherClass));


            ViewBag.StudentCount = studentCount;
            ViewBag.TeacherCount = teacherCount;
            ViewBag.TeacherClassCount = teacherClassCount;

            return View();
        }
        public ActionResult Error()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }
    }
}