namespace GorenjeDashboard.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GorenjeDashboard.Models.GorenjeDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GorenjeDashboard.Models.GorenjeDBContext";
        }

        protected override void Seed(GorenjeDashboard.Models.GorenjeDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            context.Palletes.AddOrUpdate(p => p.PalleteName,
                                new PalleteModel() { PalleteName = "Euro Paleta" },
                                new PalleteModel() { PalleteName = "Velika mrežasta paleta" },
                                new PalleteModel() { PalleteName = "Mala mrežasta paleta" },
                                new PalleteModel() { PalleteName = "Velika kovinska paleta" },
                                new PalleteModel() { PalleteName = "Mala kovisnka paleta" });

            context.Machines.AddOrUpdate(m => m.Machine,
                            new MachineModel() { Machine = "Rg-1" },
                            new MachineModel() { Machine = "Rg-2" },
                            new MachineModel() { Machine = "Trumph" },
                            new MachineModel() { Machine = "HFE" },
                            new MachineModel() { Machine = "HFB" },
                            new MachineModel() { Machine = "Laser 1" },
                            new MachineModel() { Machine = "Laser 2" },
                            new MachineModel() { Machine = "Prebijalka 1" },
                            new MachineModel() { Machine = "Prebijalka 2" },
                            new MachineModel() { Machine = "Prebijalka 3" });
        }
    }
}
