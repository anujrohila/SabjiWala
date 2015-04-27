using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrderWala.Web.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult ListAll()
        {
            return View();
        }

        public ActionResult Save(int id = 0)
        {
            return View();
        }

    }
}
