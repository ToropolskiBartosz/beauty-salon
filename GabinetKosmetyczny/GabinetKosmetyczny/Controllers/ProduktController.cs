using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GabinetKosmetyczny;

namespace GabinetKosmetyczny.Controllers
{
    public class ProduktController : Controller
    {
        private Gabinet_Kosmetyczny_DBEntities db = new Gabinet_Kosmetyczny_DBEntities();

        // GET: Produkt
        public ActionResult Index()
        {
            return View(db.produkty.ToList());
        }

        // GET: Produkt/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produkty produkty = db.produkty.Find(id);
            if (produkty == null)
            {
                return HttpNotFound();
            }
            return View(produkty);
        }

        // GET: Produkt/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Produkt/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_produktu,nazwa,cena,producent")] produkty produkty)
        {
            if (ModelState.IsValid)
            {
                db.produkty.Add(produkty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produkty);
        }

        // GET: Produkt/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produkty produkty = db.produkty.Find(id);
            if (produkty == null)
            {
                return HttpNotFound();
            }
            return View(produkty);
        }

        // POST: Produkt/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_produktu,nazwa,cena,producent")] produkty produkty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produkty);
        }

        // GET: Produkt/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produkty produkty = db.produkty.Find(id);
            if (produkty == null)
            {
                return HttpNotFound();
            }
            return View(produkty);
        }

        // POST: Produkt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produkty produkty = db.produkty.Find(id);
            db.produkty.Remove(produkty);
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
