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
                if (IsDuplicateCustomer(tblCustomerDTO.MobileNo, tblCustomerDTO.UserId))
                {
                    return 1;
                }

                if (tblCustomerDTO.UserId == 0)
                {
                    tblLogin tbllogin = new tblLogin();

                    tbllogin.MobileNo = tblCustomerDTO.MobileNo;
                    tbllogin.Password = tblCustomerDTO.Password;
                    tbllogin.UserTypeId = 1;
                    tbllogin.CreationDatetime = DateTime.Now;
                    tbllogin.IsActive = true;
                    tbllogin.RegisterDeviceId = 1;

                    OrderWalaContext.tblLogins.Add(tbllogin);
                    if (OrderWalaContext.SaveChanges() > 0)
                    {
                        tblCustomer tblcustomer = new tblCustomer();

                        tblcustomer.UserId = tbllogin.UserId;
                        tblcustomer.FirstName = tblCustomerDTO.FirstName;
                        tblcustomer.LastName = tblCustomerDTO.LastName;
                        tblcustomer.Address = tblCustomerDTO.Address;
                        tblcustomer.AreaId = tblCustomerDTO.AreaId;
                        tblcustomer.EmailAddress = tblCustomerDTO.EmailAddress;
                        tblcustomer.MobileNo = tblCustomerDTO.MobileNo;
                        tblcustomer.Latitude = tblCustomerDTO.Latitude;
                        tblcustomer.Longitude = tblCustomerDTO.Longitude;
                        tblcustomer.TotalOrderAmount = tblCustomerDTO.TotalOrderAmount;
                        tblcustomer.RecievedAmount = tblCustomerDTO.RecievedAmount;
                        tblcustomer.IsActive = true;

                        tblcustomer.IsDeleted = true;
                        tblcustomer.CreationDateTime = DateTime.Now;

                        OrderWalaContext.tblCustomers.Add(tblcustomer);
                    }

                   

                }
                //else
                //{
                //    var customerdata = OrderWalaContext.tblCustomers.Where(ct => ct.CustomerId == tblCustomerDTO.CustomerId).FirstOrDefault();
                //    customerdata.FirstName = tblCustomerDTO.FirstName;
                //    customerdata.LastName = tblCustomerDTO.LastName;
                //    customerdata.Address = tblCustomerDTO.Address;
                //    customerdata.AreaId = tblCustomerDTO.AreaId;
                //    customerdata.EmailAddress = tblCustomerDTO.EmailAddress;
                //    customerdata.MobileNo = tblCustomerDTO.MobileNo;
                //    customerdata.Latitude = tblCustomerDTO.Latitude;
                //    customerdata.Longitude = tblCustomerDTO.Longitude;
                //    customerdata.TotalOrderAmount = tblCustomerDTO.TotalOrderAmount;
                //    customerdata.RecievedAmount = tblCustomerDTO.RecievedAmount;
                //}

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


        //public int CustomerSave(tblCustomerDTO tblCustomerDTO)
        //{
        //    using (var OrderWalaContext = new OrderWalaEntities())
        //    {
        //        if (IsDuplicateCustomer(tblCustomerDTO.MobileNo, tblCustomerDTO.CustomerId))
        //        {
        //            return 1;
        //        }

        //        if (tblCustomerDTO.CustomerId == 0)
        //        {
        //            tblCustomerDTO.IsActive = true;
        //            tblCustomerDTO.IsDeleted = true;
        //            tblCustomerDTO.CreationDateTime = DateTime.Now;
        //            OrderWalaContext.tblCustomers.Add(tblCustomerDTO.ToEntity());
        //        }
        //        else
        //        {
        //            var customerdata = OrderWalaContext.tblCustomers.Where(ct => ct.CustomerId == tblCustomerDTO.CustomerId).FirstOrDefault();
        //            customerdata.FirstName = tblCustomerDTO.FirstName;
        //            customerdata.LastName = tblCustomerDTO.LastName;
        //            customerdata.Address = tblCustomerDTO.Address;
        //            customerdata.AreaId = tblCustomerDTO.AreaId;
        //            customerdata.EmailAddress = tblCustomerDTO.EmailAddress;
        //            customerdata.MobileNo = tblCustomerDTO.MobileNo;
        //            customerdata.Latitude = tblCustomerDTO.Latitude;
        //            customerdata.Longitude = tblCustomerDTO.Longitude;
        //            customerdata.TotalOrderAmount = tblCustomerDTO.TotalOrderAmount;
        //            customerdata.RecievedAmount = tblCustomerDTO.RecievedAmount;
        //        }

        //        if (OrderWalaContext.SaveChanges() > 0)
        //        {
        //            return 0;
        //        }
        //        else
        //        {
        //            return 2;
        //        }
        //    }
        //}

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
                var user = OrderWalaContext.tblLogins.Where(ut => ut.UserId == Customer.UserId).FirstOrDefault();

                OrderWalaContext.tblLogins.Remove(user);
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

        public bool IsDuplicateCustomer(string MobileNo, int UserId)
        {
            using (var orderwalacontext = new OrderWalaEntities())
            {
                var customercount = orderwalacontext.tblLogins.Where(ct => string.Compare(ct.MobileNo, MobileNo) == 0 && ct.UserId != UserId).ToList();

                return customercount.Count > 0 ? true : false;
            }
        }

    }
}
