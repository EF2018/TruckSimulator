﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator_n
{
    class Dijkstra : Builder, IRouteSearcher
    {
        public Dijkstra(List<Cargo> arrayPoints, Vehicle truck) : base(arrayPoints, truck)
        {
        }

        public void GetBestRoute()
        {
        }
    }
}
