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
        /// Get all conference events list
        /// </summary>
        /// <returns></returns>
        public OrderUserDetailDTO GetUserDetail(string mobileNo, string password)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var orderUserDetailDTO = new OrderUserDetailDTO();
                var loginDetail = (from login in OrderWalaContext.tblLogins
                                   where string.Compare(mobileNo, login.MobileNo, StringComparison.CurrentCultureIgnoreCase) == 0
                                   && string.Compare(mobileNo, login.Password, StringComparison.CurrentCultureIgnoreCase) == 0
                                   select login).FirstOrDefault();

                if (loginDetail.UserTypeId == (int)ApplicationEnum.UserType.Customer)
                {
                    orderUserDetailDTO = (from customer in OrderWalaContext.tblCustomers
                                          where customer.UserId == loginDetail.UserId
                                          select new OrderUserDetailDTO
                                            {
                                                UserId = customer.UserId
                                            }).FirstOrDefault();
                }
                return orderUserDetailDTO;
            }
        }

        #endregion
    }
}
