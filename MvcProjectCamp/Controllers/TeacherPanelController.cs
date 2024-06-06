using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using System.Data.SqlTypes;
using BusinessLayer.ValidationRules;
using FluentValidation.Results;
using Microsoft.AspNet.Identity;

namespace MvcProjectCamp.Controllers
{
    public class TeacherPanelController : Controller
    {
        // GET: TeacherPanel
        HeadingManagerBL hm = new HeadingManagerBL(new EfHeadingDAL());
        CategoryManagerBL cm = new CategoryManagerBL(new EfCategoryDAL());
        TeacherManagerBL tm = new TeacherManagerBL(new EfTeacherDAL());
        TeacherValidator teacherValidator = new TeacherValidator();
        Context c = new Context();

        [HttpGet]
        public ActionResult TeacherProfile(int id = 0)
        {
            string p = (string)Session["TeacherMail"];
            id = c.Teachers.Where(x => x.TeacherMail == p).Select(y => y.TeacherID).FirstOrDefault();
            var teachervalue = tm.GetByID(id);
            return View(teachervalue);
        }
        [HttpPost]
        public ActionResult TeacherProfile(Teacher p)
        {
            ValidationResult results = teacherValidator.Validate(p);
            if (results.IsValid)
            {
                tm.TeacherUpdate(p);
                return RedirectToAction("AllHeading", "TeacherPanel");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
        public ActionResult MyHeading(string p)
        {
            p = (string)Session["TeacherMail"];
            var teacheridinfo = c.Teachers.Where(x => x.TeacherMail == p).Select(y => y.TeacherID).FirstOrDefault();
            var values = hm.GetListByTeacher(teacheridinfo);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string teachermailinfo = (string)Session["TeacherMail"];
            var teacheridinfo = c.Teachers.Where(x => x.TeacherMail == teachermailinfo).Select(y => y.TeacherID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.TeacherID = teacheridinfo;
            p.HeadingStatus = true;
            hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valuecategory;
            var HeadingValue = hm.GetByID(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = hm.GetByID(id);
            HeadingValue.HeadingStatus = false;
            hm.HeadingDelete(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p = 1)
        {
            var headings = hm.GetList().ToPagedList(p    , 4);
            return View(headings);
        }
    }
}