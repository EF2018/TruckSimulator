using System;
using System.Drawing;
using TruckSimulator_n;

namespace TruckSimulatorDAL_n
{
    public interface IUnitOfWork:IDisposable
    {
        //IRepository<TruckN> TruckNs { get; }
        IRepository<TruckSimulator_n.Map> Maps{ get; }
        //IRepository<Cargo> Cargoes { get; }
        //IRepository<Point> Points { get; }
        void Save();
    }
}
