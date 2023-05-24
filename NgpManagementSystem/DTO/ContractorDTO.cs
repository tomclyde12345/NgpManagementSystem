using System;
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
        public Nullable<int> UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public Nullable<int> location_municipality { get; set; }
        public Nullable<int> location_barangay { get; set; }
        public string area { get; set; }
        public string year_form { get; set; }
        public string penro { get; set; }
        public string cenro { get; set; }
        public string region { get; set; }
        public string moanumber_year1 { get; set; }
        public string datemoasigned_year1 { get; set; }
        public string contractcost_year1 { get; set; }
        public string dateobligated_year1 { get; set; }
        public string orsno_year1 { get; set; }
        public string num_seedlings_produced_year1 { get; set; }
        public string commodity_year1 { get; set; }
        public string num_seedlings_planted_year1 { get; set; }
        public string num_seedlings_survive_year1 { get; set; }
        public string survivalrate_year1 { get; set; }
        public string moanumber_year2 { get; set; }
        public string datemoasigned_year2 { get; set; }
        public string unitcost_year2 { get; set; }
        public string contractcost_year2 { get; set; }
        public string dateobligated_year2 { get; set; }
        public string orsno_year2 { get; set; }
        public string num_seedlings_planted_year2 { get; set; }
        public string num_seedlings_survive_endofyear_1_year2 { get; set; }
        public string survivalrate_year2 { get; set; }
        public string num_seedlings_replanted_year2 { get; set; }
        public string moanumber_year3 { get; set; }
        public string datemoasigned_year3 { get; set; }
        public string unitcost_year3 { get; set; }
        public string contractcost_year3 { get; set; }
        public string dateobligated_year3 { get; set; }
        public string orsno_year3 { get; set; }
        public string num_seedlings_planted_year3 { get; set; }
        public string num_seedlings_survive_endofyear_1_year3 { get; set; }
        public string survivalrate_year3 { get; set; }
        public string num_seedlings_replanted_year3 { get; set; }


    }
}