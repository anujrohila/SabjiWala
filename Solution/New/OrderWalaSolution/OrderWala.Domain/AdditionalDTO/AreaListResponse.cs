using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    [DataContract]
    public class AreaListResponse : CommonModel
    {
        public AreaListResponse()
        {
            AreaList = new List<tblAreaDTO>();
        }

        [DataMember]
        public List<tblAreaDTO> AreaList { get; set; }

        [DataMember]
        public ServiceResponseStatus ServiceResponseStatus { get; set; }
    }
}
