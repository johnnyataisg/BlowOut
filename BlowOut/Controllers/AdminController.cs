using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
                    return RedirectToAction("UpdateData");
                }
                else
                {
                    ModelState.AddModelError("Username", "Username or password is incorrect");
                    ModelState.AddModelError("Password", "Username or password is incorrect");
                    return View();
                }
            }
        }

        public ActionResult UpdateData()
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

        public ActionResult Delete(int[] values)
        {
            if (values != null)
            {
                foreach (int id in values)
                {
                    db.Clients.Remove(db.Clients.Find(id));
                }
                db.SaveChanges();
            }
            return Json(true);
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.instrumentID = new SelectList(db.Products, "instrumentID", "desc", client.instrumentID);
            return View(client);
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone,instrumentID")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DisplayAll");
            }
            ViewBag.instrumentID = new SelectList(db.Products, "instrumentID", "desc", client.instrumentID);
            return View(client); ;
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }
    }
}