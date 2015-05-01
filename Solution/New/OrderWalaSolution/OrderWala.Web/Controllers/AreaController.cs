using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Domain;
using OrderWala.DAL;
using OrderWala.Web;

namespace OrderWala.Web.Controllers
{
    public class AreaController : Controller
    {
        //
        // GET: /Area/

        [HttpGet]
        public ActionResult ListAllArea()
        {
            var MasterRepository = new MasterRepository();
            var returnValue = MasterRepository.GetAllArea();

            return View(returnValue);
        
        
        }

        [HttpGet]
        public ActionResult Save( int id = 0)
        {
            getstate();
           
            var MasterRepository = new MasterRepository();
            if (id > 0)
            {
                getstate();
                var Areadata = MasterRepository.GetAreaByAreaId(id);

                return View(Areadata);
            }

            tblAreaDTO area = new tblAreaDTO();
            //subcategory.CitySave = MasterRepository.GetAllCity();
            //subcategory.SubCategoryId = MasterRepository.GetAllCity();


            return View(new tblAreaDTO());
        
        }

        [HttpPost,ActionName("Save")]
        public ActionResult Save(tblAreaDTO tblareadto)
        {
            if (ModelState.IsValid)
            {
                var MasterRepository = new MasterRepository();
                var returnValue = MasterRepository.AreaSave(tblareadto);

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
                    return RedirectToAction("ListAllArea", "Area");
                }
            }
            return View(tblareadto);
        }

        public void getstate()
        {

            OrderWalaEntities db = new OrderWalaEntities();
            ViewBag.state = db.tblStates.ToList<tblState>();
        }

        public JsonResult getcity(int Id)
        {
            OrderWalaEntities db = new OrderWalaEntities();

            //var MasterRepository = new MasterRepository();

            var Qualitylist = db.tblCities.Where(i => i.StateId == Id);
            var result = (from s in Qualitylist
                          select new
                          {
                              CityName = s.CityName,
                              CityId = s.CityId
                          }).ToList()
;

            return Json(result, JsonRequestBehavior.AllowGet);

            
        
        }


       

        [HttpPost]
        public JsonResult AreaDelete(int ID)
        {
            var MasterRepository = new MasterRepository();
            var result = MasterRepository.AreaDelete(ID);
            if (result == true)
            {
                return Json(new { Success = true, Message = "Delete Succusfully!" });
            }
            return Json(new { Success = false, Message = "Delete Fail!" });



        
        }

    }
}
