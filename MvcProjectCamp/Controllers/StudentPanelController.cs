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
    public class StudentPanelController : Controller
    {
        private readonly StudentTextManagerBL _studentTextManager;
        private readonly SchoolClassManagerBL _schoolClassManager;

        public StudentPanelController()
        {
            _studentTextManager = new StudentTextManagerBL(new EfStudentTextDAL());
            _schoolClassManager = new SchoolClassManagerBL(new EfSchoolClassDAL());
        }

        [HttpGet]
        public ActionResult NewStudentText()
        {
            
            int studentId = Convert.ToInt32(Session["StudentID"]);
            if (studentId == 0)
            {
                
                return RedirectToAction("StudentLogin", "Login");
            }

            
            var schoolClasses = _schoolClassManager.GetList();
            ViewBag.Categories = new SelectList(schoolClasses, "ClassID", "ClassList");

            // StudentID değerini view'a gönder
            ViewBag.StudentID = studentId;


            return View();
        }

        [HttpPost]
        public ActionResult NewStudentText(StudentText studentText, string classificationResult)
        {
            
            int studentId = Convert.ToInt32(Session["StudentID"]);
            if (studentId == 0)
            {
                
                return RedirectToAction("StudentLogin", "Login");
            }

            int schoolClassId = Convert.ToInt32(Session["ClassID"]);
            if (schoolClassId == 0)
            {
             
                schoolClassId = _schoolClassManager.GetList().FirstOrDefault()?.ClassID ?? 0;
            }

            if (schoolClassId == 0)
            {
                
                return RedirectToAction("NewStudentText");
            }

            studentText.StudentID = studentId;
            studentText.ClassID = schoolClassId;
            studentText.StudentTextDate = DateTime.Now;

            studentText.ClassificationResult = classificationResult;
            _studentTextManager.StudentTextAdd(studentText);

            return RedirectToAction("NewStudentText");
        }
    }
}
