using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator_n
{
    [Table("PointSet_MapPoint")]
    public partial class MapPoint : Point
    {
        #region Properties        
        public int MapIdMap { get; set; }
        public virtual Map Map { get; set; }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [NotMapped]
        public Font Font
        {
            get { return _font; }
            set { _font = value; }
        }

        [NotMapped]
        public Pen Pen
        {
            get { return _pen; }
            set { _pen = value; }
        }

        [NotMapped]
        public Brush TextColor
        {
            get { return _textColor; }
            set { _textColor = value; }
        }
        #endregion

        #region CTOR
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MapPoint(Coordinate position)
        {
            Position = position;
            Pen = new Pen(Color.Black);
            Font = new Font(FontFamily.GenericMonospace, 10);
            TextColor = Brushes.Black;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MapPoint()
        {
            Position = new Coordinate();
            Pen = new Pen(Color.Black);
            Font = new Font(FontFamily.GenericMonospace, 10);
            TextColor = Brushes.Black;
        }
        #endregion

        #region Attributes
        private string _name;
        private Pen _pen;
        private Font _font;
        private Brush _textColor;
        #endregion

    }
}