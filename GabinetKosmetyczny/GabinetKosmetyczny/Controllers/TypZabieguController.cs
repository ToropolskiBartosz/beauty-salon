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
    public class TypZabieguController : Controller
    {
        private Gabinet_Kosmetyczny_DBEntities db = new Gabinet_Kosmetyczny_DBEntities();

        // GET: TypZabiegu
        public ActionResult Index()
        {
            var typ_zabiegu = db.typ_zabiegu.Include(t => t.gabinety1).Include(t => t.pracownicy);
            return View(typ_zabiegu.ToList());
        }

        // GET: TypZabiegu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typ_zabiegu typ_zabiegu = db.typ_zabiegu.Find(id);
            if (typ_zabiegu == null)
            {
                return HttpNotFound();
            }
            return View(typ_zabiegu);
        }

        // GET: TypZabiegu/Create
        public ActionResult Create()
        {
            ViewBag.gabinety = new SelectList(db.gabinety, "id_gabinetu", "id_gabinetu");
            ViewBag.pracownik = new SelectList(db.pracownicy, "id_pracownika", "imie");
            return View();
        }

        // POST: TypZabiegu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_zabiegu,nazwa,typ,czastrwania,cena,pracownik,gabinety")] typ_zabiegu typ_zabiegu)
        {
            if (ModelState.IsValid)
            {
                db.typ_zabiegu.Add(typ_zabiegu);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.gabinety = new SelectList(db.gabinety, "id_gabinetu", "id_gabinetu", typ_zabiegu.gabinety);
            ViewBag.pracownik = new SelectList(db.pracownicy, "id_pracownika", "imie", typ_zabiegu.pracownik);
            return View(typ_zabiegu);
        }

        // GET: TypZabiegu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typ_zabiegu typ_zabiegu = db.typ_zabiegu.Find(id);
            if (typ_zabiegu == null)
            {
                return HttpNotFound();
            }
            ViewBag.gabinety = new SelectList(db.gabinety, "id_gabinetu", "id_gabinetu", typ_zabiegu.gabinety);
            ViewBag.pracownik = new SelectList(db.pracownicy, "id_pracownika", "imie", typ_zabiegu.pracownik);
            return View(typ_zabiegu);
        }

        // POST: TypZabiegu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_zabiegu,nazwa,typ,czastrwania,cena,pracownik,gabinety")] typ_zabiegu typ_zabiegu)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typ_zabiegu).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.gabinety = new SelectList(db.gabinety, "id_gabinetu", "id_gabinetu", typ_zabiegu.gabinety);
            ViewBag.pracownik = new SelectList(db.pracownicy, "id_pracownika", "imie", typ_zabiegu.pracownik);
            return View(typ_zabiegu);
        }

        // GET: TypZabiegu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            typ_zabiegu typ_zabiegu = db.typ_zabiegu.Find(id);
            if (typ_zabiegu == null)
            {
                return HttpNotFound();
            }
            return View(typ_zabiegu);
        }

        // POST: TypZabiegu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            typ_zabiegu typ_zabiegu = db.typ_zabiegu.Find(id);
            db.typ_zabiegu.Remove(typ_zabiegu);
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
