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

namespace OrderWala.Web.Controllers
{
    public class CategoryController : Controller
    {

        [HttpGet]
        public ActionResult Save(int id = 0)
        {
            var CategoryRepository = new CategoryRepository();
            if (id > 0)
            {
                var categorydata = CategoryRepository.GetCAtegoryById(id);
                return View(categorydata);
            }
            return View(new tblCategoryDTO());

        }

        [HttpPost]
        public ActionResult Save(tblCategoryDTO tblcategorydto, HttpPostedFileBase file)
        {
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
                    string path = Path.Combine(Server.MapPath("~/Images/"), guid + imagename);
                    file.SaveAs(path);
                    string f1 = path.Substring(path.LastIndexOf("\\"));
                    string[] split = f1.Split('\\');
                    string newpath = split[1];
                    string imgpath = newpath.ToString();

                    tblcategorydto.Logo = imgpath.ToString();
                    var returnValue = CategoryRepository.CategorySave(tblcategorydto);


                    if (returnValue == 1)
                    {
                        ModelState.AddModelError("CategoryName", "State Name Already Exist");
                    }
                    else if (returnValue == 2)
                    {
                        ModelState.AddModelError("CategoryName", "Error");
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
                return Json(new { Success = true, Message = "Delete Succusfully!" });
            }
            return Json(new { Success = false, Message = "Delete Fail!" });

        }


        //[HttpPost, ActionName("CategoryDelete")]
        //public ActionResult CategoryDeletedata(int id)
        //{
        //    var CategoryRepository = new CategoryRepository();
        //    var returnvalue = CategoryRepository.CategoryDelete(id);

        //    return RedirectToAction("ListAllCategory", "Category");
        //}


    }
}
