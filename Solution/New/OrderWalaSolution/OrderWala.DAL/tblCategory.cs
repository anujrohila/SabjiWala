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
    
    public partial class tblCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int LanguageId { get; set; }
        public string Description { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
