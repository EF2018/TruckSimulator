using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator.DAL.Entities
{
    public class Truck
    {
        public int IdGame { get; set; }
        public string NameTruck { get; set; }
        public string TypeName { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public byte Status { get; set; }
        public int FuelBalance { get; set; }
        public int StepOfRoute { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
