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
    
    public partial class ngp_sched
    {
        public int schedID { get; set; }
        public string ors_no { get; set; }
        public string ors_date { get; set; }
        public string dv_no { get; set; }
        public string dv_date { get; set; }
        public string lddap_no { get; set; }
        public string lddap_date { get; set; }
        public string contractor_name { get; set; }
        public Nullable<int> ContractorId { get; set; }
        public Nullable<int> ContractId { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    
        public virtual NgpRole NgpRole { get; set; }
        public virtual NgpUser NgpUser { get; set; }
    }
}
