using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TruckSimulator_n;

namespace TruckSimulatorDAL_n
{
    class MapRepository : IRepository<TruckSimulator_n.Map>
    {
        private MyContext db;

        public MapRepository(MyContext context)
        {
            db = context;
        }

        public IEnumerable<TruckSimulator_n.Map> GetAll()
        {
            return db.Map;
        }

        public TruckSimulator_n.Map Get(int id)
        {
            return db.Map.Find(id);
        }

        public void Create(TruckSimulator_n.Map map)
        {
            db.Map.Add(map);
        }

        public void Update(TruckSimulator_n.Map map)
        {
            db.Entry(map).State = EntityState.Modified;
        }

        public IEnumerable<TruckSimulator_n.Map> Find(Func<TruckSimulator_n.Map, Boolean> predicate)
        {
            return db.Map.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TruckSimulator_n.Map map = db.Map.Find(id);
            if (map != null) db.Map.Remove(map);
        }
    }
}
