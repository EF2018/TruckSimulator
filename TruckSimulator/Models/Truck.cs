using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace TruckSimulator.Models
{
    class Truck : Point, ITruck
    {
        public int Fuelbalance
        {
            get { return _fuelbalance; }
            set { _fuelbalance = value; }
        }

        public bool Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public List<Point> RouteList
        {
            get { return _routeList; }
            set { _routeList = value; }
        }

        public int StepOfRoute
        {
            get { return _stepOfRoute; }
            set { _stepOfRoute = value; }
        }

        public int FuelCharge
        {
            get { return _fuelCharge; }
            set { _fuelCharge = value; }
        }

        
        public Truck(Coordinate position)
            : base(position)
        {
            Name = (_truckCounter++).ToString();
            _fuelbalance = 0;
            _fuelCharge = 3;
            _status = true;
            _stepOfRoute = 0;
            Pen = new Pen(Color.Blue);
            TextColor = Brushes.Blue;
        }

        /// <summary>
        /// Поиск маршрута
        /// </summary>
        public override void Action(Map map)//PictureBox pictureBox)
        {
            if (Status)//если свободен - ищем новый маршрут
            {
                List<Cargo> myListCargo = map.GetCargoList();
                BruteForce myRoute = new BruteForce(myListCargo, this);
                RouteList = myRoute.BuildBestRoute();
                Status = false;
            }
            Move(map);//pictureBox);
        }


        /// <summary>
        /// Передвижение по маршруту
        /// </summary>
        /// <returns></returns>
        public void Move(Map map)//PictureBox pictureBox)
        {
            StepOfRoute++;
            if (StepOfRoute < RouteList.Count)
            {
                Fuelbalance -= FuelCharge;//расход топлива на движение
                this.Position = RouteList[StepOfRoute].Position;
                if (RouteList[StepOfRoute] is Cargo)
                {
                    Coordinate CoordCargo = RouteList[StepOfRoute].Position;
                    //Map myMap = new Map(pictureBox.Width, pictureBox.Height);
                    if (map.IsActiveCargoOnMap(CoordCargo))//myMap.IsActiveCargoOnMap(CoordCargo))
                    {
                        Fuelbalance += ((Cargo)RouteList[StepOfRoute]).Value;
                        map.LoadCargo(CoordCargo);//myMap.LoadCargo(CoordCargo);//добавление нового груза на карту
                    }
                    else
                    {
                        StopMove();
                    }
                }
            }
            else
            {
                StopMove();
            }
        }

        /// <summary>
        /// Остановка движения 
        /// </summary>
        public virtual void StopMove()
        {
            StepOfRoute = 0;
            Status = true;
        }

        /// <summary>
        /// Выводит изображение
        /// </summary>
        public override void Display(Bitmap bmp)
        {
            Graphics graphics = Graphics.FromImage(bmp);
            graphics.DrawRectangle(Pen, Position.X, Position.Y, 5, 5);
        }

        private int _fuelbalance;
        private int _stepOfRoute;//номер шага в маршрутном листе 
        private int _fuelCharge;//расход топлива на 1 ход
        private bool _status;//cтатус (свободен или нет)
        private List <Point> _routeList;//маршрутный лист
        public static int _truckCounter = 1;
    }
}
