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
        public List<tblCustomer> GetAllSportsEventList(string mobileNo, string password)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                //return (from login in OrderWalaContext.tblLogins
                //        where string.Compare(mobileNo, login.MobileNo, StringComparison.CurrentCultureIgnoreCase) == 0 
                //        && string.Compare(mobileNo, login.Password, StringComparison.CurrentCultureIgnoreCase) == 0 
                //        select new tblCustomerDTO
                //        {
                           
                //        }).ToList();
                return null;
            }
        }

        #endregion
    }
}
