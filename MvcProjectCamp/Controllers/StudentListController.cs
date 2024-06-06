using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using PagedList;
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
        TeacherManagerBL wm = new TeacherManagerBL(new EfTeacherDAL()); // Assuming you have a TeacherManager

            public ActionResult StudentListView(int? page)
            {
                var pageNumber = page ?? 1; // Sayfa numarası, eğer null ise 1 olarak ayarlanır
                var pageSize = 10; // Sayfa başına öğrenci sayısı

                var studentList = sm.GetList();

                return View(studentList);
            }


        
    }
}
