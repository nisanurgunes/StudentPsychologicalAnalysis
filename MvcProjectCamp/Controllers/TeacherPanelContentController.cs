using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class TeacherPanelContentController : Controller
    {
        // GET: TeacherPanelContent
        ContentManagerBL cm = new ContentManagerBL(new EfContentDAL());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            p = (string)Session["TeacherMail"];
            var teacheridinfo = c.Teachers.Where(x => x.TeacherMail == p).Select(y => y.TeacherID).FirstOrDefault();
            var contentvalues = cm.GetListByTeacher(teacheridinfo);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content p)
        {
            string mail = (string)Session["TeacherMail"];
            var teacheridinfo = c.Teachers.Where(x => x.TeacherMail == mail).Select(y => y.TeacherID).FirstOrDefault();
            p.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.TeacherID = teacheridinfo;
            p.ContentStatus = true;
            cm.ContentAdd(p);
            return RedirectToAction("MyContent");
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}