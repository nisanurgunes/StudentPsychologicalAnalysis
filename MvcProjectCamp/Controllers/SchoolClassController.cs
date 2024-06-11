using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class SchoolClassController : Controller
    {
        // GET: SchoolClass
        SchoolClassManagerBL scm = new SchoolClassManagerBL(new EfSchoolClassDAL());

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetSchoolClassList()
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
                return RedirectToAction("GetSchoolClassList");
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