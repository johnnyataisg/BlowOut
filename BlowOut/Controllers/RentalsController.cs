﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BlowOut.DAL;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class RentalsController : Controller
    {
        private BlowoutContext blowout = new BlowoutContext();

        // GET: Rentals
        public ActionResult Index()
        {
            return View(blowout.Products.ToArray());
        }

        [HttpGet]
        public ActionResult Create(int value)
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "clientID,firstName,lastName,address,city,state,zip,email,phone")] Client client, int value)
        {
            if (ModelState.IsValid)
            {
                client.instrumentID = value;
                blowout.Clients.Add(client);
                blowout.SaveChanges();

                List<Product> products = blowout.Products.ToList();
                Product instrument = new Product();
                foreach(Product item in products)
                {
                    if (item.instrumentID == value)
                    {
                        instrument = item;
                    }
                }
                ViewBag.Output += "<h5>Thank you " + client.firstName + " " + client.lastName + " for your purchase</h5>";
                ViewBag.Output += "<h5>Order ID: " + client.clientID + "</h5>";
                ViewBag.Output += "<h5>Instrument Purchased: " + instrument.desc + "</h5>";
                ViewBag.Output += "<h5>Instument Type: " + instrument.type + "</h5>";
                ViewBag.Output += "<h5>Monthly Price: $" + instrument.price + "</h5>";
                ViewBag.Output += "<h5>Total payment after 18 months: $" + instrument.price * 18 + "</h5>";
                ViewBag.Output += "<div style=\"padding-top: 5%;\">";
                ViewBag.Output += "<img style=\"border-radius: 50%;\" src=\"" + instrument.image + "\"/>";
                ViewBag.Output += "</div>";
                return View("Confirmation"); 
            }

            return View(client);
        }
    }
}