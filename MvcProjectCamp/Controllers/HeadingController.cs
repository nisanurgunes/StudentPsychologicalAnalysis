using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class HeadingController : Controller
    {
        // GET: Heading
        HeadingManagerBL hm = new HeadingManagerBL(new EfHeadingDAL());
        SchoolClassManagerBL scm = new SchoolClassManagerBL(new EfSchoolClassDAL());
        TeacherManagerBL wm = new TeacherManagerBL(new EfTeacherDAL());
        public ActionResult Index()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }
        public ActionResult HeadingReport()
        {
            var headingvalues = hm.GetList();
            return View(headingvalues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueschoolClass = (from x in scm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ClassList,
                                                      Value = x.ClassID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueteacher = (from x in wm.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.TeacherName + " " + x.TeacherSurname,
                                                    Value = x.TeacherID.ToString()
                                                }).ToList();
            ViewBag.vlc = valueschoolClass;
            ViewBag.vlw = valueteacher;
            return View();
        }
        [HttpPost]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueschoolClass = (from x in scm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ClassList,
                                                      Value = x.ClassID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueschoolClass;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}