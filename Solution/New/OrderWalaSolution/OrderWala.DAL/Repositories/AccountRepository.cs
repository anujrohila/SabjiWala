using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL;
using OrderWala.Domain;

namespace OrderWala.DAL
{
    public class AccountRepository
    {
        #region [Declaration]

        #endregion

        #region [Constructor]

        public AccountRepository()
        {

        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Login
        /// </summary>
        /// <returns></returns>
        public UserDetailResponse Login(string userName, string password)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                UserDetailResponse userDetailDTO = new UserDetailResponse();
                var loginDetail = (from login in OrderWalaContext.tblLogins
                                   where string.Compare(userName, login.MobileNo, StringComparison.CurrentCultureIgnoreCase) == 0
                                   && string.Compare(password, login.Password, StringComparison.CurrentCultureIgnoreCase) == 0
                                   select login).FirstOrDefault();

                if (loginDetail != null)
                {
                    if (loginDetail.UserTypeId == (int)ApplicationEnum.UserType.Customer)
                    {
                        userDetailDTO = (from customer in OrderWalaContext.tblCustomers
                                         join area in OrderWalaContext.tblAreas on customer.AreaId equals area.AreaId
                                         where customer.UserId == loginDetail.UserId
                                         select new UserDetailResponse
                                           {
                                               UserId = customer.UserId,
                                               FirstName = customer.FirstName,
                                               LastName = customer.LastName,
                                               CompanyName = string.Empty,
                                               Address = customer.Address,
                                               EmailAddress = customer.EmailAddress,
                                               MobileNo = customer.MobileNo,
                                               AreaId = customer.AreaId,
                                               AreaName = area.AreaName,
                                               IsActive = customer.IsActive,
                                               JoiningDate = customer.CreationDateTime,
                                               Latitude = customer.Latitude,
                                               Longitude = customer.Longitude,
                                               RecievedAmount = customer.RecievedAmount,
                                               TotalOrderAmount = customer.TotalOrderAmount,
                                           }).FirstOrDefault();
                    }
                }
                return userDetailDTO;
            }
        }

        /// <summary>
        /// Register Customer
        /// </summary>
        /// <returns></returns>
        public int RegisterCustomer(UserDetailResponse userDetailDTO)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var tblLogin = new tblLogin();
                tblLogin.MobileNo = userDetailDTO.MobileNo;
                tblLogin.UserTypeId = (int)ApplicationEnum.UserType.Customer;
                tblLogin.CreationDatetime = DateTime.Now;
                tblLogin.Password = userDetailDTO.Password;
                tblLogin.IsActive = true;
                tblLogin.RegisterDeviceId = userDetailDTO.RegisterDeviceId;

                OrderWalaContext.tblLogins.Add(tblLogin);
                OrderWalaContext.SaveChanges();

                // Customer details
                var tblCustomer = new tblCustomer();
                tblCustomer.UserId = tblLogin.UserId;
                tblCustomer.FirstName = userDetailDTO.FirstName;
                tblCustomer.LastName = userDetailDTO.LastName;
                tblCustomer.Address = userDetailDTO.Address;
                tblCustomer.AreaId = userDetailDTO.AreaId;
                tblCustomer.EmailAddress = userDetailDTO.EmailAddress;
                tblCustomer.MobileNo = userDetailDTO.MobileNo;
                tblCustomer.Latitude = userDetailDTO.Latitude;
                tblCustomer.Longitude = userDetailDTO.Longitude;
                tblCustomer.TotalOrderAmount = 0;
                tblCustomer.RecievedAmount = 0;
                tblCustomer.IsActive = true;
                tblCustomer.IsDeleted = false;
                tblCustomer.CreationDateTime = DateTime.Now;

                OrderWalaContext.tblCustomers.Add(tblCustomer);
                OrderWalaContext.SaveChanges();

                return tblLogin.UserId;
            }
        }

        /// <summary>
        /// Is Duplicate Registration
        /// </summary>
        /// <returns></returns>
        public bool IsDuplicateRegistration(string mobileNo)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                UserDetailResponse userDetailDTO = new UserDetailResponse();
                var loginDetails = (from login in OrderWalaContext.tblLogins
                                    where string.Compare(mobileNo, login.MobileNo, StringComparison.CurrentCultureIgnoreCase) == 0
                                    select login).ToList();

                return loginDetails.Count > 0 ? true : false;
            }
        }

        /// <summary>
        /// Register Customer
        /// </summary>
        /// <returns></returns>
        public int ChangePassword(int userId, string oldPassword, string newPassword)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                tblLogin tblLogin;

                tblLogin = OrderWalaContext.tblLogins.Find(userId);

                if (tblLogin == null)
                {
                    return 2; // no record found
                }
                else if (string.Compare(oldPassword, tblLogin.Password, StringComparison.CurrentCultureIgnoreCase) != 0)
                {
                    return 3; // old password not match
                }
                else
                {
                    tblLogin.Password = newPassword;
                    OrderWalaContext.SaveChanges();
                    return 1;
                }
            }
        }

        /// <summary>
        /// Get User Order List
        /// </summary>
        /// <returns></returns>
        public List<tblOrderDTO> GetUserOrderList(int customerId, int languageId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return (from orderObject in OrderWalaContext.tblOrders
                        where orderObject.CustomerId == customerId
                        select new tblOrderDTO
                        {
                            OrderId = orderObject.OrderId,
                            OrderDateTime = orderObject.OrderDateTime,
                            OrderStatus = orderObject.OrderStatus,
                            OrderAmount = orderObject.OrderAmount,
                            CustomerId = orderObject.CustomerId,
                            DeliveryCharges = orderObject.DeliveryCharges,
                            OtherCharges = orderObject.OtherCharges,
                            CustomerMessage = orderObject.CustomerMessage,
                            OverMessage = orderObject.OverMessage,
                            OrderItemList = (from orderItem in OrderWalaContext.tblOrderItems
                                             join languageWiseProduct in OrderWalaContext.tblLanguageWiseProducts on orderItem.ProductId equals languageWiseProduct.ProductId
                                             where orderItem.OrderId == orderObject.OrderId && languageWiseProduct.LanguageId == languageId
                                             select new tblOrderItemDTO
                                             {
                                                 OrderItemId = orderItem.OrderItemId,
                                                 OrderId = orderItem.OrderId,
                                                 ProductId = orderItem.ProductId,
                                                 Price = orderItem.Price,
                                                 Discount = orderItem.Discount,
                                                 CreationDateTime = orderItem.CreationDateTime,
                                                 ProductName = languageWiseProduct.ProductName,
                                                 ProductDescription = languageWiseProduct.Description
                                             }).ToList()
                        }).ToList();
            }
        }

        #endregion
    }
}
