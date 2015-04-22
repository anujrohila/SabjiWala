using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace OrderWala.Service.Service
{
    [ServiceContract]
    public interface IOrderAccountService
    {
        [OperationContract]
        void DoWork();
    }
}