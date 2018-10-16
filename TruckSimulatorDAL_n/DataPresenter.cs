using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruckSimulator_n;

namespace TruckSimulatorDAL_n
{
    public class DataPresenter
    {
        public IMap Mapview { get; set; }
        public MyModel Unit { get; set; }
        public TruckSimulator_n.Map MapObj { get; set; }

        public DataPresenter(IMap view)
        {
            Unit = new MyModel();
            MapObj = new TruckSimulator_n.Map();
            Mapview = view;
        }

        public TruckSimulator_n.Map LoadMapByName(string name)
        {
            var searchingMap = Unit.MapSets
                .Where(p => p.MapName == name)
                .Include(c => c.MapPoint)
                .FirstOrDefault();

            return searchingMap;
        }

        public void SaveMap()
        {
            Unit.MapSets.Add(MapObj);
            Unit.SaveChanges();
        }

        public void UpdateMap(string name)
        {
            int i = Unit.MapSets
                .Where(p => p.MapName == name)
                .FirstOrDefault()
                .IdMap;

            MapObj.IdMap = i;
            Unit.MapSets.AddOrUpdate(MapObj);
            Unit.SaveChanges();
        }

        public List<TruckSimulator_n.Map> GetNamesAllMaps()
        {
            return Unit.MapSets.ToList();
        }

        public void GetDataFromForm()
        {
            MapObj.NumCargoes = Convert.ToInt32(Mapview.QCargo);
            MapObj.NumTrucks = Convert.ToInt32(Mapview.QTruck);
            MapObj.NumIterations = Convert.ToInt32(Mapview.Qiterations);
            MapObj.WidthMap = Mapview.width;
            MapObj.HeightMap = Mapview.height;
            MapObj.InitPoints();
        }

        public void ShowMap()
        {
            Mapview.MapName = MapObj.MapName;
            Mapview.curIteration = MapObj.CurIteration.ToString();
            Mapview.QCargo = MapObj.NumCargoes.ToString();
            Mapview.QTruck = MapObj.NumTrucks.ToString();
            Mapview.Qiterations = MapObj.NumIterations.ToString();
            MapObj.WidthMap = Mapview.width;
            MapObj.HeightMap = Mapview.height;
            Mapview.Field = MapObj.Show();
        }

        public ArrayList GetArrayList()
        {
            return MapObj.GetITruckList();
        }

        public void Runs1(del method)
        {
            MapObj.RunMap(method);
        }

    }
}
