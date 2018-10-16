using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator
{
    public class Coordinate
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

        public string Lat
        {
            get { return _lat; }
            set { _lat = value; }
        }

        public string Lng
        {
            get { return _lng; }
            set { _lng = value; }
        }

        #region CTOR
        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public Coordinate()
        {
        }
        #endregion

        #region Attributes
        int _x;
        int _y;
        string _city;
        string _lat;
        string _lng;
        #endregion


    }
}
