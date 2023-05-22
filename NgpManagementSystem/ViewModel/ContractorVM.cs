using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.ViewModel
{
    public class ContractorVM
    {
        public int contractorID { get; set; }
        public string contractor_name { get; set; }
        public string address_municipality { get; set; }
        public string address_barangay { get; set; }
        public string contractor_type { get; set; }

        public string RoleId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }

    }
}