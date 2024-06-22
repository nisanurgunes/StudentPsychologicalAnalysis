using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Newtonsoft.Json;
using System.Linq;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StudentListController : Controller
    {
        StudentManagerBL sm = new StudentManagerBL(new EfStudentDAL());
        TeacherManagerBL wm = new TeacherManagerBL(new EfTeacherDAL()); // Assuming you have a TeacherManager

        // GET: StudentList
        public ActionResult StudentListView(int? page)
        {
            var pageNumber = page ?? 1; // Sayfa numarası, eğer null ise 1 olarak ayarlanır
            var pageSize = 10; // Sayfa başına öğrenci sayısı

            var studentList = sm.GetList();

            return View(studentList);
        }

        [HttpGet]
        public ContentResult GetStudentsByTeacherClass(string teacherClass)
        {
            var students = sm.GetList().Where(s => s.StudentClass == teacherClass).ToList();
            var json = JsonConvert.SerializeObject(new { students = students }, Formatting.None,
                        new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Content(json, "application/json");
        }
    }
}
