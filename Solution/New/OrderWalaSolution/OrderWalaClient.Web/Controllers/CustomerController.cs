using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderWalaClient.Web.Controllers
{
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyAccount()
        {
            return View();
        }
        public ActionResult CustOrderHistory()
        {
            return View();
        }

        public ActionResult CustomerAddress()
        {
            return View();
        }
        public ActionResult AddAddress()
        {
            return View();
        }

        
        public ActionResult CustomerWishList()
        {
            return View();
        }

        public ActionResult CustomerPersonalInformation()
        {
            return View();
        }

        public ActionResult AccountLogin()
        {
            return View();
        }

    }
}
