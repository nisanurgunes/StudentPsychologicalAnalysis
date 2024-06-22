using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StudentListController : Controller
    {
        StudentManagerBL sm = new StudentManagerBL(new EfStudentDAL());
        TeacherManagerBL tm = new TeacherManagerBL(new EfTeacherDAL()); // Assuming you have a TeacherManager

        // GET: StudentList
        public ActionResult StudentListView(int? page)
        {
            var pageNumber = page ?? 1; // Sayfa numarası, eğer null ise 1 olarak ayarlanır
            var pageSize = 10; // Sayfa başına öğrenci sayısı

            var studentList = sm.GetList();

            return View(studentList);
        }
        [HttpPost]
        public ActionResult GetMatchingStudents()
        {
            var teachers = new Dictionary<string, string>
    {
        { "meryemalpayci@gmail.com", "7-A" },
        { "fadimesarigül@gmail.com", "7-B" },
        { "omerapaydin@gmail.com", "7-C" },
        { "osmankumbul@gmail.com", "7-D" },
        { "burakpeker@gmail.com", "6-A" },
        { "mervekalan@gmail.com", "6-B" },
        { "elagulsen@gmail.com", "6-C" },
        { "umutguney@gmail.com", "6-D" },
        { "beratozcan@gmail.com", "8-A" },
        { "ozlemkahraman@gmail.com", "8-B" },
        { "pinarorak@gmail.com", "8-C" },
        { "orhanbayrak@gmail.com", "8-D" },
        // Diğer öğretmenlerin sınıf bilgileri
    };

            var matchingStudents = new List<Student>();

            foreach (var teacher in teachers)
            {
                var teacherMail = teacher.Key;
                var teacherClass = teacher.Value;

                var students = sm.GetList().Where(s => s.StudentClass == teacherClass).ToList();
                matchingStudents.AddRange(students);
            }

            var studentData = matchingStudents.Select(s => new { s.StudentName, s.StudentSurname }).ToList();

            return Json(studentData);
        }
    }
}

