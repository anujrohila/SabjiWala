using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace adminsite.Models.DTO
{
    public class orderdto
    {
        public TblCategoryMaster categoryData { get; set; }
        public TblSubCategoryMaster subcatData { get; set; }
        public TblProductMaster productData { get; set; }
        public TblEmployeeTypeMaster employeeTypeData { get; set; }
        public TblEmployeeMaster employeeData { get; set; }
        public TblCustomerMaster customerData { get; set; }
        public TblLanguageMaster languageData { get; set; }
        public TblSupplierMaster supplierData { get; set; }
        public TblAdminLoginMaster AdminData { get; set; }
        public TblUserLoginMaster userloginData { get; set; }
        public TblOrderMaster orderData { get; set; }
        public TblOrderItemDetailMaster orderitemData { get; set; }
        public TblAddressMaster AddressData { get; set; }
        public TblOrderStatusMaster orderstatusData { get; set; }
        public TblProductStatusMaster productstatusData { get; set; }

    }

    public class subcategorydto
    {
        public int sid { get; set; }
        public string cname { get; set; }
        public string sname { get; set; }
        public string simage { get; set; }
    }

    public class productdto
    {
        public int pid { get; set; }
        public string cname { get; set; }
        public string sname { get; set; }
        public string pname { get; set; }
        public string pimage { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public string language { get; set; }
    }

    public class employeedto
    {
        public int empid { get; set; }
        public string empname { get; set; }
        public string emptype { get; set; }
        public string address { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string emailid { get; set; }
    }

    public class custdto
    {
        public int custid { get; set; }
        public string custname { get; set; }
        public string password { get; set; }
        public string displayname { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string emailid { get; set; }
        public string language { get; set; }
    }

    public class supplierdto
    {
        public int suppid { get; set; }
        public int userid { get; set; }
        public string suppname { get; set; }
        public string password { get; set; }
        public string organization { get; set; }
        public string fname { get; set; }
        public string mname { get; set; }
        public string lname { get; set; }
        public string emailid { get; set; }
        public string language { get; set; }
        public string address { get; set; }
    }


    public class Admindto
    {
        public int adminid { get; set; }
        public string adminName { get; set; }
        public string password { get; set; }
        public string NewPassword { get; set; }
        public string confirmPassword { get; set; }
    }


    public class Userlogindto
    {
        public int userid { get; set; }
        public string username { get; set; }
        public string upassword { get; set; }
    }


    public class ordermasterdto
    {
        public int orderid { get; set; }
        public string customer { get; set; }
        public string address { get; set; }
        public string orderstatus { get; set; }
        public DateTime orderdatetime { get; set; }
        public string employee { get; set; }
    }

    public class orderItemDetaildto
    {
        public int orderitemid { get; set; }
        public int orderid { get; set; }
        public string product { get; set; }
        public double quantity { get; set; }
        public double price { get; set; }
        public double discount { get; set; }
        public double totalamount { get; set; }
        public string productstatus { get; set; }

    }

    //public class orderList
    //{
    //    public int orderid { get; set; }
    //    public string customer { get; set; }
    //    public string address { get; set; }
    //    public string orderstatus { get; set; }
    //    public DateTime orderdatetime { get; set; }
    //    public string employee { get; set; }
    //    public int orderitemid { get; set; }
    //    public string product { get; set; }
    //    public double quantity { get; set; }
    //    public double price { get; set; }
    //    public double discount { get; set; }
    //    public double totalamount { get; set; }
    //    public string productstatus { get; set; }

    //}
}
