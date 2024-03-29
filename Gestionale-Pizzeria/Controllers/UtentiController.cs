﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Gestionale_Pizzeria.Models;

namespace Gestionale_Pizzeria.Controllers
{
    public class UtentiController : Controller
    {
        private ModelDbContext db = new ModelDbContext();

        // GET: Utenti
        public ActionResult Index()
        {
            var utenti = db.Utenti.Include(u => u.Ruoli);
            return View(utenti.ToList());
        }

        // GET: Utenti/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        // GET: Utenti/Create
        public ActionResult Create()
        {
            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuolo", "TipoRuoli");
            return View();
        }

        // POST: Utenti/Create
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdUtente,Username,Pwd,Nome,Cognome,Indirizzo,IdRuolo")] Utenti utenti)
        {
            if (ModelState.IsValid== true && db.Utenti.Where(user => user.Username == utenti.Username).Count() == 0 )
            {     
                db.Utenti.Add(utenti);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuolo", "TipoRuoli", utenti.IdRuolo);
            return View(utenti);
        }

        // GET: Utenti/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuolo", "TipoRuoli", utenti.IdRuolo);
            return View(utenti);
        }

        // POST: Utenti/Edit/5
        // Per la protezione da attacchi di overposting, abilitare le proprietà a cui eseguire il binding. 
        // Per altri dettagli, vedere https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUtente,Username,Pwd,Nome,Cognome,Indirizzo,IdRuolo")] Utenti utenti)
        {
            if (ModelState.IsValid)
            {
                db.Entry(utenti).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdRuolo = new SelectList(db.Ruoli, "IdRuolo", "TipoRuoli", utenti.IdRuolo);
            return View(utenti);
        }

        // GET: Utenti/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Utenti utenti = db.Utenti.Find(id);
            if (utenti == null)
            {
                return HttpNotFound();
            }
            return View(utenti);
        }

        // POST: Utenti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Utenti utenti = db.Utenti.Find(id);
            db.Utenti.Remove(utenti);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
