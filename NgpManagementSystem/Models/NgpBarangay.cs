//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NgpManagementSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class NgpBarangay
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NgpBarangay()
        {
            this.ngp_contract = new HashSet<ngp_contract>();
            this.ngp_contractor = new HashSet<ngp_contractor>();
        }
    
        public int BarangayId { get; set; }
        public string BarangayName { get; set; }
        public Nullable<int> MunicipalityId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ngp_contract> ngp_contract { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ngp_contractor> ngp_contractor { get; set; }
        public virtual NgpMunicipality NgpMunicipality { get; set; }
    }
}
