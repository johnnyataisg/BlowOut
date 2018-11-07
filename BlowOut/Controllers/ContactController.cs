using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.Models;
using System.Net;
using System.Net.Mail;


namespace BlowOut.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ViewBag.Message += "<p>";
            ViewBag.Message += "Please call Support at <b style=\"text-decoration: underline;\">801-555-1212</b>. Thank you!</p>";
            return View();
        }

        public ActionResult Email(string name, string email)
        {
            var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
            var message = new MailMessage();
            message.To.Add(new MailAddress(email));  // replace with valid value 
            message.From = new MailAddress("johnnypao43@gmail.com");  // replace with valid value
            message.Subject = "Thank you " + email;
            message.Body = "This is a confirmation email";
            message.IsBodyHtml = true;

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "johnnypao43@gmail.com",  // replace with valid value
                    Password = "HwP072696"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                ViewBag.Message += "<p>";
                ViewBag.Message += "Thank you " + name + ". We will send an email to " + email + "</p>";
                smtp.Send(message);
                return View();
            }
        }
    }
}