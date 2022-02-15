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
    public class GabinetController : Controller
    {
        private Gabinet_Kosmetyczny_DBEntities db = new Gabinet_Kosmetyczny_DBEntities();

        // GET: Gabinet
        public ActionResult Index()
        {
            return View(db.gabinety.ToList());
        }

        // GET: Gabinet/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gabinety gabinety = db.gabinety.Find(id);
            if (gabinety == null)
            {
                return HttpNotFound();
            }
            return View(gabinety);
        }

        // GET: Gabinet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gabinet/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_gabinetu,wielkosc_m2,pomieszczenia")] gabinety gabinety)
        {
            if (ModelState.IsValid)
            {
                db.gabinety.Add(gabinety);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gabinety);
        }

        // GET: Gabinet/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gabinety gabinety = db.gabinety.Find(id);
            if (gabinety == null)
            {
                return HttpNotFound();
            }
            return View(gabinety);
        }

        // POST: Gabinet/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_gabinetu,wielkosc_m2,pomieszczenia")] gabinety gabinety)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gabinety).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gabinety);
        }

        // GET: Gabinet/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gabinety gabinety = db.gabinety.Find(id);
            if (gabinety == null)
            {
                return HttpNotFound();
            }
            return View(gabinety);
        }

        // POST: Gabinet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gabinety gabinety = db.gabinety.Find(id);
            db.gabinety.Remove(gabinety);
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
