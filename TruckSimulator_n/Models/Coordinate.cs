
namespace TruckSimulator_n
{
    public partial class Coordinate
    {
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Coordinate()
        {
        }

        #region CTOR
        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }
        #endregion

        #region Attributes
        int _x;
        int _y;
        #endregion
    }
}
