﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.DTO
{
    public class ContractorDTO
    {
        public int contractorID { get; set; }
        public string contractor_name { get; set; }
        public Nullable<int> address_municipality { get; set; }
        public Nullable<int> address_barangay { get; set; }
        public string contractor_type { get; set; }
        public Nullable<int> RoleId { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }
}