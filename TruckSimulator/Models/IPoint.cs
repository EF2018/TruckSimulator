using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace TruckSimulator.Models
{
    interface IPoint
    {
        Coordinate Position { get; set; }
        Pen Pen { get; set; }
        string Name { get; set; }
    }
}
