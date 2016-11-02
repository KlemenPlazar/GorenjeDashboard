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
    public class MaterialModelsController : Controller
    {
        private GorenjeDBContext db = new GorenjeDBContext();

        // GET: MaterialModels
        public ActionResult Index()
        {
            return View(db.Materials.ToList());
        }

        // GET: MaterialModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialModel materialModel = db.Materials.Find(id);
            if (materialModel == null)
            {
                return HttpNotFound();
            }
            return View(materialModel);
        }

        // GET: MaterialModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MaterialModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialId,Material,MaterialCode,MaterialStructure")] MaterialModel materialModel)
        {
            if (ModelState.IsValid)
            {
                db.Materials.Add(materialModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materialModel);
        }

        // GET: MaterialModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialModel materialModel = db.Materials.Find(id);
            if (materialModel == null)
            {
                return HttpNotFound();
            }
            return View(materialModel);
        }

        // POST: MaterialModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialId,Material,MaterialCode,MaterialStructure")] MaterialModel materialModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materialModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materialModel);
        }

        // GET: MaterialModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MaterialModel materialModel = db.Materials.Find(id);
            if (materialModel == null)
            {
                return HttpNotFound();
            }
            return View(materialModel);
        }

        // POST: MaterialModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MaterialModel materialModel = db.Materials.Find(id);
            db.Materials.Remove(materialModel);
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
