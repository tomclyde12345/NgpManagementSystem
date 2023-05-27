using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.DTO
{
    public class LocationBarangayDTO
    {
        public int BarangayId { get; set; }
        public string BarangayName { get; set; }
        public Nullable<int> MunicipalityId { get; set; }
    }
}