using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    [DataContract]
    public class CustomerOrderListResponse : CommonModel
    {
        [DataMember]
        public ServiceResponseStatus ServiceResponseStatus { get; set; }

        public List<tblOrderDTO> OrderList { get; set; }
    }
}
