using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator.Models
{
    interface IRouteSearcher
    {
        //ITruck _truck { get; set; }//авто
        //List<Cargo> _arrayPoints { get; set; }//входящий список точек маршрута

        void GetBestRoute();
    }
}
