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
    
    public partial class ngp_projects
    {
        public int projectID { get; set; }
        public string site_code { get; set; }
        public Nullable<int> location_municipality { get; set; }
        public Nullable<int> location_barangay { get; set; }
        public string area { get; set; }
        public string year_form { get; set; }
        public string penro { get; set; }
        public string cenro { get; set; }
        public string region { get; set; }
        public Nullable<int> dropdownID { get; set; }
        public Nullable<int> RoleId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    
        public virtual ngp_dropdown ngp_dropdown { get; set; }
        public virtual ngp_projects ngp_projects1 { get; set; }
        public virtual ngp_projects ngp_projects2 { get; set; }
        public virtual NgplocationMunicipality NgplocationMunicipality { get; set; }
        public virtual NgpRole NgpRole { get; set; }
        public virtual NgpUser NgpUser { get; set; }
    }
}
