using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Partial_Demo1.Controllers
{
    public class PartialController : Controller
    {
        // GET: Partial
        public ActionResult Sample1()
        {
            return View();
        }
        public ActionResult Sample2()
        {
            return View();
        }
        public ActionResult PartialViewContent()
        {
            return PartialView("_PartialView");
        }
    }
}