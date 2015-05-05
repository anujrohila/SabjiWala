﻿using OrderWala.Domain;
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
        [OperationContract(Name = "GetAreaList")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetAreaList")]
        AreaListResponse GetAreaList();

        [OperationContract(Name = "Login")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "Login?userName={userName}&password={password}")]
        UserDetailResponse Login(string userName, string password);

        [OperationContract(Name = "CustomerRegister")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "CustomerRegister?firstName={firstName}&lastName={lastName}&address={address}&areaId={areaId}&emailAddress={emailAddress}&mobileNo={mobileNo}&password={password}&latitude={latitude}&longitude={longitude}&registerDeviceId={registerDeviceId}")]
        RegisterCustomerResponse CustomerRegister(string firstName, string lastName, string address, int areaId, string emailAddress, string mobileNo, string password, string latitude, string longitude, int registerDeviceId);

        [OperationContract(Name = "ChangePassword")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "ChangePassword?userId={userId}&oldPassword={oldPassword}&newPassword={newPassword}")]
        ChangePasswordResponse ChangePassword(int userId, string oldPassword, string newPassword);

        [OperationContract(Name = "GetProductMainCategoryList")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetProductMainCategoryList?languageId={languageId}")]
        ProductMainCategoryResponse GetProductMainCategoryList(int languageId);

        [OperationContract(Name = "GetProductSubCategoryList")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetProductSubCategoryList?mainCategoryId={mainCategoryId}&languageId={languageId}")]
        ProductSubCategoryResponse GetProductSubCategoryList(int mainCategoryId, int languageId);

        [OperationContract(Name = "GetProductList")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetProductList?subCategoryId={subCategoryId}&languageId={languageId}&cityId={cityId}")]
        ProductResponse GetProductList(int subCategoryId, int languageId, int cityId);

        [OperationContract(Name = "GetUCustomerOrderList")]
        [WebInvoke(Method = "GET", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json, BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "GetUCustomerOrderList?customerId={userId}&languageId={languageId}")]
        CustomerOrderListResponse GetUCustomerOrderList(int customerId, int languageId);
    }
}