﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace OrderWala.Domain
{
    /// <summary>
    /// This view model will be inherited in all models (DTOs)
    /// </summary>
    [DataContract()]
    public class CommonModel
    {
        public CommonModel()
        {
            ModelMessage = new List<ModelMessage>();
        }

        [DataMember(EmitDefaultValue = false)]
        public List<ModelMessage> ModelMessage { get; set; }

    }

    public class ModelMessage
    {
        public string Message { get; set; }
    }

    public enum ServiceResponseStatus
    {
        Error,
        Success
    }
}
