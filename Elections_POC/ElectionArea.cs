//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Elections_POC
{
    using System;
    using System.Collections.Generic;
    
    public partial class ElectionArea
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ElectionArea()
        {
            this.PollingStations = new HashSet<PollingStation>();
        }
    
        public int ElectionAreaId { get; set; }
        public string ElectionAreaNameEn { get; set; }
        public string ElectionAreaAr { get; set; }
        public Nullable<int> GovernorateId { get; set; }
    
        public virtual Governorate Governorate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PollingStation> PollingStations { get; set; }
    }
}