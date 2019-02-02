using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AzmanAzWebPage.Models;

namespace AzmanAzWebPage.Controllers
{
    public class KampanyasController : Controller
    {
        private DB_A3E145_SaglamligimEntities db = new DB_A3E145_SaglamligimEntities();

        // GET: Kampanyas
        public ActionResult Index()
        {
            return View(db.Kampanyas.ToList());
        }

        // GET: Kampanyas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanyas.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            return View(kampanya);
        }

        // GET: Kampanyas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Kampanyas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Kampanya kampanya, HttpPostedFileBase kampanya_photo)
        {
            if (ModelState.IsValid)
            {
                var file_name = Path.GetFileName(kampanya_photo.FileName);
                var src = Path.Combine(Server.MapPath("~/Yuklenen"), file_name);
                kampanya_photo.SaveAs(src);

                kampanya.kampanya_photo = Path.GetFileName(kampanya_photo.FileName);
                db.Kampanyas.Add(kampanya);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kampanya);
        }

        // GET: Kampanyas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanyas.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            return View(kampanya);
        }

        // POST: Kampanyas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "kampanya_id,kampanya_adi,kampanya_mehsullari,kampanya_qiymeti,kampanya_info,kampanya_link")] Kampanya kampanya, HttpPostedFileBase kampanya_photo)
        {
            if (ModelState.IsValid)
            {
                var file_adi = Path.GetFileName(kampanya_photo.FileName);
                var sorc = Path.Combine(Server.MapPath("~/Yuklenen"), file_adi);
                kampanya_photo.SaveAs(sorc);
                kampanya.kampanya_photo = Path.GetFileName(kampanya_photo.FileName);


                db.Entry(kampanya).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kampanya);
        }

        // GET: Kampanyas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kampanya kampanya = db.Kampanyas.Find(id);
            if (kampanya == null)
            {
                return HttpNotFound();
            }
            return View(kampanya);
        }

        // POST: Kampanyas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kampanya kampanya = db.Kampanyas.Find(id);
            db.Kampanyas.Remove(kampanya);
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
