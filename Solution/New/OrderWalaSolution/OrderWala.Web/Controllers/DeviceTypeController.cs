using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Domain;
using OrderWala.Web;
using OrderWala.DAL;
using OrderWala.DAL.Repositories;
using OrderWala.Domain.Resource;


namespace OrderWala.Web.Controllers
{
    public class DeviceTypeController : Controller
    {
        [HttpGet]
        public ActionResult ListAllDeviceType()
        {
          var DeviceRepository = new DeviceRepository();
          var returnValue = DeviceRepository.GetAllDevice();
          return View(returnValue);

        }

        [HttpGet]
        public ActionResult DeviceSave(int id=0)
        {
            var DeviceRepository = new DeviceRepository();
            if (id > 0)
            {
                var devicedata = DeviceRepository.GetDeviceByDeviceId(id);
                return View(devicedata);
            }
            return View(new tblDeviceTypeDTO());
        }

        [HttpPost]
        public ActionResult DeviceSave(tblDeviceTypeDTO tbldevicetypedto)
        {
            if (ModelState.IsValid)
            {
                var DeviceRepository = new DeviceRepository();
                var returnValue = DeviceRepository.DeviceSave(tbldevicetypedto);

                if (returnValue == 1)
                {
                    ModelState.AddModelError("DeviceType", OrderWalaResource.valDuplicateDeviceName);
                }
                else if (returnValue == 2)
                {
                    ModelState.AddModelError("DeviceType", OrderWalaResource.lblError);
                }
                else
                {
                    return RedirectToAction("ListAllDeviceType", "DeviceType");
                }
            }
            return View(tbldevicetypedto);
        }


      


        [HttpPost]
        public JsonResult DeviceDelete(int id)
        {
            var DeviceRepository = new DeviceRepository();
            var returnvalue = DeviceRepository.DeviceDelete(id);
            if (returnvalue == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully });
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail});
        }


    }
}
