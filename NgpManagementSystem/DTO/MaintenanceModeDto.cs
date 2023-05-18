using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.DTO
{
    public class MaintenanceModeDto
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public bool isActive { get; set; }
        public string Message { get; set; }
    }
}