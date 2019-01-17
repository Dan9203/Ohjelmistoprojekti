using System;
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
    public class OsaamisaiheController : Controller
    {
        private ohjelmistodataEntities db = new ohjelmistodataEntities();

        // GET: Osaamisaihe
        public ActionResult Index()
        {
            return View(db.Osaamisaiheet.ToList());
        }

        // GET: Osaamisaihe/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osaamisaiheet osaamisaiheet = db.Osaamisaiheet.Find(id);
            if (osaamisaiheet == null)
            {
                return HttpNotFound();
            }
            return View(osaamisaiheet);
        }

        // GET: Osaamisaihe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Osaamisaihe/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OsaamisaiheID,Kuvaus")] Osaamisaiheet osaamisaiheet)
        {
            if (ModelState.IsValid)
            {
                db.Osaamisaiheet.Add(osaamisaiheet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(osaamisaiheet);
        }

        // GET: Osaamisaihe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osaamisaiheet osaamisaiheet = db.Osaamisaiheet.Find(id);
            if (osaamisaiheet == null)
            {
                return HttpNotFound();
            }
            return View(osaamisaiheet);
        }

        // POST: Osaamisaihe/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OsaamisaiheID,Kuvaus")] Osaamisaiheet osaamisaiheet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(osaamisaiheet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(osaamisaiheet);
        }

        // GET: Osaamisaihe/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Osaamisaiheet osaamisaiheet = db.Osaamisaiheet.Find(id);
            if (osaamisaiheet == null)
            {
                return HttpNotFound();
            }
            return View(osaamisaiheet);
        }

        // POST: Osaamisaihe/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Osaamisaiheet osaamisaiheet = db.Osaamisaiheet.Find(id);
            db.Osaamisaiheet.Remove(osaamisaiheet);
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
