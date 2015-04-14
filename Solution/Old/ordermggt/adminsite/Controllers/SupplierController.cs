using adminsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.Mvc;
using adminsite.Models.DTO;
using PagedList.Mvc;
using PagedList;
using System.Web.UI;

namespace adminsite.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class SupplierController : Controller
    {
        //
        // GET: /Supplier/
        private OrderManagmentEntities db = new OrderManagmentEntities();

        public void setdata()
        {
            ViewBag.Lang = db.TblLanguageMasters.ToList<TblLanguageMaster>();
        }



        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
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

            var emp = from s in db.TblSupplierMasters
                      select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                emp = emp.Where(s => s.SupplierName.Contains(searchString)
                                       || s.FirstName.Contains(searchString)
                                       || s.MiddleName.Contains(searchString)
                                       || s.LastName.Contains(searchString)
                                       || s.OrganizationName.Contains(searchString)
                                       || s.EmailID.Contains(searchString));
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
                    emp = emp.OrderBy(s => s.SupplierID);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(emp.ToPagedList(pageNumber, pageSize));



            //List<TblSupplierMaster> objlistdata = new List<TblSupplierMaster>();
            //objlistdata = db.TblSupplierMasters.ToList<TblSupplierMaster>();
            //return View(objlistdata);
        }

        //Create Supplier
        [HttpGet]
        public ActionResult CreateSupplier()
        {
            setdata();
            return View();
        }
        [HttpPost]
        public ActionResult CreateSupplier(TblSupplierMaster Model)
        {

            setdata();


            //  var A = db.TblSupplierMasters.Where(a => a.SupplierID.Equals(Model.supplierData.SupplierID) && a.UserID.Equals(Model.supplierData.UserID)).FirstOrDefault();
            var check = db.TblSupplierMasters.Where(h => h.EmailID.Equals(Model.EmailID) && h.OrganizationName.Equals(Model.OrganizationName)).FirstOrDefault();

            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    if (Session["UserName"] != null)
                    {

                        Model.SupplierName = Session["UserName"].ToString();
                        Model.Password = Session["Password"].ToString();
                        Model.UserID = int.Parse(Session["UserID"].ToString());
                        Model.IsActive = true;
                        Model.CreatedBy = int.Parse(Session["AdminName"].ToString());
                        Model.CreatedDateTime = DateTime.Now;
                        db.TblSupplierMasters.Add(Model);
                        db.SaveChanges();
                        ViewBag.actionmsg = "1";
                        return RedirectToAction("Index", "Supplier");

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
                ViewBag.email = check.EmailID;
                ViewBag.organization = check.OrganizationName;
                return View(Model);
            }

        }

        //Supplier detail
        public ActionResult Detail(int id)
        {
            supplierdto qry = (from supp in db.TblSupplierMasters
                               join lang in db.TblLanguageMasters on supp.LanguageID equals lang.LanguageID
                               where supp.SupplierID == id && supp.IsActive == true
                               select new supplierdto
                           {
                               suppname = supp.SupplierName,
                               password = supp.Password,
                               language = lang.Language,
                               fname = supp.FirstName,
                               mname = supp.MiddleName,
                               lname = supp.LastName,
                               emailid = supp.EmailID,
                               address = supp.Address,
                               organization = supp.OrganizationName

                           }).FirstOrDefault<supplierdto>();
            return View(qry);
        }

        //Delete Record
        public ActionResult Delete(int id)
        {
            supplierdto qry = (from supp in db.TblSupplierMasters
                               join lang in db.TblLanguageMasters on supp.LanguageID equals lang.LanguageID
                               where supp.SupplierID == id && supp.IsActive == true
                               select new supplierdto
                               {
                                   suppname = supp.SupplierName,
                                   password = supp.Password,
                                   language = lang.Language,
                                   fname = supp.FirstName,
                                   mname = supp.MiddleName,
                                   lname = supp.LastName,
                                   emailid = supp.EmailID,
                                   address = supp.Address,
                                   organization = supp.OrganizationName

                               }).FirstOrDefault<supplierdto>();
            return View(qry);
        }


        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            orderdto orderdto = new orderdto();
            orderdto.supplierData = db.TblSupplierMasters.Where(h => h.SupplierID == id).FirstOrDefault();
            orderdto.languageData = db.TblLanguageMasters.Find(orderdto.supplierData.SupplierID);
            db.TblSupplierMasters.Remove(orderdto.supplierData);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Edit Supplier Detail
        [HttpGet]
        public ActionResult Edit(int id = 0)
        {
            setdata();
            TblSupplierMaster supplier = db.TblSupplierMasters.Where(h => h.SupplierID == id).FirstOrDefault();
            return View(supplier);
        }


        [HttpPost]
        public ActionResult Edit(TblSupplierMaster sup)
        {

            setdata();
           
            var check = db.TblSupplierMasters.Where(h => h.SupplierID != sup.SupplierID && ( h.EmailID.Equals(sup.EmailID) || h.OrganizationName.Equals(sup.OrganizationName) || h.SupplierName.Equals(sup.SupplierName) )).ToList();

            if (check.Count == 0)
            {
                if (ModelState.IsValid)
                {
                    TblSupplierMaster temp = db.TblSupplierMasters.Where(h => h.SupplierID == sup.SupplierID).FirstOrDefault();
                    temp.SupplierName = sup.SupplierName;
                    temp.Password = sup.Password;
                    temp.EmailID = sup.EmailID;
                    temp.FirstName = sup.FirstName;
                    temp.MiddleName = sup.MiddleName;
                    temp.LastName = sup.LastName;
                    temp.OrganizationName = sup.OrganizationName;
                    temp.LanguageID = sup.LanguageID;
                    temp.IsActive = true;
                    temp.UpdatedBy = int.Parse(Session["AdminName"].ToString());
                    temp.UpdatedDateTime = DateTime.Now;

                    if (db.SaveChanges() > 0)
                        return RedirectToAction("Index");
                    else
                        return View(sup);
                } 
                return View(sup);
            }
            else
            {
                ViewBag.actionmsg = "0";
                //ViewBag.email = check.EmailID;
                //ViewBag.organization = check.OrganizationName;
                return View(sup);
            }

        }
    }
}
