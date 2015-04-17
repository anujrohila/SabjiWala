//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:03
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OrderWala.Domain
{
    [DataContract()]
    public partial class tblOrderItemDTO
    {
        [DataMember()]
        public Int32 OrderItemId { get; set; }

        [DataMember()]
        public Int32 OrderId { get; set; }

        [DataMember()]
        public Int32 ProductId { get; set; }

        [DataMember()]
        public Double Price { get; set; }

        [DataMember()]
        public Double Discount { get; set; }

        [DataMember()]
        public DateTime CreationDateTime { get; set; }

        [DataMember()]
        public Int32 Status { get; set; }

        public tblOrderItemDTO()
        {
        }

        public tblOrderItemDTO(Int32 orderItemId, Int32 orderId, Int32 productId, Double price, Double discount, DateTime creationDateTime, Int32 status)
        {
			this.OrderItemId = orderItemId;
			this.OrderId = orderId;
			this.ProductId = productId;
			this.Price = price;
			this.Discount = discount;
			this.CreationDateTime = creationDateTime;
			this.Status = status;
        }
    }
}