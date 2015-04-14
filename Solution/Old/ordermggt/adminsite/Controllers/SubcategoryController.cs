using adminsite.Models;
using adminsite.Models.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace adminsite.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class SubcategoryController : Controller
    {
        //
        // GET: /Subcategory/
        private OrderManagmentEntities db = new OrderManagmentEntities();

        public void setdata()
        {
            ViewBag.Cat = db.TblCategoryMasters.ToList<TblCategoryMaster>();
        }

        //View Index Of Subcategory 
        public ActionResult SubcategoryIndex()
        {
            List<subcategorydto> qry = (from subcat in db.TblSubCategoryMasters
                                        join cat in db.TblCategoryMasters on subcat.CategoryID equals cat.CategoryID
                                        select new subcategorydto
                                        {
                                            sid = subcat.SubCategoryID,
                                            cname = cat.CategoryName,
                                            sname = subcat.SubCategoryName,
                                            simage = subcat.SubCategoryImage
                                        }).ToList<subcategorydto>();
            return View(qry);
        }

        //Create Subcategory

        public ActionResult createSubcategory()
        {
            setdata();
            return View();
        }




        [HttpPost]
        public ActionResult createSubcategory(TblSubCategoryMaster Model, HttpPostedFileBase file)
        {

            setdata();
            var check = db.TblSubCategoryMasters.Where(h => h.SubCategoryName == Model.SubCategoryName).FirstOrDefault();

            if (check == null)
            {
                if (ModelState.IsValid)
                {


                    string pic = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/Subcategory/"), pic);
                    Model.SubCategoryImage = pic;
                    file.SaveAs(path);

                    Model.IsActive = true;
                    Model.CreatedBy = int.Parse(Session["AdminName"].ToString());
                    Model.CreatedDateTime = DateTime.Now;
                    db.TblSubCategoryMasters.Add(Model);
                    db.SaveChanges();
                    ViewBag.actionmsg = "1";
                    return RedirectToAction("SubcategoryIndex", "Subcategory");
                }
                return View(Model);
            }
            else
            {
                ViewBag.actionmsg = "0";
                ViewBag.subcatNAME = check.SubCategoryName;
                return View(Model);
            }

        }

        //SubCategory detail
        public ActionResult SubcategoryDetail(int id)
        {
            subcategorydto qry = (from subcat in db.TblSubCategoryMasters
                                  join cat in db.TblCategoryMasters on subcat.CategoryID equals cat.CategoryID
                                  where subcat.SubCategoryID == id && subcat.IsActive == true
                                  select new subcategorydto
                                  {
                                      sid = subcat.SubCategoryID,
                                      cname = cat.CategoryName,
                                      sname = subcat.SubCategoryName,
                                      simage = subcat.SubCategoryImage
                                  }).FirstOrDefault<subcategorydto>();

            return View(qry);
        }

        //Delete SubCategory
        public ActionResult SubcategoryDelete(int id)
        {
            subcategorydto qry = (from subcat in db.TblSubCategoryMasters
                                  join cat in db.TblCategoryMasters on subcat.CategoryID equals cat.CategoryID
                                  where subcat.SubCategoryID == id && subcat.IsActive == true
                                  select new subcategorydto
                                  {
                                      sid = subcat.SubCategoryID,
                                      cname = cat.CategoryName,
                                      sname = subcat.SubCategoryName,
                                      simage = subcat.SubCategoryImage
                                  }).FirstOrDefault<subcategorydto>();


            return View(qry);

        }


        [HttpPost, ActionName("SubcategoryDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            orderdto orderdto = new orderdto();
            orderdto.subcatData = db.TblSubCategoryMasters.Where(h => h.SubCategoryID == id).FirstOrDefault();
            orderdto.categoryData = db.TblCategoryMasters.Find(orderdto.subcatData.SubCategoryID);
            db.TblSubCategoryMasters.Remove(orderdto.subcatData);
            db.SaveChanges();
            return RedirectToAction("SubcategoryIndex");
        }


        // Edit Subcategory 
        [HttpGet]
        public ActionResult SubcategoryEdit(int id = 0)
        {
            setdata();

            TblSubCategoryMaster subcatData = db.TblSubCategoryMasters.Where(h => h.SubCategoryID == id).FirstOrDefault();
            return View(subcatData);
        }


        [HttpPost]
        public ActionResult SubcategoryEdit(TblSubCategoryMaster scate)
        {

            setdata();

            TblSubCategoryMaster temp = db.TblSubCategoryMasters.Where(h => h.SubCategoryID == scate.SubCategoryID).FirstOrDefault();
            var check = db.TblSubCategoryMasters.Where(h => h.SubCategoryName == scate.SubCategoryName && h.SubCategoryID != scate.SubCategoryID).FirstOrDefault();
            if (check == null)
            {
                if (ModelState.IsValid)
                {

                    temp.SubCategoryName = scate.SubCategoryName;
                    temp.CategoryID = scate.CategoryID;
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
                            string path = System.IO.Path.Combine(Server.MapPath("~/Images/Subcategory/"), pic);
                            temp.SubCategoryImage = pic;
                            file.SaveAs(path);
                            
                        }
                    }
                    

                    //string pic = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
                    //string path = System.IO.Path.Combine(Server.MapPath("~/Images/Subcategory/"), pic);
                    //temp.SubCategoryImage = pic;
                    //file.SaveAs(path);

                    if (db.SaveChanges() > 0)
                        return RedirectToAction("SubcategoryIndex");
                    else
                        return View(scate);
                }
                return View(scate);
            }
            else
            {
                ViewBag.actionmsg = "0";
                ViewBag.subcatNAME = check.SubCategoryName;
                return View(scate);
            }
        }
    }
}