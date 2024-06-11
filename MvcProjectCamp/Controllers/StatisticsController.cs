using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        SchoolClassManagerBL scm = new SchoolClassManagerBL(new EfSchoolClassDAL());
        Context db = new Context();
        Statistics stats = new Statistics();
        public ActionResult Index()
        {
            //1. Soru: Toplam Kategori Sayısı
            stats.TotalSchoolClassCount = scm.GetList().Count();

            //3. Soru: Yazar adında 'a' harfi geçen yazar sayısı
            stats.TotalTeacherLetterACount = db.Teachers.Count(x => x.TeacherName.ToLower().Contains("a"));

            //4. Soru: En fazla başlığa sahip kategori adı
            stats.MaxHeadingSchoolClassList = scm.GetList().Where(x => x.ClassID == db.Headings.ToList()
            .GroupBy(y => y.ClassID).ToList().OrderBy(z => z.Count()).Last().Key).FirstOrDefault().ClassList;

            //5. Soru: Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki
            //sayısal fark
            stats.DifferenceSchoolClassStatus = scm.GetList().Where(x => x.ClassStatus == true).Count() -
                scm.GetList().Where(x => x.ClassStatus == false).Count();

            return View(stats);
        }
    }
}