﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PryDelivery.Controllers
{
    public class CerrarController : Controller
    {
        // GET: Cerrar
        public ActionResult LogOff()
        {
            Session["User"] = null;


            return RedirectToAction("Login", "Login");
        }
    }
}