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
    
    public partial class ngp_history
    {
        public int historyID { get; set; }
        public Nullable<int> user_no { get; set; }
        public Nullable<int> contractor_no { get; set; }
    
        public virtual ngp_contractor ngp_contractor { get; set; }
    }
}
