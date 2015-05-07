using OrderWala.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Domain;
using OrderWala.Domain.Resource;
using System.IO;

namespace OrderWala.Web.Controllers
{
    public class ProductController : Controller
    {
        //
        // GET: /Product/

        public ActionResult Index()
        {
            return View();
        }

        public void getLanguage()
        {
            OrderWalaEntities db = new OrderWalaEntities();
            ViewBag.Lang = db.tblLanguages.ToList<tblLanguage>();
            ViewBag.QtyType = db.tblQuantityTypes.ToList<tblQuantityType>();
        }

        [HttpGet]
        public ActionResult ListAllProduct()
        {
            var ProductRepository = new ProductRepository();
            var returnValue = ProductRepository.GetAllProduct();
            return View(returnValue);
        }

        [HttpGet]
        public ActionResult ProductSave(int id = 0)
        {
            getLanguage();
            getCategory();
            var ProductRepository = new ProductRepository();
            
            if (id > 0)
            {
                getLanguage();
                getCategory();
                var ProductData = ProductRepository.GetProductById(id);
                return View(ProductData);
            }
            return View(new tblProductDTO());
        }

        [HttpPost]
        public ActionResult ProductSave(tblLanguageWiseProductDTO tblProduct, HttpPostedFileBase file)
        {
           
            getLanguage();
            getCategory();
            if (ModelState.IsValid)
            {
                var ProductRepository = new ProductRepository();

                var Product = new tblProductDTO();

                string imagename = Path.GetFileName(file.FileName);
                var guid = DateTime.Now.ToString("ddmmyyyyhhmmss"); //Guid.NewGuid().ToString();
                string path = Path.Combine(Server.MapPath("~/Images/Document/Category/"), guid + imagename);
                file.SaveAs(path);
                string f1 = path.Substring(path.LastIndexOf("\\"));
                string[] split = f1.Split('\\');
                string newpath = split[1];
                string imgpath = newpath.ToString();

                Product.Logo = imgpath.ToString();

                var returnValue = ProductRepository.ProductSave(tblProduct);

                if (returnValue == 1)
                {
                    ModelState.AddModelError("ProductName", OrderWalaResource.valDuplicateProduct);
                }
                else if (returnValue == 2)
                {
                    ModelState.AddModelError("ProductName", OrderWalaResource.lblError);
                }
                else
                {
                    return RedirectToAction("ListAllProduct", "Product");
                }
            }
            return View(tblProduct);
        }



        public void getCategory()
        {
            OrderWalaEntities db = new OrderWalaEntities();                    
            ViewBag.Category = db.tblCategories.ToList<tblCategory>();
           
        }

        public JsonResult getSubCategory(int Id)
        {
            OrderWalaEntities db = new OrderWalaEntities();                                  

            var Qualitylist = db.tblSubCategories.Where(i => i.CategoryId == Id);
            var result = (from s in Qualitylist
                          select new
                          {
                             //SubCategoryName = s.SubCategoryName,
                             SubCategoryId = s.SubCategoryId
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);



        }
    }
}
