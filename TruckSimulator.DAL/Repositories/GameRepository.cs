using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TruckSimulator.DAL.EF;
using TruckSimulator.DAL.Entities;
using TruckSimulator.DAL.Interfaces;

namespace TruckSimulator.DAL.Repositories
{
    public class GameRepository : IRepository<Game>
    {
        private GameContext db;

        public GameRepository(GameContext context)
        {
            this.db = context;
        }

        public IEnumerable<Game> GetAll()
        {
            return db.Games;
        }

        public Game Get(int id)
        {
            return db.Games.Find(id);
        }

        public void Create(Game g)
        {
            db.Games.Add(g);
        }

        public void Update(Game g)
        {
            db.Entry(g).State = EntityState.Modified;
        }

        public IEnumerable<Game> Find(Func<Game, Boolean> predicate)
        {
            return db.Games.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            Game game = db.Games.Find(id);
            if (game != null)
                db.Games.Remove(game);
        }
    }
}
