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
    public class ProduktDoZabieguController : Controller
    {
        private Gabinet_Kosmetyczny_DBEntities db = new Gabinet_Kosmetyczny_DBEntities();

        // GET: ProduktDoZabiegu
        public ActionResult Index()
        {
            var produkty_do_zabiegu = db.produkty_do_zabiegu.Include(p => p.produkty).Include(p => p.typ_zabiegu);
            return View(produkty_do_zabiegu.ToList());
        }

        // GET: ProduktDoZabiegu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produkty_do_zabiegu produkty_do_zabiegu = db.produkty_do_zabiegu.Find(id);
            if (produkty_do_zabiegu == null)
            {
                return HttpNotFound();
            }
            return View(produkty_do_zabiegu);
        }

        // GET: ProduktDoZabiegu/Create
        public ActionResult Create()
        {
            ViewBag.produkt = new SelectList(db.produkty, "id_produktu", "nazwa");
            ViewBag.nazwazabiegu = new SelectList(db.typ_zabiegu, "id_zabiegu", "nazwa");
            return View();
        }

        // POST: ProduktDoZabiegu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_produkty_do_zabiegu,produkt,nazwazabiegu")] produkty_do_zabiegu produkty_do_zabiegu)
        {
            if (ModelState.IsValid)
            {
                db.produkty_do_zabiegu.Add(produkty_do_zabiegu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.produkt = new SelectList(db.produkty, "id_produktu", "nazwa", produkty_do_zabiegu.produkt);
            ViewBag.nazwazabiegu = new SelectList(db.typ_zabiegu, "id_zabiegu", "nazwa", produkty_do_zabiegu.nazwazabiegu);
            return View(produkty_do_zabiegu);
        }

        // GET: ProduktDoZabiegu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produkty_do_zabiegu produkty_do_zabiegu = db.produkty_do_zabiegu.Find(id);
            if (produkty_do_zabiegu == null)
            {
                return HttpNotFound();
            }
            ViewBag.produkt = new SelectList(db.produkty, "id_produktu", "nazwa", produkty_do_zabiegu.produkt);
            ViewBag.nazwazabiegu = new SelectList(db.typ_zabiegu, "id_zabiegu", "nazwa", produkty_do_zabiegu.nazwazabiegu);
            return View(produkty_do_zabiegu);
        }

        // POST: ProduktDoZabiegu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_produkty_do_zabiegu,produkt,nazwazabiegu")] produkty_do_zabiegu produkty_do_zabiegu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produkty_do_zabiegu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.produkt = new SelectList(db.produkty, "id_produktu", "nazwa", produkty_do_zabiegu.produkt);
            ViewBag.nazwazabiegu = new SelectList(db.typ_zabiegu, "id_zabiegu", "nazwa", produkty_do_zabiegu.nazwazabiegu);
            return View(produkty_do_zabiegu);
        }

        // GET: ProduktDoZabiegu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            produkty_do_zabiegu produkty_do_zabiegu = db.produkty_do_zabiegu.Find(id);
            if (produkty_do_zabiegu == null)
            {
                return HttpNotFound();
            }
            return View(produkty_do_zabiegu);
        }

        // POST: ProduktDoZabiegu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            produkty_do_zabiegu produkty_do_zabiegu = db.produkty_do_zabiegu.Find(id);
            db.produkty_do_zabiegu.Remove(produkty_do_zabiegu);
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
