using OrderWala.DAL;
using OrderWala.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Web;
using PagedList;


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
            city.StateList = MasterRepository.GetAllState();
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
                    ModelState.AddModelError("StateName", "State Name Already Exist");
                }
                else if (returnValue == 2)
                {
                    ModelState.AddModelError("StateName", "Error");
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
                return Json(new { Success = true, Message = "Delete Succusfully!" });
            }
            return Json(new { Success = false, Message = "Delete Fail!" });

        }

    }
}
