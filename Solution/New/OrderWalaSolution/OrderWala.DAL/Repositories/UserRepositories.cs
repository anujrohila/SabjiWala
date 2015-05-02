using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL;
using OrderWala.Domain;

namespace OrderWala.DAL
{
    public class UserRepositories
    {

        #region

        /// <summary>
        /// disply all admin user for login
        /// </summary>
        /// <returns></returns>
        public List<tblLoginDTO> GetAllLogin()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {


                return OrderWalaContext.tblLogins.ToList().ToDTOs();
            }
        
        
        }



   

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public tblLoginDTO GetUserByUserId(int UserId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblLogins.Where(lt => lt.UserId == UserId).FirstOrDefault().ToDTO();
            }

        
        }

        #endregion

    }
}
