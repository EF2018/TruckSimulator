using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator_n
{
    [Table("PointSet_Vehicle")]
    public abstract partial class Vehicle : MapPoint
    {
        public int StepOfRoute { get { return _stepOfRoute; } set { _stepOfRoute = value; } }
        public int Fuelbalance { get { return _fuelbalance; } set { _fuelbalance = value; } }
        public bool Status { get { return _status; } set { _status = value; } }
        public int FuelCharge { get { return _fuelCharge; } set { _fuelCharge = value; } }
        [NotMapped]
        public List<IPoint> RoutePoint { get { return _routeList; } set { _routeList = value; } }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle(Coordinate position):base(position)
        {
            RoutePoint = new List<IPoint>();
            Position = position;
            StepOfRoute = 0;
            Fuelbalance = 0;
            FuelCharge = 3;
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vehicle()
        {
            RoutePoint = new List<IPoint>();
            Position = new Coordinate();
            StepOfRoute = 0;
            Fuelbalance = 0;
            FuelCharge = 3;
        }
        /// <summary>
        /// Поиск маршрута
        /// </summary>
        public override void Action(Map map)
        {
            if (Status)//если свободен - ищем новый маршрут
            {
                List<Cargo> myListCargo = map.GetActiveCargoList();
                BruteForce myRoute = new BruteForce(myListCargo, this);
                RoutePoint = myRoute.BuildBestRoute();
                Status = false;   
            }
            Move(map);
        }


        /// <summary>
        /// Передвижение по маршруту
        /// </summary>
        /// <returns></returns>
        public void Move(Map map)
        {
            StepOfRoute++;
            if (StepOfRoute < RoutePoint.Count)
            {
                Fuelbalance -= FuelCharge;//расход топлива на движение
                Position = RoutePoint[StepOfRoute].Position;

                if (RoutePoint[StepOfRoute] is Cargo)
                {
                    Coordinate CoordCargo = RoutePoint[StepOfRoute].Position;
                    if (map.IsActiveCargoOnMap(CoordCargo))
                    {
                        Fuelbalance += ((Cargo)RoutePoint[StepOfRoute]).Value;
                        map.LoadCargo(CoordCargo);//добавление нового груза на карту
                        map.InformAllVehicleAboutChanges();//информирование о появлении нового груза
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
        private List<IPoint> _routeList;//маршрутный лист
    }
}
