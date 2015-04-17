//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:02
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OrderWala.Domain.DTO
{
    [DataContract()]
    public partial class tblOrderDTO
    {
        [DataMember()]
        public Int32 OrderId { get; set; }

        [DataMember()]
        public DateTime OrderDateTime { get; set; }

        [DataMember()]
        public Int32 OrderStatus { get; set; }

        [DataMember()]
        public Double OrderAmount { get; set; }

        [DataMember()]
        public Int32 CustomerId { get; set; }

        [DataMember()]
        public Double DeliveryCharges { get; set; }

        [DataMember()]
        public Double OtherCharges { get; set; }

        [DataMember()]
        public String CustomerMessage { get; set; }

        [DataMember()]
        public String OverMessage { get; set; }

        public tblOrderDTO()
        {
        }

        public tblOrderDTO(Int32 orderId, DateTime orderDateTime, Int32 orderStatus, Double orderAmount, Int32 customerId, Double deliveryCharges, Double otherCharges, String customerMessage, String overMessage)
        {
			this.OrderId = orderId;
			this.OrderDateTime = orderDateTime;
			this.OrderStatus = orderStatus;
			this.OrderAmount = orderAmount;
			this.CustomerId = customerId;
			this.DeliveryCharges = deliveryCharges;
			this.OtherCharges = otherCharges;
			this.CustomerMessage = customerMessage;
			this.OverMessage = overMessage;
        }
    }
}
