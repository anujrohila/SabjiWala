using ClientSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ClientSite.Controllers
{
     [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class HomeController : Controller
    {
        OrderManagmentEntities db = new OrderManagmentEntities();

        public ActionResult Index()
        {
          //  ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            ViewBag.product = db.TblProductMasters.ToList();


            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult AboutUs()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }
        public ActionResult TermCondition()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        [AllowAnonymous]
        public ActionResult getProductDetailById(string productID)
        {
            int id = Convert.ToInt32(productID);
            var product = db.TblProductMasters.Where(p => p.ProductID == id).FirstOrDefault();
            return Json(new { result = product }, JsonRequestBehavior.AllowGet);
            //  return View();
        }
       
    }
}
