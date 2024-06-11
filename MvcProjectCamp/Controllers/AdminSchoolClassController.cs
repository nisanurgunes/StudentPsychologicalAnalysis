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
    public class AdminSchoolClassController : Controller
    {
        SchoolClassManagerBL scm = new SchoolClassManagerBL(new EfSchoolClassDAL());
        [Authorize]

        public ActionResult Index()
        {
            var schoolClassvalues = scm.GetList();
            return View(schoolClassvalues);
        }
        [HttpGet]
        public ActionResult AddSchoolClass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSchoolClass(SchoolClass p)
        {
            SchoolClassValidator schoolClassValidator = new SchoolClassValidator();
            ValidationResult results = schoolClassValidator.Validate(p);
            if (results.IsValid)
            {
                scm.SchoolClassAdd(p);
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

        public ActionResult DeleteSchoolClass(int id)
        {
            var schoolClassvalue = scm.GetByID(id);

            scm.SchoolClassDelete(schoolClassvalue);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditSchoolClass(int id)
        {
            var schoolClassvalue = scm.GetByID(id);
            return View(schoolClassvalue);
        }

        [HttpPost]
        public ActionResult EditSchoolClass(SchoolClass p)
        {
            scm.SchoolClassUpdate(p);
            return RedirectToAction("Index");
        }
    }
}