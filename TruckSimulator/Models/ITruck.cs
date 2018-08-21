using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TruckSimulator.Models
{
    interface ITruck
    {
        int Fuelbalance { get; set; }
        int StepOfRoute { get; set; }
        int FuelCharge { get; set; }
        bool Status { get; set; }
        List<Point> RouteList { get; set; }
        void Action(Map pictureBox);
        void Move(Map pictureBox);
        void StopMove();
    }  
}
