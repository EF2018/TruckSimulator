using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator
{
    public abstract class Builder
    {
        public List<List<Cargo>> BestCombinationArray
        {
            get { return _bestCombinationArray; }
            set { _bestCombinationArray = value; }
        }

        /// <summary>
        /// входящий список точек маршрута
        /// </summary>
        public List<Cargo> ArrayPoints
        {
            get { return _arrayPoints; }
            set { _arrayPoints = value; }
        }

        public ITruck Truck
        {
            get { return _truck; }
            set { _truck = value; }
        }

        public Builder(List<Cargo> arrayPoints, ITruck truck)
        {
            _arrayPoints = arrayPoints;
            _truck = truck;
            _bestCombinationArray = new List<List<Cargo>>();
        }

        /// <summary>
        /// Вычисляет общую длину маршрута
        /// </summary>
        /// <returns></returns>
        public int LenghtRoute(List<Cargo> Arr)
        {
            return this.BuildRouteByPoints(Arr).Count;
        }

        /// <summary>
        /// Выдает количество ходов в маршруте
        /// </summary>
        /// <returns></returns>
        public int CountPointsOfRoute()
        {
            return ArrayPoints.Count;
        }

        public List<Point> BuildRouteByPoints(List<Cargo> Arr)
        {
            List<Point> Route = new List<Point>();
            Way approach = new Way((Point) Truck, Arr[0]);
            Route.AddRange(approach.BuildWay());
            Route.Add(Arr[0]);

            for (int i = 0; i < Arr.Count - 1; i++)
            {
                Way trip = new Way(Arr[i], Arr[i + 1]);
                Route.AddRange(trip.BuildWay());
                Route.Add(Arr[i + 1]);
            }
            return Route;
        }


        public void DrawRoute(Bitmap bmpmain)
        {
            Way way0 = new Way((Point)Truck, ArrayPoints[0]);
            way0.DrawWay(bmpmain);

            for (int i = 0; i < ArrayPoints.Count - 1; i++)
            {
                Way way = new Way(ArrayPoints[i], ArrayPoints[i + 1]);
                way.DrawWay(bmpmain);
            }
        }

        public void ClearRoute(Bitmap bmpmain)
        {
            Way way0 = new Way((Point)Truck, ArrayPoints[0]);
            way0.ClearWay(bmpmain);

            for (int i = 0; i < ArrayPoints.Count - 1; i++)
            {
                Way way = new Way(ArrayPoints[i], ArrayPoints[i + 1]);
                way.ClearWay(bmpmain);
            }
        }

        /// <summary>
        /// Поиск и построение кратчайшего маршрута  
        /// </summary>
        /// <returns></returns>
        //public List<Point> BuildBestRoute()
        //{
        //    this.GetBestRoute();
        //    return BuildRouteByPoints(BestCombinationArray[0]);
        //}


        static List<List<Cargo>> _bestCombinationArray = new List<List<Cargo>>();//массив лучшей перестановки
        ITruck _truck { get; set; }//авто
        List<Cargo> _arrayPoints { get; set; }

    }
}
