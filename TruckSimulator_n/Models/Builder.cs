using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator_n
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

        public Vehicle Truck
        {
            get { return _truck; }
            set { _truck = value; }
        }

        public Builder(List<Cargo> arrayPoints, Vehicle truck)
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

        public List<IPoint> BuildRouteByPoints(List<Cargo> Arr)
        {
            List <IPoint> Route = new List<IPoint>();
            Way approach = new Way(Truck.Position, Arr[0].Position);
            Route.AddRange(approach.BuildWay());
            Route.Add(Arr[0]);

            for (int i = 0; i < Arr.Count - 1; i++)
            {
                Way trip = new Way(Arr[i].Position, Arr[i + 1].Position);
                Route.AddRange(trip.BuildWay());
                Route.Add(Arr[i + 1]);
            }

            //перевод на Route
            //List <RoutePoint> Newroute = new List<RoutePoint>();
            //foreach (var item in Route)
            //{
            //    RoutePoint rr = new RoutePoint();
            //    rr.Position = item.Position;
            //    rr.Vehicle = Truck;
            //    rr.IdRoutePoint = Truck.Id;
            //    Newroute.Add(rr);
            //}

            return Route;
        }


        public void DrawRoute(Bitmap bmpmain)
        {
            Way way0 = new Way(Truck.Position, ArrayPoints[0].Position);
            way0.DrawWay(bmpmain);

            for (int i = 0; i < ArrayPoints.Count - 1; i++)
            {
                Way way = new Way(ArrayPoints[i].Position, ArrayPoints[i + 1].Position);
                way.DrawWay(bmpmain);
            }
        }

        public void ClearRoute(Bitmap bmpmain)
        {
            Way way0 = new Way(Truck.Position, ArrayPoints[0].Position);
            way0.ClearWay(bmpmain);

            for (int i = 0; i < ArrayPoints.Count - 1; i++)
            {
                Way way = new Way(ArrayPoints[i].Position, ArrayPoints[i + 1].Position);
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
        Vehicle _truck;//авто
        List<Cargo> _arrayPoints;

    }
}
