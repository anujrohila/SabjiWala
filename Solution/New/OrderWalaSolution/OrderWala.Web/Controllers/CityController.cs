using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.DAL;
using OrderWala.Domain;
using OrderWala.Web;

namespace OrderWala.Web.Controllers
{
    public class CityController : Controller
    {
        //
        // GET: /City/

        [HttpGet]
        public ActionResult Save(int id = 0)
        {
            var MasterRepository = new MasterRepository();
            getstate();
            if (id > 0)
            {
                var citydata = MasterRepository.GetCityByCityId(id);
                
                return View(citydata);
            }

            tblSubCategoryDTO subcategory = new tblSubCategoryDTO();
            //subcategory.CitySave = MasterRepository.GetAllCity();
            //subcategory.SubCategoryId = MasterRepository.GetAllCity();
           

            return View(new tblCityDTO());

        }

        [HttpPost]
        public ActionResult Save(tblCityDTO tblcitydto)
        {
            if (ModelState.IsValid)
            {
                var MasterRepository = new MasterRepository();
                var returnValue = MasterRepository.CitySave(tblcitydto);

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
                    return RedirectToAction("ListAllCity", "City");
                }
            }
            return View(tblcitydto);
        
        }

        public void getstate()
        {

            OrderWalaEntities db = new OrderWalaEntities();


            ViewBag.state = db.tblStates.ToList<tblState>();
        
        }

        [HttpGet]
        public ActionResult ListAllCity()
        {
            var MasterRepository = new MasterRepository();
            var returnValue = MasterRepository.GetAllCity();

            return View(returnValue);
        }


        [HttpGet]
        public ActionResult CityDelete(int id)
        {

            var MasterRepository = new MasterRepository();
            var CityData = MasterRepository.GetCityByCityId(id);
            return View(CityData);
        }

        [HttpPost, ActionName("CityDelete")]
        public ActionResult CityDeleteData(int id)
        {

            var MasterRepository = new MasterRepository();
            var returnvalue = MasterRepository.citydelete(id);

            return RedirectToAction("ListAllCity", "City");
            
        
        }
    }
}
