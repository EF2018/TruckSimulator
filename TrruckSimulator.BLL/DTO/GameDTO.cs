using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator.BLL.DTO
{
    public class GameDTO
    { 
        public int Id { get; set; }
        public string SaveName { get; set; }
        public int iterations { get; set; }
        public int CurIteration { get; set; }
        public int QTruck { get; set; }
        public int QCargo { get; set; }
    }
}
