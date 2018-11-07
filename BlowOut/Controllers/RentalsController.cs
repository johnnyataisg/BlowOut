using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class RentalsController : Controller
    {
        static Instrument instrument = new Instrument();

        // GET: Rentals
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Instrument(string value)
        {
            if (value == "Trumpet")
            {
                instrument.Name = "Trumpet";
                instrument.ImageURL = "~/Content/trumpet.jpg";
                instrument.NewPrice = 55;
                instrument.UsedPrice = 25;
            }
            else if (value == "Trombone")
            {
                instrument.Name = "Trombone";
                instrument.ImageURL = "~/Content/trumpet.jpg";
                instrument.NewPrice = 60;
                instrument.UsedPrice = 35;
            }
            else if (value == "Tuba")
            {
                instrument.Name = "Tuba";
                instrument.ImageURL = "~/Content/trumpet.jpg";
                instrument.NewPrice = 70;
                instrument.UsedPrice = 50;
            }
            else if (value == "Flute")
            {
                instrument.Name = "Flute";
                instrument.ImageURL = "~/Content/trumpet.jpg";
                instrument.NewPrice = 40;
                instrument.UsedPrice = 25;
            }
            else if (value == "Clarinet")
            {
                instrument.Name = "Clarinet";
                instrument.ImageURL = "~/Content/trumpet.jpg";
                instrument.NewPrice = 35;
                instrument.UsedPrice = 27;
            }
            else
            {
                instrument.Name = "Saxophone";
                instrument.ImageURL = "~/Content/trumpet.jpg";
                instrument.NewPrice = 42;
                instrument.UsedPrice = 30;
            }
            instrument.Price = instrument.NewPrice;
            ViewBag.Output += "<div>";
            ViewBag.Logo += instrument.ImageURL;
            ViewBag.Output += "<p>" + instrument.Name + "</p>";
            ViewBag.Output += "<p>" + instrument.Price + "</p>";
            ViewBag.Output += "</div>";
            return View();
        }

        public ActionResult New()
        {
            instrument.Price = instrument.NewPrice;
            ViewBag.Output += "<div>";
            ViewBag.Output += "<img " + "src=\"" + instrument.ImageURL + "\">";
            ViewBag.Output += "<p>" + instrument.Name + "</p>";
            ViewBag.Output += "<p>" + instrument.Price + "</p>";
            ViewBag.Output += "</div>";
            return View("Instrument");
        }

        public ActionResult Used()
        {
            instrument.Price = instrument.UsedPrice;
            ViewBag.Output += "<div>";
            ViewBag.Output += "<img " + "src=\"" + instrument.ImageURL + "\">";
            ViewBag.Output += "<p>" + instrument.Name + "</p>";
            ViewBag.Output += "<p>" + instrument.Price + "</p>";
            ViewBag.Output += "</div>";
            return View("Instrument");
        }
    }
}