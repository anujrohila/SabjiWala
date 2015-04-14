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
    public class ProductController : Controller
    {
        //
        // GET: /Product/
        private OrderManagmentEntities db = new OrderManagmentEntities();

        public void setdata()
        {
            ViewBag.Cat = db.TblCategoryMasters.ToList<TblCategoryMaster>();
            ViewBag.SCat = db.TblSubCategoryMasters.ToList<TblSubCategoryMaster>();

        }

        //Index of Product
        public ActionResult ProductIndex()
        {
            List<productdto> qry = (from prod in db.TblProductMasters
                                    join cat in db.TblCategoryMasters on prod.CategoryID equals cat.CategoryID
                                    join subcat in db.TblSubCategoryMasters on prod.SubCategoryID equals subcat.SubCategoryID
                                    select new productdto
                                        {
                                            pid = prod.ProductID,
                                            cname = cat.CategoryName,
                                            sname = subcat.SubCategoryName,
                                            pname = prod.ProductName,
                                            pimage = prod.ProductImage,
                                            price = prod.ProductPrice.Value,
                                            discount = prod.ProductDiscount.Value
                                        }).ToList<productdto>();
            return View(qry);
        }

        //create a product
        [HttpGet]
        public ActionResult createProduct()
        {
            setdata();
            var categorylist = db.TblCategoryMasters.ToList();
            ViewBag.category = categorylist;
            return View();
        }

        public ActionResult subType(String Id)
        {
            if (String.IsNullOrEmpty(Id))
            {
                throw new ArgumentNullException("Id");
            }

            int id = Int32.Parse(Id);
            var Qualitylist = db.TblSubCategoryMasters.Where(i => i.CategoryID == id);
            var result = (from c in Qualitylist
                          select new
                          {
                              name = c.SubCategoryName,
                              id = c.SubCategoryID
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult createProduct(TblProductMaster obj, HttpPostedFileBase file)
        {
           // setdata();
            var categorylist = db.TblCategoryMasters.ToList();
            ViewBag.category = categorylist;

            var check = db.TblProductMasters.Where(h => h.ProductName == obj.ProductName).FirstOrDefault();

            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    string pic = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
                    string path = System.IO.Path.Combine(Server.MapPath("~/Images/Product/"), pic);
                    obj.ProductImage = pic;
                    file.SaveAs(path);

                    obj.IsActive = true;
                    obj.CreatedBy = int.Parse(Session["AdminName"].ToString());
                    obj.CreatedDateTime = DateTime.Now;
                    db.TblProductMasters.Add(obj);
                    db.SaveChanges();
                    ViewBag.actionmsg = "1";
                    return RedirectToAction("ProductIndex", "Product");
                }
                return View(obj);
            }
            else
            {
                ViewBag.actionmsg = "0";
                ViewBag.prodNAME = check.ProductName;
                return View(obj);
            }

        }

        //SubCategory detail
        public ActionResult ProductDetail(int id)
        {
            productdto qry = (from prod in db.TblProductMasters
                              join cat in db.TblCategoryMasters on prod.CategoryID equals cat.CategoryID
                              join subcat in db.TblSubCategoryMasters on prod.SubCategoryID equals subcat.SubCategoryID
                              where prod.ProductID == id && prod.IsActive == true
                              select new productdto
                              {

                                  cname = cat.CategoryName,
                                  sname = subcat.SubCategoryName,
                                  pname = prod.ProductName,
                                  pimage = prod.ProductImage,
                                  price = prod.ProductPrice.Value,
                                  discount = prod.ProductDiscount.Value
                              }).FirstOrDefault<productdto>();
            return View(qry);
        }
        //Delete Product
        public ActionResult ProductDelete(int id)
        {

            productdto qry = (from prod in db.TblProductMasters
                              join cat in db.TblCategoryMasters on prod.CategoryID equals cat.CategoryID
                              join subcat in db.TblSubCategoryMasters on prod.SubCategoryID equals subcat.SubCategoryID
                              where prod.ProductID == id && prod.IsActive == true
                              select new productdto
                              {

                                  cname = cat.CategoryName,
                                  sname = subcat.SubCategoryName,
                                  pname = prod.ProductName,
                                  pimage = prod.ProductImage,
                                  price = prod.ProductPrice.Value,
                                  discount = prod.ProductDiscount.Value
                              }).FirstOrDefault<productdto>();
            return View(qry);
        }


        [HttpPost, ActionName("ProductDelete")]
        public ActionResult DeleteConfirmed(int id)
        {
            orderdto orderdto = new orderdto();
            orderdto.productData = db.TblProductMasters.Where(h => h.ProductID == id).FirstOrDefault();
            orderdto.categoryData = db.TblCategoryMasters.Find(orderdto.productData.ProductID);
            orderdto.subcatData = db.TblSubCategoryMasters.Find(orderdto.productData.ProductID);
            db.TblProductMasters.Remove(orderdto.productData);
            db.SaveChanges();
            return RedirectToAction("ProductIndex");
        }

        // Edit Product 
        [HttpGet]
        public ActionResult ProductEdit(int id = 0)
        {
            //setdata();

            TblProductMaster pro = db.TblProductMasters.Where(h => h.ProductID == id).FirstOrDefault();
            var categorylist = db.TblCategoryMasters.ToList();
            ViewBag.category = categorylist;
            var Subcategorylist = db.TblSubCategoryMasters.ToList();
            ViewBag.subcategory = Subcategorylist;
            return View(pro);
        }


        [HttpPost]
        public ActionResult ProductEdit(TblProductMaster prod)
        {


            var categorylist = db.TblCategoryMasters.ToList();
            ViewBag.category = categorylist;
            var Subcategorylist = db.TblSubCategoryMasters.ToList();
            ViewBag.subcategory = Subcategorylist;

            TblProductMaster temp = db.TblProductMasters.Where(h => h.ProductID == prod.ProductID).FirstOrDefault();
            var check = db.TblProductMasters.Where(h => h.ProductName == prod.ProductName && h.ProductID != prod.ProductID).FirstOrDefault();

            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    temp.CategoryID = prod.CategoryID;
                    temp.SubCategoryID = prod.SubCategoryID;
                    temp.ProductName = prod.ProductName;
                    temp.ProductPrice = prod.ProductPrice;
                    temp.ProductDiscount = prod.ProductDiscount;
                    temp.IsActive = true;
                    temp.UpdatedBy = int.Parse(Session["AdminName"].ToString());
                    temp.UpdatedDateTime = DateTime.Now;

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
                            string path = System.IO.Path.Combine(Server.MapPath("~/Images/Product/"), pic);
                            temp.ProductImage = pic;
                            file.SaveAs(path);


                        }
                    }
                   

                    //string pic = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
                    //string path = System.IO.Path.Combine(Server.MapPath("~/Images/Product/"), pic);
                    //temp.ProductImage = pic;
                    //file.SaveAs(path);

                   
                    if (db.SaveChanges() > 0)
                        return RedirectToAction("ProductIndex");
                    else
                        return View(prod);
                }
                return View(prod);
            }
            else
            {
                ViewBag.actionmsg = "0";
                ViewBag.prodNAME = check.ProductName;
                return View(prod);
            }
        }
    }
}
