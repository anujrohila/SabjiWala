using OrderWala.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Web;
using OrderWala.Domain;
using OrderWala.DAL.Repositories;
using System.IO;
using OrderWala.Domain.Resource;

namespace OrderWala.Web.Controllers
{
    public class CategoryController : Controller
    {

        //public void getLanguage()
        //{
        //    OrderWalaEntities db = new OrderWalaEntities();
        //    ViewBag.Lang = db.tblLanguages.ToList<tblLanguage>();
        //}

        [HttpGet]
        public ActionResult Save(int id = 0)
        {
           // getLanguage();
            var categorydto = new tblCategoryDTO();
            var CategoryRepository = new CategoryRepository();
             var languageRepository = new LanguageRepository();
            if (id > 0)
            {
                categorydto = CategoryRepository.GetCAtegoryById(id);
                
            }
            categorydto.LanguageList = languageRepository.GetAllLanguage();
            return View(categorydto);
        }

        [HttpPost]
        public ActionResult Save(tblCategoryDTO tblcategorydto, HttpPostedFileBase file)
        {
           // getLanguage();
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    TempData["msg"] = "Please Select Image";
                }
                else
                {

                    var CategoryRepository = new CategoryRepository();
                    string imagename = Path.GetFileName(file.FileName);
                    var guid = DateTime.Now.ToString("ddmmyyyyhhmmss"); //Guid.NewGuid().ToString();
                    string path = Path.Combine(Server.MapPath("~/Images/Document/Category/"), guid + imagename);
                    file.SaveAs(path);
                    string f1 = path.Substring(path.LastIndexOf("\\"));
                    string[] split = f1.Split('\\');
                    string newpath = split[1];
                    string imgpath = newpath.ToString();
                    tblcategorydto.Logo = imgpath.ToString();

                    var returnValue = CategoryRepository.CategorySave(tblcategorydto);
                    if (returnValue == 1)
                    {
                        ModelState.AddModelError("CategoryName", OrderWalaResource.valDuplicateCategory);
                    }
                    else if (returnValue == 2)
                    {
                        ModelState.AddModelError("CategoryName", OrderWalaResource.lblError);
                    }
                    else
                    {
                        return RedirectToAction("ListAllCategory", "Category");
                    }
                }
            }
            return View(tblcategorydto);
        }

        [HttpGet]
        public ActionResult ListAllCategory()
        {
            var CategoryRepository = new CategoryRepository();
            var returnValue = CategoryRepository.GetAllCategory();
            return View(returnValue);
        }


        [HttpPost]
        public JsonResult CategoryDelete(int id = 0)
        {
            var CategoryRepository = new CategoryRepository();
            var result = CategoryRepository.CategoryDelete(id);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully});
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail});

        }
                           
    }
}
