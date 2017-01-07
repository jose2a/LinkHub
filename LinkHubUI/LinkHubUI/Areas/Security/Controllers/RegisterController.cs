﻿using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkHubUI.Areas.Security.Controllers
{
    public class RegisterController : BaseSecurityController
    {
        // GET: Security/Register
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    user.Role = "U";
                    objBs.userBs.Insert(user);
                    TempData["Msg"] = "Registered successfully.";
                }
                return View("Index");

            }
            catch (Exception e)
            {
                TempData["Msg"] = "Registration failed. " + e.Message;
                return View("Index");
            }

        }
    }
}