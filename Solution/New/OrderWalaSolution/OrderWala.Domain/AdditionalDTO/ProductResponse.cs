using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    [DataContract]
    public class ProductResponse : CommonModel
    {
        [DataMember]
        public ServiceResponseStatus ServiceResponseStatus { get; set; }

        public List<tblProductDTO> ProductList { get; set; }
    }
}
