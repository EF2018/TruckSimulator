using System;
using TruckSimulator_n;

namespace TruckSimulatorDAL_n
{
    public class EFUnitOfWork: IUnitOfWork
    {
        private MyContext db;
        private MapRepository mapRepo;
        //private TruckRepository truckRepo;
       
        //private PointRepository pointRepo;
        
        public EFUnitOfWork(string connectionString)
        {
            db = new MyContext();
        }

        public IRepository<TruckSimulator_n.Map> Maps
        {
            get
            {
                if (mapRepo == null)
                {
                    mapRepo = new MapRepository(db);
                }
                return mapRepo;
            }
        }

        //public IRepository<TruckSimulator_n.TruckN> TruckNs
        //{
        //    get
        //    {
        //        if (truckRepo == null)
        //        {
        //            truckRepo = new TruckRepository(db);
        //        }
        //        return truckRepo;
        //    }
        //}

        //public IRepository<TruckSimulator_n.Point> Points
        //{
        //    get
        //    {
        //        if (pointRepo == null)
        //        {
        //            pointRepo = new PointRepository(db);
        //        }
        //        return pointRepo;
        //    }
        //}

        public void Save()
        {
            db.SaveChanges();
        }

        public bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
