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
    public class StudentController : Controller
    {
        StudentManagerBL sm = new StudentManagerBL(new EfStudentDAL());
        StudentValidator studentValidator = new StudentValidator();

        // GET: Student
        public ActionResult IndexS()
        {
            var StudentValues = sm.GetList();
            return View(StudentValues);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddStudent(Student p) //AddStudent
        {
            ValidationResult results = studentValidator.Validate(p);
            if (results.IsValid)
            {
                // doğrulama çalışıyorsa ekle
                sm.StudentAdd(p);
                return RedirectToAction("IndexS");
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
        public ActionResult EditStudent(int id)
        {
            var studentvalue = sm.GetByID(id);
            return View(studentvalue);
        }

        [HttpPost]
        public ActionResult EditStudent(Student p)
        {
            ValidationResult results = studentValidator.Validate(p);
            if (results.IsValid)
            {
                sm.StudentUpdate(p);
                return RedirectToAction("IndexS");
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