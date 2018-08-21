using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator.Models
{
    class BruteForce : IRouteSearcher
    {
        public ITruck truck { get; set; }
        public List<Cargo> _arrayPoints { get; set; }

        public void GetBestRoute()
        {
            
        }
    }
}
