//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-22 - 18:46:06
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
    public partial class tblSubCategoryDTO
    {
        [DataMember()]
        public Int32 SubCategoryId { get; set; }

        [DataMember()]
        public Int32 CategoryId { get; set; }

        [DataMember()]
        public Int32 LanguageId { get; set; }

        [DataMember()]
        public String SubCategoryName { get; set; }

        [DataMember()]
        public String Description { get; set; }

        [DataMember()]
        public String Logo { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public Boolean IsDeleted { get; set; }

        public string MainCategoryName { get; set; }

        public List<tblCategoryDTO> CategoryList { get; set; }
        
    }
}
