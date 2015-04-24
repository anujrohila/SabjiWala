using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    [DataContract]
    public class UserDetailResponse : CommonModel
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string MobileNo { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public DateTime JoiningDate { get; set; }

        [DataMember]
        public string Latitude { get; set; }

        [DataMember]
        public string Longitude { get; set; }

        [DataMember]
        public double RecievedAmount { get; set; }

        [DataMember]
        public double TotalOrderAmount { get; set; }

        [DataMember]
        public string Address { get; set; }

        [DataMember]
        public string AreaName { get; set; }

        [DataMember]
        public int AreaId { get; set; }

        [DataMember]
        public int RegisterDeviceId { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public ServiceResponseStatus ServiceResponseStatus { get; set; }
    }
}
