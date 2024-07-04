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
            _context.Configuration.LazyLoadingEnabled = false; 
        }

        public ActionResult TextResults(string studentSearch = "", string studentClass = "", string selectedDate = "")
        {
            // Sınıf seçenekleri
            List<SelectListItem> schoolClasses = new List<SelectListItem>
            {
                new SelectListItem { Text = "Tüm Sınıflar", Value = "" }
            };

            for (int grade = 6; grade <= 8; grade++)
            {
                for (char section = 'A'; section <= 'D'; section++)
                {
                    string className = $"{grade}-{section}";
                    schoolClasses.Add(new SelectListItem { Text = className, Value = className });
                }
            }

            ViewBag.SchoolClasses = schoolClasses;

            
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

            if (!string.IsNullOrEmpty(selectedDate))
            {
                DateTime selectedDateTime;
                if (DateTime.TryParse(selectedDate, out selectedDateTime))
                {
                    studentTexts = studentTexts.Where(st => st.StudentTextDate.Date == selectedDateTime.Date).ToList();
                }
                else
                {
                    
                    ModelState.AddModelError("selectedDate", "Geçersiz tarih formatı.");
                }
            }

            
            var dates = studentTexts.Select(st => st.StudentTextDate.Date).Distinct().OrderBy(date => date).ToList();
            var dateSelectList = dates.Select(date => new SelectListItem
            {
                Text = date.ToString("dd-MMM-yyyy"),
                Value = date.ToString("yyyy-MM-dd")
            }).ToList();

            ViewBag.Dates = new SelectList(dateSelectList, "Value", "Text");

            return View(studentTexts);
        }
    }
}
