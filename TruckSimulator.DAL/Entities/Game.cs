using System;

namespace TruckSimulator.DAL.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string SaveName { get; set; }
        public int Iterations { get; set; }
        public int CurIteration { get; set; }
        public int QTruck { get; set; }
        public int QCargo { get; set; }
    }
}
