using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL;
using OrderWala.Domain;

namespace OrderWala.DAL
{
   public class DeliveryChargeRepository
   {
       public List<tblDeliveryChargeDTO> GetAllDeliveryCharge()
       {
           using (var OrderWalaContext = new OrderWalaEntities())
           {
               return OrderWalaContext.tblDeliveryCharges.ToList().ToDTOs();
           }
       }

       public tblDeliveryChargeDTO GetDeliveryById(int DeliveryId)
       {
           using (var OrderWalaContext = new OrderWalaEntities())
           {
               return OrderWalaContext.tblDeliveryCharges.Where(dt => dt.DeliveryChargesId == DeliveryId).FirstOrDefault().ToDTO();
           }
       }


       public int DeliveryChargeSave(tblDeliveryChargeDTO tbldeliverychargedto)
       {
           using (var OrderWalaContext = new OrderWalaEntities())
           {
               if (tbldeliverychargedto.DeliveryChargesId == 0)
               {
                   tbldeliverychargedto.CreationDateTime = DateTime.Now;
                   OrderWalaContext.tblDeliveryCharges.Add(tbldeliverychargedto.ToEntity());
               }
               else
               {
                   var deliverydata = OrderWalaContext.tblDeliveryCharges.Where(dlt => dlt.DeliveryChargesId == tbldeliverychargedto.DeliveryChargesId).FirstOrDefault();
                   deliverydata.StartAmount = tbldeliverychargedto.StartAmount;
                   deliverydata.EndAmount = tbldeliverychargedto.EndAmount;
                   deliverydata.Charges = tbldeliverychargedto.Charges;
               }

               if (OrderWalaContext.SaveChanges() > 0)
               {
                   return 0;
               }
               else
               {
                   return 2;
               }
           }
       }

       public bool DeliveryChargeDeletedata(int ID)
       {
           using (var OrderWalaContext = new OrderWalaEntities())
           {
               var Delivery = OrderWalaContext.tblDeliveryCharges.Where(st => st.DeliveryChargesId == ID).FirstOrDefault();
               OrderWalaContext.tblDeliveryCharges.Remove(Delivery);
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
