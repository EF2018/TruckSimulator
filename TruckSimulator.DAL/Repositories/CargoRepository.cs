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
    public class CargoRepository:IRepository<Cargo>
    {
        private GameContext db;

        public CargoRepository(GameContext context)
        {
            db = context;
        }

        public IEnumerable<Cargo> GetAll()
        {
            return db.Cargoes;
        }

        public Cargo Get(int id)
        {
            return db.Cargoes.Find(id);
        }

        public void Create(Cargo g)
        {
            db.Cargoes.Add(g);
        }

        public void Update(Cargo g)
        {
            db.Entry(g).State = EntityState.Modified;
        }

        public IEnumerable<Cargo> Find(Func<Cargo, Boolean> predicate)
        {
            return db.Cargoes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Cargo cargo = db.Cargoes.Find(id);
            if (cargo != null)
                db.Cargoes.Remove(cargo);
        }
    }
}
