using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace adminsite.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class CalenderController : Controller
    {
        //
        // GET: /Calender/

        public ActionResult calender1()
        {
            return View();
        }

    }
}
