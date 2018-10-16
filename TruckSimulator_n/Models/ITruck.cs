using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TruckSimulator_n
{
    public interface ITruck:IPoint
    {
        int StepOfRoute { get; set; }
        int Fuelbalance { get; set; }
        bool Status { get; set; }
        int FuelCharge { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        ICollection<RoutePoint> RoutePoint { get; set; }

        new void Action(Map pictureBox);
        void Move(Map pictureBox);
        void StopMove();
    }  
}
