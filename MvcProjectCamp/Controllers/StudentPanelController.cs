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
            // Session'dan StudentID değerini al
            int studentId = Convert.ToInt32(Session["StudentID"]);
            if (studentId == 0)
            {
                // Eğer Session'da StudentID bulunmuyorsa, login sayfasına yönlendir
                return RedirectToAction("StudentLogin", "Login");
            }

            // Gerekirse kategori bilgilerini al ve ViewBag içine koy
            var schoolClasses = _schoolClassManager.GetList();
            ViewBag.Categories = new SelectList(schoolClasses, "ClassID", "ClassList");

            // StudentID değerini view'a gönder
            ViewBag.StudentID = studentId;

            // Model dosya yollarını view'a gönder
            ViewBag.ModelPath = Url.Content("~/Scripts-Model/tfjs_model/model.json");
            ViewBag.Group1Path = Url.Content("~/Scripts-Model/tfjs_model/group1-shard1of2.bin");
            ViewBag.TokenizerPath = Url.Content("~/Scripts-Model/tfjs_model/tokenizer.pickle");

            return View();
        }

        [HttpPost]
        public ActionResult NewStudentText(StudentText studentText, string classificationResult)
        {
            // Session'dan StudentID değerini al
            int studentId = Convert.ToInt32(Session["StudentID"]);
            if (studentId == 0)
            {
                // Eğer Session'da StudentID bulunmuyorsa, login sayfasına yönlendir
                return RedirectToAction("StudentLogin", "Login");
            }

            // Session'dan CategoryID değerini al veya belirle
            int schoolClassId = Convert.ToInt32(Session["ClassID"]);
            if (schoolClassId == 0)
            {
                // Eğer Session'da CategoryID bulunmuyorsa, default bir değer veya mantıksal bir seçim yapılabilir
                // Burada, ilk kategoriyi alabilirsiniz:
                schoolClassId = _schoolClassManager.GetList().FirstOrDefault()?.ClassID ?? 0;
            }

            if (schoolClassId == 0)
            {
                // Eğer geçerli bir SchoolClassID bulunamazsa, bir hata sayfasına yönlendir veya bir mesaj göster
                return RedirectToAction("NewStudentText");
            }

            // Alınan StudentID ve SchoolClassID değerlerini studentText nesnesine ekle
            studentText.StudentID = studentId;
            studentText.ClassID = schoolClassId;
            studentText.StudentTextDate = DateTime.Now;

            // Sınıflandırma sonucunu ekle
            studentText.ClassificationResult = classificationResult;

            // StudentText tablosuna ekle
            _studentTextManager.StudentTextAdd(studentText);

            return RedirectToAction("NewStudentText");
        }
    }
}
