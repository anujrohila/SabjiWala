using adminsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace adminsite.Controllers
{
     [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class HomeController : Controller
    {
        private OrderManagmentEntities db = new OrderManagmentEntities();
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

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
        public string supplier()
        {
            var qry = (from c in db.TblSupplierMasters select c.SupplierID).Count();
            return qry.ToString();
        }
        public string Customer()
        {
            var qry = (from c in db.TblCustomerMasters select c.CustomerID).Count();
            return qry.ToString();
        }

        public string Employee()
        {
            var qry = (from c in db.TblEmployeeMasters select c.EmployeeID).Count();
            return qry.ToString();
        }

        public string Category()
        {
            var qry = (from c in db.TblCategoryMasters select c.CategoryID).Count();
            return qry.ToString();
        }

        public string Subcategory()
        {
            var qry = (from c in db.TblSubCategoryMasters select c.SubCategoryID).Count();
            return qry.ToString();
        }

        public string Product()
        {
            var qry = (from c in db.TblProductMasters select c.ProductID).Count();
            return qry.ToString();
        }

        public string Order()
        {
            var qry = (from c in db.TblOrderMasters select c.OrderID).Count();
            return qry.ToString();
        }

        public string User()
        {
            var qry = (from c in db.TblUserLoginMasters select c.UserID).Count();
            return qry.ToString();
        }


        public string SUPnotification()
        {
            System.DateTime date = new System.DateTime();
            int minutes = date.Minute;
            var qry = (from c in db.TblSupplierMasters where c.CreatedDateTime >= DateTime.Today.Date select c).Count();
            return qry.ToString();
        }

        public string CUStnotification()
        {
            System.DateTime date = new System.DateTime();
            int minutes = date.Minute;
            var qry = (from c in db.TblCustomerMasters where c.CreatedDateTime >= DateTime.Today.Date select c).Count();
            return qry.ToString();
        }

        public string EMPtnotification()
        {
            System.DateTime date = new System.DateTime();
            int minutes = date.Minute;
            var qry = (from c in db.TblEmployeeMasters where c.CreatedDateTime >= DateTime.Today.Date select c).Count();
            return qry.ToString();
        }


        public string CATEGORYtnotification()
        {
            System.DateTime date = new System.DateTime();
            int minutes = date.Minute;
            var qry = (from c in db.TblCategoryMasters where c.CreatedDateTime >= DateTime.Today.Date select c).Count();
            return qry.ToString();
        }

        public string SUbCATEGORYtnotification()
        {
            System.DateTime date = new System.DateTime();
            int minutes = date.Minute;
            var qry = (from c in db.TblSubCategoryMasters where c.CreatedDateTime >= DateTime.Today.Date select c).Count();
            return qry.ToString();
        }

        public string PRODUCTnotification()
        {
            System.DateTime date = new System.DateTime();
            int minutes = date.Minute;
            var qry = (from c in db.TblProductMasters where c.CreatedDateTime >= DateTime.Today.Date select c).Count();
            return qry.ToString();
        }

        public string ORDERnotification()
        {
            System.DateTime date = new System.DateTime();
            int minutes = date.Minute;
            var qry = (from c in db.TblOrderMasters where c.CreatedDateTime >= DateTime.Today.Date select c).Count();
            return qry.ToString();
        }

        public string USERnotification()
        {
            System.DateTime date = new System.DateTime();
            int minutes = date.Minute;
            var qry = (from c in db.TblUserLoginMasters where c.CreatedDateTime >= DateTime.Today.Date select c).Count();
            return qry.ToString();
        }


    }
}
