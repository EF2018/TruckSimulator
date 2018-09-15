using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator
{
    class Genetic : Builder, IRouteSearcher
    {
        public Genetic(List<Cargo> arrayPoints, ITruck truck) : base(arrayPoints, truck)
        {
        }

        public void GetBestRoute()
        {
            throw new NotImplementedException();
        }
    }
}
