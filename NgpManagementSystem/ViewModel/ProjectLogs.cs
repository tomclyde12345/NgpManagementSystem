using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.ViewModel
{
    public class ProjectLogs
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LogMessage { get; set; }
        public string UserId { get; set; }
        public string RoleId { get; set; }
    }
}