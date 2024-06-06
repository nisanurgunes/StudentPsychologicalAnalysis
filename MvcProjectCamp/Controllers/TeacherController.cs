using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class TeacherController : Controller
    {
        TeacherManagerBL tm = new TeacherManagerBL(new EfTeacherDAL());
        TeacherValidator teacherValidator = new TeacherValidator();

        // GET: Teacher
        public ActionResult Index()
        {
            var TeacherValues = tm.GetList();
            return View(TeacherValues);
        }

        [HttpGet]
        public ActionResult AddTeacher()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddTeacher(Teacher p) //AddTeacher
        {
            ValidationResult results = teacherValidator.Validate(p);
            if (results.IsValid)
            {
                // doğrulama çalışıyorsa ekle
                tm.TeacherAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                // hata varsa yakala
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            // hiçbir şey yoksa view döndür
            return View();
        }
        [HttpGet]
        public ActionResult EditTeacher(int id)
        {
            var teachervalue = tm.GetByID(id);
            return View(teachervalue);
        }

        [HttpPost]
        public ActionResult EditTeacher(Teacher p)
        {
            ValidationResult results = teacherValidator.Validate(p);
            if (results.IsValid)
            {
                tm.TeacherUpdate(p);
                return RedirectToAction("Index");
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
    }
}