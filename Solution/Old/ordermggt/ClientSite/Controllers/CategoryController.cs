using ClientSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ClientSite.Controllers
{
     [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        OrderManagmentEntities db = new OrderManagmentEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Category(int id)
        {
            
            var model = new VegitableGalleryModel();
            
            model.CategoryList = db.TblCategoryMasters.Where(cat => cat.CategoryID == id).ToList();
            model.SubCategoryList = db.TblSubCategoryMasters.Where(subCategory => subCategory.CategoryID == id).ToList();
            model.ProductListing = (from product in db.TblProductMasters
                                        join sub in db.TblSubCategoryMasters on product.SubCategoryID equals sub.SubCategoryID
                                        where sub.CategoryID == id
                                        select product).ToList();
             return View(model);
            
        }
        [AllowAnonymous]
        public ActionResult getProductDetailById(string productID)
        {
            int id = Convert.ToInt32(productID);
            var product = db.TblProductMasters.Where(p => p.ProductID == id).FirstOrDefault();
            return Json(new { result = product }, JsonRequestBehavior.AllowGet);
            //  return View();


            
        }
       
       
    }
}
