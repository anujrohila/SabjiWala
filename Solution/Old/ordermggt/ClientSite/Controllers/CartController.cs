using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ClientSite.Controllers
{
     [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class CartController : Controller
    {
        //
        // GET: /Cart/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShoppingCart(itemDetails item)
        {
            Carts.CartDetails.Add(item);
            return View(item);
        }
    }
}
