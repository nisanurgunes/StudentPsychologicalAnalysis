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
        private readonly CategoryManagerBL _categoryManager;

        public StudentPanelController()
        {
            _studentTextManager = new StudentTextManagerBL(new EfStudentTextDAL());
            _categoryManager = new CategoryManagerBL(new EfCategoryDAL());
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
            var categories = _categoryManager.GetList();
            ViewBag.Categories = new SelectList(categories, "CategoryID", "CategoryName");

            // StudentID değerini view'a gönder
            ViewBag.StudentID = studentId;

            return View();
        }

        [HttpPost]
        public ActionResult NewStudentText(StudentText studentText)
        {
            // Session'dan StudentID değerini al
            int studentId = Convert.ToInt32(Session["StudentID"]);
            if (studentId == 0)
            {
                // Eğer Session'da StudentID bulunmuyorsa, login sayfasına yönlendir
                return RedirectToAction("StudentLogin", "Login");
            }

            // Session'dan CategoryID değerini al veya belirle
            int categoryId = Convert.ToInt32(Session["CategoryID"]);
            if (categoryId == 0)
            {
                // Eğer Session'da CategoryID bulunmuyorsa, default bir değer veya mantıksal bir seçim yapılabilir
                // Burada, ilk kategoriyi alabilirsiniz:
                categoryId = _categoryManager.GetList().FirstOrDefault()?.CategoryID ?? 0;
            }

            if (categoryId == 0)
            {
                // Eğer geçerli bir CategoryID bulunamazsa, bir hata sayfasına yönlendir veya bir mesaj göster
                return RedirectToAction("NewStudentText");
            }

            // Alınan StudentID ve CategoryID değerlerini studentText nesnesine ekle
            studentText.StudentID = studentId;
            studentText.CategoryID = categoryId;
            studentText.StudentTextDate = DateTime.Now;

            // StudentText tablosuna ekle
            _studentTextManager.StudentTextAdd(studentText);

            return RedirectToAction("NewStudentText");
        }
    }
}