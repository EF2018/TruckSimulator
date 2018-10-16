using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TruckSimulator_n
{
    [Table("PointSet_Cargo")]
    public partial class Cargo : MapPoint
    {
        public bool StatusCargo
        {
            get { return _statusCargo; }
            set { _statusCargo = value; }
        }

        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        #region CTOR
        public Cargo()
        {
            Pen = new Pen(Color.Red);
            TextColor = Brushes.Red;
        }

        public Cargo(Coordinate position) : base(position)
        {
            Name = (_cargoCounter++).ToString();
            Value = 1000;
            StatusCargo = true;
            Pen = new Pen(Color.Red, 2);
            TextColor = Brushes.Red;
        }
        #endregion

        /// <summary>
        /// Выводит изображение
        /// </summary>
        public override void Display(Bitmap bmp)
        {
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.DrawRectangle(Pen, Position.X, Position.Y, 5, 5);
        }

        #region Attributes
        private int _value;
        public static int _cargoCounter;
        private bool _statusCargo;
        #endregion
    }
}
