using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderWala.DAL;
using OrderWala.Domain;

namespace OrderWala.DAL
{
    public class CustomerRepository
    {
        public List<tblCustomerDTO> GetAllCustomer()
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblCustomers.ToList().ToDTOs();
            }
        }


        public int CustomerSave(tblCustomerDTO tblCustomerDTO)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                if (IsDuplicateCustomer(tblCustomerDTO.MobileNo, tblCustomerDTO.CustomerId))
                {
                    return 1;
                }

                if (tblCustomerDTO.CustomerId == 0)
                {
                    tblCustomerDTO.IsActive = true;
                    tblCustomerDTO.IsDeleted = true;
                    tblCustomerDTO.CreationDateTime = DateTime.Now;
                    OrderWalaContext.tblCustomers.Add(tblCustomerDTO.ToEntity());
                }
                else
                {
                    var customerdata = OrderWalaContext.tblCustomers.Where(ct => ct.CustomerId == tblCustomerDTO.CustomerId).FirstOrDefault();
                    customerdata.FirstName = tblCustomerDTO.FirstName;
                    customerdata.LastName = tblCustomerDTO.LastName;
                    customerdata.Address = tblCustomerDTO.Address;
                    customerdata.AreaId = tblCustomerDTO.AreaId;
                    customerdata.EmailAddress = tblCustomerDTO.EmailAddress;
                    customerdata.MobileNo = tblCustomerDTO.MobileNo;
                    customerdata.Latitude = tblCustomerDTO.Latitude;
                    customerdata.Longitude = tblCustomerDTO.Longitude;
                    customerdata.TotalOrderAmount = tblCustomerDTO.TotalOrderAmount;
                    customerdata.RecievedAmount = tblCustomerDTO.RecievedAmount;
                }

                if (OrderWalaContext.SaveChanges() > 0)
                {
                    return 0;
                }
                else
                {
                    return 2;
                }
            }
        }

        public tblCustomerDTO GetCustomerById(int Customerid)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                return OrderWalaContext.tblCustomers.Where(ct => ct.CustomerId == Customerid).FirstOrDefault().ToDTO();
            }
        }

        public bool CustomerDelete(int CustomerId)
        {
            using (var OrderWalaContext = new OrderWalaEntities())
            {
                var Customer = OrderWalaContext.tblCustomers.Where(ct => ct.CustomerId == CustomerId).FirstOrDefault();
                OrderWalaContext.tblCustomers.Remove(Customer);
                if (OrderWalaContext.SaveChanges() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool IsDuplicateCustomer(string MobileNo, int CustomerId)
        {
            using (var orderwalacontext = new OrderWalaEntities())
            {
                var customercount = orderwalacontext.tblCustomers.Where(ct => string.Compare(ct.MobileNo, MobileNo) == 0 && ct.CustomerId != CustomerId).ToList();

                return customercount.Count > 0 ? true : false;
            }
        }

    }
}
