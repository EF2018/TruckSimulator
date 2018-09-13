using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator.Models
{
    abstract class Builder
    {
        public static List<List<Cargo>> _bestCombinationArray = new List<List<Cargo>>();//массив лучшей перестановки
        public ITruck _truck { get; set; }//авто
        public List<Cargo> _arrayPoints { get; set; }//входящий список точек маршрута

        public List<List<Cargo>> BestCombinationArray
        {
            get { return _bestCombinationArray; }
            set { _bestCombinationArray = value; }
        }

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
            Route.AddRange(approach.BuildLine());
            Route.Add(Arr[0]);

            for (int i = 0; i < Arr.Count - 1; i++)
            {
                Way trip = new Way(Arr[i], Arr[i + 1]);
                Route.AddRange(trip.BuildLine());
                Route.Add(Arr[i + 1]);
            }
            return Route;
        }


        public void DrawRoute(Bitmap bmpmain)
        {
            Way way0 = new Way((Point)Truck, ArrayPoints[0]);
            way0.DrawLine(bmpmain);

            for (int i = 0; i < ArrayPoints.Count - 1; i++)
            {
                Way way = new Way(ArrayPoints[i], ArrayPoints[i + 1]);
                way.DrawLine(bmpmain);
            }
        }

        public void ClearRoute(Bitmap bmpmain)
        {
            Way way0 = new Way((Point)Truck, ArrayPoints[0]);
            way0.Clear(bmpmain);

            for (int i = 0; i < ArrayPoints.Count - 1; i++)
            {
                Way way = new Way(ArrayPoints[i], ArrayPoints[i + 1]);
                way.Clear(bmpmain);
            }
        }
    }
}
