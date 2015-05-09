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
            var tblProductDTO = new tblProductDTO();
            var productRepository = new ProductRepository();
            var categoryRepository = new CategoryRepository();
            var languageRepository = new LanguageRepository();
            if (id > 0)
            {
               tblProductDTO = productRepository.GetProductById(id);
            }
            tblProductDTO.categorylist = categoryRepository.GetAllCategory();
            tblProductDTO.LanguageList = languageRepository.GetAllLanguage();
            tblProductDTO.QunatityList = languageRepository.GetAllQuantity();
            return View(tblProductDTO);
        }

        [HttpPost]
        public ActionResult ProductSave(tblProductDTO tblProduct, HttpPostedFileBase file)
        {          
           if (ModelState.IsValid)
            {
                if (file == null)
                {
                    TempData["msg"] = "Please Select Image";
                }
                else
                {
                    var ProductRepository = new ProductRepository();
                    string imagename = Path.GetFileName(file.FileName);
                    var guid = DateTime.Now.ToString("ddmmyyyyhhmmss"); //Guid.NewGuid().ToString();
                    string path = Path.Combine(Server.MapPath("~/Images/Document/Product/"), guid + imagename);
                    file.SaveAs(path);
                    string f1 = path.Substring(path.LastIndexOf("\\"));
                    string[] split = f1.Split('\\');
                    string newpath = split[1];
                    string imgpath = newpath.ToString();

                    tblProduct.Logo = imgpath.ToString();

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
            }
            return View(tblProduct);
        }
              

        public JsonResult getSubCategory(int mainCategoryId)
        {
            //var subcate = db.tblSubCategories.Where(i => i.CategoryId == mainCategoryId).FirstOrDefault();
            //var Qualitylist = db.tblLanguageWiseSubCategories.Where(q => q.SubCategoryId == subcate.SubCategoryId );
            //var result = (from s in Qualitylist
            //               select new  tblSubCategoryDTO
            //              {
            //                 SubCategoryName = s.SubCategoryName,
            //                 SubCategoryId = s.SubCategoryId
                            
            //              }).ToList();
            var masterRepository = new MasterRepository();
            var result = masterRepository.GetProductSubCategoryList(mainCategoryId, 1);
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        

        [HttpPost]
        public JsonResult ProductDelete(int id = 0)
        {
            var ProductRepository = new ProductRepository();
            var result = ProductRepository.ProductDelete(id);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully });
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail });

        }
    }
}
