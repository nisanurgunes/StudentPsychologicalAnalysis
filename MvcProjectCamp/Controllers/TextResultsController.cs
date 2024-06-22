using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Newtonsoft.Json;

namespace MvcProjectCamp.Controllers
{
    public class TextResultsController : Controller
    {
        private readonly Context _context;

        public TextResultsController()
        {
            _context = new Context();

        }
                public ActionResult TextResults()
        {
            var studentTexts = _context.StudentTexts.ToList();
            return View(studentTexts);
        }
 
    }
}
