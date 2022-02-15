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
    public class KlienciController : Controller
    {
        private Gabinet_Kosmetyczny_DBEntities db = new Gabinet_Kosmetyczny_DBEntities();

        // GET: Klienci
        public ActionResult Index()
        {
            return View(db.klienci.ToList());
        }

        // GET: Klienci/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            klienci klienci = db.klienci.Find(id);
            if (klienci == null)
            {
                return HttpNotFound();
            }
            return View(klienci);
        }

        // GET: Klienci/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Klienci/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_klienta,imie,nazwisko,telefon,email,plec")] klienci klienci)
        {
            if (ModelState.IsValid)
            {
                db.klienci.Add(klienci);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(klienci);
        }

        // GET: Klienci/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            klienci klienci = db.klienci.Find(id);
            if (klienci == null)
            {
                return HttpNotFound();
            }
            return View(klienci);
        }

        // POST: Klienci/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_klienta,imie,nazwisko,telefon,email,plec")] klienci klienci)
        {
            if (ModelState.IsValid)
            {
                db.Entry(klienci).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(klienci);
        }

        // GET: Klienci/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            klienci klienci = db.klienci.Find(id);
            if (klienci == null)
            {
                return HttpNotFound();
            }
            return View(klienci);
        }

        // POST: Klienci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            klienci klienci = db.klienci.Find(id);
            db.klienci.Remove(klienci);
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
