using Microsoft.Office.Interop.Outlook;
using MvcProjectCamp.Graphics;
using MvcProjectCamp.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class ChartController : Controller
    {
        // GET: Chart
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult StudentChart()
        {
            return Json(StudentList(), JsonRequestBehavior.AllowGet);
        }

        public List<StudentsGraphics> StudentList()
        {
            List<StudentsGraphics> sg = new List<StudentsGraphics>();
            sg.Add(new StudentsGraphics()
            {
                StudentClass = "8-A",
                StudentCount = 10
            });
            sg.Add(new StudentsGraphics()
            {
                StudentClass = "8-B",
                StudentCount = 10
            });
            sg.Add(new StudentsGraphics()
            {
                StudentClass = "8-C",
                StudentCount = 10
            });
            sg.Add(new StudentsGraphics()
            {
                StudentClass = "Spor",
                StudentCount = 10
            });
            return sg;
        }
    }
}