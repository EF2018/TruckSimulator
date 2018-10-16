using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace TruckSimulator_n
{
    [Table("PointSet_RoutePoint")]
    public class RoutePoint:Point
    {
        public virtual Vehicle Vehicle { get; set; }
        public int VehicleId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoutePoint()
        {
            this.Position = new Coordinate();
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoutePoint(Coordinate position) :base(position)
        {
            this.Position = position;
        }
    }
}
