using adminsite.Models;
using adminsite.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Web.UI;

namespace adminsite.Controllers
{
     [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class CustomerController : Controller
    {
        //
        // GET: /Customer/
        private OrderManagmentEntities db = new OrderManagmentEntities();

        public void setdata()
        {
            ViewBag.Lang = db.TblLanguageMasters.ToList<TblLanguageMaster>();
        }
        // Create Index of customer
        public ActionResult CustomerIndex(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var emp = from s in db.TblCustomerMasters
                      select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                emp = emp.Where(s => s.CustomerName.Contains(searchString)
                                       || s.FirstName.Contains(searchString)
                                       || s.MiddleName.Contains(searchString)
                                       || s.LastName.Contains(searchString)
                                       || s.EmailId.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    emp = emp.OrderByDescending(s => s.MiddleName);
                    break;
                case "Date":
                    emp = emp.OrderBy(s => s.MiddleName);
                    break;
                case "date_desc":
                    emp = emp.OrderByDescending(s => s.MiddleName);
                    break;
                default:  // Name ascending 
                    emp = emp.OrderBy(s => s.CustomerID);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(emp.ToPagedList(pageNumber, pageSize));

            //List<TblCustomerMaster> objlistdata = new List<TblCustomerMaster>();
            //objlistdata = db.TblCustomerMasters.ToList<TblCustomerMaster>();
            //return View(objlistdata);
        }


        //Create Customer
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            setdata();
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(TblCustomerMaster Model)
        {

            setdata();
            var check = db.TblCustomerMasters.Where(h => h.EmailId == Model.EmailId).FirstOrDefault();

            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    if (Session["UserName"] != null)
                    {

                        Model.CustomerName = Session["UserName"].ToString();
                        Model.Password = Session["Password"].ToString();
                        Model.UserID = int.Parse(Session["UserID"].ToString());
                        Model.IsActive = true;
                        Model.CreatedBy = int.Parse(Session["AdminName"].ToString());
                        Model.CreatedDateTime = DateTime.Now;
                        db.TblCustomerMasters.Add(Model);
                        db.SaveChanges();
                        ViewBag.actionmsg = "1";
                        return RedirectToAction("CustomerIndex", "Customer");
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
                ViewBag.email = check.EmailId;
                return View(Model);
            }
        }

        //Customer detail
        public ActionResult CustomerDetail(int id)
        {
            custdto qry = (from cust in db.TblCustomerMasters
                           join lang in db.TblLanguageMasters on cust.LanguageID equals lang.LanguageID
                           where cust.CustomerID == id && cust.IsActive == true
                           select new custdto
                               {
                                   //  custid = cust.CustomerID,
                                   password = cust.Password,
                                   custname = cust.CustomerName,
                                   language = lang.Language,
                                   fname = cust.FirstName,
                                   mname = cust.MiddleName,
                                   lname = cust.LastName,
                                   emailid = cust.EmailId,
                                   displayname = cust.DisplayName

                               }).FirstOrDefault<custdto>();
            return View(qry);
        }

        //Delete Record
        public ActionResult CustomerDelete(int id)
        {
            custdto qry = (from cust in db.TblCustomerMasters
                           join lang in db.TblLanguageMasters on cust.LanguageID equals lang.LanguageID
                           where cust.CustomerID == id && cust.IsActive == true
                           select new custdto
                           {
                               // custid = cust.CustomerID,
                               password = cust.Password,
                               custname = cust.CustomerName,
                               language = lang.Language,
                               fname = cust.FirstName,
                               mname = cust.MiddleName,
                               lname = cust.LastName,
                               emailid = cust.EmailId,
                               displayname = cust.DisplayName

                           }).FirstOrDefault<custdto>();
            return View(qry);
        }


        [HttpPost, ActionName("CustomerDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            orderdto orderdto = new orderdto();
            orderdto.customerData = db.TblCustomerMasters.Where(h => h.CustomerID == id).FirstOrDefault();
            orderdto.languageData = db.TblLanguageMasters.Find(orderdto.customerData.CustomerID);
            db.TblCustomerMasters.Remove(orderdto.customerData);
            db.SaveChanges();
            return RedirectToAction("CustomerIndex");
        }


        //Edit Customer Detail
        [HttpGet]
        public ActionResult CustomerEdit(int id = 0)
        {
            setdata();
            TblCustomerMaster customer = db.TblCustomerMasters.Where(h => h.CustomerID == id).FirstOrDefault();
            return View(customer);
        }


        [HttpPost]
        public ActionResult CustomerEdit(TblCustomerMaster cust)
        {
            setdata();
                                  
            var check = db.TblCustomerMasters.Where(h =>  h.CustomerID != cust.CustomerID &&( h.EmailId == cust.EmailId || h.CustomerName == cust.CustomerName)).ToList();

            if (check.Count == 0)
            {
                if (ModelState.IsValid)
                {
                    TblCustomerMaster temp = db.TblCustomerMasters.Where(h => h.CustomerID == cust.CustomerID).FirstOrDefault();
                    temp.CustomerName = cust.CustomerName;
                    temp.DisplayName = cust.DisplayName;
                    temp.Password = cust.Password;
                    temp.FirstName = cust.FirstName;
                    temp.MiddleName = cust.MiddleName;
                    temp.LastName = cust.LastName;
                    temp.EmailId = cust.EmailId;
                    temp.LanguageID = cust.LanguageID;
                    temp.IsActive = true;
                    temp.UpdatedBy = int.Parse(Session["AdminName"].ToString());
                    temp.UpdatedDateTime = DateTime.Now;

                    if (db.SaveChanges() > 0)
                        return RedirectToAction("CustomerIndex");
                    else
                        return View(cust);
                }
                return View(cust);
            }
            else
            {
                ViewBag.actionmsg = "0";
               // ViewBag.email = check.EmailId;
                return View(cust);
            }
        }
    }
}
