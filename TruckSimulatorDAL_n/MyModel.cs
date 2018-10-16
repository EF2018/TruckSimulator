using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using TruckSimulator_n;

namespace TruckSimulatorDAL_n
{
    
    public partial class MyModel : DbContext
    {
        public MyModel()
            : base("name=MyModel")
        {
        }

        public virtual DbSet<TruckSimulator_n.Map> MapSets { get; set; }
        public virtual DbSet<TruckSimulator_n.Point> PointSets { get; set; }
        public virtual DbSet<TruckSimulator_n.Cargo> PointSet_Cargo { get; set; }
        public virtual DbSet<TruckSimulator_n.MapPoint> PointSet_MapPoint { get; set; }
        public virtual DbSet<TruckSimulator_n.TruckN> PointSet_Truck { get; set; }
        public virtual DbSet<TruckSimulator_n.User> PointSet_User { get; set; }
        public virtual DbSet<TruckSimulator_n.Vehicle> PointSet_Vehicle { get; set; }
        public virtual DbSet<TruckSimulator_n.RoutePoint> PointSet_RoutePoint { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<TruckSimulator_n.Map>()
        //        .HasMany(e => e.MapPoint)
        //        .WithRequired(e => e.Map)
        //        .HasForeignKey(e => e.MapIdMap)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<TruckSimulator_n.MapPoint>()
        //        .HasOptional(e => e.Id)
        //        .WithRequired(e => e.PointSet)
        //        .WillCascadeOnDelete();

        //    modelBuilder.Entity<TruckSimulator_n.MapPoint>()
        //        .HasOptional(e => e.Id)
        //        .WithRequired(e => e.PointSet_MapPoint)
        //        .WillCascadeOnDelete();

        //    modelBuilder.Entity<TruckSimulator_n.MapPoint>()
        //        .HasOptional(e => e.Id)
        //        .WithRequired(e => e.PointSet_MapPoint)
        //        .WillCascadeOnDelete();

        //    modelBuilder.Entity<TruckSimulator_n.Vehicle>()
        //        .HasOptional(e => e.)
        //        .WithRequired(e => e.PointSet_Vehicle)
        //        .WillCascadeOnDelete();

        //    modelBuilder.Entity<TruckSimulator_n.Vehicle>()
        //        .HasOptional(e => e.PointSet_User)
        //        .WithRequired(e => e.PointSet_Vehicle)
        //        .WillCascadeOnDelete();
        //}
    }
}
