using Common.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repository
{
    public class ShesDbContext : DbContext
    {
        public DbSet<SolarPanel> SolarPanels { get; set; }
        public DbSet<Battery> Batteries { get; set; }
        public DbSet<Consumer> Consumers { get; set; }
        public DbSet<Utility> Utility { get; set; }
        public DbSet<Measurement> Measurements { get; set; }

        public ShesDbContext() : base("shes")
        {

        }
    }
}
