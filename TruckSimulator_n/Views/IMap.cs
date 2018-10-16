using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator_n
{
    public interface IMap
    {
        string MapName { get; set; }
        string Qiterations { get; set; }
        string curIteration { get; set; }
        string QCargo { get; set; }
        string QTruck { get; set; }
        int width { get; set; }
        int height { get; set; }

        Bitmap Field { set; }
        ArrayList ArrPoints { set; }
    }
}