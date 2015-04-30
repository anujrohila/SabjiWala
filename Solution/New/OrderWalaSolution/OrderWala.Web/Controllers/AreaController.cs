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
            getcity();
            var MasterRepository = new MasterRepository();
            if (id > 0)
            {
                getstate();
                getcity();
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

        public void getcity()
        {
            OrderWalaEntities db = new OrderWalaEntities();

            ViewBag.city = db.tblCities.ToList<tblCity>();
        
        
        }


        [HttpGet]
        public ActionResult AreaDelete(int id)
        {

            var MasterRepository = new MasterRepository();
            var AreaData = MasterRepository.GetAreaByAreaId(id);
            return View(AreaData);
        }

        [HttpPost,ActionName("AreaDelete")]
        public ActionResult AreaDeleteData(int id)
        {
            var MasterRepository = new MasterRepository();
            var returnvalue = MasterRepository.AreaDelete(id);

            return RedirectToAction("ListAllArea", "Area");
            
        
        
        }

    }
}
