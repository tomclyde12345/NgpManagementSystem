using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.DTO
{
    public class ProjectDTO
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

    }
}