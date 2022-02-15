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
    public class pracownicyController : Controller
    {
        private Gabinet_Kosmetyczny_DBEntities db = new Gabinet_Kosmetyczny_DBEntities();

        // GET: pracownicy
        public ActionResult Index()
        {
            return View(db.pracownicy.ToList());
        }

        // GET: pracownicy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pracownicy pracownicy = db.pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        // GET: pracownicy/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: pracownicy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pracownika,imie,nazwisko,telefon,pesel,data_zatrudnienia")] pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                db.pracownicy.Add(pracownicy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pracownicy);
        }

        // GET: pracownicy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pracownicy pracownicy = db.pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        // POST: pracownicy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pracownika,imie,nazwisko,telefon,pesel,data_zatrudnienia")] pracownicy pracownicy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pracownicy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pracownicy);
        }

        // GET: pracownicy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            pracownicy pracownicy = db.pracownicy.Find(id);
            if (pracownicy == null)
            {
                return HttpNotFound();
            }
            return View(pracownicy);
        }

        // POST: pracownicy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pracownicy pracownicy = db.pracownicy.Find(id);
            db.pracownicy.Remove(pracownicy);
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
