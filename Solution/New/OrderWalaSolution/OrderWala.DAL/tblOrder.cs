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
    
    public partial class tblOrder
    {
        public int OrderId { get; set; }
        public System.DateTime OrderDateTime { get; set; }
        public int OrderStatus { get; set; }
        public double OrderAmount { get; set; }
        public int CustomerId { get; set; }
        public double DeliveryCharges { get; set; }
        public double OtherCharges { get; set; }
        public string CustomerMessage { get; set; }
        public string OverMessage { get; set; }
    }
}
