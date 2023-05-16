using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NgpManagementSystem.DTO
{
    public class LogsProjectDTO
    {
        public int Id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LogMessage { get; set; }
        public Nullable<int> UserId { get; set; }
        public string RoleId { get; set; }
    }
}