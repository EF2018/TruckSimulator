using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSimulator.DAL.Entities;

namespace TruckSimulator.DAL.EF
{
    public class GameContext : DbContext
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<Truck> Truck { get; set; }

        public GameContext(string connectionString):base(connectionString)
        {
        }
    }
}
