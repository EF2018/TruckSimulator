using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator.Models
{
    class Genetic : IRouteSearcher
    {
        public ITruck _truck { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<Cargo> _arrayPoints { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void GetBestRoute()
        {
            throw new NotImplementedException();
        }
    }
}
