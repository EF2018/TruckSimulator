using System;
using TruckSimulator.DAL.EF;
using TruckSimulator.DAL.Entities;
using TruckSimulator.DAL.Interfaces;

namespace TruckSimulator.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private GameContext db;
        private TruckRepository truckRepository;
        private GameRepository gameRepository;
        private CargoRepository cargoRepository;

        public EFUnitOfWork(string connectionString)
        {
            db = new GameContext(connectionString);
        }

        public IRepository<Truck> Trucks
        {
            get
            {
                if (truckRepository == null)
                    truckRepository = new TruckRepository(db);
                return truckRepository;
            }
        }

        public IRepository<Game> Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }

        public IRepository<Cargo> Cargoes
        {
            get
            {
                if (cargoRepository == null)
                    cargoRepository = new CargoRepository(db);
                return cargoRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

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
