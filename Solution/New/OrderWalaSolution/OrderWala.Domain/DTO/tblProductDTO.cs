//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:03
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

        [DataMember()]
        public Int32 CategoryId { get; set; }

        [DataMember()]
        public Int32 QuantityTypeId { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public Boolean IsDeleted { get; set; }

        public tblProductDTO()
        {
        }

        public tblProductDTO(Int32 productId, Int32 subCategoryId, Int32 categoryId, Int32 quantityTypeId, Boolean isActive, Boolean isDeleted)
        {
			this.ProductId = productId;
			this.SubCategoryId = subCategoryId;
			this.CategoryId = categoryId;
			this.QuantityTypeId = quantityTypeId;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
        }
    }
}
