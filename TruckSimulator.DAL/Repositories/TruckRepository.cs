using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSimulator.DAL.EF;
using TruckSimulator.DAL.Entities;
using TruckSimulator.DAL.Interfaces;

namespace TruckSimulator.DAL.Repositories
{
    public class TruckRepository:IRepository<Truck>
    {
        private GameContext db;

        public TruckRepository(GameContext context)
        {
            this.db = context;
        }

        public IEnumerable<Truck> GetAll()
        {
            return db.Truck;//.Include(o => o.Phone);
        }

        public Truck Get(int id)
        {
            return db.Truck.Find(id);
        }

        public void Create(Truck truck)
        {
            db.Truck.Add(truck);
        }

        public void Update(Truck truck)
        {
            db.Entry(truck).State = EntityState.Modified;
        }

        public IEnumerable<Truck> Find(Func<Truck, Boolean> predicate)
        {
            return db.Truck.Include(o => o.Games).Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Truck truck = db.Truck.Find(id);
            if (truck != null)
                db.Truck.Remove(truck);
        }
    }
}
