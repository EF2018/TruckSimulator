using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSimulator;
using System.Windows.Forms;
using System.Threading;

namespace TruckSimulator
{
    class MapPresenter
    {
        public IMap mapview;
        public Map _map;

        public MapPresenter(IMap view)
        {
            mapview = view;
            _map = new Map();
        }

        public void ShowPoints()
        {
            _map.NumCargoes = Convert.ToInt32(mapview.QCargo);
            _map.NumTrucks = Convert.ToInt32(mapview.QTruck);
            _map.Iteration = Convert.ToInt32(mapview.Qiterations);
            _map.WidthMap = mapview.width;
            _map.HeightMap = mapview.height;
            _map.InitPoints();

            ShowMyMap();
        }

        public void ShowMyMap()
        {    
            mapview.curIteration = _map.CurIteration.ToString();
            mapview.QCargo = _map.NumCargoes.ToString();
            mapview.QTruck = _map.NumTrucks.ToString();
            mapview.Qiterations = _map.Iteration.ToString();
            _map.WidthMap = mapview.width;
            _map.HeightMap = mapview.height;
            mapview.Field = _map.ShowMap();
        }

        //public void LoadData()
        //{
        //    mapview.Field = _map.ShowMap();
        //    mapview.curIteration = _map.CurIteration.ToString();
        //}

        public ArrayList GetArrayList()
        {
            return _map.GetITruckList();
        }

        public void Runs1(del method)
        {
            _map.RunMap(method);
        }
    }
}