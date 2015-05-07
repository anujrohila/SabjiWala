using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.DAL.Repositories;
using OrderWala.Domain;
using OrderWala.DAL;
using System.IO;
using OrderWala.Domain.Resource;

namespace OrderWala.Web.Controllers
{
    public class SubCategoryController : Controller
    {

        [HttpGet]
        public ActionResult ListAllSubCategory()
        {
            var SubCategoryRepository = new SubCategoryRepository();
            var returnValue = SubCategoryRepository.GetAllCategory();
            return View(returnValue);
        }

        public void getcat()
        {
            OrderWalaEntities db = new OrderWalaEntities();
            ViewBag.categorydata = db.tblCategories.ToList<tblCategory>();
        }

        [HttpGet]
        public ActionResult SubCategorySave(int id = 0)
        {

            var SubCategoryRepository = new SubCategoryRepository();

            getcat();

            if (id > 0)
            {
                var Subdata = SubCategoryRepository.GetSubCategoryById(id);
                return View(Subdata);
            }
            return View(new tblSubCategoryDTO());
        }

        [HttpPost]
        public ActionResult SubCategorySave(tblSubCategoryDTO tblSubCategoryDTO, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file == null)
                {
                    TempData["msg"] = "Please Select Image";
                }
                else
                {
                    var SubCategoryRepository = new SubCategoryRepository();

                    string imagename = Path.GetFileName(file.FileName);
                    var guid = DateTime.Now.ToString("ddmmyyyyhhmmss"); //Guid.NewGuid().ToString();
                    string path = Path.Combine(Server.MapPath("~/Images/Document/Subcategory/"), guid + imagename);
                    file.SaveAs(path);
                    string f1 = path.Substring(path.LastIndexOf("\\"));
                    string[] split = f1.Split('\\');
                    string newpath = split[1];
                    string imgpath = newpath.ToString();

                    tblSubCategoryDTO.Logo = imgpath.ToString();


                    var returnValue = SubCategoryRepository.SubCategorySavedata(tblSubCategoryDTO);

                    if (returnValue == 1)
                    {
                        ModelState.AddModelError("SubCategoryName", OrderWalaResource.valDuplicateSubCategory);
                    }
                    else if (returnValue == 2)
                    {
                        ModelState.AddModelError("SubCategoryName", OrderWalaResource.lblError);
                    }
                    else
                    {
                        return RedirectToAction("ListAllSubCategory", "SubCategory");
                    }
                }
            }
            return View(tblSubCategoryDTO);
        }


        [HttpPost]
        public JsonResult SubCategoryDelete(int id = 0)
        {
            var SubCategoryRepository = new SubCategoryRepository();
            var result = SubCategoryRepository.SubCategoryDelete(id);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully });
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail });

        }
    }
}
