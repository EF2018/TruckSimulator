using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator
{
    class Lexographic : Builder, IRouteSearcher
    {
        public Lexographic(List<Cargo> arrayPoints, ITruck truck) : base(arrayPoints, truck)
        {
        }

        public void GetBestRoute()
        {

        }
    }
}
