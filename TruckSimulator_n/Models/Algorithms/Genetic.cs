using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator_n
{
    class Genetic : Builder, IRouteSearcher
    {
        public Genetic(List<Cargo> arrayPoints, Vehicle truck) : base(arrayPoints, truck)
        {
        }

        public void GetBestRoute()
        {
            throw new NotImplementedException();
        }
    }
}
