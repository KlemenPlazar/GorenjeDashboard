using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GorenjeDashboard.Models
{
    public enum OrderState
    {
        TODO = 0,
        Done = 1,
        Canceled = 2
    }

    public enum Shifts
    {
        Morning,
        Aftenoon,
        Night
    }

    public class ShiftTime
    {
        public Shifts Shift { get; set; }

        public DateTime FromHours { get; set; }
        public DateTime ToHours { get; set; }
    }

    public class ShiftTimes
    {
        TimeZoneInfo myTimeZone;
        List<ShiftTime> times = new List<ShiftTime>();
        TimeSpan morning = new TimeSpan(6, 0, 0);
        TimeSpan afternoon = new TimeSpan(14, 0, 0);
        TimeSpan night = new TimeSpan(22, 0, 0);

        public ShiftTimes()
        {
            myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            var currentTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, this.myTimeZone);
            times.Add(new ShiftTime
            {
                Shift = Shifts.Morning,
                FromHours = currentTime.Date + morning,
                ToHours = currentTime.Date + morning + new TimeSpan(8, 0, 0),
            });
            times.Add(new ShiftTime
            {
                Shift = Shifts.Aftenoon,
                FromHours = currentTime.Date + afternoon,
                ToHours = currentTime.Date + afternoon + new TimeSpan(8, 0, 0),
            });
            times.Add(new ShiftTime
            {
                Shift = Shifts.Night,
                FromHours = currentTime.Date + night,
                ToHours = currentTime.Date + night + new TimeSpan(8, 0, 0),
            });
        }

        public ShiftTime GetCurrentShift()
        {
            var today = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, this.myTimeZone);

            foreach(ShiftTime time in times)
            {
                if (today >= time.FromHours && today < time.ToHours)
                    return time;
            }

            return new ShiftTime
            {
                Shift = Shifts.Night,
                FromHours = today.Date + night,
                ToHours = today + new TimeSpan(8, 0 , 0)
            };
        }
    }

    public class OrderModel
    {
        public OrderModel()
        {
            TimeZoneInfo myTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central Europe Standard Time");
            this.TimeAdded = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, myTimeZone);
        }

        public int ID { get; set; }

        [DisplayName("Ime")]
        public string Name { get; set; }

        [DisplayName("Stroj")]
        public int MachineId {get; set; }
        public virtual MachineModel Machine { get; set; }

        [DisplayName("Material")]
        public int MaterialId { get; set; }
        public virtual MaterialModel Material { get; set; }

        [DisplayName("Paleta")]
        public int PalleteId { get; set; }
        public virtual PalleteModel Pallete { get; set; }

        [DisplayName("Prioriteta")]
        public string Priority { get; set; }

        [DefaultValue(0)]
        public OrderState State { get; set; }

        public DateTime TimeAdded { get; set; }
    }

    public class OrderViewModel
    {
        public List<OrderModel> Orders { get; set; }

    }
}