using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.Models;

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
            //"Thank you Scott. We will send an email to test@test.com")
            ViewBag.Message += "<p>";
            ViewBag.Message += "Thank you " + name + ". We will send an email to " + email + "</p>";
            return View();
        }
    }
}