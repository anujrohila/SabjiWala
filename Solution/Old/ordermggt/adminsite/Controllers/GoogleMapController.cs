using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace adminsite.Controllers
{
     [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class GoogleMapController : Controller
    {
        //
        // GET: /GoogleMap/

        public ActionResult googlemap()
        {
            return View();
        }

    }
}
