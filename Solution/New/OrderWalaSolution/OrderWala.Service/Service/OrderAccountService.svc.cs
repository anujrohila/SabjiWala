using OrderWala.DAL;
using OrderWala.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using OrderWala.Domain.Resource;
using System.Text.RegularExpressions;

namespace OrderWala.Service.Service
{
    public class OrderAccountService : IOrderAccountService
    {

        #region [Public Method]

        public AreaListResponse GetAreaList()
        {
            var areaListResponse = new AreaListResponse();
            try
            {
                var masterRepository = new MasterRepository();
                areaListResponse.AreaList = masterRepository.GetAllArea();
                areaListResponse.ServiceResponseStatus = ServiceResponseStatus.Success;
            }
            catch (Exception)
            {
                areaListResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInTransaction });
                areaListResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
            }
            return areaListResponse;
        }

        public UserDetailResponse Login(string userName, string password)
        {
            var userDetailDTO = new UserDetailResponse();
            userDetailDTO.ModelMessage = new List<ModelMessage>();
            try
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(userName))
                {
                    userDetailDTO.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.valRequiredUserName });
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    userDetailDTO.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.valRequiredPassword });
                    isValid = false;
                }
                if (isValid)
                {
                    var accountRepository = new AccountRepository();
                    userDetailDTO = accountRepository.Login(userName, Encryption.EncryptToBase64(password));
                    if (userDetailDTO.UserId == 0)
                    {
                        userDetailDTO.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.valInvalidLoginDetail });
                        userDetailDTO.ServiceResponseStatus = ServiceResponseStatus.Error;
                    }
                    else
                    {
                        userDetailDTO.ServiceResponseStatus = ServiceResponseStatus.Success;
                    }
                }
                else
                {
                    userDetailDTO.ServiceResponseStatus = ServiceResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                userDetailDTO.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInTransaction });
                userDetailDTO.ServiceResponseStatus = ServiceResponseStatus.Error;
            }
            return userDetailDTO;
        }

        public RegisterCustomerResponse CustomerRegister(string firstName, string lastName, string address, int areaId, string emailAddress, string mobileNo, string password, string latitude, string longitude, int registerDeviceId)
        {
            var registerCustomerResponse = new RegisterCustomerResponse();
            try
            {
                bool isValid = true;

                var userDetailDTO = new UserDetailResponse();
                userDetailDTO.FirstName = firstName;
                userDetailDTO.LastName = firstName;
                userDetailDTO.AreaId = areaId;
                userDetailDTO.Address = address;
                userDetailDTO.EmailAddress = emailAddress;
                userDetailDTO.MobileNo = mobileNo;
                if (!string.IsNullOrWhiteSpace(password))
                {
                    userDetailDTO.Password = Encryption.EncryptToBase64(password);
                }
                userDetailDTO.Latitude = latitude;
                userDetailDTO.Longitude = longitude;
                userDetailDTO.RegisterDeviceId = registerDeviceId;

                registerCustomerResponse.ModelMessage = CustomerRegisterValidation(userDetailDTO);
                isValid = registerCustomerResponse.ModelMessage.Count > 0 ? false : true;

                if (isValid)
                {
                    var accountRepository = new AccountRepository();
                    var isDuplicateRegistration = accountRepository.IsDuplicateRegistration(mobileNo);
                    if (!isDuplicateRegistration)
                    {
                        var registerResponse = accountRepository.RegisterCustomer(userDetailDTO);
                        if (registerResponse == 0)
                        {
                            userDetailDTO.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInRegistration });
                            registerCustomerResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
                        }
                        else
                        {
                            registerCustomerResponse.UserId = registerResponse;
                            registerCustomerResponse.ServiceResponseStatus = ServiceResponseStatus.Success;
                            userDetailDTO.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgRegisterSuccessfullly });
                        }
                    }
                    else
                    {
                        registerCustomerResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
                        registerCustomerResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgDuplicateUserName });
                    }
                }
                else
                {
                    registerCustomerResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                registerCustomerResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
                registerCustomerResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInTransaction });
            }
            return registerCustomerResponse;
        }

        public ChangePasswordResponse ChangePassword(int userId, string oldPassword, string newPassword)
        {
            var changePasswordResponse = new ChangePasswordResponse();
            changePasswordResponse.ModelMessage = new List<ModelMessage>();
            try
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(oldPassword))
                {
                    changePasswordResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.valRequiredOldPassword });
                }
                if (string.IsNullOrWhiteSpace(newPassword))
                {
                    changePasswordResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.valRequiredNewPassword });
                }
                isValid = changePasswordResponse.ModelMessage.Count == 0 ? true : false;
                if (isValid)
                {
                    var accountRepository = new AccountRepository();
                    var result = accountRepository.ChangePassword(userId, Encryption.EncryptToBase64(oldPassword), Encryption.EncryptToBase64(newPassword));
                    if (result == 1)
                    {
                        changePasswordResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgPasswordChangedSuccessfully });
                        changePasswordResponse.ServiceResponseStatus = ServiceResponseStatus.Success;
                    }
                    else if (result == 2)
                    {
                        changePasswordResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgNoUserFound });
                        changePasswordResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
                    }
                    else
                    {
                        changePasswordResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgOldPasswordNotMatch });
                        changePasswordResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
                    }
                }
                else
                {
                    changePasswordResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
                }
            }
            catch (Exception)
            {
                changePasswordResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInTransaction });
                changePasswordResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
            }
            return changePasswordResponse;
        }

        public ProductMainCategoryResponse GetProductMainCategoryList(int languageId)
        {
            var productMainCategoryResponse = new ProductMainCategoryResponse();
            productMainCategoryResponse.ModelMessage = new List<ModelMessage>();
            try
            {
                var masterRepository = new MasterRepository();
                productMainCategoryResponse.CategoryList = masterRepository.GetProductMainCategoryList(languageId);
                productMainCategoryResponse.ServiceResponseStatus = ServiceResponseStatus.Success;
            }
            catch (Exception)
            {
                productMainCategoryResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInTransaction });
                productMainCategoryResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
            }
            return productMainCategoryResponse;
        }

        public ProductSubCategoryResponse GetProductSubCategoryList(int mainCategoryId, int languageId)
        {
            var productSubCategoryResponse = new ProductSubCategoryResponse();
            productSubCategoryResponse.ModelMessage = new List<ModelMessage>();
            try
            {
                var masterRepository = new MasterRepository();
                productSubCategoryResponse.SubCategoryList = masterRepository.GetProductSubCategoryList(mainCategoryId, languageId);
                productSubCategoryResponse.ServiceResponseStatus = ServiceResponseStatus.Success;
            }
            catch (Exception)
            {
                productSubCategoryResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInTransaction });
                productSubCategoryResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
            }
            return productSubCategoryResponse;
        }

        public ProductResponse GetProductList(int subCategoryId, int languageId, int cityId)
        {
            var productResponse = new ProductResponse();
            productResponse.ModelMessage = new List<ModelMessage>();
            try
            {
                var masterRepository = new MasterRepository();
                productResponse.ProductList = masterRepository.GetProductList(subCategoryId, languageId, cityId);
                productResponse.ServiceResponseStatus = ServiceResponseStatus.Success;
            }
            catch (Exception)
            {
                productResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInTransaction });
                productResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
            }
            return productResponse;
        }

        public CustomerOrderListResponse GetUCustomerOrderList(int customerId, int languageId)
        {
            var customerOrderListResponse = new CustomerOrderListResponse();
            customerOrderListResponse.ModelMessage = new List<ModelMessage>();
            try
            {
                var accountRepository = new AccountRepository();
                customerOrderListResponse.OrderList = accountRepository.GetUserOrderList(customerId, languageId);
                customerOrderListResponse.ServiceResponseStatus = ServiceResponseStatus.Success;
            }
            catch (Exception)
            {
                customerOrderListResponse.ModelMessage.Add(new ModelMessage { Message = OrderWalaResource.msgErrorInTransaction });
                customerOrderListResponse.ServiceResponseStatus = ServiceResponseStatus.Error;
            }
            return customerOrderListResponse;
        }
        #endregion

        #region [Private Method]

        public List<ModelMessage> CustomerRegisterValidation(UserDetailResponse userDetailDTO)
        {
            var validationModel = new List<ModelMessage>();
            if (string.IsNullOrWhiteSpace(userDetailDTO.FirstName))
            {
                validationModel.Add(new ModelMessage { Message = OrderWalaResource.valRequiredFirstName });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.LastName))
            {
                validationModel.Add(new ModelMessage { Message = OrderWalaResource.valRequiredLastName });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.Address))
            {
                validationModel.Add(new ModelMessage { Message = OrderWalaResource.valRequiredAddress });
            }
            if (!string.IsNullOrWhiteSpace(userDetailDTO.EmailAddress))
            {
                bool isValidEmail = Regex.IsMatch(userDetailDTO.EmailAddress, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", RegexOptions.IgnoreCase);
                if (!isValidEmail)
                {
                    validationModel.Add(new ModelMessage { Message = OrderWalaResource.valInvalidEmail });
                }
            }
            if (userDetailDTO.AreaId == 0)
            {
                validationModel.Add(new ModelMessage { Message = OrderWalaResource.valRequiredArea });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.MobileNo))
            {
                validationModel.Add(new ModelMessage { Message = OrderWalaResource.valRequiredMobileNo });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.Password))
            {
                validationModel.Add(new ModelMessage { Message = OrderWalaResource.valRequiredPassword });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.Latitude) || string.IsNullOrWhiteSpace(userDetailDTO.Longitude))
            {
                validationModel.Add(new ModelMessage { Message = OrderWalaResource.valRequiredMapAddress });
            }
            return validationModel;
        }

        #endregion
    }
}
