﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Threading;
using System.Data.SqlClient;
using System.Data.Common;

namespace TruckSimulator
{
    delegate void ArgReturningVoidDelegate();
    delegate void StringArgReturningVoidDelegate(string x);

    partial class Form1 : Form, IMap
    {
        private Thread demoThread = null;
        MapPresenter presenter;

        string IMap.MapName
        {
            get { return lblMapName.Text; }
            set { lblMapName.Text = value; }
        }

        string IMap.Qiterations
        {
            get { return txtIterations.Text; }
            set { txtIterations.Text = value; }
        }

        string IMap.QCargo
        {
            get { return txtQCargo.Text; }
            set { txtQCargo.Text = value; }
        }

        string IMap.QTruck
        {
            get { return txtQTruck.Text; }
            set { txtQTruck.Text = value; }
        }

        Bitmap IMap.Field
        {
            set { pictureBox1.BackgroundImage = value; }
        }

        int IMap.width
        {
            get { return pictureBox1.Width; }
            set { pictureBox1.Width = value; }
        }

        int IMap.height
        {
            get { return pictureBox1.Height; }
            set { pictureBox1.Height = value; }
        }

        ArrayList IMap.ArrPoints
        {
            set { ArrayList listITruck = value; }
        }

        string IMap.curIteration
        {
            get { return lblIteration.Text; }
            set
            {
                if (this.lblIteration.InvokeRequired)
                {
                    this.Invoke(new Action(() => { this.Controls.Add(lblIteration); }));
                }
                else
                {
                    lblIteration.Text = value;
                }
            }
        }

        void SetlblCurIteration()
        {
            if (this.lblIteration.InvokeRequired)
            {
                ArgReturningVoidDelegate d = new ArgReturningVoidDelegate(SetlblCurIteration);
                this.Invoke(d);
            }
            else
            {
                this.lblIteration.Refresh();
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Получение точек
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void btn_GetNewPoints_Click(object sender, EventArgs e)
        {
            presenter = new MapPresenter(this);
            presenter.GetDataFromForm();
            presenter.ShowMap();
            UpdateStat();
        }

        /// <summary>
        /// Обновление поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UpdateFields(object sender, EventArgs e)
        {
            presenter.ShowMap();
            UpdateStat();
        }

        /// <summary>
        /// Обновление статистики
        /// </summary>
        public void UpdateStat()
        {
            if (this.dataGridView1.InvokeRequired)
            {
                ArgReturningVoidDelegate d = new ArgReturningVoidDelegate(UpdateStat);
                this.Invoke(d);
            }
            else
            {
                this.dataGridView1.Rows.Clear();
                ArrayList Arr = presenter.GetArrayList();
                for (int i = 0; i < Arr.Count; i++)
                {
                    this.dataGridView1.Rows.Add();
                    this.dataGridView1[0, i].Value = ((TruckSimulator.Point)(Arr[i])).GetType().Name + ((TruckSimulator.Point)(Arr[i])).Name.ToString();
                    this.dataGridView1[1, i].Value = ((TruckSimulator.ITruck)(Arr[i])).Fuelbalance;
                }
                lblIteration.Text = this.presenter.Map.CurIteration.ToString();
                this.Invalidate();
            }
        }


        /// <summary>
        /// Старт программы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Start_Click(object sender, EventArgs e)
        {
            del del1 = new del(UpdateFields);
            this.demoThread = new Thread(new ThreadStart(() => this.presenter.Runs1(del1)));
            this.demoThread.Start();
            //presenter.Runs1(del1);
        }

        //public void ClickMouseProcess(int x, int y)
        //{
        //Map myMap = new Map(textBoxQTruck, textBoxQCargo, pictureBox1);
        //    List<Cargo> myCargoes = Map.GetCargoList();

        //    foreach (var item in myCargoes)
        //    {
        //        if (x < item.Position.X + 10 & x > item.Position.X - 10)
        //        {
        //            if (y < item.Position.Y + 10 & y > item.Position.Y - 10)
        //            {
        //                HighlightCargo(item);
        //            }
        //        }
        //    }
        //}

        public void PictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (sender != null)
            {
                int x = e.X; int y = e.Y;
                //ClickMouseProcess(x, y);
            }
        }

        //public void HighlightCargo(Cargo cargo)
        //{
        //    Pen pen = new Pen(Color.Red, 3);
        //    Graphics graph = Graphics.FromImage(bmpmain);

        //    graph.DrawRectangle(pen, cargo.Position.X, cargo.Position.Y, 5, 5);
        //    pictureBox1.Refresh();

        //Map myMap = new Map(textBoxQTruck, textBoxQCargo, pictureBox1);
        //    User me = Map.GetUser();
        //    me.ChoosePoint(cargo, bmpmain);

        //    UpdateGameField();
        //}

        //private void UpdateGameField()
        //{
        //    pictureBox1.Image = bmpmain;
        //    pictureBox1.Refresh();
        //}

        //public void UpdateChart(Truck truck)
        //{
        //    myChartTimePermutation.Series[truck.Name].Points.AddY(truck.CurfindingTime);
        //    myChartTimePermutation.Invalidate();
        //}

        /// <summary>
        /// Инициализация графика
        /// </summary>
        //public void SetGraphics()
        //{
        //    for (int i = 0; i < Convert.ToInt32(Map.NumTrucks); i++)
        //    {
        //        Series mySeriesOfPoint = new Series();
        //        mySeriesOfPoint.Name = i.ToString();
        //        mySeriesOfPoint.ChartType = SeriesChartType.Line;
        //        mySeriesOfPoint.ChartArea = "Math functions";
        //        myChartTimePermutation.Series.Add(mySeriesOfPoint);
        //    }
        //}


        private SqlConnectionStringBuilder CreateConnection()
        {
            SqlConnectionStringBuilder bldr = new SqlConnectionStringBuilder();
            bldr.DataSource = "ADMIN-ПК/SQLEXPRESS1";
            bldr.InitialCatalog = "Simulator_base";
            bldr.IntegratedSecurity = true;
            return bldr;
        }

        /// <summary>
        /// Сохранить сценарий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SqlConnectionStringBuilder bldr = CreateConnection();
            using (SqlConnection conn = new SqlConnection(bldr.ConnectionString))
            {
                conn.Open();
                try
                {
                    SqlCommand commInsert = new SqlCommand("DELETE Games; Delete Trucks; Delete Cargoes; INSERT INTO Games (SaveName, Iterations, CurIteration, QCargo, QTruck) values(@SaveName, @Iterations, @CurIteration, @QCargo, @QTruck)", conn);

                    commInsert.Parameters.Add("@SaveName", SqlDbType.NChar, 50);
                    commInsert.Parameters["@SaveName"].Value = DateTime.Now.ToString();

                    commInsert.Parameters.Add("@Iterations", SqlDbType.Int);
                    commInsert.Parameters["@Iterations"].Value =presenter.Map.NumIterations;

                    commInsert.Parameters.Add("@CurIteration", SqlDbType.Int);
                    commInsert.Parameters["@CurIteration"].Value = presenter.Map.CurIteration;

                    commInsert.Parameters.Add("@QTruck", SqlDbType.Int);
                    commInsert.Parameters["@QTruck"].Value = presenter.Map.NumTrucks;

                    commInsert.Parameters.Add("@QCargo", SqlDbType.Int);
                    commInsert.Parameters["@QCargo"].Value = presenter.Map.NumCargoes;

                    commInsert.ExecuteNonQuery();

                    for (int i = 0; i < presenter.Map.Points.Count; i++)
                    {
                        if (presenter.Map.Points[i] is Truck)
                        {
                            try
                            {
                                SqlCommand commInsertTrucks = new SqlCommand("INSERT INTO Trucks (IdGame, TypeName, NameTruck, PositionX, PositionY, Status, FuelBalance, StepOfRoute) values(@IdGame, @TypeName, @NameTruck, @PositionX, @PositionY, @Status, @FuelBalance, @StepOfRoute)", conn);

                                commInsertTrucks.Parameters.Add("@IdGame", SqlDbType.Int);
                                commInsertTrucks.Parameters["@IdGame"].Value = 1;

                                commInsertTrucks.Parameters.Add("@TypeName", SqlDbType.NChar, 50);
                                commInsertTrucks.Parameters["@TypeName"].Value = ((Truck)presenter.Map.Points[i]).GetType().Name;

                                commInsertTrucks.Parameters.Add("@NameTruck", SqlDbType.NChar, 10);
                                commInsertTrucks.Parameters["@NameTruck"].Value = ((Truck)presenter.Map.Points[i]).Name;

                                commInsertTrucks.Parameters.Add("@PositionX", SqlDbType.Int);
                                commInsertTrucks.Parameters["@PositionX"].Value = ((Truck)presenter.Map.Points[i]).Position.X;

                                commInsertTrucks.Parameters.Add("@PositionY", SqlDbType.Int);
                                commInsertTrucks.Parameters["@PositionY"].Value = ((Truck)presenter.Map.Points[i]).Position.Y;

                                commInsertTrucks.Parameters.Add("@Status", SqlDbType.Bit);
                                commInsertTrucks.Parameters["@Status"].Value = ((Truck)presenter.Map.Points[i]).Status;

                                commInsertTrucks.Parameters.Add("@FuelBalance", SqlDbType.Int);
                                commInsertTrucks.Parameters["@FuelBalance"].Value = ((Truck)presenter.Map.Points[i]).Fuelbalance;

                                commInsertTrucks.Parameters.Add("@StepOfRoute", SqlDbType.Int);
                                commInsertTrucks.Parameters["@StepOfRoute"].Value = ((Truck)presenter.Map.Points[i]).StepOfRoute;

                                commInsertTrucks.ExecuteNonQuery();
                            }
                            catch (Exception exTruck)
                            {
                                MessageBox.Show(exTruck.ToString());
                            }

                        }
                        if (presenter.Map.Points[i] is Cargo)
                        {
                            try
                            {
                                SqlCommand commInsertCargoes = new SqlCommand("INSERT INTO Cargoes (IdGame, TypeName, NameCargo, PositionX, PositionY, Status) values(@IdGame, @TypeName, @NameCargo, @PositionX, @PositionY, @Status)", conn);

                                commInsertCargoes.Parameters.Add("@IdGame", SqlDbType.Int);
                                commInsertCargoes.Parameters["@IdGame"].Value = 1;

                                commInsertCargoes.Parameters.Add("@TypeName", SqlDbType.NChar, 50);
                                commInsertCargoes.Parameters["@TypeName"].Value = ((Cargo)presenter.Map.Points[i]).GetType().Name;

                                commInsertCargoes.Parameters.Add("@NameCargo", SqlDbType.NChar, 10);
                                commInsertCargoes.Parameters["@NameCargo"].Value = ((Cargo)presenter.Map.Points[i]).Name;

                                commInsertCargoes.Parameters.Add("@PositionX", SqlDbType.Int);
                                commInsertCargoes.Parameters["@PositionX"].Value = ((Cargo)presenter.Map.Points[i]).Position.X;

                                commInsertCargoes.Parameters.Add("@PositionY", SqlDbType.Int);
                                commInsertCargoes.Parameters["@PositionY"].Value = ((Cargo)presenter.Map.Points[i]).Position.Y;

                                commInsertCargoes.Parameters.Add("@Status", SqlDbType.Bit);
                                commInsertCargoes.Parameters["@Status"].Value = ((Cargo)presenter.Map.Points[i]).StatusCargo;

                                commInsertCargoes.ExecuteNonQuery();
                            }
                            catch (Exception exCargo)
                            {
                                MessageBox.Show(exCargo.ToString());
                            }

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                    MessageBox.Show("Сценарий сохранен");
                }
            }
        }

        /// <summary>
        /// Загрузить последний сценарий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void загрузитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            presenter = new MapPresenter(this);
            SqlConnectionStringBuilder bldr = CreateConnection();
            using (SqlConnection conn = new SqlConnection(bldr.ConnectionString))
            {
                conn.Open();

                SqlCommand cmdGames = new SqlCommand();
                cmdGames.Connection = conn;
                cmdGames.CommandText = "Select Iterations, CurIteration, QCargo, QTruck FROM Games";

                using (DbDataReader reader = cmdGames.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            presenter.Map.NumIterations = Convert.ToInt32(reader.GetValue(0));
                            presenter.Map.NumCargoes = Convert.ToInt32(reader.GetValue(2));
                            presenter.Map.NumTrucks = Convert.ToInt32(reader.GetValue(3));
                            presenter.Map.CurIteration = Convert.ToInt32(reader.GetValue(1));
                        }
                    }
                }

                SqlCommand cmdTrucks = new SqlCommand();
                cmdTrucks.Connection = conn;
                cmdTrucks.CommandText = "Select TypeName, Nametruck, PositionX, PositionY, Status, FuelBalance, StepOfRoute FROM Trucks";

                using (DbDataReader reader = cmdTrucks.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Coordinate coord = new Coordinate();
                            coord.X = Convert.ToInt32(reader.GetValue(2));
                            coord.Y = Convert.ToInt32(reader.GetValue(3));

                            ITruck truck;

                            if ((Convert.ToString(reader.GetValue(0))) == "Truck     ")
                            {
                                truck = new Truck(coord);
                            }
                            else
                            {
                                truck = new User(coord);
                            }

                            ((Point)truck).Name = Convert.ToString(reader.GetValue(1));
                            truck.Status = Convert.ToBoolean(reader.GetValue(4));
                            truck.Fuelbalance = Convert.ToInt32(reader.GetValue(5));
                            truck.StepOfRoute = Convert.ToInt32(reader.GetValue(6));
                            presenter.Map.Points.Add(truck);
                        }
                    }
                }

                SqlCommand cmdCargoes = new SqlCommand();
                cmdCargoes.Connection = conn;
                cmdCargoes.CommandText = "Select NameCargo, PositionX, PositionY, Status FROM Cargoes";

                using (DbDataReader reader = cmdCargoes.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Coordinate coord = new Coordinate();
                            coord.X = Convert.ToInt32(reader.GetValue(1));
                            coord.Y = Convert.ToInt32(reader.GetValue(2));

                            Cargo cargo = new Cargo(coord);

                            ((Point)cargo).Name = Convert.ToString(reader.GetValue(0));
                            cargo.StatusCargo = Convert.ToBoolean(reader.GetValue(3));

                            if (cargo.StatusCargo == false) 
                            {
                                cargo.Pen = new Pen(Color.RosyBrown);
                                cargo.TextColor = Brushes.RosyBrown;
                            }
                            presenter.Map.Points.Add(cargo);
                        }
                    }
                }
            }
            presenter.ShowMap();
        }

    }
}


        