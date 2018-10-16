using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using TruckSimulator_n;
using TruckSimulatorDAL_n;

namespace TruckSimulatorPL
{
    public delegate void del(object x, EventArgs y);
    delegate void ArgReturningVoidDelegate();
    delegate void StringArgReturningVoidDelegate(string x);

    public partial class MapFrm : Form, IMap
    {
        private Thread demoThread = null;
        DataPresenter presenter;

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

        string IMap.MapName
        {
            get { return lblMapName.Text; }
            set { lblMapName.Text = value; }
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

        public MapFrm()
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
            presenter = new DataPresenter(this);
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
                    this.dataGridView1[0, i].Value = ((TruckSimulator_n.Vehicle)Arr[i]).Name.ToString();
                    this.dataGridView1[1, i].Value = ((TruckSimulator_n.Vehicle)(Arr[i])).Fuelbalance;
                }
                lblIteration.Text = this.presenter.MapObj.CurIteration.ToString();
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
            btn_Start.Enabled = false;
            btn_Stop.Enabled = true;
            TruckSimulator_n.del del1 = new TruckSimulator_n.del(UpdateFields);
            demoThread = new Thread(new ThreadStart(() => this.presenter.Runs1(del1)));
            demoThread.Start();
        }

        /// <summary>
        /// Сохранение карты с координами всех точек и расчитанных маршрутов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (demoThread != null)
            {
                demoThread.Suspend();
            }
            MapSaveFrm form = new MapSaveFrm();
            foreach (var row in presenter.GetNamesAllMaps())
            {
                form.ListBox1.Items.Add(row.MapName);
            }
            form.ShowDialog();
            presenter.MapObj.MapName = form.nameMap;

            if (form.update)
            {
                presenter.UpdateMap(presenter.MapObj.MapName);
            }

            if (form.save)
            {
                presenter.SaveMap();
            }
            UpdateFields(this, new EventArgs());
        }


        /// <summary>
        /// Загрузка карт
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadMapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (demoThread!=null)
            {
                demoThread.Suspend();
            }
            presenter = new DataPresenter(this);
            MapListFrm form = new MapListFrm();

            foreach (var row in presenter.GetNamesAllMaps())
            {
                form.ListBox1.Items.Add(row.MapName);
            }
            form.ShowDialog();

            string name = form.ListBox1.SelectedItem.ToString();
            presenter.MapObj = presenter.LoadMapByName(name);
            presenter.ShowMap();
            UpdateStat();
            btn_Start.Enabled = true;
            btn_Stop.Enabled = false;
        }

        /// <summary>
        /// Остановка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            demoThread.Suspend();
            btn_Stop.Enabled = false;
            btn_Start.Enabled = true;
        }
    }
}
