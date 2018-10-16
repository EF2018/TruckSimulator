using System;
using System.Collections;
using TruckSimulator_n;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using TruckSimulatorDAL_n;

namespace TruckSimulatorPL
{
    class DataMapPresenter
    {
        public IMap Mapview { get => _mapview; set => _mapview = value; }
        public TruckSimulator_n.Map Map { get => _map; set => _map = value; }
        public DataAccessLayer Dal { get => _dal; set => _dal = value; }

        public DataMapPresenter(IMap view)
        {
            _mapview = view;
            _map = new TruckSimulator_n.Map();
            _dal = new DataAccessLayer();
        }

        public DataMapPresenter(IMap view, TruckSimulator_n.Map map)
        {
            _dal = new DataAccessLayer();
            _mapview = view;
            _map = map;
        }

        public DataMapPresenter(IMap view, TruckSimulator_n.Map map, DataAccessLayer dal)
        {
            _dal = dal;
            _mapview = view;
            _map = map;
        }

        public void GetDataFromForm()
        {
            Map.NumCargoes = Convert.ToInt32(Mapview.QCargo);
            Map.NumTrucks = Convert.ToInt32(Mapview.QTruck);
            Map.NumIterations = Convert.ToInt32(Mapview.Qiterations);
            Map.WidthMap = Mapview.width;
            Map.HeightMap = Mapview.height;
            Map.InitPoints();
        }

        public void ShowMap()
        {
            Mapview.MapName = Map.MapName;
            Mapview.curIteration = Map.CurIteration.ToString();
            Mapview.QCargo = Map.NumCargoes.ToString();
            Mapview.QTruck = Map.NumTrucks.ToString();
            Mapview.Qiterations = Map.NumIterations.ToString();
            Map.WidthMap = Mapview.width;
            Map.HeightMap = Mapview.height;
            Mapview.Field = Map.Show();
        }

        public ArrayList GetArrayList()
        {
            return Map.GetITruckList();
        }

        public void Runs1(TruckSimulator_n.del method)
        {
            Map.RunMap(method);
        }

        public void MapInsert(TruckSimulator_n.Map NewMap)
        {
            SqlParameter[] sqlParam = new SqlParameter[5];
            sqlParam[0] = new SqlParameter("@MapName", NewMap.MapName);
            sqlParam[1] = new SqlParameter("@NumIterations", NewMap.NumIterations);
            sqlParam[2] = new SqlParameter("@CurIteration", NewMap.CurIteration);
            sqlParam[3] = new SqlParameter("@NumTrucks", NewMap.NumTrucks);
            sqlParam[4] = new SqlParameter("@NumCargoes", NewMap.NumCargoes);
            int idmap = Dal.ExNonQuery("Sp_MapsInsert", CommandType.StoredProcedure, sqlParam);
            
            foreach (dynamic item in NewMap.MapPoint)
            {
                SqlParameter[] sqlParamPoint = new SqlParameter[8];
                sqlParamPoint[0] = new SqlParameter("@IDMap", idmap);
                sqlParamPoint[1] = new SqlParameter("@TypeName", item.GetType().ToString());
                sqlParamPoint[2] = new SqlParameter("@Name", item.Name);
                sqlParamPoint[3] = new SqlParameter("@PositionX", item.Position.X);
                sqlParamPoint[4] = new SqlParameter("@PositionY", item.Position.Y);
                sqlParamPoint[5] = new SqlParameter("@Status", item.Status);
                sqlParamPoint[6] = new SqlParameter("@FuelBalanceTruck", item.Fuelbalance);
                sqlParamPoint[7] = new SqlParameter("@StepRouteTruck", item.StepOfRoute);
                int idpoint = Dal.ExNonQuery("Sp_PointsInsert", CommandType.StoredProcedure, sqlParamPoint);

                if (item.GetType() == typeof(TruckN)|| item.GetType() == typeof(TruckSimulator_n.User))
                {
                    if (item.RouteList!=null)
                    {
                        foreach (TruckSimulator_n.Point routePoint in item.RouteList)
                        {
                            SqlParameter[] sqlParamRoutePoint = new SqlParameter[3];
                            sqlParamRoutePoint[0] = new SqlParameter("@IDITruck", idpoint);
                            sqlParamRoutePoint[1] = new SqlParameter("@PositionX", routePoint.Position.X);
                            sqlParamRoutePoint[2] = new SqlParameter("@PositionY", routePoint.Position.Y);
                            int y = Dal.ExNonQuery("Sp_RoutesInsert", CommandType.StoredProcedure, sqlParamRoutePoint);
                        }
                    }
                }
            }
        }

        public int MapUpdate(TruckSimulator_n.Map NewMap, int IDOldMap)
        {
            NewMap.IdMap = IDOldMap;//Map_id
            SqlParameter[] sqlParam = new SqlParameter[5];
            sqlParam[0] = new SqlParameter("@ID", IDOldMap);
            sqlParam[1] = new SqlParameter("@NumIterations", NewMap.NumIterations);
            sqlParam[2] = new SqlParameter("@CurIteration", NewMap.CurIteration);
            sqlParam[3] = new SqlParameter("@NumTrucks", NewMap.NumTrucks);
            sqlParam[4] = new SqlParameter("@NumCargoes", NewMap.NumCargoes);

            int Result = Dal.ExNonQuery("Sp_MapsUpdate", CommandType.StoredProcedure, sqlParam);
            return Result;
        }

        public int MapDelete(int ID)
        {
            SqlParameter[] sqlParam = new SqlParameter[1];
            sqlParam[0] = new SqlParameter("@ID", ID);
            int Result = Dal.ExNonQuery("Sp_MapsDelete", CommandType.StoredProcedure, sqlParam);
            return Result;
        }

        public DataTable MapReadAll()
        {
            DataTable dt = new DataTable();
            dt = Dal.ExReader("Sp_MapsReadAll", CommandType.StoredProcedure);
            return dt;
        }

        public TruckSimulator_n.Map MapReadByID(int ID)
        {
            SqlParameter[] sqlParam = new SqlParameter[1];
            sqlParam[0] = new SqlParameter("@ID", ID);
            DataTable dt = Dal.ExReader("Sp_MapsReadByID", CommandType.StoredProcedure, sqlParam);

            SqlParameter[] sqlParam1 = new SqlParameter[1];
            sqlParam1[0] = new SqlParameter("@IDMap", ID);
            DataTable dt_points = Dal.ExReader("Sp_PointsReadByIDMap", CommandType.StoredProcedure, sqlParam1);

            //получаем точки на карте
            List<TruckSimulator_n.MapPoint> list = new List<TruckSimulator_n.MapPoint>();
            int i = 0;
            foreach (DataRow row in dt_points.Rows)
            {
                Type type = Type.GetType(dt_points.Rows[i]["TypeName"].ToString()+ ", TruckSimulator", false, true);
                dynamic obj = Activator.CreateInstance(type);
                
                obj.Name = dt_points.Rows[i]["Name"].ToString();
                obj.Position.X = (int)(dt_points.Rows[i]["PositionX"]);
                obj.Position.Y = (int)(dt_points.Rows[i]["PositionY"]);
                if (obj.GetType() == typeof(TruckN) || obj.GetType() == typeof(TruckSimulator_n.User))
                {
                    ((TruckN)obj).Status = (bool)(dt_points.Rows[i]["Status"]);
                    ((TruckN)obj).StepOfRoute = (int)(dt_points.Rows[i]["StepRouteTruck"]);
                    ((TruckN)obj).Fuelbalance = (int)(dt_points.Rows[i]["FuelBalanceTruck"]);

                    //заполняем маршрутный лист авто
                    SqlParameter[] sqlParam2 = new SqlParameter[1];
                    sqlParam2[0] = new SqlParameter("@IDITruck", (int)(dt_points.Rows[i]["ID"]));
                    DataTable dt_routes = Dal.ExReader("Sp_RoutesReadByIDITruck", CommandType.StoredProcedure, sqlParam2);
                    //int j = 0;
                    //((TruckN)obj).Point = new List<Point>();
                    //foreach (DataRow point in dt_routes.Rows)
                    //{
                    //    Coordinate coord = new Coordinate((int)dt_routes.Rows[j]["PositionX"], (int)dt_routes.Rows[j]["PositionY"]);
                    //    ((TruckN)obj).Point.Add(new Point(coord));
                    //    j++;
                    //}
                }
                if (obj.GetType() == typeof(TruckSimulator_n.Cargo))
                {
                    ((TruckSimulator_n.Cargo)obj).StatusCargo = (bool)(dt_points.Rows[i]["Status"]);
                }
                list.Add(obj);
                i++;
            }

            ID = (int)dt.Rows[0]["ID"];
            Map.MapName = dt.Rows[0]["MapName"].ToString();
            Map.NumIterations = (int)dt.Rows[0]["NumIterations"];
            Map.CurIteration = (int)dt.Rows[0]["CurIteration"];
            Map.NumTrucks = (int)dt.Rows[0]["NumTrucks"];
            Map.NumCargoes = (int)dt.Rows[0]["NumCargoes"];
            Map.MapPoint = list;
            return Map;
        }

        private IMap _mapview;
        private TruckSimulator_n.Map _map;
        private DataAccessLayer _dal;
    }
}
