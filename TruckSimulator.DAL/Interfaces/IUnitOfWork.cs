using System;
using TruckSimulator.DAL.Entities;

namespace TruckSimulator.DAL.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IRepository<Cargo> Cargoes { get; }
        IRepository<Game> Games { get; }
        IRepository<Truck> Trucks { get; }
        void Save();
    }
}
