using adminsite.Models;
using adminsite.Models.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace adminsite.Controllers
{
    [OutputCache(NoStore = true, Duration = 0, Location = OutputCacheLocation.None)]
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        private OrderManagmentEntities db = new OrderManagmentEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            CommonFunction cf = new CommonFunction();
          //  cf.sendEmail("vashumakwana8892@gmail.com");
            return View();
        }

        [HttpPost, ActionName("login")]
        public ActionResult loginData(TblAdminLoginMaster admin)
        {
            if (ModelState.IsValid)
            {
                var v = db.TblAdminLoginMasters.Where(a => a.AdminName.Equals(admin.AdminName) && a.Password.Equals(admin.Password)).FirstOrDefault();
                if (v != null)
                {
                    Session["AdminName"] = v.AdminName.ToString();
                    Session["adminid"] = v.AdminID;
                    Session["DisplayName"] = v.DisplayName.ToString();
                    Session["EmailID"] = v.EmailID.ToString();
                    Session["Address"] = v.Address.ToString();
                    Session["MobileNo"] = v.MobileNo.ToString();
                   
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    
                    TempData["Error"] = "Wrong username & Password";
                    return RedirectToAction("login");
                }
            }

            return View(admin);
        }

        //Change Admin Password

        [HttpGet]
        public ActionResult ChangePassword1(int id=0)
        {
            TblAdminLoginMaster admin = db.TblAdminLoginMasters.Where(a => a.AdminID == id).FirstOrDefault();
            return View(admin);
        }

        [HttpPost]
        public ActionResult ChangePassword1(Admindto  adm)
        {
            if (Session["adminid"] != null)
            {
                var v=int.Parse(Session["adminid"].ToString());
                               
                TblAdminLoginMaster temp = db.TblAdminLoginMasters.Where(h => h.AdminID.Equals(v) && h.Password.Equals(adm.password)).FirstOrDefault();
                if (temp != null)
                {
                    temp.Password = adm.NewPassword;
                    temp.UpdatedBy = int.Parse(Session["AdminName"].ToString());
                    temp.UpdatedDateTime = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return View(adm);
                }
               
            }
            return View(adm);     
        }


        //Admin Profile 
        
        public ActionResult Profile1(TblAdminLoginMaster admin)
        {
            if (Session["adminid"] != null)
            {
                var v = int.Parse(Session["adminid"].ToString());
                TblAdminLoginMaster adm = db.TblAdminLoginMasters.Where(a => a.AdminID == v).FirstOrDefault();
                return View(adm);
            }
            return View(admin);
        }

        [HttpGet]
        public ActionResult ProfileEdit(TblAdminLoginMaster admin)
        {
            if (Session["adminid"] != null)
            {
                var v = int.Parse(Session["adminid"].ToString());
                TblAdminLoginMaster adm = db.TblAdminLoginMasters.Where(a => a.AdminID == v).FirstOrDefault();
                return View(adm);
            }
            return View(admin);
        }
        [HttpPost]
        public ActionResult ProfileEdit(TblAdminLoginMaster admin, HttpPostedFileBase file)
        {
            TblAdminLoginMaster temp = db.TblAdminLoginMasters.Where(h => h.AdminID == admin.AdminID).FirstOrDefault();
            temp.AdminName = admin.AdminName;
            temp.Address = admin.Address;
            temp.MobileNo = admin.MobileNo;
            temp.EmailID = admin.EmailID;
         
            string pic = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(System.IO.Path.GetFileName(file.FileName));
            string path = System.IO.Path.Combine(Server.MapPath("~/Images/Admin/"), pic);
            temp.AdminProfile = pic;
            file.SaveAs(path);


            temp.UpdatedBy = int.Parse(Session["AdminName"].ToString());
            temp.UpdatedDateTime = DateTime.Now;

            if (db.SaveChanges() > 0)
                return RedirectToAction("Profile1");
            else
                return View(admin);
        }



        [HttpGet]
        public ActionResult forgotpassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult forgotpassword(String EmailID)
        {
            try
            {
                Random Rnumber = new Random();
                string newpassword = Rnumber.Next(100000, 999999).ToString();


                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.IsBodyHtml = true;
                mail.From = new MailAddress(ConfigurationManager.AppSettings["FROM_EMAIL"]);
                mail.To.Add(EmailID);
                mail.Subject = "Test Mail";
                mail.Body = "<p>Dear user ...<br> Your new Password Is:<b>" + newpassword + "</b></p></br><p>Thank you,<br> SABJI MARKET..</p>";
               
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["FROM_EMAIL"], ConfigurationManager.AppSettings["EMAIL_PASSWORD"]);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                TblAdminLoginMaster obj = db.TblAdminLoginMasters.Where(a => a.EmailID == EmailID).FirstOrDefault();
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


           }
}
