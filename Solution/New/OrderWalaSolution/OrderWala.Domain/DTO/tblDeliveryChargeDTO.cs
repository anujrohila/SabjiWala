//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-22 - 18:46:04
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
    public partial class tblDeliveryChargeDTO
    {
        [DataMember()]
        public Int32 DeliveryChargesId { get; set; }

        [DataMember()]
        public Double StartAmount { get; set; }

        [DataMember()]
        public Double EndAmount { get; set; }

        [DataMember()]
        public Double Charges { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public DateTime CreationDateTime { get; set; }

        public tblDeliveryChargeDTO()
        {
        }

        public tblDeliveryChargeDTO(Int32 deliveryChargesId, Double startAmount, Double endAmount, Double charges, Boolean isActive, DateTime creationDateTime)
        {
			this.DeliveryChargesId = deliveryChargesId;
			this.StartAmount = startAmount;
			this.EndAmount = endAmount;
			this.Charges = charges;
			this.IsActive = isActive;
			this.CreationDateTime = creationDateTime;
        }
    }
}
