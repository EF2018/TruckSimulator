using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckSimulator
{
    class DataLayer
    {
        public DataLayer()//string serverName, string databaseName)
        {
            SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();
            bldr.DataSource = @"ADMIN-ПК\SQLEXPRESS1";
            bldr.InitialCatalog = "Simulator_base";
            bldr.IntegratedSecurity = true;
            //bldr.UserID = "net171";
            //bldr.Password = "net171";
            conn = new SqlConnection(bldr.ConnectionString);
        }

        public DataTable GetCombi()
        {
            SqlCommand cmdGetJob = conn.CreateCommand();
            cmdGetJob.CommandText = "GetMinRoute";    // !!! только имя хранимки
            cmdGetJob.CommandType = System.Data.CommandType.StoredProcedure;    // !!! тип запроса - вызов хранимой процедуры

            SqlDataAdapter jobAdapter = new SqlDataAdapter(cmdGetJob);
            DataTable tblJobs = new DataTable("Routes");
            jobAdapter.Fill(tblJobs);    // заполнение таблицы при помощи адаптера
            return tblJobs;
        }

        public void Dispose()
        {
            conn.Close();    // закрытие соединения с БД
            // conn.Dispose();    // или можно так: освобождение ресурсов, связанных с соединением с БД
        }

        public DataTable GetMaps()
        {
            SqlCommand cmdMaps = conn.CreateCommand();
            cmdMaps.CommandText = "SELECT * FROM Games";
            cmdMaps.CommandType = System.Data.CommandType.Text;

            SqlDataAdapter Adapter = new SqlDataAdapter(cmdMaps);
            DataTable tbl = new DataTable("Games");
            Adapter.Fill(tbl);    // заполнение таблицы при помощи адаптера

            return tbl;
        }

        public DataTable GetOrdersInWork()
        {
            SqlCommand cmdGetOrdersInWork = conn.CreateCommand();
            cmdGetOrdersInWork.CommandText = "SELECT * FROM OrdersView WHERE Status = 'в работе'";
            cmdGetOrdersInWork.CommandType = System.Data.CommandType.Text;

            SqlDataAdapter Adapter = new SqlDataAdapter(cmdGetOrdersInWork);
            DataTable tbl = new DataTable("OrdersInWork");
            Adapter.Fill(tbl);    // заполнение таблицы при помощи адаптера

            return tbl;
        }
        SqlConnection conn = null;
    }
}
