﻿using Gestionale_Pizzeria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gestionale_Pizzeria.Controllers
{
    public class AreaRiservataController : Controller
    {
        private ModelDbContext db = new ModelDbContext();
        // GET: AreaRiservata
        public ActionResult Index()
        {
            return View(db.Prodotti.ToList());
        }
    }
}