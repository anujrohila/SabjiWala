using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderWalaClient.Web.Controllers
{
    public class CustomerCheckOutController : Controller
    {
        //
        // GET: /CustomerCheckOut/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerShipping()
        {
            return View();
        }
        public ActionResult CustomerPayment()
        {
            return View();
        }
        public ActionResult CustomerOrder()
        {
            return View();
        }
    }
}
