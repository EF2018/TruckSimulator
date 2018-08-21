using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;


namespace TruckSimulator.Models
{
    class Cargo : Point
    {
        #region CTOR
        public Cargo(Coordinate position) : base(position)
        {
            Name = (_cargoCounter++).ToString();
            _value = 1000;
            _statusCargo = true;
            Pen = new Pen(Color.Red);
            //Font = new Font(FontFamily.GenericSerif, 10);
            TextColor = Brushes.Red;
        }
        #endregion

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

        public override void Action(Map map)//PictureBox pictureBox1)
        {
        }

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
