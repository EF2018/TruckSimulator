using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace TruckSimulator
{
    public class BruteForce: Builder, IRouteSearcher
    {
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
            _qPointsOfRoute = arrayPoints.Count() + 1;
            a = CreatePermutationArr();//инициализация массив перебора
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
        /// Поиск и построение кратчайшего маршрута  
        /// </summary>
        /// <returns></returns>
        public List<Point> BuildBestRoute()
        {
            this.GetBestRoute();
            return BuildRouteByPoints(BestCombinationArray[0]);
        }

        /// <summary>
        /// Поиск кратчайшего маршрута. Помещает его в BestCombinationArray
        /// </summary>
        public void GetBestRoute()
        {
            int n = QpointsOfRoute;//this.CountPointsOfRoute()+1;
            if (t == n - 1)
            {
                ChangeToRoute();
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
        private void ChangeToRoute()
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

        private static int[] a;
        private static int t; //индекс элемента, который включается в очередную перестановку
        private static int _bestCombinationArrayCount;//длина массива лучшей перестановки
        private static List<int[]> b = new List<int[]>();

        private List<Cargo> _arrayPointsTemp;//
        private int _qPointsOfRoute;//количество точек в маршруте
    }
}
