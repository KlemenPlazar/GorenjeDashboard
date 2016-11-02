using GorenjeDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using GorenjeDashboard.Infrastucture;

namespace GorenjeDashboard.Controllers
{
    public class HomeController : Controller
    {
        private IGorenjeDataSource db = new GorenjeDBContext();

        private ShiftTimes shifts = new ShiftTimes();

        public ActionResult Index()
        {
            OrderViewModel model = new OrderViewModel();
            ShiftTime currentShift = shifts.GetCurrentShift();
            model.Orders = db.Orders.Where(o => o.TimeAdded > currentShift.FromHours
                                                && o.TimeAdded < currentShift.ToHours)
                                                .Include(o => o.Machine).Include(o => o.Material).ToList();
            return View(model);
        }

        public ActionResult CompleteTask(int orderID)
        {
            OrderModel order = db.Orders.FirstOrDefault(o => o.ID == orderID);

            if(order != null)
            {
                order.State = OrderState.Done;
                db.Save();
            }

            return RedirectToAction("Index");
        }


        public ActionResult CancelTask(int orderID)
        {
            OrderModel order = db.Orders.FirstOrDefault(o => o.ID == orderID);

            if (order != null)
            {
                order.State = OrderState.Canceled;
                db.Save();
            }

            return RedirectToAction("Index");
        }

        public ActionResult UndoTask(int orderID)
        {
            OrderModel order = db.Orders.FirstOrDefault(o => o.ID == orderID);

            if (order != null)
            {
                order.State = OrderState.TODO;
                db.Save();
            }

            return RedirectToAction("Index");
        }

    }
}