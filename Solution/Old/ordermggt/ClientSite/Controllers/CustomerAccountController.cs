using ClientSite.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Web.UI;

namespace ClientSite.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]

    public class CustomerAccountController : Controller
    {
        //
        // GET: /CustomerAccount/
        OrderManagmentEntities db = new OrderManagmentEntities();

        public void setdata()
        {
            ViewBag.Lang = db.TblLanguageMasters.ToList<TblLanguageMaster>();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Myaccount()
        {
            return View();
        }



        //User Registration

        [HttpGet]
        public ActionResult userRegistration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult userRegistration(TblUserLoginMaster Model)
        {
            var check = db.TblUserLoginMasters.Where(h => h.UserName == Model.UserName).FirstOrDefault();
            if (check == null)
            {
                if (ModelState.IsValid)
                {

                    Model.IsActive = true;

                    // Model.CreatedBy = int.Parse(Session["AdminName"].ToString());
                    Model.CreatedDateTime = DateTime.Now;
                    Model.TypeID = 2;
                    db.TblUserLoginMasters.Add(Model);
                    db.SaveChanges();

                    Session["UserName"] = Model.UserName;
                    Session["Password"] = Model.Password;
                    Session["UserID"] = Model.UserID;
                    return RedirectToAction("CustRegistration", "CustomerAccount");
                }
                return View(Model);
            }
            else
            {
                ViewBag.actionmsg = "0";
                ViewBag.userNAME = check.UserName;
                return View(Model);
            }
        }

        //Customer Registration

        [HttpGet]
        public ActionResult CustRegistration()
        {
            setdata();
            return View();
        }

        [HttpPost]
        public ActionResult CustRegistration(TblCustomerMaster Model)
        {
            setdata();
            var check = db.TblCustomerMasters.Where(h => h.EmailId == Model.EmailId).FirstOrDefault();

            if (check == null)
            {
                if (ModelState.IsValid)
                {
                    if (Session["UserName"] != null)
                    {

                        Model.CustomerName = Session["UserName"].ToString();
                        Model.Password = Session["Password"].ToString();
                        Model.UserID = int.Parse(Session["UserID"].ToString());
                        Model.IsActive = true;
                        // Model.CreatedBy = int.Parse(Session["AdminName"].ToString());
                        Model.CreatedDateTime = DateTime.Now;
                        db.TblCustomerMasters.Add(Model);
                        db.SaveChanges();
                        ViewBag.actionmsg = "1";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View(Model);
                    }
                }
                return View(Model);
            }
            else
            {
                ViewBag.actionmsg = "0";
                ViewBag.email = check.EmailId;
                return View(Model);
            }


        }

        //My Address
        [HttpGet]
        public ActionResult MyAddress()
        {

            if (Session["UserId"] != null)
            {

                var v = int.Parse(Session["customerId"].ToString());
                var Address = db.TblAddressMasters.Where(x => x.CustomerID == v).ToList();
                return View(Address);

            }
            return View();

        }

        //Edit Customer Address
        [HttpGet]
        public ActionResult EditAddress(int id = 0)
        {
            setdata();
            TblAddressMaster address = db.TblAddressMasters.Where(h => h.AddressID == id).FirstOrDefault();
            return View(address);
        }

        [HttpPost]
        public ActionResult EditAddress(TblAddressMaster adr)
        {
            TblAddressMaster temp = db.TblAddressMasters.Where(h => h.AddressID == adr.AddressID).FirstOrDefault();
            var check = db.TblAddressMasters.Where(h => h.Address == adr.Address && h.AddressID != adr.AddressID).FirstOrDefault();
            if (check == null)
            {

                temp.Address = adr.Address;
                //  temp.UpdatedBy = int.Parse(Session["Displayname"].ToString());
                temp.UpdatedDateTime = DateTime.Now;
                if (db.SaveChanges() > 0)
                    return RedirectToAction("MyAddress", "CustomerAccount");
                else
                    return View(adr);
            }

            return View(adr);
        }


        //Delete Customer Address
        [HttpGet]
        public ActionResult DeleteAddress(int id)
        {
            TblAddressMaster ad = db.TblAddressMasters.Where(h => h.AddressID == id).FirstOrDefault();
            db.TblAddressMasters.Remove(ad);
            db.SaveChanges();
            return View();
        }


        //Add Address
        [HttpGet]
        public ActionResult AddAddress()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAddress(TblAddressMaster model)
        {
            if (Session["UserId"] != null)
            {
                model.CustomerID = int.Parse(Session["customerId"].ToString());
                model.CreatedDateTime = DateTime.Now;
                db.TblAddressMasters.Add(model);
                db.SaveChanges();
                return RedirectToAction("MyAddress", "CustomerAccount");
            }
            else
            {
                return View(model);
            }
        }


        //User Information
        public ActionResult UserInformation(TblCustomerMaster cust)
        {
            if (Session["UserId"] != null)
            {
                var v = int.Parse(Session["customerId"].ToString());
                TblCustomerMaster customer = db.TblCustomerMasters.Where(x => x.CustomerID == v).FirstOrDefault();
                return View(customer);
            }
            return View(cust);
        }


        //Edit User Information
        [HttpGet]
        public ActionResult EditUserInformation(TblCustomerMaster cust)
        {
            if (Session["UserId"] != null)
            {
                var v = int.Parse(Session["customerId"].ToString());
                TblCustomerMaster customer = db.TblCustomerMasters.Where(x => x.CustomerID == v).FirstOrDefault();
                return View(customer);
            }
            return View();
        }

        [HttpPost, ActionName("EditUserInformation")]
        public ActionResult EditInformation(TblCustomerMaster cust)
        {
           

                var check = db.TblCustomerMasters.Where(h => h.CustomerID != cust.CustomerID && (h.EmailId == cust.EmailId || h.CustomerName == cust.CustomerName)).ToList();
               
                    if (check.Count == 0)
                    {
                        if (ModelState.IsValid)
                        {

                        TblCustomerMaster temp = db.TblCustomerMasters.Where(h => h.CustomerID == cust.CustomerID).FirstOrDefault();
                        temp.CustomerName = cust.CustomerName;
                        temp.DisplayName = cust.DisplayName;
                        // temp.Password = cust.Password;
                        temp.FirstName = cust.FirstName;
                        temp.MiddleName = cust.MiddleName;
                        temp.LastName = cust.LastName;
                        temp.EmailId = cust.EmailId;
                        //temp.LanguageID = cust.LanguageID;
                        temp.IsActive = true;
                        // temp.UpdatedBy = int.Parse(Session["Customername"].ToString());
                        temp.UpdatedDateTime = DateTime.Now;

                        if (db.SaveChanges() > 0)
                            return RedirectToAction("UserInformation", "CustomerAccount");
                        else
                            return View(cust);

                    }

                    return View(cust);
                }
                else
                {
                    //  ViewBag.actionmsg = "0";
                    // ViewBag.email = check.EmailId;
                    return View(cust);
                }
           


            //if (Session["customerId"] != null)
            //{

            //    TblCustomerMaster temp = db.TblCustomerMasters.Where(h => h.CustomerID == cust.CustomerID).FirstOrDefault();
            //    temp.CustomerName = cust.CustomerName;
            //    temp.EmailId = cust.EmailId;
            //    temp.FirstName = cust.FirstName;
            //    temp.MiddleName = cust.MiddleName;
            //    temp.LastName = cust.LastName;
            //    temp.DisplayName = cust.DisplayName;
            //    temp.UpdatedDateTime = DateTime.Now;
            //    if (db.SaveChanges() > 0)
            //        return RedirectToAction("UserInformation", "CustomerAccount");
            //    else
            //        return View(cust);
            //}
            //return View(cust);
        }

        [HttpGet]
        public ActionResult CustLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CustLogin(TblUserLoginMaster user)
        {
            if (ModelState.IsValid)
            {
                var v = db.TblUserLoginMasters.Where(a => a.UserName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                if (v != null)
                {
                    var x = db.TblCustomerMasters.Where(a => a.CustomerName.Equals(user.UserName) && a.Password.Equals(user.Password)).FirstOrDefault();
                    if (x != null)
                    {
                        Session["customerId"] = x.CustomerID;
                        Session["Customername"] = x.CustomerName.ToString();
                        Session["Displayname"] = x.DisplayName.ToString();
                        Session["UserId"] = v.UserID;
                        return RedirectToAction("Index", "Home");
                    }

                    return View(user);
                }
                else
                {

                    TempData["Error"] = "Wrong username & Password";
                    return RedirectToAction("CustLogin", "CustomerAccount");
                }
            }

            return View(user);
        }

        [HttpGet]
        public ActionResult forgotpassword()
        {
            return View();
        }
        [HttpPost, ActionName("forgotpassword")]
        public ActionResult forgotpassword(String EmailId)
        {
            try
            {
                Random Rnumber = new Random();
                string newpassword = Rnumber.Next(100000, 999999).ToString();


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(ConfigurationManager.AppSettings["FROM_EMAIL"]);
                mail.To.Add(EmailId);
                mail.Subject = "Test Mail";
                mail.Body = "<p>Dear user ...<br> Your new Password Is:<b>" + newpassword + "</b></p></br><p>Thank you,<br> SABJI MARKET..</p>";

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FROM_EMAIL"], ConfigurationManager.AppSettings["EMAIL_PASSWORD"]);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                TblCustomerMaster obj = db.TblCustomerMasters.Where(a => a.EmailId == EmailId).FirstOrDefault();
                obj.Password = newpassword;
                db.SaveChanges();



                //MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.ToString());
            }
            return View();
        }

        public ActionResult userLogout()
        {
            if (Session["UserId"] != null)
            {
               Session["Displayname"] = null;
               Session["UserId"] = null;
               Session["customerId"] = null;
               Response.Cache.SetCacheability(HttpCacheability.NoCache);
               Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
               Response.Cache.SetNoStore();
            }
            return View();
        }
    }
}
