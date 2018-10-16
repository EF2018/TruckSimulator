using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TruckSimulator.WEB.Model
{
    public class GameViewModel
    {
        public int Id { get; set; }
        public string SaveName { get; set; }
        public int iterations { get; set; }
        public int CurIteration { get; set; }
        public int QTruck { get; set; }
        public int QCargo { get; set; }
    }
}