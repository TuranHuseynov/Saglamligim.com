using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzmanAzWebPage.Models;

namespace AzmanAzWebPage.Controllers
{
    public class ZakazimController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Zakazim
        public ActionResult Index()
        {
            var zakazims = db.Zakazims.Include(z => z.Zakaznovu);
            return View(zakazims.Where(s => s.zakaz_novu_id == 1).ToList());
        }


        public ActionResult IndexGorunen()
        {
            var zakazims = db.Zakazims.Include(z => z.Zakaznovu);
            return View(zakazims.Where(s => s.zakaz_novu_id == 2).ToList());
        }
        // GET: Zakazim/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazim zakazim = db.Zakazims.Find(id);
            if (zakazim == null)
            {
                return HttpNotFound();
            }
            return View(zakazim);
        }

        // GET: Zakazim/Create
        public ActionResult Create()
        {
            ViewBag.zakaz_novu_id = new SelectList(db.Zakaznovus, "zakaznovu_id", "zakaznovu_ad");
            return View();
        }

        // POST: Zakazim/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "zakazim_id,zakazim_adi_soyad,zakazim_telefon,zakazim_mehsul,zakaz_vaxti,zakaz_novu_id")] Zakazim zakazim)
        {
            if (ModelState.IsValid)
            {
                db.Zakazims.Add(zakazim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.zakaz_novu_id = new SelectList(db.Zakaznovus, "zakaznovu_id", "zakaznovu_ad", zakazim.zakaz_novu_id);
            return View(zakazim);
        }

        // GET: Zakazim/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazim zakazim = db.Zakazims.Find(id);
            if (zakazim == null)
            {
                return HttpNotFound();
            }
            ViewBag.zakaz_novu_id = new SelectList(db.Zakaznovus, "zakaznovu_id", "zakaznovu_ad", zakazim.zakaz_novu_id);
            return View(zakazim);
        }

        // POST: Zakazim/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "zakazim_id,zakazim_adi_soyad,zakazim_telefon,zakazim_mehsul,zakaz_vaxti,zakaz_novu_id")] Zakazim zakazim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zakazim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.zakaz_novu_id = new SelectList(db.Zakaznovus, "zakaznovu_id", "zakaznovu_ad", zakazim.zakaz_novu_id);
            return View(zakazim);
        }

        // GET: Zakazim/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zakazim zakazim = db.Zakazims.Find(id);
            if (zakazim == null)
            {
                return HttpNotFound();
            }
            return View(zakazim);
        }

        // POST: Zakazim/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zakazim zakazim = db.Zakazims.Find(id);
            db.Zakazims.Remove(zakazim);
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
