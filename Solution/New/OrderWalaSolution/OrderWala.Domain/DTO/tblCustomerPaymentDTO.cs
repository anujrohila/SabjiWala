//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/05/07 - 17:17:08
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
    public partial class tblCustomerPaymentDTO
    {
        [DataMember()]
        public Int32 PaymentId { get; set; }

        [DataMember()]
        public Int32 CustomerId { get; set; }

        [DataMember()]
        public DateTime PaymentDate { get; set; }

        [DataMember()]
        public Double Amount { get; set; }

        [DataMember()]
        public Int32 RecievedBy { get; set; }

        [DataMember()]
        public DateTime CreationDateTime { get; set; }

        public tblCustomerPaymentDTO()
        {
        }

        public tblCustomerPaymentDTO(Int32 paymentId, Int32 customerId, DateTime paymentDate, Double amount, Int32 recievedBy, DateTime creationDateTime)
        {
			this.PaymentId = paymentId;
			this.CustomerId = customerId;
			this.PaymentDate = paymentDate;
			this.Amount = amount;
			this.RecievedBy = recievedBy;
			this.CreationDateTime = creationDateTime;
        }
    }
}
