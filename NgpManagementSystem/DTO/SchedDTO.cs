using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.DTO
{
    public class SchedDTO
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
    }
}