//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:04
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
    public partial class tblQuantityTypeDTO
    {
        [DataMember()]
        public Int32 QuantityTypeId { get; set; }

        [DataMember()]
        public String TypeName { get; set; }

        public tblQuantityTypeDTO()
        {
        }

        public tblQuantityTypeDTO(Int32 quantityTypeId, String typeName)
        {
			this.QuantityTypeId = quantityTypeId;
			this.TypeName = typeName;
        }
    }
}