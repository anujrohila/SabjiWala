using adminsite.Models;
using adminsite.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace adminsite.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class UserLoginController : Controller
    {
        //
        // GET: /UserLogin/
        private OrderManagmentEntities db = new OrderManagmentEntities();

        public void setData()
        {
            ViewBag.type = db.TblTypeMasters.ToList<TblTypeMaster>();

        }

        public ActionResult Index()
        {
            return View();
        }



        // [HttpGet]
        //public ActionResult Userlogin()
        //{
        //    setData();
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Userlogin(TblUserLoginMaster Model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        setData();

        //        db.TblUserLoginMasters.Add(Model);
        //        db.SaveChanges();



        //        if (Model.TypeID == 1)
        //        {
        //            Session["UserName"] = Model.UserName;
        //            Session["Password"] = Model.Password;
        //            Session["UserID"] = Model.UserID;

        //        }
        //        else if (Model.TypeID == 2)
        //        {
        //            Session["UserName"] = Model.UserName;
        //            Session["Password"] = Model.Password;
        //            Session["UserID"] = Model.UserID;
        //            return RedirectToAction("CreateCustomer", "Customer");
        //        }
        //        else
        //        {
        //            return View(Model);
        //        }

        //    }
        //    return RedirectToAction("CreateSupplier", "Supplier");    
        //}


        [HttpGet]
        public ActionResult UserReg()
        {
            setData();
            return View();
        }
        [HttpPost]
        public ActionResult UserReg(TblUserLoginMaster Model)
        {
            setData();
            var check = db.TblUserLoginMasters.Where(h => h.UserName == Model.UserName).FirstOrDefault();

            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    Model.IsActive = true;
                    Model.CreatedBy = int.Parse(Session["AdminName"].ToString());
                    Model.CreatedDateTime = DateTime.Now;
                    db.TblUserLoginMasters.Add(Model);
                    db.SaveChanges();
                    ViewBag.actionmsg = "1";
                    if (Model.TypeID == 1)
                    {
                        Session["UserName"] = Model.UserName;
                        Session["Password"] = Model.Password;
                        Session["UserID"] = Model.UserID;
                        return RedirectToAction("CreateSupplier", "Supplier");
                    }
                    else if (Model.TypeID == 2)
                    {
                        Session["UserName"] = Model.UserName;
                        Session["Password"] = Model.Password;
                        Session["UserID"] = Model.UserID;
                        return RedirectToAction("CreateCustomer", "Customer");
                    }
                    else
                    {
                        return View(Model);
                    }
                }
                return View(Model);
            }
            else
            {
                ViewBag.actionmsg = "0";
                ViewBag.userNAME = check.UserName;
                return View(Model);
            }

        }





    }
}
