using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TruckSimulator_n;

namespace TruckSimulatorDAL_n
{
    public class MyContext : DbContext
    {
        public MyContext(): base("name=MyContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

       
        public virtual DbSet<TruckSimulator_n.Map> Map { get; set; }
        public virtual DbSet<TruckSimulator_n.TruckN> TruckN { get; set; }
        public virtual DbSet<TruckSimulator_n.Cargo> Cargo { get; set; }
        public virtual DbSet<TruckSimulator_n.User> User { get; set; }
        public virtual DbSet<TruckSimulator_n.RoutePoint> RoutePoint { get; set; }
        public virtual DbSet<TruckSimulator_n.Vehicle> Vehicle { get; set; }
        public virtual DbSet<TruckSimulator_n.Point> Point { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //modelBuilder.Entity<Map>()
        //    .Property(e => e.MapName)
        //    .IsUnicode(false);

        //modelBuilder.Entity<Map>()
        //    .HasMany(e => e.TruckN)
        //    .WithRequired(e => e.Map)
        //    .WillCascadeOnDelete(false);

        //modelBuilder.Entity<TruckN>()
        //    .Property(e => e.Element.Name)
        //    .IsUnicode(false);

        //modelBuilder.Entity<TruckN>()
        //.HasMany(e => e.Point)
        //.WithRequired(e => e.TruckN)
        //.HasForeignKey(e => e.IdTruckN)
        //.WillCascadeOnDelete(false);
        //}
    }
}
