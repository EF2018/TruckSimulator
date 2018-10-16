using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TruckSimulator
{
    public class Point
    {
        #region Properties        

        [Key]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

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

        public Brush TextColor
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
            _font = new Font(FontFamily.GenericMonospace, 10);
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
        private int _id;
        private string _name;
        private Pen _pen;
        private Font _font;
        private Brush _textColor;
        private Coordinate _position;
        #endregion
    }
}
