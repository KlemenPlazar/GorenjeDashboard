using GorenjeDashboard.Infrastucture;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GorenjeDashboard.Models
{
    public class GorenjeDBContext : DbContext, IGorenjeDataSource
    {
        public DbSet<MaterialModel> Materials { get; set; }
        public DbSet<MachineModel> Machines { get; set; }
        public DbSet<PalleteModel> Palletes { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        IQueryable<MaterialModel> IGorenjeDataSource.Materials
        {
            get
            {
                return Materials;
            }
        }

        IQueryable<MachineModel> IGorenjeDataSource.Machines
        {
            get
            {
                return Machines;
            }
        }

        IQueryable<PalleteModel> IGorenjeDataSource.Palletes
        {
            get
            {
                return Palletes;
            }
        }

        IQueryable<OrderModel> IGorenjeDataSource.Orders
        {
            get
            {
                return Orders;
            }
        }

        void IGorenjeDataSource.Save()
        {
            SaveChanges();
        }

        void IGorenjeDataSource.Dispose()
        {
            Dispose();
        }
    }
}