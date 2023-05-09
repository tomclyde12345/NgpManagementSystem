using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.ViewModel
{
    public class SchedVM
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
    }
}