using OrderWala.DAL;
using OrderWala.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Web;
using PagedList;
using OrderWala.Domain.Resource;


namespace OrderWala.Web.Controllers
{
    public class StateController : Controller
    {
        //
        // GET: /State/
        [HttpGet]
        public ActionResult Save(int id = 0)
        {
            var MasterRepository = new MasterRepository();
            if (id > 0)
            {
                var stateData = MasterRepository.GetStateByStateID(id);
                return View(stateData);
            }

            tblCityDTO city = new tblCityDTO();
           
            return View(new tblStateDTO());
        }

        [HttpPost]
        public ActionResult Save(tblStateDTO tblStateDTO)
        {
            if (ModelState.IsValid)
            {
                var MasterRepository = new MasterRepository();
                var returnValue = MasterRepository.StateSave(tblStateDTO);

                if (returnValue == 1)
                {
                    ModelState.AddModelError("StateName", OrderWalaResource.valDuplicateState);
                }
                else if (returnValue == 2)
                {
                    ModelState.AddModelError("StateName", OrderWalaResource.lblError);
                }
                else
                {
                    return RedirectToAction("ListAllState", "State");
                }
            }
            return View(tblStateDTO);
        }


        [HttpGet]
        public ActionResult ListAllState()
        {

            var MasterRepository = new MasterRepository();
            var returnValue = MasterRepository.GetAllState();

            return View(returnValue);

        }




        [HttpPost]
        public JsonResult StateDelete(int ID)
        {
            var MasterRepository = new MasterRepository();
            var result = MasterRepository.StateDelete(ID);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully });
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail });

        }

    }
}
