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

namespace OrderWala.Service.Service
{
    public class OrderAccountService : IOrderAccountService
    {

        #region [Public Method]

        public List<tblAreaDTO> GetAreaList()
        {
            var areaList = new List<tblAreaDTO>();
            try
            {
                var masterRepository = new MasterRepository();
                areaList = masterRepository.GetAllArea();
            }
            catch (Exception)
            {
            }
            return areaList;
        }

        public UserDetailDTO Login(string userName, string password)
        {
            var userDetailDTO = new UserDetailDTO();
            userDetailDTO.ModelMessage = new List<ModelMessage>();
            try
            {
                bool isValid = true;
                if (string.IsNullOrWhiteSpace(userName))
                {
                    userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valRequiredUserName });
                    isValid = false;
                }
                if (string.IsNullOrWhiteSpace(password))
                {
                    userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valRequiredPassword });
                    isValid = false;
                }
                if (isValid)
                {
                    var accountRepository = new AccountRepository();
                    userDetailDTO = accountRepository.Login(userName, Encryption.EncryptToBase64(password));
                    if (userDetailDTO.UserId == 0)
                    {
                        userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valInvalidLoginDetail });
                    }
                }
            }
            catch (Exception)
            {
                userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.msgErrorInTransaction });
            }
            return userDetailDTO;
        }

        public RegisterCustomerResponse CustomerRegister(string firstName, string lastName, string address, int areaId, string emailAddress, string mobileNo, string password, string latitude, string longitude, int registerDeviceId)
        {
            var registerCustomerResponse = new RegisterCustomerResponse();
            try
            {
                bool isValid = true;

                var userDetailDTO = new UserDetailDTO();
                userDetailDTO.FirstName = firstName;
                userDetailDTO.LastName = firstName;
                userDetailDTO.AreaId = areaId;
                userDetailDTO.EmailAddress = emailAddress;
                userDetailDTO.MobileNo = mobileNo;
                userDetailDTO.Password = Encryption.EncryptToBase64(password);
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
                            userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.msgErrorInRegistration });
                        }
                    }
                    else
                    {
                        registerCustomerResponse.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.msgDuplicateUserName });
                    }
                }
            }
            catch (Exception)
            {
                registerCustomerResponse.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.msgErrorInTransaction });
            }
            return registerCustomerResponse;
        }

        #endregion

        #region [Private Method]

        public List<ModelMessage> CustomerRegisterValidation(UserDetailDTO userDetailDTO)
        {
            var validationModel = new List<ModelMessage>();
            if (string.IsNullOrWhiteSpace(userDetailDTO.FirstName))
            {
                userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valRequiredFirstName });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.LastName))
            {
                userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valRequiredLastName });
            }
            if (userDetailDTO.AreaId == 0)
            {
                userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valRequiredArea });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.MobileNo))
            {
                userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valRequiredMobileNo });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.Password))
            {
                userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valRequiredPassword });
            }
            if (string.IsNullOrWhiteSpace(userDetailDTO.Latitude) || string.IsNullOrWhiteSpace(userDetailDTO.Longitude))
            {
                userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valRequiredMapAddress });
            }
            return validationModel;
        }

        #endregion
    }
}
