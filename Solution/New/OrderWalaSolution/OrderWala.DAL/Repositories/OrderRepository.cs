using OrderWala.Domain;
using OrderWala.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.DAL.Repositories
{
   public class OrderRepository
    {
       /// <summary>
       /// order
       /// </summary>
       /// <returns></returns>
       public List<tblOrderDTO> GetAllOrder()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from Order in OrderWalaContext.tblOrders
                        join customer in OrderWalaContext.tblCustomers on Order.CustomerId equals customer.CustomerId
                        select new tblOrderDTO
                        {
                           OrderId = Order.OrderId,
                           OrderDateTime = Order.OrderDateTime,
                           OrderStatus =Order.OrderStatus,
                           OrderAmount = Order.OrderAmount,
                           DeliveryCharges = Order.DeliveryCharges,
                           OtherCharges = Order.OtherCharges,
                           CustomerMessage =Order.CustomerMessage,
                           OverMessage = Order.OverMessage,
                           CustomerName = customer.FirstName

                        }).ToList();
            }
        }

       /// <summary>
       /// order Item
       /// </summary>
       /// <param name="Id"></param>
       /// <returns></returns>
       public  tblOrderDTO GetAllOrderItem(int Id)
       {
           using (var OrderWalaContext = new OrderWalaEntities())
           {

               var orderDto = new tblOrderDTO();


               orderDto = (from Order in OrderWalaContext.tblOrders
                           join customer in OrderWalaContext.tblCustomers on Order.CustomerId equals customer.CustomerId
                           where Order.OrderId == Id
                           select new tblOrderDTO
                           {
                               OrderId = Order.OrderId,
                               OrderDateTime = Order.OrderDateTime,
                               OrderStatus = Order.OrderStatus,
                               OrderAmount = Order.OrderAmount,
                               DeliveryCharges = Order.DeliveryCharges,
                               OtherCharges = Order.OtherCharges,
                               CustomerMessage = Order.CustomerMessage,
                               OverMessage = Order.OverMessage,
                               CustomerName = customer.FirstName

                           }).FirstOrDefault();

               orderDto.OrderItemList = (from Orderitem in OrderWalaContext.tblOrderItems
                       join order in OrderWalaContext.tblOrders on Orderitem.OrderId equals order.OrderId
                       join Product in OrderWalaContext.tblProducts on Orderitem.ProductId equals Product.ProductId
                       where Orderitem.OrderId == Id
                       select new tblOrderItemDTO
                       {
                         OrderItemId = Orderitem.OrderItemId,
                         OrderId = order.OrderId,
                         ProductId = Product.ProductId,
                         Price =Orderitem.Price,
                         Discount = Orderitem.Discount,
                         CreationDateTime =Orderitem.CreationDateTime,
                         Status = Orderitem.Status

                       }).ToList();

               return orderDto;
           }
       }

       /// <summary>
       /// order item delete
       /// </summary>
       /// <param name="OrderItemId"></param>
       /// <returns></returns>
       public bool OrderItemdelete(int OrderItemId)
       {
           using (var OrderWalaContext = new OrderWalaEntities())
           {
               var orderItem = OrderWalaContext.tblOrderItems.Where(OI => OI.OrderItemId == OrderItemId ).FirstOrDefault();
               OrderWalaContext.tblOrderItems.Remove(orderItem);
               if (OrderWalaContext.SaveChanges() > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
       }

       /// <summary>
       /// Order delete
       /// </summary>
       /// <param name="OrderItemId"></param>
       /// <returns></returns>
       public bool Orderdelete(int OrderId)
       {
           using (var OrderWalaContext = new OrderWalaEntities())
           {
               var order = OrderWalaContext.tblOrders.Where(OI => OI.OrderId == OrderId).FirstOrDefault();
               OrderWalaContext.tblOrders.Remove(order);
               if (OrderWalaContext.SaveChanges() > 0)
               {
                   return true;
               }
               else
               {
                   return false;
               }
           }
       }


       

    }
}
