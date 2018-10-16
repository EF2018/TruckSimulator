using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckSimulator.WEB.Model
{
    public class CargoViewModel
    {
        public int IdGame { get; set; }
        public string NameCargo { get; set; }
        public string TypeName { get; set; }
        public int PositionX { get; set; }
        public int PositionY { get; set; }
        public byte Status { get; set; }
    }
}