using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using TruckSimulator_n;

namespace TruckSimulatorPL
{
    public partial class MapListFrm : Form
    {
        public int id;

        public MapListFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = listBox1.SelectedIndex + 1;
            this.Close();
        }
    }
}
