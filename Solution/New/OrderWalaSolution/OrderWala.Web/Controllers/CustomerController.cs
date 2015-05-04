using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.DAL;
using OrderWala.Domain;

namespace OrderWala.Web.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult ListAllCustomer()
        {
            var CustomerRepository = new CustomerRepository();
            var returnValue = CustomerRepository.GetAllCustomer();
            return View(returnValue);
        }

        public void getArea()
        {
            OrderWalaEntities db = new OrderWalaEntities();
            ViewBag.Area = db.tblAreas.ToList<tblArea>();
        }

        [HttpGet]
        public ActionResult CustomerSave(int id = 0)
        {
            var CustomerRepository = new CustomerRepository();
            getArea();
            if (id > 0)
            {
                var Customerdata = CustomerRepository.GetCustomerById(id);
                return View(Customerdata);
            }
            return View(new tblCustomerDTO());
        }

        [HttpPost]
        public ActionResult CustomerSave(tblCustomerDTO tblCustomerDTO)
        {
            getArea();
            if (ModelState.IsValid)
            {
                var CustomerRepository = new CustomerRepository();
                var returnValue = CustomerRepository.CustomerSave(tblCustomerDTO);

                if (returnValue == 1)
                {
                    ModelState.AddModelError("MobileNo", "User Name Already Exist");
                }
                else if (returnValue == 2)
                {
                    ModelState.AddModelError("MobileNo", "Error");
                }
                else
                {
                    return RedirectToAction("ListAllCustomer", "Customer");
                }
            }
            return View(tblCustomerDTO);
        }



        //[HttpGet]
        //public ActionResult CustomerSave(int id = 0)
        //{
        //    var CustomerRepository = new CustomerRepository();
        //    if (id > 0)
        //    {
        //        var Customerdata = CustomerRepository.GetCustomerById(id);
        //        return View(Customerdata);
        //    }
        //    return View(new tblCustomerDTO());
        //}

        //[HttpPost]
        //public ActionResult CustomerSave(tblCustomerDTO tblCustomerDTO)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var CustomerRepository = new CustomerRepository();
        //        var returnValue = CustomerRepository.CustomerSave(tblCustomerDTO);

        //        if (returnValue == 1)
        //        {
        //            ModelState.AddModelError("MobileNo", "User Name Already Exist");
        //        }
        //        else if (returnValue == 2)
        //        {
        //            ModelState.AddModelError("MobileNo", "Error");
        //        }
        //        else
        //        {
        //            return RedirectToAction("ListAllCustomer", "Customer");
        //        }
        //    }
        //    return View(tblCustomerDTO);
        //}

        [HttpPost]
        public JsonResult CustomerDelete(int id = 0)
        {
            var CustomerRepository = new CustomerRepository();
            var result = CustomerRepository.CustomerDelete(id);
            if (result == true)
            {
                return Json(new { Success = true, Message = "Delete Succusfully!" });
            }
            return Json(new { Success = false, Message = "Delete Fail!" });

        }

    }
}
