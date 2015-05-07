using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.DAL;
using OrderWala.Domain;
using OrderWala.Web;
using OrderWala.Domain.Resource;

namespace OrderWala.Web.Controllers
{
    public class LanguageController : Controller
    {
        //
        // GET: /Language/

       
        [HttpGet]
        public ActionResult Save(int id = 0)
        {
            var languageRepository = new  LanguageRepository() ;     

            if (id > 0)
            {
                var langData = languageRepository.GetLanguageById(id);
               

                return View(langData);
            }          
                  
             return View(new tblLanguageDTO());

        }


        [HttpPost]
        public ActionResult Save(tblLanguageDTO tblLangDTO)
        {
            if (ModelState.IsValid)
            {
                var LanguageRepository = new LanguageRepository();

                var returnValue = LanguageRepository.LanguageSave(tblLangDTO);

                if (returnValue == 1)
                {
                    ModelState.AddModelError("LanguageName", OrderWalaResource.valDuplicateLanguage);
                }
                else if (returnValue == 2)
                {
                    ModelState.AddModelError("LanguageName", OrderWalaResource.lblError);
                }
                else
                {
                    return RedirectToAction("ListAllLanguage", "Language");
                }
            }
            return View(tblLangDTO);
        }



        [HttpGet]
        public ActionResult ListAllLanguage()
        {

            var LanguageRepository = new LanguageRepository();
            var returnValue = LanguageRepository.GetAllLanguage();
            return View(returnValue);

        }


        [HttpPost]
        public JsonResult LanguageDelete(int ID)
        {
            var LanguageRepository = new LanguageRepository();
            var result = LanguageRepository.Languagedelete(ID);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully});
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail});

        }
    } 

}
