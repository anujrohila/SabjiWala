using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ClientSite.Controllers
{
     [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class CustomerCheckOutController : Controller
    {
        //
        // GET: /CustomerCheckOut/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustAddress()
        {
            return View();
        }
        public ActionResult CustBilling()
        {
            return View();
        }
        public ActionResult CustShipping()
        {
            return View();
        }
        public ActionResult CustPayment()
        {
            return View();
        }
        public ActionResult CustOrder()
        {
            return View();
        }
    }
}
