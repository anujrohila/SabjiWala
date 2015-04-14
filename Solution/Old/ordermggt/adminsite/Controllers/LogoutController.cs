using adminsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace adminsite.Controllers
{
    public class LogoutController : Controller
    {
        //
        // GET: /Logout/
        private OrderManagmentEntities db = new OrderManagmentEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {

            if (Session["adminid"] != null)
            {
                Session["DisplayName"] = null;
                Session["adminid"] = null;
                Session["AdminName"] = null;
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
                Response.Cache.SetNoStore();
            }
            return View();

        }


    }
}
