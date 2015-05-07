using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Domain;
using OrderWala.DAL;
using OrderWala.Domain.Resource;

namespace OrderWala.Web.Controllers
{
    public class DeliveryChargeController : Controller
    {
        [HttpGet]
        public ActionResult ListAllDeliveryCharge()
        {
            var DelieryChargeRepository = new DeliveryChargeRepository();
            var returnValue = DelieryChargeRepository.GetAllDeliveryCharge();
            return View(returnValue);
        }

        [HttpGet]
        public ActionResult DeliveryChargeSave(int id = 0)
        {
            var DeliveryChargeRepository = new DeliveryChargeRepository();
            if (id > 0)
            {
                var devicedata = DeliveryChargeRepository.GetDeliveryById(id);
                return View(devicedata);
            }
            return View(new tblDeliveryChargeDTO());
        }

        [HttpPost]
        public ActionResult DeliveryChargeSave(tblDeliveryChargeDTO tbldeliverychargedto)
        {
            if (ModelState.IsValid)
            {
                var DeliveryChargeRepository = new DeliveryChargeRepository();
                var returnValue = DeliveryChargeRepository.DeliveryChargeSave(tbldeliverychargedto);

                if (returnValue == 1)
                {
                    ModelState.AddModelError("DeviceType", "State Name Already Exist");
                }
                else if (returnValue == 2)
                {
                    ModelState.AddModelError("DeliveryCharge", OrderWalaResource.lblError);
                }
                else
                {
                    return RedirectToAction("ListAllDeliveryCharge", "DeliveryCharge");
                }
            }
            return View(tbldeliverychargedto);
        }

        [HttpPost]
        public JsonResult DeliveryChargeDeletedata(int id = 0)
        {
            var DeliveryChargeRepository = new DeliveryChargeRepository();
            var result = DeliveryChargeRepository.DeliveryChargeDeletedata(id);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully });
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail});
        }


        //[HttpPost, ActionName("DeliveryChargeDelete")]
        //public ActionResult DeliveryChargeDeletedata(int id)
        //{
        //    var DeliveryChargeRepository = new DeliveryChargeRepository();
        //    var returnvalue = DeliveryChargeRepository.DeleveryChargeDelete(id);

        //    return RedirectToAction("ListAllDeliveryCharge", "DeliveryCharge");
        //}

    }
}
