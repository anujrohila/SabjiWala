//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/05/07 - 17:17:09
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
    public partial class tblLanguageDTO
    {
        [DataMember()]
        public Int32 LanguageId { get; set; }

        [DataMember()]
        public String LanguageName { get; set; }

        [DataMember()]
        public String Description { get; set; }

        public tblLanguageDTO()
        {
        }

        public tblLanguageDTO(Int32 languageId, String languageName, String description)
        {
			this.LanguageId = languageId;
			this.LanguageName = languageName;
			this.Description = description;
        }
    }
}
