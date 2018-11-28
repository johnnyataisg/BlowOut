using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class AdminController : Controller
    {
        private BlowoutContext db = new BlowoutContext();

        // GET: Admin
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login user)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                if (user.Username == "Missouri" && user.Password == "ShowMe")
                {
                    return RedirectToAction("DisplayAll");
                }
                else
                {
                    ModelState.AddModelError("Username", "Username or password is incorrect");
                    ModelState.AddModelError("Password", "Username or password is incorrect");
                    return View();
                }
            }
        }

        public ActionResult DisplayAll()
        {
            List<FullOrder> allOrders = new List<FullOrder>();
            foreach (Client client in db.Clients.ToList())
            {
                Product product = db.Products.Where(instrument => instrument.instrumentID == client.instrumentID).FirstOrDefault();
                allOrders.Add(new FullOrder
                {
                    ClientID = client.clientID,
                    FirstName = client.firstName,
                    LastName = client.lastName,
                    Address = client.address,
                    City = client.city,
                    State = client.state,
                    Zip = client.zip,
                    Email = client.email,
                    Phone = client.phone,
                    Description = product.desc,
                    Type = product.type,
                    Price = product.price
                });
            }
            return View(allOrders);
        }

        public ActionResult SaveList(string[] values)
        {
            return Json(new { Result = string.Format("First item in list: '{0}'", values[0]) });
        }
    }
}