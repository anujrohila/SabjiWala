//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015/05/07 - 17:17:14
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
    public partial class tblUserTypeDTO
    {
        [DataMember()]
        public Int32 UserTypeId { get; set; }

        [DataMember()]
        public String TypeName { get; set; }

        public tblUserTypeDTO()
        {
        }

        public tblUserTypeDTO(Int32 userTypeId, String typeName)
        {
			this.UserTypeId = userTypeId;
			this.TypeName = typeName;
        }
    }
}
