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
    public class AdvertiseController : Controller
    {
        //
        // GET: /Advertise/

        public ActionResult ListAllAdvertise()
        {
            var AdvertiseRepository = new AdvertiseRepository();
            var returnvalue = AdvertiseRepository.GetAllAdvertisement();
            return View(returnvalue);        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Save(int id = 0)
        {
            var AdvertiseRepository = new AdvertiseRepository();
            if (id > 0)
            {
                var AdvertiseData = AdvertiseRepository.GetAdvertiseByAdvertiseId(id);
                return View(AdvertiseData);
            }

            tblAdvertisementDTO advertise = new tblAdvertisementDTO();


            return View(new tblAdvertisementDTO());
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="tblAdvertisementDTO"></param>
        /// <returns></returns>
        [HttpPost , ActionName("Save")]
        public ActionResult Save(tblAdvertisementDTO tblAdvertisementDTO)
        {
            if (ModelState.IsValid)
            {
               
                var AdvertiseRepository = new AdvertiseRepository();
                var returnValue = AdvertiseRepository.AdvertiseSave(tblAdvertisementDTO);

                if (returnValue == 1)
                {
                    ModelState.AddModelError("AdvertisementName", OrderWalaResource.valDuplicateAdvertise);
                }
                else if (returnValue == 2)
                {
                    ModelState.AddModelError("AdvertisementName", OrderWalaResource.lblError);
                }
                else
                {
                    return RedirectToAction("ListAllAdvertise", "State");
                }
            }
            return View(tblAdvertisementDTO);
        }


       

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult AdvertiseDelete(int ID)
        {
            var AdvertiseRepository = new AdvertiseRepository();
            var result = AdvertiseRepository.AdvertiseDelete(ID);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully});
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail });
        
        }

    }
}
