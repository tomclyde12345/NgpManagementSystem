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
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string location_municipality { get; set; }
        public string location_barangay { get; set; }
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
        public string grossammount_year1_1st { get; set; }
        public string lddap_no_year1_1st { get; set; }
        public string date_lddap_year1_1st { get; set; }
        public string grossammount_year1_2nd { get; set; }
        public string retention_fee_year1_2nd { get; set; }
        public string mobilization_fund_year1_2nd { get; set; }
        public string amountless_rf_mf_year1_2nd { get; set; }
        public string bir_year1_2nd { get; set; }
        public string netammountpaid_year1_2nd { get; set; }
        public string lddapno_year1_2nd { get; set; }
        public string date_lddap_year1_2nd { get; set; }
        public string grossammount_year1_3rd { get; set; }
        public string retention_fee_year1_3rd { get; set; }
        public string mobilization_fund_year1_3rd { get; set; }
        public string amountless_rf_mf_year1_3rd { get; set; }
        public string bir_year1_3rd { get; set; }
        public string netammountpaid_year1_3rd { get; set; }
        public string lddapno_year1_3rd { get; set; }
        public string date_lddap_year1_3rd { get; set; }
        public string grossammount_year1_4th { get; set; }
        public string retention_fee_year1_4th { get; set; }
        public string mobilization_fund_year1_4th { get; set; }
        public string amountless_rf_mf_year1_4th { get; set; }
        public string bir_year1_4th { get; set; }
        public string netammountpaid_year1_4th { get; set; }
        public string lddapno_year1_4th { get; set; }
        public string date_lddap_year1_4th { get; set; }
        public string grossammount_year1_5th { get; set; }
        public string retention_fee_year1_5th { get; set; }
        public string mobilization_fund_year1_5th { get; set; }
        public string amountless_rf_mf_year1_5th { get; set; }
        public string bir_year1_5th { get; set; }
        public string netammountpaid_year1_5th { get; set; }
        public string lddapno_year1_5th { get; set; }
        public string date_lddap_year1_5th { get; set; }
        public string grossammount_year1_6th { get; set; }
        public string retention_fee_year1_6th { get; set; }
        public string mobilization_fund_year1_6th { get; set; }
        public string amountless_rf_mf_year1_6th { get; set; }
        public string bir_year1_6th { get; set; }
        public string survivalrate_year2_1st { get; set; }
        public string grossammount_year2_1st { get; set; }
        public string redentionfee_fee_year2_1st { get; set; }
        public string amountless_rf_year2_1st { get; set; }
        public string bir_year2_1st { get; set; }
        public string netamount_paid_year2_1st { get; set; }
        public string lddapno_year2_1st { get; set; }
        public string date_lddap_year2_1st { get; set; }
        public string survivalrate_year2_2nd { get; set; }
        public string grossammount_year2_2nd { get; set; }
        public string redentionfee_fee_year2_2nd { get; set; }
        public string amountless_rf_year2_2nd { get; set; }
        public string bir_year2_2nd { get; set; }
        public string netamount_paid_year2_2nd { get; set; }
        public string lddapno_year2_2nd { get; set; }
        public string date_lddap_year2_2nd { get; set; }
        public string survivalrate_year2_3rd { get; set; }
        public string grossammount_year2_3rd { get; set; }
        public string redentionfee_fee_year2_3rd { get; set; }
        public string amountless_rf_year2_3rd { get; set; }
        public string bir_year2_3rd { get; set; }
        public string netamount_paid_year2_3rd { get; set; }
        public string lddapno_year2_3rd { get; set; }
        public string date_lddap_year2_3rd { get; set; }
        public string survivalrate_year2_4th { get; set; }
        public string grossammount_year2_4th { get; set; }
        public string redentionfee_fee_year2_4th { get; set; }
        public string amountless_rf_year2_4th { get; set; }
        public string bir_year2_1st3 { get; set; }
        public string netamount_paid_year2_4th { get; set; }
        public string lddapno_year2_4th { get; set; }
        public string date_lddap_year2_4th { get; set; }




    }
}