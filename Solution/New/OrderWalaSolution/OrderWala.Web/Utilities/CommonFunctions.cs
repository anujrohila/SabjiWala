using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace OrderWala.Web
{
    public static class CommonFunctions
    {

        #region [Variable]

        public static string WebAdminMailAccount = System.Configuration.ConfigurationManager.AppSettings["WebAdminMailAccount"];

        /// <summary>
        /// Get ContentUrlPrefix
        /// </summary>
        public static string WebUrlPrefix
        {
            get
            {
                return Convert.ToString(System.Configuration.ConfigurationManager.AppSettings["WebUrlPrefix"]);
            }
        }

        #endregion

        #region [Methods]

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool SendEmail(string toAddress, string subject, string body)
        {
           
            try
            {
                if (CommonFunctions.WebUrlPrefix.Contains("ltsplatform.net"))
                {
                    string senderID = "info@ltsplatform.net";// use sender’s email id here..
                    string senderPassword = "Ltsplatform!1";
                    MailAddress mailfrom = new MailAddress("info@ltsplatform.net");
                    MailAddress mailto = new MailAddress(toAddress);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    newmsg.Subject = subject;
                    newmsg.Body = body;
                    newmsg.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("ltsplatform.net");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(senderID, senderPassword);

                    smtp.Send(newmsg);
                }
                else
                {
                    string senderID = "info@skynettechnosys.com";// use sender’s email id here..
                    string senderPassword = "Sky@Net@121";
                    MailAddress mailfrom = new MailAddress("admin@skynettechnosys.com");
                    MailAddress mailto = new MailAddress(toAddress);
                    MailMessage newmsg = new MailMessage(mailfrom, mailto);

                    newmsg.Subject = subject;
                    newmsg.Body = body;
                    newmsg.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("relay-hosting.secureserver.net");
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(senderID, senderPassword);

                    smtp.Send(newmsg);
                }
                
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Send email
        /// </summary>
        /// <param name="toAddress"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool SendEmail1(string toAddress, string subject, string body)
        {
            //string senderID = "skynetexpertteam@gmail.com";// use sender’s email id here..
            //const string senderPassword = "Sky@Net@121"; // sender password here…
            string senderID = "anuj.rohila94@gmail.com";// use sender’s email id here..
            const string senderPassword = "itmc123!A_gmail"; // sender password here…
            try
            {
                //SmtpClient smtp = new SmtpClient
                //{
                //    Host = "smtp.gmail.com", // smtp server address here…
                //    Port = 587,
                //    EnableSsl = true,
                //    DeliveryMethod = SmtpDeliveryMethod.Network,
                //    Credentials = new System.Net.NetworkCredential(senderID, senderPassword),
                //    Timeout = 30000
                //};

                //MailMessage message = new MailMessage(senderID, toAddress, subject, body);
                //message.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                //message.IsBodyHtml = true;
                //smtp.Send(message);

                MailMessage msg = new MailMessage();
                //Add your email address to the recipients
                msg.To.Add(toAddress);
                //Configure the address we are sending the mail from
                MailAddress address = new MailAddress(toAddress);
                msg.From = address;
                msg.Subject = subject;
                msg.Body = body;
                msg.IsBodyHtml = true;

                //Configure an SmtpClient to send the mail.            
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 25;

                //Setup credentials to login to our sender email address ("UserName", "Password")
                NetworkCredential credentials = new NetworkCredential(senderID, senderPassword);
                client.UseDefaultCredentials = true;
               
                client.Credentials = credentials;
                //Send the msg
                client.Send(msg);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Get Hash Value
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string HashPassword(string password)
        {
            var sha256 = new SHA384Managed();
            return Convert.ToBase64String(sha256.ComputeHash(UTF8Encoding.UTF8.GetBytes(String.Concat(password, System.Web.HttpContext.Current.Application["PasswordSalt"]))));
        }

        #endregion

    }
}