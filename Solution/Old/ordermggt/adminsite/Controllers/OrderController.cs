using adminsite.Models;
using adminsite.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace adminsite.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class OrderController : Controller
    {
        //
        // GET: /Order/
        private OrderManagmentEntities db = new OrderManagmentEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult orderMaster()
        {
            List<ordermasterdto> qry = (from order in db.TblOrderMasters
                                        join cust in db.TblCustomerMasters on order.CustomerID equals cust.CustomerID
                                        join addr in db.TblAddressMasters on order.AddressID equals addr.AddressID
                                        join status in db.TblOrderStatusMasters on order.OrderStatusID equals status.OrderStatusID
                                        join employee in db.TblEmployeeMasters on order.EmployeeID equals employee.EmployeeID
                                        select new ordermasterdto
                                        {
                                            orderid = order.OrderID,
                                            customer = cust.DisplayName,
                                            address = addr.Address,
                                            orderstatus = status.OrderStatus,
                                            orderdatetime = order.OrderDateTime.Value,
                                            employee = employee.MiddleName

                                        }).ToList<ordermasterdto>();
            return View(qry);

        }

        public ActionResult OrderItemDetail(int id)
        {
            List<orderItemDetaildto> qry = (from orderitem in db.TblOrderItemDetailMasters
                                            join order in db.TblOrderMasters on orderitem.OrderID equals order.OrderID
                                            join product in db.TblProductMasters on orderitem.ProductID equals product.ProductID
                                            join status in db.TblProductStatusMasters on orderitem.ProductStatusID equals status.ProductStatusID
                                            where orderitem.OrderID == id
                                            select new orderItemDetaildto
                                            {
                                                orderitemid = orderitem.OrderItemID,
                                                orderid = order.OrderID,
                                                product = product.ProductName,
                                                quantity = orderitem.Quantity.Value,
                                                price = orderitem.Price.Value,
                                                discount = orderitem.Discount.Value,
                                                totalamount = orderitem.TotalAmount.Value,
                                                productstatus = status.ProductStatus
                                            }).ToList<orderItemDetaildto>();
            return View(qry);
        }

        public ActionResult OrderDetail(int id)
        {
            ordermasterdto qry = (from order in db.TblOrderMasters
                                        join cust in db.TblCustomerMasters on order.CustomerID equals cust.CustomerID
                                        join addr in db.TblAddressMasters on order.AddressID equals addr.AddressID
                                        join status in db.TblOrderStatusMasters on order.OrderStatusID equals status.OrderStatusID
                                        join employee in db.TblEmployeeMasters on order.EmployeeID equals employee.EmployeeID
                                        where order.OrderID == id
                                        select new ordermasterdto
                                        {
                                            orderid = order.OrderID,
                                            customer = cust.DisplayName,
                                            address = addr.Address,
                                            orderstatus = status.OrderStatus,
                                            orderdatetime = order.OrderDateTime.Value,
                                            employee = employee.MiddleName

                                        }).FirstOrDefault<ordermasterdto>();
            return View(qry);

        }
        



        [HttpGet]
        public ActionResult orderMasterdelete(int id)
        {
           
                orderdto orderdto = new orderdto();
                orderdto.orderData = db.TblOrderMasters.Where(h => h.OrderID == id).FirstOrDefault();
                orderdto.customerData = db.TblCustomerMasters.Find(orderdto.orderData.OrderID);
                orderdto.AddressData = db.TblAddressMasters.Find(orderdto.orderData.OrderID);
                orderdto.orderstatusData = db.TblOrderStatusMasters.Find(orderdto.orderData.OrderID);
                orderdto.employeeData = db.TblEmployeeMasters.Find(orderdto.orderData.OrderID);
                TempData["notice"] = "Successfully Delete";
                db.TblOrderMasters.Remove(orderdto.orderData);
                db.SaveChanges();
                TempData["notice"] = "Successfully Delete";

                ViewBag.Message = "Message Sent";

                return RedirectToAction("orderMaster");
            
        }






        public ActionResult OrderitemDelete(int id)
        {

            orderdto orderdto = new orderdto();
            orderdto.orderitemData = db.TblOrderItemDetailMasters.Where(h => h.OrderItemID == id).FirstOrDefault();
            orderdto.orderData = db.TblOrderMasters.Find(orderdto.orderitemData.OrderItemID);
            orderdto.productData = db.TblProductMasters.Find(orderdto.orderitemData.OrderItemID);
            orderdto.productstatusData = db.TblProductStatusMasters.Find(orderdto.orderitemData.OrderItemID);


            db.TblOrderItemDetailMasters.Remove(orderdto.orderitemData);
            db.SaveChanges();
            return RedirectToAction("OrderItemDetail");


        }

    }
}
