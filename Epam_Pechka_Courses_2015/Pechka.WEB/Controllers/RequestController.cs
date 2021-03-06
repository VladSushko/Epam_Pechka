﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;


namespace Pechka.WEB.Controllers
{
    [Authorize(Roles="Admin")]
    public class RequestController : Controller
    {
        // GET: Request
        public ActionResult Index()
        {
            var a = User.Identity.Name;
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Index", "Admin");
            }
           
                return RedirectToAction("Index", "User");
            
        }
    }
}