using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Windows.Forms;
using TruckSimulator_n;

namespace TruckSimulator_n
{
    public delegate void del(object x, EventArgs y);

    [Table("MapSet")]
    public partial class Map
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Map()
        {
            this.MapPoint = new List<MapPoint>();
        }

        [Key]
        public int IdMap { get; set; }
        public string MapName { get; set; }
        public int NumCargoes { get; set; }
        public int NumTrucks { get; set; }
        public int NumIterations { get; set; }
        public int CurIteration { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual List<MapPoint> MapPoint
        {
            get { return _points; }
            set { _points = value; }
        }

        [NotMapped]
        public int WidthMap
        {
            get { return _widthMap; }
            set { _widthMap = value; }
        }

        [NotMapped]
        public int HeightMap
        {
            get { return _heightMap; }
            set { _heightMap = value; }
        }
        /// <summary>
        /// Получает новые случайные координаты
        /// </summary>
        /// <returns></returns>
        public Coordinate GetRandomCoord()
        {
            int x, y;
            do
            {
                x = _random.Next(15, WidthMap - 15);
                y = _random.Next(15, HeightMap - 15);
            }
            while (MapPoint.Contains(new MapPoint(new Coordinate(x, y))));
            return new Coordinate(x, y);
        }

        /// <summary>
        /// Добавление грузов на карту
        /// </summary>
        public void AddCargoes()
        {
            Cargo._cargoCounter = 1;
            //Coordinate empty;
            for (int count = 0; count < NumCargoes; count++)
            {
                Cargo cargo = new Cargo(GetRandomCoord());
                MapPoint.Add(cargo);
            }
        }

        /// <summary>
        /// Добавление авто на карту 
        /// </summary>
        public void AddTrucks()
        {
            TruckN._truckCounter = 1;

            Color[] ColorColl = new Color[10];
            ColorColl[0] = Color.Blue;
            ColorColl[1] = Color.YellowGreen;
            ColorColl[2] = Color.Gold;
            ColorColl[3] = Color.Indigo;
            ColorColl[4] = Color.Violet;
            ColorColl[5] = Color.Yellow;
            ColorColl[6] = Color.Tomato;
            ColorColl[7] = Color.Black;
            ColorColl[8] = Color.Brown;
            ColorColl[9] = Color.HotPink;

            Brush[] ColorColl1 = new Brush[10];
            ColorColl1[0] = Brushes.Blue;
            ColorColl1[1] = Brushes.YellowGreen;
            ColorColl1[2] = Brushes.Gold;
            ColorColl1[3] = Brushes.Indigo;
            ColorColl1[4] = Brushes.Violet;
            ColorColl1[5] = Brushes.Yellow;
            ColorColl1[6] = Brushes.Tomato;
            ColorColl1[7] = Brushes.Black;
            ColorColl1[8] = Brushes.Brown;
            ColorColl1[9] = Brushes.HotPink;


            Coordinate empty;
            for (int count = 0; count < NumTrucks; count++)
            {
                empty = GetRandomCoord();
                TruckSimulator_n.TruckN truck = new TruckSimulator_n.TruckN(empty);
                truck.Pen = new Pen(ColorColl[count]);
                truck.TextColor = ColorColl1[count];
                MapPoint.Add(truck);
            }
        }

        /// <summary>
        /// Добавление авто пользователя
        /// </summary>
        public void AddUser()
        {
            Coordinate empty;
            for (int count = 0; count < 1; count++)
            {
                empty = GetRandomCoord();
                MapPoint.Add(new User(empty));
            }
        }

        /// <summary>
        /// Получает список активных грузов
        /// </summary>
        /// <returns></returns>
        public List<Cargo> GetActiveCargoList()
        {
            List<Cargo> ListCargo = new List<Cargo>();
            foreach (var item in _points)
            {
                if (item is Cargo)
                {
                    Cargo item1 = (Cargo)item;
                    if (item1.StatusCargo == true)
                    {
                        ListCargo.Add((Cargo)item);
                    }
                }
            }
            return ListCargo;
        }

        /// <summary>
        /// Информируем все авто о появлении нового груза
        /// </summary>
        public void InformAllVehicleAboutChanges()
        {
            foreach (Vehicle item in this.GetITruckList())
            {
                item.Status = true;
                item.StepOfRoute = 0;
            }
        }


        /// <summary>
        /// Получает список ITruck
        /// </summary>
        /// <returns></returns>
        public ArrayList GetITruckList()
        {
            ArrayList VehicleList = new ArrayList();
            foreach (var item in _points)
            {
                if (item is Vehicle)
                {
                    VehicleList.Add(item);
                }
            }
            return VehicleList;
        }

        /// <summary>
        /// Проверяет наличие груза на карте
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public bool IsActiveCargoOnMap(Coordinate CoordCargo)
        {
            List<Cargo> CargoList = GetActiveCargoList();
            foreach (var item in CargoList)
            {
                if (item.Position == CoordCargo && item.StatusCargo == true)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Возвращает индекс искомого груза
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public int FindIndexCargoOnMap(Coordinate CoordCargo)
        {
            
            for (int i = 0; i < MapPoint.Count; i++)
            {
                if (MapPoint[i] is Cargo)
                {
                    var dd = (Cargo)MapPoint[i];
                    if (dd.Position == CoordCargo)
                        return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// Удаление груза с карты
        /// </summary>
        /// <param name="index"></param>
        public void LoadCargo(Coordinate CoordCargo)
        {
            int index = FindIndexCargoOnMap(CoordCargo);
            ((Cargo)_points[index]).Pen = new Pen(Color.RosyBrown);
            ((Cargo)_points[index]).StatusCargo = false;
            ((Cargo)_points[index]).TextColor = Brushes.RosyBrown;

            Cargo cargo = new Cargo(GetRandomCoord());
            //_points[index] = cargo;
            _points.Add(cargo);
        }

        /// <summary>
        /// Инициализация точек
        /// </summary>
        public void InitPoints()
        {
            //Truck._truckCounter = 1;
            //Cargo._cargoCounter = 0;
            if (_numTrucks > 10)
            {
                _numTrucks = 10;
            }

            if (_numCargoes > 10)
            {
                _numCargoes = 10;
            }
            AddTrucks();
            AddCargoes();
            AddUser();
        }

        public Bitmap Show()
        {
            Bitmap bmpmain = new Bitmap(Properties.Resources.europe_10, WidthMap, HeightMap);

            foreach (MapPoint item in MapPoint)
            {
                Graphics graph = Graphics.FromImage(bmpmain);
                graph.DrawRectangle(item.Pen, item.Position.X, item.Position.Y, 5, 5);
                graph.DrawString(item.Name, item.Font, item.TextColor, item.Position.X + 3, item.Position.Y + 3);
                if (item is Vehicle)
                {
                    var vehicle = (Vehicle)item;
                    for (int i = vehicle.StepOfRoute; i < vehicle.RoutePoint.Count; i++)
                    {
                        graph.DrawRectangle(item.Pen, vehicle.RoutePoint[i].Position.X, vehicle.RoutePoint[i].Position.Y, 0.5f, 0.5f);
                    }
                }
            }
            return bmpmain;
        }

        //internal void RunMap(del meth)
        //{
        //    Task task = new Task(() => RunMap1(meth));
        //    task.Start();
        //    task.Wait();
        //}

        /// <summary>
        /// Запуск генерации
        /// </summary>
        /// <param name="method"></param>
        public void RunMap(del method)
        {
            for (; CurIteration < NumIterations; CurIteration++)
            {
                foreach (MapPoint one in MapPoint.ToArray())
                {
                    one.Action(this);
                }
                method.Invoke(this, new EventArgs());
            };
            MessageBox.Show("Iterations end");
        }

        private Random _random = new Random();
        private string _mapName;
        private int _numTrucks;
        private int _numCargoes;
        private int _numIterations;
        private int _curIteration = 0;
        private List<MapPoint> _points = new List<MapPoint>();
        private int _widthMap = 100;
        private int _heightMap = 100;
        //private int _systemTime = 0;
    }
}
