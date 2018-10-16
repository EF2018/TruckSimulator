using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TruckSimulator_n
{
    [Table("PointSet_Truck")]
    public class TruckN: Vehicle
    {
        public TruckN(Coordinate position) : base(position)
        {
            Name = "Truck"+(_truckCounter++).ToString();
            Position = position;
            Status = true;
            TextColor = Brushes.Blue;
            Pen = new Pen(Color.Blue);//Color.Blue);
        }

        public TruckN()
        {
            Name = "Truck " + (_truckCounter++).ToString();
            Status = true;
            TextColor = Brushes.Blue;
            Pen = new Pen(Color.Blue);
        }

        public static int _truckCounter;
    }
}