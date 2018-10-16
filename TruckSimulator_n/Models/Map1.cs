using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Windows.Forms;

namespace TruckSimulator_n
{
    public delegate void del(object x, EventArgs y);

    public class Map //: TruckSimulatorDAL.DataAccessLayer
    {
        //Constructor by default
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Map()
        {
            TruckNs = new HashSet<TruckN>();
        }

        //public Map(string con) : base(con)
        //{
        //    StrCon = con;
        //}

        [Key]
        public int Map_id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string MapName
        {
            get { return _mapName; }
            set { _mapName = value; }
        }

        public int NumCargoes
        {
            get { return _numCargoes; }
            set { _numCargoes = value; }
        }

        public int NumTrucks
        {
            get { return _numTrucks; }
            set { _numTrucks = value; }
        }

        public int NumIterations
        {
            get { return _numIterations; }
            set { _numIterations = value; }
        }

        public int CurIteration
        {
            get { return _curIteration; }
            set { _curIteration = value; }
        }

        public virtual Map Maps { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TruckN> TruckNs { get; set; }

        [NotMapped]
        public ArrayList Points
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
            while (Points.Contains(new Coordinate(x, y)));
            return new Coordinate(x, y);
        }

        /// <summary>
        /// Добавление грузов на карту
        /// </summary>
        public void AddCargoes(int numCargoes)
        {
            //Coordinate empty;
            for (int count = 0; count < numCargoes; count++)
            {
                Cargo cargo = new Cargo(GetRandomCoord());
                _points.Add(cargo);
            }
        }

        /// <summary>
        /// Добавление авто на карту 
        /// </summary>
        public void AddTrucks()
        {
            Coordinate empty;
            for (int count = 0; count < NumTrucks; count++)
            {
                empty = GetRandomCoord();
                _points.Add(new Truck(empty));
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
                _points.Add(new User(empty));
            }
        }

        //public User GetUser()
        //{
        //    foreach (var item in _points)
        //    {
        //        if (item is User)
        //        {
        //            User user = (User)item;
        //            return user;
        //        }
        //    }
        //    return null;
        //}

        /// <summary>
        /// Получает текущий список грузов
        /// </summary>
        /// <returns></returns>
        public List<Cargo> GetCargoList()
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
        /// Получает список ITruck
        /// </summary>
        /// <returns></returns>
        public ArrayList GetITruckList()
        {
            ArrayList ListITruck = new ArrayList();
            foreach (var item in _points)
            {
                if (item is ITruck)
                {
                    ListITruck.Add(item);
                }
            }
            return ListITruck;
        }

        /// <summary>
        /// Проверяет наличие груза на карте
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        public bool IsActiveCargoOnMap(Coordinate CoordCargo)
        {
            List<Cargo> CargoList = GetCargoList();
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
            for (int i = 0; i < _points.Count; i++)
            {
                if (_points[i] is Cargo)
                {
                    var dd = (Cargo)_points[i];
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
            AddCargoes(NumCargoes);
            AddUser();
        }

        public Bitmap Show()
        {
            Bitmap bmpmain = new Bitmap(_widthMap, _heightMap);

            foreach (Point item in _points)
            {
                Graphics graph = Graphics.FromImage(bmpmain);
                //graph.DrawRectangle(item.Pen1, item.Position.X, item.Position.Y, 5, 5);
                graph.DrawString(item.Name, item.Font, item.TextColor, item.Position.X + 3, item.Position.Y + 3);
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
                foreach (Point on in _points.ToArray())
                {
                    on.Action(this);
                }
                method.Invoke(this, new EventArgs());
            };
            MessageBox.Show("Iterations end");
        }

        private Random _random = new Random();
        private int _id;
        private string _mapName;
        private int _numTrucks;
        private int _numCargoes;
        private int _widthMap = 100;
        private int _heightMap = 100;
        private int _numIterations;
        private int _curIteration = 0;
        private ArrayList _points = new ArrayList();
        //private int _systemTime = 0;
    }
}
