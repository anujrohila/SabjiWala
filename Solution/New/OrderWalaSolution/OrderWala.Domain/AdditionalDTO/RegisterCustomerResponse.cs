﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    [DataContract]
    public class RegisterCustomerResponse : CommonModel
    {
        [DataMember]
        public int UserId { get; set; }

        [DataMember]
        public ServiceResponseStatus ServiceResponseStatus { get; set; }
    }
}
