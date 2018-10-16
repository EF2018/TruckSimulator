using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator_n
{
    public interface IPoint
    {
        //int Id { get; set; }
        //string Name { get; set; }
        Coordinate Position { get; set; }
        //Pen Pen { get; set; }
        //Brush TextColor { get; set; }
        //Font Font { get; set; }
        //Map Map { get; set; }

        void Display(Bitmap bmp);
        void Action(Map map);
    }
}
