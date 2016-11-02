using GorenjeDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GorenjeDashboard.Controllers
{
    public class MaterialController : Controller
    {
        private GorenjeDBContext db = new GorenjeDBContext();


        // GET: Material
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddMaterial()
        {
            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Machine");
            ViewBag.MaterialId = new SelectList(db.Materials, "MaterialId", "Material");
            ViewBag.PalleteId = new SelectList(db.Palletes, "PalleteId", "PalleteName");

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMaterial([Bind(Include = "ID,Name,MachineId,MaterialId,PalleteId,Priority,State")] OrderModel orderModel)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(orderModel);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.MachineId = new SelectList(db.Machines, "MachineId", "Machine", orderModel.MachineId);
            ViewBag.MaterialId = new SelectList(db.Materials, "MaterialId", "Material", orderModel.MaterialId);
            ViewBag.PalleteId = new SelectList(db.Palletes, "PalleteId", "PalleteName", orderModel.PalleteId);
            return View(orderModel);
        }
    }
}