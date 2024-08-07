﻿using BusinessLayer.Concrete;
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
            var teacherMail = User.Identity.Name; 
            var teacherClass = tm.GetList().FirstOrDefault(t => t.TeacherMail == teacherMail)?.TeacherClass;

            if (teacherClass != null)
            {
                var matchingStudents = sm.GetList().Where(s => s.StudentClass == teacherClass)
                                                   .Select(s => new { s.StudentClass , s.StudentName, s.StudentSurname, s.StudentUserName, s.StudentImage })
                                                   .ToList();

                return Json(matchingStudents);
            }

            return Json(null);
        }

    }
}

