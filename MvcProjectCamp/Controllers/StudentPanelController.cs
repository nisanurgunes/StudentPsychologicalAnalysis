using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjectCamp.Controllers
{
    public class StudentPanelController : Controller
    {
        // GET: StudentPanel

        public ActionResult StudentScreen()
        {
            return View();
        }
    }
}