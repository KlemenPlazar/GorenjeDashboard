using GorenjeDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GorenjeDashboard.Infrastucture
{
    interface IGorenjeDataSource
    {
        IQueryable<MaterialModel> Materials { get; }
        IQueryable<MachineModel> Machines { get; }
        IQueryable<PalleteModel> Palletes { get; }
        IQueryable<OrderModel> Orders { get; }
        void Save();
        void Dispose();
    }
}
