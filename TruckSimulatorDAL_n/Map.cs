//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TruckSimulatorDAL_n
{
    using System;
    using System.Collections.Generic;
    
    public partial class Map
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Map()
        {
            this.MapPoint = new HashSet<MapPoint>();
        }
    
        public int IdMap { get; set; }
        public string MapName { get; set; }
        public int NumCargoes { get; set; }
        public int NumTrucks { get; set; }
        public int NumIterations { get; set; }
        public int CurIteration { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MapPoint> MapPoint { get; set; }
    }
}
