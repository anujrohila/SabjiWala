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
        public void DoWork()
        {
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

        //public RegisterCustomerResponse CustomerRegister(string firstName, string lastName, string address, int areaId, string emailAddress, string mobileNo, string password, string latitude, string longitude, int registerDeviceId)
        //{
        //    var registerCustomerResponse = new RegisterCustomerResponse();
        //    try
        //    {
        //        bool isValid = true;

        //        var userDetailDTO = new UserDetailDTO();
        //        userDetailDTO.FirstName = firstName;
        //        userDetailDTO.LastName = firstName;
        //        userDetailDTO.AreaId = areaId;
        //        userDetailDTO.EmailAddress = emailAddress;
        //        userDetailDTO.MobileNo = mobileNo;
        //        userDetailDTO.Password = password;
        //        userDetailDTO.Latitude = latitude;
        //        userDetailDTO.Logitude = longitude;
        //        userDetailDTO.RegisterDeviceId = registerDeviceId;

        //        registerCustomerResponse.ModelMessage = CustomerRegisterValidation(userDetailDTO);
        //        isValid = registerCustomerResponse.ModelMessage.Count > 0 ? false : true;

        //        if (isValid)
        //        {
        //            var accountRepository = new AccountRepository();
        //            var isDuplicateRegistration = accountRepository.IsDuplicateRegistration(mobileNo);
        //            if (!isDuplicateRegistration)
        //            {
        //                userDetailDTO = accountRepository.RegisterCustomer(userName, Encryption.EncryptToBase64(password));
        //                if (userDetailDTO.UserId == 0)
        //                {
        //                    userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valInvalidLoginDetail });
        //                }
        //            }
        //            else
        //            {
        //                userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.valInvalidLoginDetail });
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        userDetailDTO.ModelMessage.Add(new ModelMessage { Status = MessageType.Error, Message = OrderWalaResource.msgErrorInTransaction });
        //    }
        //    return userDetailDTO;
        //}



        #region [Private Method]

        public List<ModelMessage> CustomerRegisterValidation(UserDetailDTO userDetailDTO)
        {
            var validationModel = new List<ModelMessage>();
            return validationModel;
        }

        #endregion
    }
}
