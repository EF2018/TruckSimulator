using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator.DAL.Entities
{
    public class Cargo
    {
        public int IdGame { get; set; }
        public string NameCargo { get; set; }
        public string TypeName { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public byte Status { get; set; }
        public ICollection<Cargo> Games { get; set; }

    }
}
