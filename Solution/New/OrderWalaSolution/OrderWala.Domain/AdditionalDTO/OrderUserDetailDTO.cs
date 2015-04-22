using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    public class OrderUserDetailDTO : CommonModel
    {
        public int UserId { get; set; }
        public string FirstNam { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public int UserType { get; set; }
        public string UserTypeName { get; set; }
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public string JoiningDate { get; set; }
        public string Latitude { get; set; }
        public string Logitude { get; set; }
        public float RecievedAmount { get; set; }
        public float TotalOrderAmount { get; set; }
        public string Address { get; set; }
        public string AreaName { get; set; }
        public int AreaId { get; set; }
    }
}
