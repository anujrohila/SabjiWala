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
    
    public partial class TblProductMaster
    {
        public int ProductID { get; set; }
        public Nullable<int> SubCategoryID { get; set; }
        public Nullable<int> CategoryID { get; set; }
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public Nullable<double> ProductPrice { get; set; }
        public Nullable<double> ProductDiscount { get; set; }
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}