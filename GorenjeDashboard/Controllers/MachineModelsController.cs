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
    public class MachineModelsController : Controller
    {
        private GorenjeDBContext db = new GorenjeDBContext();

        // GET: MachineModels
        public ActionResult Index()
        {
            return View(db.Machines.ToList());
        }

        // GET: MachineModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineModel machineModel = db.Machines.Find(id);
            if (machineModel == null)
            {
                return HttpNotFound();
            }
            return View(machineModel);
        }

        // GET: MachineModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MachineModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MachineId,Machine")] MachineModel machineModel)
        {
            if (ModelState.IsValid)
            {
                db.Machines.Add(machineModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(machineModel);
        }

        // GET: MachineModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineModel machineModel = db.Machines.Find(id);
            if (machineModel == null)
            {
                return HttpNotFound();
            }
            return View(machineModel);
        }

        // POST: MachineModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MachineId,Machine")] MachineModel machineModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(machineModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(machineModel);
        }

        // GET: MachineModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineModel machineModel = db.Machines.Find(id);
            if (machineModel == null)
            {
                return HttpNotFound();
            }
            return View(machineModel);
        }

        // POST: MachineModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MachineModel machineModel = db.Machines.Find(id);
            db.Machines.Remove(machineModel);
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
