using System;
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
        static Instrument instrument = new Instrument();
        private BlowoutContext blowout = new BlowoutContext();

        // GET: Rentals
        public ActionResult Index()
        {
            return View(blowout.Products.ToArray());
        }

        public ActionResult Create()
        {
            return View();
        }
        
        public ActionResult Instrument(string value)
        {
            if (value == "Trumpet")
            {
                instrument.Name = "Trumpet";
                instrument.ImageURL = "../Content/trumpet.jpg";
                instrument.NewPrice = 55;
                instrument.UsedPrice = 25;
            }
            else if (value == "Trombone")
            {
                instrument.Name = "Trombone";
                instrument.ImageURL = "../Content/trombone.jpg";
                instrument.NewPrice = 60;
                instrument.UsedPrice = 35;
            }
            else if (value == "Tuba")
            {
                instrument.Name = "Tuba";
                instrument.ImageURL = "../Content/tuba.jpg";
                instrument.NewPrice = 70;
                instrument.UsedPrice = 50;
            }
            else if (value == "Flute")
            {
                instrument.Name = "Flute";
                instrument.ImageURL = "../Content/flute.jpg";
                instrument.NewPrice = 40;
                instrument.UsedPrice = 25;
            }
            else if (value == "Clarinet")
            {
                instrument.Name = "Clarinet";
                instrument.ImageURL = "../Content/clarinet.jpg";
                instrument.NewPrice = 35;
                instrument.UsedPrice = 27;
            }
            else
            {
                instrument.Name = "Saxophone";
                instrument.ImageURL = "../Content/saxophone.jpg";
                instrument.NewPrice = 42;
                instrument.UsedPrice = 30;
            }
            instrument.Price = instrument.NewPrice;
            ViewBag.Output += "<div>";
            ViewBag.Logo += instrument.ImageURL;
            ViewBag.Output += "<h3>" + instrument.Name + "</h3>";
            ViewBag.Output += "<h3>Price: $" + instrument.Price + "/month</h3>";
            ViewBag.Output += "</div>";
            return View();
        }

        public ActionResult New()
        {
            instrument.Price = instrument.NewPrice;
            ViewBag.Output += "<div>";
            ViewBag.Logo += instrument.ImageURL;
            ViewBag.Output += "<h3>" + instrument.Name + "</h3>";
            ViewBag.Output += "<h3>Price: $" + instrument.Price + "/month</h3>";
            ViewBag.Output += "</div>";
            return View("Instrument");
        }

        public ActionResult Used()
        {
            instrument.Price = instrument.UsedPrice;
            ViewBag.Output += "<div>";
            ViewBag.Logo += instrument.ImageURL;
            ViewBag.Output += "<h3>" + instrument.Name + "</h3>";
            ViewBag.Output += "<h3>Price: $" + instrument.Price + "/month</h3>";
            ViewBag.Output += "</div>";
            return View("Instrument");
        }
    }
}