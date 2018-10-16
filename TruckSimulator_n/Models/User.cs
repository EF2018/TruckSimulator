using System.Collections.Generic;
using System.Linq;
using System.Drawing;
using System.ComponentModel.DataAnnotations.Schema;

namespace TruckSimulator_n
{
    [Table("PointSet_User")]
    public class User: Vehicle
    {
        //delegate void ClickMouse1();
        //ClickMouse1 del;
        //del=Action();

        [NotMapped]
        public List<Cargo> ChoosePointsArr
        {
            get { return _choosePointsArr; }
            set { _choosePointsArr = value; }
        }

        public User(Coordinate position):base(position)
        {
            Position = position;
            ChoosePointsArr = new List<Cargo>();
            Status = true;
            Name = "User";
            Pen = new Pen(Color.Orange, 1);
            TextColor = Brushes.Orange;
        }

        public User()
        {
            ChoosePointsArr = new List<Cargo>();
            Status = true;
            Name = "User";
            Pen = new Pen(Color.Orange, 1);
            TextColor = Brushes.Orange;
        }

        public override void Action(Map map)//PictureBox pictureBox)
        {
            RequestStatus();
            
            if (!Status)
            {
                Move(map);//pictureBox);
            }
        }

        /// <summary>
        /// Запрос статуса 
        /// </summary>
        public void RequestStatus()
        {
            if (RoutePoint.Count() > StepOfRoute) 
            {
                Status = false;
            }
            else
            {
                Status = true;
            }
        }

        /// <summary>
        /// Остановка движения 
        /// </summary>
        public override void StopMove()
        {
        }

        /// <summary>
        /// Выбор точки
        /// </summary>
        /// <param name="cargo"></param>
        /// <param name="bmpmain"></param>
        public void ChoosePoint(Cargo cargo, Bitmap bmpmain)
        {
            if (FindIndexCargoInChoosePointsArr(cargo) == null)
            {
                AddPointToArr(cargo, bmpmain);
            }
            else
            {
                DeletePointFromArr(cargo, bmpmain);
            }
        }
        
        /// <summary>
        /// Поиск груза списке отобранных точек
        /// </summary>
        /// <param name="cargo"></param>
        /// <returns></returns>
        private Cargo FindIndexCargoInChoosePointsArr(Cargo cargo)
        {
            foreach (var item in ChoosePointsArr)
            {
                if (item == cargo)
                {
                    return item;
                }
            }
            return null;
        }

        /// <summary>
        /// Добавление точки в список
        /// </summary>
        /// <param name="cargo"></param>
        /// <param name="bmpmain"></param>
        public void AddPointToArr(Cargo cargo, Bitmap bmpmain)
        {
            ChoosePointsArr.Add(cargo);
            UpdateRoute(bmpmain);
        }

        /// <summary>
        /// Удаление точки из списка
        /// </summary>
        /// <param name="cargo"></param>
        /// <param name="bmpmain"></param>
        public void DeletePointFromArr(Cargo cargo, Bitmap bmpmain)
        {
            BruteForce myRoute = new BruteForce(ChoosePointsArr, this);
            myRoute.ClearRoute(bmpmain);
            ChoosePointsArr.Remove(cargo);
            UpdateRoute(bmpmain);
        }

        /// <summary>
        /// Обновление маршрута
        /// </summary>
        /// <param name="bmpmain"></param>
        private void UpdateRoute(Bitmap bmpmain)
        {
            BruteForce myRoute = new BruteForce(ChoosePointsArr, this);
            RoutePoint = myRoute.BuildRouteByPoints(ChoosePointsArr);//RouteList = myRoute.BuildRouteByPoints(ChoosePointsArr);
            myRoute.ClearRoute(bmpmain);
            myRoute.DrawRoute(bmpmain);
        }

        //public delegate void MouseClick();
        
        //public event MouseClick Withdrawn;

        private List<Cargo> _choosePointsArr;
    }
}
