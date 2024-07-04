using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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


        public Context db = new Context(); // Update with your actual DbContext name

        // GET: Student
        public ActionResult IndexS()
        {
            var model = new List<Student>();
            return View(model);
        }

        [HttpGet]
        public JsonResult GetStudentsByClass(string studentClass)
        {
            var students = db.Students
                             .Where(s => s.StudentClass == studentClass)
                             .Select(s => new {
                                 s.StudentName,
                                 s.StudentSurname,
                                 s.StudentClass,
                                 s.StudentUserName,
                                 s.StudentImage,
                                 s.StudentID
                             })
                             .ToList();

            return Json(students, JsonRequestBehavior.AllowGet);
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