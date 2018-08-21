using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TruckSimulator.Models
{
    class Point : IPoint
    {
        #region Properties        
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        public Pen Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }

        public Coordinate Position
        {
            set { _position = value; }
            get { return _position; }
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public System.Drawing.Brush TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
        #endregion

        #region CTOR
        public Point(Coordinate position)
        {
            _position = position;
            _pen = new Pen(Color.Black);
            _font = new Font(FontFamily.GenericMonospace, 10);
            _textColor = Brushes.Black;
        }

        public Point()
        {
            _position = new Coordinate();
            _pen = new Pen(Color.Black);
        }
        #endregion

        /// <summary>
        /// Выводит изображение точкии
        /// </summary>
        public virtual void Display(Bitmap bmp)
        {
        }

        public virtual void Action(Map map)//PictureBox pictureBox)
        {
        }

        #region Attributes
        private string _name;
        private Pen _pen;
        private Font _font;
        private System.Drawing.Brush _textColor;
        private Coordinate _position;
        #endregion
    }
}
