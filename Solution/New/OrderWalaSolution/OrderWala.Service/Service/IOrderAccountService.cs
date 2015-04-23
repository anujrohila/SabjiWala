using OrderWala.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;

namespace OrderWala.Service.Service
{
    [ServiceContract]
    public interface IOrderAccountService
    {
        [OperationContract]
        void DoWork();

        [OperationContract(Name = "Login")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Login?userName={userName}&password={password}")]
        UserDetailDTO Login(string userName, string password);

        //[OperationContract(Name = "CustomerRegister")]
        //[WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Login?firstName={firstName}&lastName={lastName}&address={address}&areaId={areaId}&emailAddress={emailAddress}&mobileNo={mobileNo}&password={password},&latitude={latitude}&longitude={longitude}&registerDeviceId={registerDeviceId}")]
        //RegisterCustomerResponse CustomerRegister(string firstName, string lastName, string address, int areaId, string emailAddress, string mobileNo, string password, string latitude, string longitude, int registerDeviceId);
    }
}