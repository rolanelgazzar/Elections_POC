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
    
    public partial class PollingStation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PollingStation()
        {
            this.Users = new HashSet<User>();
        }
    
        public int PollingStationsId { get; set; }
        public string PollingStationsNameEn { get; set; }
        public string PollingStationsAr { get; set; }
        public Nullable<System.DateTime> VotingDate { get; set; }
        public Nullable<int> ListNumberInRegister { get; set; }
        public string ElectorIdentificationNumber { get; set; }
        public string ElectorName { get; set; }
        public Nullable<int> ElectorTypeId { get; set; }
        public Nullable<int> IdentificationType { get; set; }
        public Nullable<int> ElectionAreaId { get; set; }
        public string Decrypt_ElectorName { get; set; }
        public string Decrypt_ElectorIdentificationNumber { get; set; }
    
        public virtual ElectionArea ElectionArea { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
