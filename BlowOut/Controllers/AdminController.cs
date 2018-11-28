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
            List<Client> allClients = db.Clients.ToList();

            return View();
        }
    }
}