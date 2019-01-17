﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ohjelmistoprojekti.Models;

namespace Ohjelmistoprojekti.Controllers
{
    public class HenkilonOsaamisController : Controller
    {
        private ohjelmistodataEntities db = new ohjelmistodataEntities();

        // GET: HenkilonOsaamis
        public ActionResult Index()
        {
            var henkilonOsaamiset = db.HenkilonOsaamiset.Include(h => h.Henkilot).Include(h => h.Osaamisaiheet);
            return View(henkilonOsaamiset.ToList());
        }

        // GET: HenkilonOsaamis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HenkilonOsaamiset henkilonOsaamiset = db.HenkilonOsaamiset.Find(id);
            if (henkilonOsaamiset == null)
            {
                return HttpNotFound();
            }
            return View(henkilonOsaamiset);
        }

        // GET: HenkilonOsaamis/Create
        public ActionResult Create()
        {
            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi");
            ViewBag.OsaamisaiheID = new SelectList(db.Osaamisaiheet, "OsaamisaiheID", "Kuvaus");
            return View();
        }

        // POST: HenkilonOsaamis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HenkilonOsaamisID,OsaamisaiheID,HenkiloID,Osaamistaso")] HenkilonOsaamiset henkilonOsaamiset)
        {
            if (ModelState.IsValid)
            {
                db.HenkilonOsaamiset.Add(henkilonOsaamiset);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi", henkilonOsaamiset.HenkiloID);
            ViewBag.OsaamisaiheID = new SelectList(db.Osaamisaiheet, "OsaamisaiheID", "Kuvaus", henkilonOsaamiset.OsaamisaiheID);
            return View(henkilonOsaamiset);
        }

        // GET: HenkilonOsaamis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HenkilonOsaamiset henkilonOsaamiset = db.HenkilonOsaamiset.Find(id);
            if (henkilonOsaamiset == null)
            {
                return HttpNotFound();
            }
            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi", henkilonOsaamiset.HenkiloID);
            ViewBag.OsaamisaiheID = new SelectList(db.Osaamisaiheet, "OsaamisaiheID", "Kuvaus", henkilonOsaamiset.OsaamisaiheID);
            return View(henkilonOsaamiset);
        }

        // POST: HenkilonOsaamis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HenkilonOsaamisID,OsaamisaiheID,HenkiloID,Osaamistaso")] HenkilonOsaamiset henkilonOsaamiset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(henkilonOsaamiset).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HenkiloID = new SelectList(db.Henkilot, "HenkiloID", "Etunimi", henkilonOsaamiset.HenkiloID);
            ViewBag.OsaamisaiheID = new SelectList(db.Osaamisaiheet, "OsaamisaiheID", "Kuvaus", henkilonOsaamiset.OsaamisaiheID);
            return View(henkilonOsaamiset);
        }

        // GET: HenkilonOsaamis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HenkilonOsaamiset henkilonOsaamiset = db.HenkilonOsaamiset.Find(id);
            if (henkilonOsaamiset == null)
            {
                return HttpNotFound();
            }
            return View(henkilonOsaamiset);
        }

        // POST: HenkilonOsaamis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HenkilonOsaamiset henkilonOsaamiset = db.HenkilonOsaamiset.Find(id);
            db.HenkilonOsaamiset.Remove(henkilonOsaamiset);
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
