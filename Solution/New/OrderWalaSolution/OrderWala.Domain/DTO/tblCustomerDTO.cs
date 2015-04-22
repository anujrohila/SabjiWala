//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:01
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
    public partial class tblCustomerDTO
    {
        [DataMember()]
        public Int32 CustomerId { get; set; }

        [DataMember()]
        public String FirstName { get; set; }

        [DataMember()]
        public String LastName { get; set; }

        [DataMember()]
        public String Address { get; set; }

        [DataMember()]
        public Int32 AreaId { get; set; }

        [DataMember()]
        public String EmailAddress { get; set; }

        [DataMember()]
        public String MobileNo { get; set; }

        [DataMember()]
        public String Latitude { get; set; }

        [DataMember()]
        public String Longitude { get; set; }

        [DataMember()]
        public Double TotalOrderAmount { get; set; }

        [DataMember()]
        public Double RecievedAmount { get; set; }

        [DataMember()]
        public Boolean IsActive { get; set; }

        [DataMember()]
        public Boolean IsDeleted { get; set; }

        [DataMember()]
        public DateTime CreationDateTime { get; set; }

        [DataMember()]
        public Int32 RegisterDeviceFrom { get; set; }

        public tblCustomerDTO()
        {
        }

        public tblCustomerDTO(Int32 customerId, String firstName, String lastName, String address, Int32 cityId, String emailAddress, String mobileNo, String latitude, String longitude, Double totalOrderAmount, Double recievedAmount, Boolean isActive, Boolean isDeleted, DateTime creationDateTime, Int32 registerDeviceFrom)
        {
			this.CustomerId = customerId;
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Address = address;
			this.AreaId = cityId;
			this.EmailAddress = emailAddress;
			this.MobileNo = mobileNo;
			this.Latitude = latitude;
			this.Longitude = longitude;
			this.TotalOrderAmount = totalOrderAmount;
			this.RecievedAmount = recievedAmount;
			this.IsActive = isActive;
			this.IsDeleted = isDeleted;
			this.CreationDateTime = creationDateTime;
			this.RegisterDeviceFrom = registerDeviceFrom;
        }
    }
}
