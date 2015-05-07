using OrderWala.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OrderWala.Domain.Resource;

namespace OrderWala.Web.Controllers
{
    public class OrderController : Controller
    {
        //
        // GET: /Order/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ListAllOrder()
        {

            var OrderRepository = new OrderRepository();
            var returnValue = OrderRepository.GetAllOrder();
            return View(returnValue);
        }

        [HttpGet]
        public ActionResult ListAllOrderItem(int Id)
        {

            var OrderRepository = new OrderRepository();
            var returnValue = OrderRepository.GetAllOrderItem(Id);
            return View(returnValue);
        }



        [HttpPost]
        public JsonResult OrderItemDelete(int ID)
        {
            var OrderRepository = new OrderRepository();
            var result = OrderRepository.OrderItemdelete(ID);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully });
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail});

        }


        [HttpPost]
        public JsonResult OrderDelete(int ID)
        {
            var OrderRepository = new OrderRepository();
            var result = OrderRepository.Orderdelete(ID);
            if (result == true)
            {
                return Json(new { Success = true, OrderWalaResource.msgDeleteSuccessfully});
            }
            return Json(new { Success = false, OrderWalaResource.msgDeleteFail});

        }

       

    }
}
