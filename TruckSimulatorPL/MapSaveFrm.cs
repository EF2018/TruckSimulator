using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TruckSimulatorDAL_n;

namespace TruckSimulatorPL
{
    public partial class MapSaveFrm : Form
    {
        public int? id;
        public string nameMap;
        public bool save = true;
        public bool update = false;

        public MapSaveFrm()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            txtBoxNameMap.Text = listBox1.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var item in listBox1.Items)
            {
                if (item.ToString() == txtBoxNameMap.Text) 
                {
                    DialogResult result = MessageBox.Show(
                           "Сохранить вместо существующей карты",
                           "Сообщение",
                           MessageBoxButtons.YesNo,
                           MessageBoxIcon.Information,
                           MessageBoxDefaultButton.Button1,
                           MessageBoxOptions.DefaultDesktopOnly);
                    if (result == DialogResult.No)
                    {
                        update = false;
                        save = false;
                        break;
                    }
                    nameMap = txtBoxNameMap.Text;
                    update = true;
                    save = false;
                    break;
                }
            }
            if (save)
            {
                nameMap = txtBoxNameMap.Text;
            }
            Close();
        }
    }
}
