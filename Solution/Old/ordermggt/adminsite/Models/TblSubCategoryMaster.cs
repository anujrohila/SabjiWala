//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace adminsite.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class TblSubCategoryMaster
    {
        public int SubCategoryID { get; set; }
        [Required(ErrorMessage = "Please select Category Name")]
        public Nullable<int> CategoryID { get; set; }

        [Required(ErrorMessage = "Please Enter SubCategory Name")]
        public string SubCategoryName { get; set; }

     //   [Required(ErrorMessage = "Please Select SubCategory Image")]
        public string SubCategoryImage { get; set; }
    

        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
