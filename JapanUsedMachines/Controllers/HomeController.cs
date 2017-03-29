using JapanUsedMachines.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Net;


namespace JapanUsedMachines.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Contact(Contact contact)
        {
            bool IsEmailSent = false;

           
            SmtpClient smtp = new SmtpClient();

            try
            {
                MailMessage Msg = new MailMessage();
                // Sender e-mail address.
                Msg.From = new MailAddress("info@japanusedmachines.com");
                // Recipient e-mail address.
                Msg.To.Add("info@japanusedmachines.com");
                //Msg.Subject = txtSubject.Text;
                //Msg.Body = "some body message";
                //Msg.Subject = "New Enquiry";



                string messageBody = "Dear Admin," + Environment.NewLine + "New enquiry details are as follows :" + Environment.NewLine + Environment.NewLine + "First Name : " + contact.FirstName + " ; " + Environment.NewLine;
                StringBuilder messageBodyBuilder = new StringBuilder(messageBody);
                messageBodyBuilder.Append("Last Name : " + contact.LastName + " ; "+ Environment.NewLine);
                messageBodyBuilder.Append("Email : " + contact.Email + " ; "+ Environment.NewLine);
                messageBodyBuilder.Append("Telephone : " + contact.MobileNumber + " ; "+ Environment.NewLine);
                messageBodyBuilder.Append("Comments : " + contact.Message + Environment.NewLine + Environment.NewLine);
                messageBodyBuilder.Append("Regards,"+ Environment.NewLine + "info-team");
                Msg.Body = messageBodyBuilder.ToString();

                smtp.Host = "relay-hosting.secureserver.net";
                smtp.Send(Msg);

                IsEmailSent = true;
            }
            catch (Exception ex)
            {
                IsEmailSent = false;
            }

            return Json(IsEmailSent, JsonRequestBehavior.AllowGet);
            
        }
    }
}