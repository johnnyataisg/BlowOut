﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BlowOut.Models;

namespace BlowOut.Controllers
{
    public class AdminController : Controller
    {
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
            return View();
        }
    }
}