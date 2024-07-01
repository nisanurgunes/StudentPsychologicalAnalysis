using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace MvcProjectCamp.Controllers
{
    public class TextResultsController : Controller
    {
        private readonly Context _context;

        public TextResultsController()
        {
            _context = new Context();
        }

        public ActionResult TextResults(string studentSearch = "", string studentClass = "")
        {
            // Sınıf seçenekleri
            List<SelectListItem> schoolClasses = new List<SelectListItem>();
            for (int grade = 6; grade <= 8; grade++)
            {
                for (char section = 'A'; section <= 'D'; section++)
                {
                    string className = $"{grade}-{section}";
                    schoolClasses.Add(new SelectListItem { Text = className, Value = className });
                }
            }
            ViewBag.SchoolClasses = schoolClasses;

            // Öğrenci metinlerini al ve filtrele
            var studentTexts = _context.StudentTexts.Include("Student").ToList();

            if (!string.IsNullOrEmpty(studentSearch))
            {
                studentTexts = studentTexts.Where(st =>
                    st.Student.StudentName.ToLower().Contains(studentSearch.ToLower()) ||
                    st.Student.StudentSurname.ToLower().Contains(studentSearch.ToLower())).ToList();
            }

            if (!string.IsNullOrEmpty(studentClass))
            {
                studentTexts = studentTexts.Where(st => st.Student.StudentClass.Equals(studentClass, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return View(studentTexts);
        }
    }
}
