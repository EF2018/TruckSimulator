using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TruckSimulator_n
{
    public class TruckN: Point, ITruck
    {
        [Key]
        public int TruckN_id
        {
            get { return _idTruck; }
            set { _idTruck = value; }
        }

        //[ForeignKey("Maps")]
        public int Map_id
        {
            get { return _idMap; }
            set { _idMap = value; }
        }

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

        public int StepOfRoute
        {
            get { return _stepOfRoute; }
            set { _stepOfRoute = value; }
        }

        [NotMapped]
        public int FuelCharge
        {
            get { return _fuelCharge; }
            set { _fuelCharge = value; }
        }

        public virtual Map Maps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Point> Points { get; set; }

        public List<Point> RouteList
        {
            get { return Points.ToList(); }
            set { Points = value; }
        }

        public TruckN()
        {
            Points = new HashSet<Point>();
            Pen = new Pen(Color.Blue);
            TextColor = Brushes.Blue;
            RouteList = new List<Point>();
        }

        public TruckN(Coordinate position): base(position)
        {
            Points = new HashSet<Point>();
            Name = (_truckCounter++).ToString();
            Fuelbalance = 0;
            FuelCharge = 3;
            Status = true;
            StepOfRoute = 0;
            Pen = new Pen(Color.Blue);
            TextColor = Brushes.Blue;
            RouteList = new List<Point>();
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
                Points = myRoute.BuildBestRoute();
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
            if (StepOfRoute < Points.Count)
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

        private int _idTruck;
        private int _idMap;
        private int _fuelbalance;
        private int _stepOfRoute;//номер шага в маршрутном листе 
        private int _fuelCharge;//расход топлива на 1 ход
        private bool _status;//cтатус (свободен или нет)
        //private List <Point> _routeList;//маршрутный лист
        //private ICollection<Map> _maps;
        private static int _truckCounter = 1;

    }
}
//public partial class Truck
//{
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//    public Truck()
//    {
//        this.RouteLists = new HashSet<RouteList>();
//    }

//    public int Id { get; set; }
//    public int IdMap { get; set; }
//    public string Name { get; set; }
//    public int Fuelbalance { get; set; }
//    public int StepOfRoute { get; set; }
//    public bool Status { get; set; }
//    public int IdCoordinate { get; set; }

//    public virtual Coordinate Coordinate { get; set; }
//    public virtual Map Map { get; set; }
//    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//    public virtual ICollection<RouteList> RouteLists { get; set; }
//}



//namespace TruckSimulatorDAL
//{
//    using System;
//    using System.Collections.Generic;
//
//    public partial class Truck
//    {
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public Truck()
//        {
//            this.RouteLists = new HashSet<RouteList>();
//        }

//        public int Id { get; set; }
//        public int IdMap { get; set; }
//        public string Name { get; set; }
//        public int Fuelbalance { get; set; }
//        public int StepOfRoute { get; set; }
//        public bool Status { get; set; }
//        public int IdCoordinate { get; set; }

//        public virtual Coordinate Coordinate { get; set; }
//        public virtual Map Map { get; set; }
//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<RouteList> RouteLists { get; set; }
//    }
//}