using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TruckSimulator.Models
{
    class BruteForce: Builder, IRouteSearcher
    {
        //public List<Cargo> ArrayPoints
        //{
        //    get { return _arrayPoints; }
        //    set { _arrayPoints = value; }
        //}

        //public ITruck Truck
        //{
        //    get { return _truck; }
        //    set { _truck = value; }
        //}

        //public List<List<Cargo>> BestCombinationArray
        //{
        //    get { return _bestCombinationArray; }
        //    set { _bestCombinationArray = value; }
        //}

        public List<Cargo> ArrayPointsTemp
        {
            get { return _arrayPointsTemp; }
            set { _arrayPointsTemp = value; }
        }

        public int QpointsOfRoute
        {
            get { return _qPointsOfRoute; }
            set { _qPointsOfRoute = value; }
        }


        public BruteForce(List<Cargo> arrayPoints, ITruck truck):base(arrayPoints, truck)
        {
            //_arrayPoints = arrayPoints;
            //_truck = truck;
            _qPointsOfRoute = arrayPoints.Count() + 1;
            a = CreatePermutationArr();//инициализация массив перебора
            //_bestCombinationArray = new List<List<Cargo>>();
        }

        /// <summary>
        /// Cоздаем и инициализируем массив значений точек перебора
        /// </summary>
        /// <returns></returns>
        private int[] CreatePermutationArr()
        {
            int[] permutationArray = new int[this.CountPointsOfRoute()];
            for (int i = 0; i < this.CountPointsOfRoute(); i++)
            {
                permutationArray[i] = i + 1;
            }
            return permutationArray;
        }

        /// <summary>
        /// Вычисляет общую длину маршрута
        /// </summary>
        /// <returns></returns>
        //public int LenghtRoute(List<Cargo> Arr)
        //{
        //    return this.BuildRouteByPoints(Arr).Count;
        //}

        /// <summary>
        /// Выдает количество ходов в маршруте
        /// </summary>
        /// <returns></returns>
        //private int CountPointsOfRoute()
        //{
        //    return ArrayPoints.Count;
        //}

        /// <summary>
        /// Построение маршрута по списку точек
        /// </summary>
        /// <returns></returns>
        //public List<Point> BuildRouteByPoints(List<Cargo> Arr)
        //{
        //    List<Point> Route = new List<Point>();
        //    Way approach = new Way((Point)Truck, Arr[0]);
        //    Route.AddRange(approach.BuildLine());
        //    Route.Add(Arr[0]);

        //    for (int i = 0; i < Arr.Count - 1; i++)
        //    {
        //        Way trip = new Way(Arr[i], Arr[i + 1]);
        //        Route.AddRange(trip.BuildLine());
        //        Route.Add(Arr[i + 1]);
        //    }
        //    return Route;
        //}

        /// <summary>
        /// Поиск и построение кратчайшего маршрута  
        /// </summary>
        /// <returns></returns>
        public List<Point> BuildBestRoute()
        {
            this.GetBestRoute();
            return BuildRouteByPoints(BestCombinationArray[0]);
        }

        /// <summary>
        /// Ищет кратчайший маршрут и помещает его в BestCombinationArray
        /// </summary>
        public void GetBestRoute()
        {
            int n = QpointsOfRoute;//this.CountPointsOfRoute()+1;
            if (t == n - 1)
            {
                ChangeNumbersToRoute();
                if (BestCombinationArray.Count == 0)//если еще не заполнен
                {
                    BestCombinationArray.Add(ArrayPointsTemp);
                    _bestCombinationArrayCount = this.BuildRouteByPoints(BestCombinationArray[0]).Count();
                }
                else
                {
                    CompareWithBestRoutes();
                }
                //Route1._bestCombinationArray.Add(combinationArr);
                //Route1.b.Add(b1);//проверка
            }
            else
            {
                for (int j = t; j < n - 1; ++j)
                {
                    int c = a[t];//обмен
                    a[t] = a[j];
                    a[j] = c;
                    t++;
                    this.GetBestRoute(); //Рекурсивный вызов
                    t--;
                    int d = a[t];
                    a[t] = a[j];
                    a[j] = d;
                }
            }
        }

        /// <summary>
        /// Получение маршрута из числовой перестановки 
        /// </summary>
        private void ChangeNumbersToRoute()
        {
            //int n = this.CountPointsOfRoute() + 1;
            List<Cargo> combinationArr = new List<Cargo>(); //Создаем технический массив для размещения в нем комбинации маршрута

            //int[] b1 = new int[QpointsOfRoute - 1];//проверка
            for (int i = 0; i < a.Length; i++)
            {
                combinationArr.Add(ArrayPoints[a[i] - 1]);
                //    b1[i] = a[i];//проверка
            }
            ArrayPointsTemp = combinationArr;
        }

        /// <summary>
        /// Сравнение маршрутов и отбор минимального 
        /// </summary>
        /// <param name="CompareArr"></param>
        private void CompareWithBestRoutes()
        {
            int newroute = this.BuildRouteByPoints(ArrayPointsTemp).Count();
            int bestroute = _bestCombinationArrayCount;//this.BuildRouteByPoints(BestCombinationArray[0]).Count();

            if (newroute < bestroute)
            {//вставляем новое минимальное значение комбинации
                BestCombinationArray.Clear();
                BestCombinationArray.Add(ArrayPointsTemp);
                _bestCombinationArrayCount = this.BuildRouteByPoints(BestCombinationArray[0]).Count();
            }
            //           применить при оценке конкурентных маршрутов
            //           if (newroute == bestroute)
            //           {
            //               Route._bestCombinationArray.Add(ArrayPointsTemp);
            //           }
        }

        //public void DrawRoute(Bitmap bmpmain)
        //{
        //    Way way0 = new Way((Point)Truck, ArrayPoints[0]);
        //    way0.DrawLine(bmpmain);

        //    for (int i = 0; i < ArrayPoints.Count - 1; i++)
        //    {
        //        Way way = new Way(ArrayPoints[i], ArrayPoints[i + 1]);
        //        way.DrawLine(bmpmain);
        //    }
        //}

        //public void ClearRoute(Bitmap bmpmain)
        //{
        //    Way way0 = new Way((Point)Truck, ArrayPoints[0]);
        //    way0.Clear(bmpmain);

        //    for (int i = 0; i < ArrayPoints.Count - 1; i++)
        //    {
        //        Way way = new Way(ArrayPoints[i], ArrayPoints[i + 1]);
        //        way.Clear(bmpmain);
        //    }
        //}

        private static int[] a;
        private static int t; //индекс элемента, который включается в очередную перестановку
        private static int _bestCombinationArrayCount;//длина массива лучшей перестановки
        private static List<int[]> b = new List<int[]>();

        //private static List<List<Cargo>> _bestCombinationArray = new List<List<Cargo>>();//массив лучшей перестановки

        //public ITruck _truck { get; set; }//авто
        //public List<Cargo> _arrayPoints { get; set; }//входящий список точек маршрута
        //private int _arraPointsCount; //входящее количество точек маршрута

        private List<Cargo> _arrayPointsTemp;//
        private int _qPointsOfRoute;//количество точек в маршруте
    }
}
