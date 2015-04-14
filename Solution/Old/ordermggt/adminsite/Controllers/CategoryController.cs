using adminsite.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
using System.Web.UI;

namespace adminsite.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        private OrderManagmentEntities db = new OrderManagmentEntities();

        public ActionResult CategoryIndex(string sortOrder, string currentFilter, string searchString, int? page)
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

            var emp = from s in db.TblCategoryMasters
                      select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                emp = emp.Where(s => s.CategoryName.Contains(searchString)
                                       || s.CategoryImage.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    emp = emp.OrderByDescending(s => s.CategoryName);
                    break;
                case "Date":
                    emp = emp.OrderBy(s => s.CategoryName);
                    break;
                case "date_desc":
                    emp = emp.OrderByDescending(s => s.CategoryName);
                    break;
                default:  // Name ascending 
                    emp = emp.OrderBy(s => s.CategoryID);
                    break;
            }

            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(emp.ToPagedList(pageNumber, pageSize));


            //List<TblCategoryMaster> objlistdata = new List<TblCategoryMaster>();
            //objlistdata = db.TblCategoryMasters.ToList<TblCategoryMaster>();
            //return View(objlistdata);
        }



        [HttpGet]
        public ActionResult CreateCategory()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateCategory(TblCategoryMaster Model, HttpPostedFileBase file)
        {

            var catcheck = db.TblCategoryMasters.Where(h => h.CategoryName == Model.CategoryName).FirstOrDefault();

            if (catcheck == null)
            {
                if (ModelState.IsValid)
                {
                    string pic = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/Category/"), pic);
                    Model.CategoryImage = pic;
                    file.SaveAs(path);

                    Model.IsActive = true;
                    Model.CreatedBy = int.Parse(Session["AdminName"].ToString());
                    Model.CreatedDateTime = DateTime.Now;
                    db.TblCategoryMasters.Add(Model);
                    db.SaveChanges();
                    ViewBag.actionmsg = "1";
                    return RedirectToAction("CategoryIndex", "Category");
                }
                return View(Model);
            }
            else
            {

                ViewBag.actionmsg = "0";
                ViewBag.catNAME = catcheck.CategoryName;
                return View(Model);
            }

        }

        //Category detail
        public ActionResult CategoryDetail(int id)
        {
            TblCategoryMaster cat = db.TblCategoryMasters.Where(h => h.CategoryID == id).FirstOrDefault();
            cat.IsActive = true;
            return View(cat);
        }

        //Delete Category
        public ActionResult CategoryDelete(int id)
        {

            TblCategoryMaster cat = db.TblCategoryMasters.Where(h => h.CategoryID == id).FirstOrDefault();
            cat.IsActive = true;
            return View(cat);
        }


        [HttpPost, ActionName("CategoryDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            TblCategoryMaster cat = db.TblCategoryMasters.Where(h => h.CategoryID == id).FirstOrDefault();
            db.TblCategoryMasters.Remove(cat);
            db.SaveChanges();
            return RedirectToAction("CategoryIndex");
        }

        // Edit category 
        [HttpGet]
        public ActionResult CategoryEdit(int id = 0)
        {


            TblCategoryMaster cat = db.TblCategoryMasters.Where(h => h.CategoryID == id).FirstOrDefault();
            return View(cat);
        }


        [HttpPost]
        public ActionResult CategoryEdit(TblCategoryMaster cate)
        {
            TblCategoryMaster temp = db.TblCategoryMasters.Where(h => h.CategoryID == cate.CategoryID).FirstOrDefault();
            var catcheck = db.TblCategoryMasters.Where(h => h.CategoryName == cate.CategoryName && h.CategoryID != cate.CategoryID).FirstOrDefault();

            if (catcheck == null)
            {
                if (ModelState.IsValid)
                {

                    temp.CategoryName = cate.CategoryName;
                    temp.UpdatedBy = int.Parse(Session["AdminName"].ToString());
                    temp.UpdatedDateTime = DateTime.Now;
                    temp.IsActive = true;
                    if (Request.Files.Count > 0)
                    {
                        var file = Request.Files[0];
                        if (file.FileName == "")
                        {
                            //
 
                        }
                        else
                        {
                            string pic = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
                            string path = System.IO.Path.Combine(Server.MapPath("~/Images/Category/"), pic);
                            temp.CategoryImage = pic;
                            file.SaveAs(path);

                        }
                    }
                    //string pic = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
                    //string path = System.IO.Path.Combine(Server.MapPath("~/Images/Category/"), pic);
                    //temp.CategoryImage = pic;
                    //file.SaveAs(path);

                    ViewBag.actionmsg = "1";
                    if (db.SaveChanges() > 0)
                        return RedirectToAction("CategoryIndex");
                    else
                        return View(cate);
                }
                return View(cate);
            }
            else
            {

                ViewBag.actionmsg = "0";
                ViewBag.catNAME = catcheck.CategoryName;
                return View(cate);
            }
        }

    }
}
