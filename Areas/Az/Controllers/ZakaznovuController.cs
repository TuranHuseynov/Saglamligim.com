using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzmanAzWebPage.Models;

namespace AzmanAzWebPage.Areas.Az.Controllers
{
    public class ZakaznovuController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Az/Zakaznovu
        public ActionResult Index()
        {
            return View(db.Zakaznovus.ToList());
        }

        // GET: Az/Zakaznovu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakaznovu zakaznovu = db.Zakaznovus.Find(id);
            if (zakaznovu == null)
            {
                return HttpNotFound();
            }
            return View(zakaznovu);
        }

        // GET: Az/Zakaznovu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Az/Zakaznovu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "zakaznovu_id,zakaznovu_ad")] Zakaznovu zakaznovu)
        {
            if (ModelState.IsValid)
            {
                db.Zakaznovus.Add(zakaznovu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zakaznovu);
        }

        // GET: Az/Zakaznovu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakaznovu zakaznovu = db.Zakaznovus.Find(id);
            if (zakaznovu == null)
            {
                return HttpNotFound();
            }
            return View(zakaznovu);
        }

        // POST: Az/Zakaznovu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "zakaznovu_id,zakaznovu_ad")] Zakaznovu zakaznovu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakaznovu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zakaznovu);
        }

        // GET: Az/Zakaznovu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakaznovu zakaznovu = db.Zakaznovus.Find(id);
            if (zakaznovu == null)
            {
                return HttpNotFound();
            }
            return View(zakaznovu);
        }

        // POST: Az/Zakaznovu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zakaznovu zakaznovu = db.Zakaznovus.Find(id);
            db.Zakaznovus.Remove(zakaznovu);
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
