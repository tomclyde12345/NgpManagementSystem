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
    
    public partial class NgplocationBarangay
    {
        public int BarangayId { get; set; }
        public string BarangayName { get; set; }
        public Nullable<int> MunicipalityId { get; set; }
    
        public virtual NgplocationMunicipality NgplocationMunicipality { get; set; }
    }
}
