//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderWala.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblCustomerPayment
    {
        public int PaymentId { get; set; }
        public int CustomerId { get; set; }
        public System.DateTime PaymentDate { get; set; }
        public double Amount { get; set; }
        public int RecievedBy { get; set; }
        public System.DateTime CreationDateTime { get; set; }
    }
}