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
    
    public partial class TblCustomerMaster
    {
        public int CustomerID { get; set; }

        //[Required(ErrorMessage = "Please Enter Customer name as a Mobile  Number")]
        //[StringLength(10, ErrorMessage = "Maximum  Must Be 10 Digit", MinimumLength = 10)]
        //[RegularExpression(@"^([0-9])+$", ErrorMessage = "Please Enter Digit")]
        public string CustomerName { get; set; }

        
        public string Password { get; set; }
        public Nullable<int> UserID { get; set; }

         [Required(ErrorMessage = "Please Enter Customer  Display Name")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }

         [Required(ErrorMessage = "Please Enter Middel Name")]
        public string MiddleName { get; set; }

          [Required(ErrorMessage = "Please Enter Last Name")]
        public string LastName { get; set; }

          [Required(ErrorMessage = "Please Enter Email Id")]
          [Display(Name = "EmailId")]
          [RegularExpression(@"^([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$", ErrorMessage = "Please Enter Correct Email Id")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Please Select Language")]
        public Nullable<int> LanguageID { get; set; }
        public Nullable<int> ConformationCode { get; set; }
        public Nullable<int> CustomerDeviceID { get; set; }
        public Nullable<int> CustomerStatusID { get; set; }
        public Nullable<int> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public Nullable<System.DateTime> UpdatedDateTime { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsActive { get; set; }
    }
}
