//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:00
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OrderWala.Domain.DTO
{
    [DataContract()]
    public partial class tblCategoryDTO
    {
        [DataMember()]
        public Int32 CategoryId { get; set; }

        [DataMember()]
        public String CategoryName { get; set; }

        [DataMember()]
        public Int32 LanguageId { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public Byte[] Logo { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public Boolean IsDeleted { get; set; }

        public tblCategoryDTO()
        {
        }

        public tblCategoryDTO(Int32 categoryId, String categoryName, Int32 languageId, String description, Byte[] logo, Boolean isActive, Boolean isDeleted)
        {
			this.CategoryId = categoryId;
			this.CategoryName = categoryName;
			this.LanguageId = languageId;
			this.Description = description;
			this.Logo = logo;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
        }
    }
}
