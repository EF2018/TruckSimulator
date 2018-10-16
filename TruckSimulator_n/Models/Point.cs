using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TruckSimulator_n
{
    [Table("PointSet")]
    public partial class Point:IPoint
    {
        #region Properties        
        [Key]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Coordinate Position
        {
            set { _position = value; }
            get { return _position; }
        }

        #endregion

        #region CTOR
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Point(Coordinate position)
        {
            Position = position;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Point()
        {
            Position = new Coordinate();
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
        private Coordinate _position;
        #endregion
    }
}
