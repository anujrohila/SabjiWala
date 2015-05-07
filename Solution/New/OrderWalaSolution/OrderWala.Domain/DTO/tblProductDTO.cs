//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/05/07 - 17:17:13
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
    public partial class tblProductDTO
    {
        [DataMember()]
        public Int32 ProductId { get; set; }

        [DataMember()]
        public Int32 SubCategoryId { get; set; }

        public String SubCategoryName { get; set; }

        public String CategoryName { get; set; }

        public String Quantity { get; set; }

        [DataMember()]
        public Int32 CategoryId { get; set; }

        [DataMember()]
        public Int32 QuantityTypeId { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public Boolean IsDeleted { get; set; }

        [DataMember()]
        public String Logo { get; set; }

        public Nullable<Int32> LanguageId { get; set; }
       
        public Nullable<Int32> CityId { get; set; }

       
        public Nullable<Double> OldPrice { get; set; }

       
        public Nullable<Double> NewPrice { get; set; }

        public String ProductName { get; set; }

      
        public String Description { get; set; }

        public String QuantityTypeName { get; set; }


        public tblLanguageWiseProductDTO lngwiseProduct { get; set; }


        public tblProductDTO()
        {
        }

        public tblProductDTO(Int32 productId, Int32 subCategoryId, Int32 categoryId, Int32 quantityTypeId, Boolean isActive, Boolean isDeleted, String logo)
        {
			this.ProductId = productId;
			this.SubCategoryId = subCategoryId;
			this.CategoryId = categoryId;
			this.QuantityTypeId = quantityTypeId;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
			this.Logo = logo;
        }

      
    }
}
