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
    public partial class tblCityDTO
    {
        [DataMember()]
        public Int32 CityId { get; set; }

        [DataMember()]
        public String CityName { get; set; }

        [DataMember()]
        public Int32 StateId { get; set; }

        public tblCityDTO()
        {
        }

        public tblCityDTO(Int32 cityId, String cityName, Int32 stateId)
        {
			this.CityId = cityId;
			this.CityName = cityName;
			this.StateId = stateId;
        }
    }
}
