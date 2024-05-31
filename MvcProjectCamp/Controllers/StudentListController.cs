using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StudentListController : Controller
    {
        // GET: StudentList
        StudentManagerBL sm = new StudentManagerBL(new EfStudentDAL());
        public ActionResult StudentListView()
        {
           
                var StudentValues = sm.GetList();
                return View(StudentValues);
            
        }
    }
}