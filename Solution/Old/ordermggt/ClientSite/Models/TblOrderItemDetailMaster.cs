//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClientSite.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TblOrderItemDetailMaster
    {
        public int OrderItemID { get; set; }
        public Nullable<int> OrderID { get; set; }
        public Nullable<int> ProductID { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Nullable<double> Price { get; set; }
        public Nullable<double> Discount { get; set; }
        public Nullable<double> TotalAmount { get; set; }
        public Nullable<int> ProductStatusID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
    
        public virtual TblOrderMaster TblOrderMaster { get; set; }
    }
}