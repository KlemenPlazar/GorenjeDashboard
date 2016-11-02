using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GorenjeDashboard.Models;

namespace GorenjeDashboard.Controllers
{
    public class PalleteModelsController : Controller
    {
        private GorenjeDBContext db = new GorenjeDBContext();

        // GET: PalleteModels
        public ActionResult Index()
        {
            return View(db.Palletes.ToList());
        }

        // GET: PalleteModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PalleteModel palleteModel = db.Palletes.Find(id);
            if (palleteModel == null)
            {
                return HttpNotFound();
            }
            return View(palleteModel);
        }

        // GET: PalleteModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PalleteModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PalleteId,PalleteName")] PalleteModel palleteModel)
        {
            if (ModelState.IsValid)
            {
                db.Palletes.Add(palleteModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(palleteModel);
        }

        // GET: PalleteModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PalleteModel palleteModel = db.Palletes.Find(id);
            if (palleteModel == null)
            {
                return HttpNotFound();
            }
            return View(palleteModel);
        }

        // POST: PalleteModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PalleteId,PalleteName")] PalleteModel palleteModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(palleteModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(palleteModel);
        }

        // GET: PalleteModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PalleteModel palleteModel = db.Palletes.Find(id);
            if (palleteModel == null)
            {
                return HttpNotFound();
            }
            return View(palleteModel);
        }

        // POST: PalleteModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PalleteModel palleteModel = db.Palletes.Find(id);
            db.Palletes.Remove(palleteModel);
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
