using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace TruckSimulator
{
    public class Way
    {
        public Point StartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }

        public Point EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; }
        }

        public Way(Point start, Point finish)
        {
            _startPoint = start;
            _endPoint = finish;
        }

        /// <summary>
        /// Вычисление длины ломаной линии от начальной точки к конечной 
        /// </summary>
        /// <returns></returns>
        public int CountLenghtWay()
        {
            return this.BuildWay().Length;
        }

        /// <summary>
        /// Метод строит ломанную максимально привязываясь к прямой между двумя точками
        /// </summary>
        /// <returns></returns>
        public Point[] BuildWay()
        {
            Point[] LineArray = new Point[1] { new Point() };//???
            double x1 = StartPoint.Position.X;
            double x2 = EndPoint.Position.X;
            double y1 = StartPoint.Position.Y;
            double y2 = EndPoint.Position.Y;
            double i1;
            double i2;
            double j1;
            double j2;
            int i3 = 1; //счетчик для изменения размера массива

            if (x1 > x2)
            {
                i1 = x2; i2 = x1;
            }
            else
            {
                i1 = x1; i2 = x2;
            }

            for (; i1 < i2; i1++)
            {
                double Y = (x1 * y2 - x2 * y1 + i1 * y1 - i1 * y2) / (x1 - x2);
                Array.Resize(ref LineArray, i3);
                LineArray[i3 - 1] = new Point();
                LineArray[i3 - 1].Position.X = (int)i1;
                LineArray[i3 - 1].Position.Y = (int)Y;
                i3 += 1;
            }

            if (y1 > y2)
            {
                j1 = y2; j2 = y1;
            }
            else
            {
                j1 = y1; j2 = y2;
            }

            for (; j1 < j2; j1++)
            {
                double X = (x2 * y1 + x1 * j1 - x2 * j1 - x1 * y2) / (y1 - y2);
                Array.Resize(ref LineArray, i3);
                LineArray[i3 - 1] = new Point();
                LineArray[i3 - 1].Position.X = (int)X;
                LineArray[i3 - 1].Position.Y = (int)j1;
                i3 += 1;
            }

            //Сортировка массива LineArray по Х коордитатам точек
            for (int k = 0; k < LineArray.Length; k++)
            {
                for (int l = k + 1; l < LineArray.Length; l++)
                {
                    if (LineArray[k].Position.X > LineArray[l].Position.X)//если первый элемент больше l-элемента, =>обмен 
                    {
                        Point C = new Point(new Coordinate());
                        C = LineArray[k];
                        LineArray[k] = LineArray[l];
                        LineArray[l] = C;
                    }
                }
            }

            //Построение ломаной линии по отрезкам
            //Создаем новый массив для размещения в нем точек ломанной на основе массива Point
            Point[] BrokenLineArray = new Point[LineArray.Length];
            for (int i = 0; i < BrokenLineArray.Length; i++)
            {
                BrokenLineArray[i] = new Point();
            }

            for (int f = 0; f < LineArray.Length - 1; f++)
            {
                //для Х
                if (LineArray[f].Position.X > LineArray[f + 1].Position.X)
                {
                    double X = LineArray[f].Position.X;
                    if ((X - (int)X) > 0)
                    {
                        BrokenLineArray[f].Position.X = (int)X + 1;
                    }
                    else
                    {
                        BrokenLineArray[f].Position.X = (int)X;
                    }
                }
                else
                {
                    double X = LineArray[f + 1].Position.X;
                    if ((X - (int)X) > 0)
                    {
                        BrokenLineArray[f].Position.X = (int)X + 1;
                    }
                    else
                    {
                        BrokenLineArray[f].Position.X = (int)X;
                    }
                }
                //для Y
                if (LineArray[f].Position.Y > LineArray[f + 1].Position.Y)
                {
                    double Y = LineArray[f].Position.Y;
                    if ((Y - (int)Y) > 0)
                    {
                        BrokenLineArray[f].Position.Y = (int)Y + 1;
                    }
                    else
                    {
                        BrokenLineArray[f].Position.Y = (int)Y;
                    }
                }
                else
                {
                    double Y = LineArray[f + 1].Position.Y;
                    if ((Y - (int)Y) > 0)
                    {
                        BrokenLineArray[f].Position.Y = (int)Y + 1;
                    }
                    else
                    {
                        BrokenLineArray[f].Position.Y = (int)Y;
                    }
                }
                //BrokenLineArray[f].Symbol = '.';
                //BrokenLineArray[f].Color = ConsoleColor.White;
                //BrokenLineArray[f].backColor = ConsoleColor.Black;
            }
            if (StartPoint.Position.X > EndPoint.Position.X)
            {
                Array.Reverse(BrokenLineArray);

                int i = 0;
                do
                {
                    BrokenLineArray[i] = BrokenLineArray[i + 1];
                    i++;
                } while (i < BrokenLineArray.Length - 1);

            }
            return BrokenLineArray;
        }

        public Bitmap DrawWay(Bitmap bmpmain)
        {
            Pen penline = new Pen(Color.Red, 1);
            Graphics graph = Graphics.FromImage(bmpmain);
            graph.DrawLine(penline, StartPoint.Position.X, StartPoint.Position.Y, EndPoint.Position.X, EndPoint.Position.Y);
            return bmpmain;
        }

        public Bitmap ClearWay(Bitmap bmpmain)
        {
            Pen penline = new Pen(Color.White, 1);
            Graphics graph = Graphics.FromImage(bmpmain);
            graph.DrawLine(penline, StartPoint.Position.X, StartPoint.Position.Y, EndPoint.Position.X, EndPoint.Position.Y);
            return bmpmain;
        }

        //public Bitmap DisplayWays(Point[] way, Bitmap bmp)
        //{
        //    Pen pen = new Pen(Color.Aqua);
        //    foreach (var item in way)
        //    {
        //        Graphics graph = Graphics.FromImage(bmp);
        //        graph.DrawRectangle(pen, item.Position.X, item.Position.Y, 1, 1);
        //    }
        //    return bmp;
        //}

        private Point _startPoint;
        private Point _endPoint;
    }
}
