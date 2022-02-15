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
    public class ZabiegController : Controller
    {
        private Gabinet_Kosmetyczny_DBEntities db = new Gabinet_Kosmetyczny_DBEntities();

        // GET: Zabieg
        public ActionResult Index()
        {
            var zabiegi = db.zabiegi.Include(z => z.klienci).Include(z => z.typ_zabiegu);
            return View(zabiegi.ToList());
        }

        // GET: Zabieg/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zabiegi zabiegi = db.zabiegi.Find(id);
            if (zabiegi == null)
            {
                return HttpNotFound();
            }
            return View(zabiegi);
        }

        // GET: Zabieg/Create
        public ActionResult Create()
        {
            ViewBag.klient = new SelectList(db.klienci, "id_klienta", "imie");
            ViewBag.zabieg = new SelectList(db.typ_zabiegu, "id_zabiegu", "nazwa");
            return View();
        }

        // POST: Zabieg/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_zabiegu,klient,zabieg,termin,wykonano")] zabiegi zabiegi)
        {
            if (ModelState.IsValid)
            {
                db.zabiegi.Add(zabiegi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.klient = new SelectList(db.klienci, "id_klienta", "imie", zabiegi.klient);
            ViewBag.zabieg = new SelectList(db.typ_zabiegu, "id_zabiegu", "nazwa", zabiegi.zabieg);
            return View(zabiegi);
        }

        // GET: Zabieg/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zabiegi zabiegi = db.zabiegi.Find(id);
            if (zabiegi == null)
            {
                return HttpNotFound();
            }
            ViewBag.klient = new SelectList(db.klienci, "id_klienta", "imie", zabiegi.klient);
            ViewBag.zabieg = new SelectList(db.typ_zabiegu, "id_zabiegu", "nazwa", zabiegi.zabieg);
            return View(zabiegi);
        }

        // POST: Zabieg/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_zabiegu,klient,zabieg,termin,wykonano")] zabiegi zabiegi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zabiegi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.klient = new SelectList(db.klienci, "id_klienta", "imie", zabiegi.klient);
            ViewBag.zabieg = new SelectList(db.typ_zabiegu, "id_zabiegu", "nazwa", zabiegi.zabieg);
            return View(zabiegi);
        }

        // GET: Zabieg/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            zabiegi zabiegi = db.zabiegi.Find(id);
            if (zabiegi == null)
            {
                return HttpNotFound();
            }
            return View(zabiegi);
        }

        // POST: Zabieg/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            zabiegi zabiegi = db.zabiegi.Find(id);
            db.zabiegi.Remove(zabiegi);
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
