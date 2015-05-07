using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Domain;
using OrderWala.DAL;

namespace OrderWala.Web.Controllers
{
    public class LoginController : Controller
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult ListAllLogin()
        {
            var UserRepositories = new UserRepositories();
            var returnvalue = UserRepositories.GetAllLogin();

            return View(returnvalue);
        }



        [HttpGet]
        public ActionResult Save(int id = 0)
        {
            var UserRepositories = new UserRepositories();

            getusertype();
            if (id > 0)
            {
                var UserData = UserRepositories.GetUserByUserId(id);

                return View(UserData);
            }

            tblLoginDTO login = new tblLoginDTO();
            




            return View(new tblLoginDTO());
        }


        public void getusertype()
        {
            OrderWalaEntities db = new OrderWalaEntities();


            ViewBag.user = db.tblUserTypes.ToList<tblUserType>();
        }

    }
}
