using AutoMapper;
using NgpManagementSystem.DTO;
using NgpManagementSystem.Models;
using NgpManagementSystem.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace NgpManagementSystem.Controllers.API
{
    public class ContractorAPIController : ApiController
    {
        public NgpdbmsEntities Db = new NgpdbmsEntities();

        protected override void Dispose(bool disposing)
        {

            Db.Dispose();
        }
        //CREATE/SAVING METHODS contractor
        [HttpPost
        ]
        [Route("api/contractor/post")
        ]
        public IHttpActionResult SaveContractor(ContractorDTO contractorDTO)
        {
            var contractor = Mapper.Map<ContractorDTO, ngp_contractor>(contractorDTO);

            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            if (contractorDTO.contractorID == 0)
            {

                contractor.contractor_name = contractorDTO.contractor_name;
                contractor.address_municipality = contractorDTO.address_municipality;
                contractor.address_barangay = contractorDTO.address_barangay;
                contractor.contractor_type = contractorDTO.contractor_type;
                //for Project
                contractor.location_municipality = contractorDTO.location_municipality;
                contractor.location_barangay = contractorDTO.location_barangay;
                contractor.area = contractorDTO.area;
                contractor.year_form = contractorDTO.year_form;
                contractor.penro = contractorDTO.penro;
                contractor.cenro = contractorDTO.cenro;
                contractor.region = contractorDTO.region;
                //for contract year 1
                contractor.moanumber_year1 = contractorDTO.moanumber_year1;
                contractor.datemoasigned_year1 = contractorDTO.datemoasigned_year1;
                contractor.contractcost_year1 = contractorDTO.contractcost_year1;
                contractor.dateobligated_year1 = contractorDTO.dateobligated_year1;
                contractor.orsno_year1 = contractorDTO.orsno_year1;
                contractor.num_seedlings_produced_year1 = contractorDTO.num_seedlings_produced_year1;
                contractor.commodity_year1 = contractorDTO.commodity_year1;
                contractor.num_seedlings_planted_year1 = contractorDTO.num_seedlings_planted_year1;
                contractor.survivalrate_year1 = contractorDTO.survivalrate_year1;
                //for contract year 2
                contractor.moanumber_year2 = contractorDTO.moanumber_year2;
                contractor.datemoasigned_year2 = contractorDTO.datemoasigned_year2;
                contractor.unitcost_year2 = contractorDTO.unitcost_year2;
                contractor.contractcost_year2 = contractorDTO.contractcost_year2;
                contractor.dateobligated_year2 = contractorDTO.dateobligated_year2;
                contractor.orsno_year2 = contractorDTO.orsno_year2;
                contractor.num_seedlings_planted_year2 = contractorDTO.num_seedlings_planted_year2;
                contractor.num_seedlings_survive_endofyear_1_year2 = contractorDTO.num_seedlings_survive_endofyear_1_year2;
                contractor.survivalrate_year2 = contractorDTO.survivalrate_year2;
                contractor.num_seedlings_replanted_year2 = contractorDTO.num_seedlings_replanted_year2;

                //for contract year 3
                contractor.moanumber_year3 = contractorDTO.moanumber_year3;
                contractor.datemoasigned_year3 = contractorDTO.datemoasigned_year3;
                contractor.unitcost_year3 = contractorDTO.unitcost_year3;
                contractor.contractcost_year3 = contractorDTO.contractcost_year3;
                contractor.dateobligated_year3 = contractorDTO.dateobligated_year3;
                contractor.orsno_year2 = contractorDTO.orsno_year2;
                contractor.num_seedlings_planted_year3 = contractorDTO.num_seedlings_planted_year3;
                contractor.num_seedlings_survive_endofyear_1_year3 = contractorDTO.num_seedlings_survive_endofyear_1_year3;
                contractor.survivalrate_year3 = contractorDTO.survivalrate_year3;
                contractor.num_seedlings_replanted_year3 = contractorDTO.num_seedlings_replanted_year3;

                //for payments 


                //year1 1st release
                contractor.grossammount_year1_1st = contractorDTO.grossammount_year1_1st;
                contractor.lddap_no_year1_1st = contractorDTO.lddap_no_year1_1st;
                contractor.date_lddap_year1_1st = contractorDTO.date_lddap_year1_1st;

                //year1 2nd release
                contractor.grossammount_year1_2nd = contractorDTO.grossammount_year1_2nd;
                contractor.retention_fee_year1_2nd = contractorDTO.retention_fee_year1_2nd;
                contractor.mobilization_fund_year1_2nd = contractorDTO.mobilization_fund_year1_2nd;
                contractor.amountless_rf_mf_year1_2nd = contractorDTO.amountless_rf_mf_year1_2nd;
                contractor.bir_year1_2nd = contractorDTO.bir_year1_2nd;
                contractor.netammountpaid_year1_2nd = contractorDTO.netammountpaid_year1_2nd;
                contractor.lddapno_year1_2nd = contractorDTO.lddapno_year1_2nd;
                contractor.date_lddap_year1_2nd = contractorDTO.date_lddap_year1_2nd;


                //year1 3rd release
                contractor.grossammount_year1_3rd = contractorDTO.grossammount_year1_3rd;
                contractor.retention_fee_year1_3rd = contractorDTO.retention_fee_year1_3rd;
                contractor.mobilization_fund_year1_3rd = contractorDTO.mobilization_fund_year1_3rd;
                contractor.amountless_rf_mf_year1_3rd = contractorDTO.amountless_rf_mf_year1_3rd;
                contractor.bir_year1_3rd = contractorDTO.bir_year1_2nd;
                contractor.netammountpaid_year1_3rd = contractorDTO.netammountpaid_year1_3rd;
                contractor.lddapno_year1_3rd = contractorDTO.lddapno_year1_3rd;
                contractor.date_lddap_year1_3rd = contractorDTO.date_lddap_year1_3rd;


                //year1 4rd release
                contractor.grossammount_year1_4th = contractorDTO.grossammount_year1_4th;
                contractor.retention_fee_year1_4th = contractorDTO.retention_fee_year1_4th;
                contractor.mobilization_fund_year1_4th = contractorDTO.mobilization_fund_year1_4th;
                contractor.amountless_rf_mf_year1_4th = contractorDTO.amountless_rf_mf_year1_4th;
                contractor.bir_year1_4th = contractorDTO.bir_year1_2nd;
                contractor.netammountpaid_year1_4th = contractorDTO.netammountpaid_year1_4th;
                contractor.lddapno_year1_4th = contractorDTO.lddapno_year1_4th;
                contractor.date_lddap_year1_4th = contractorDTO.date_lddap_year1_4th;

                //year1 5th release
                contractor.grossammount_year1_5th = contractorDTO.grossammount_year1_5th;
                contractor.retention_fee_year1_5th = contractorDTO.retention_fee_year1_5th;
                contractor.mobilization_fund_year1_5th = contractorDTO.mobilization_fund_year1_5th;
                contractor.amountless_rf_mf_year1_5th = contractorDTO.amountless_rf_mf_year1_5th;
                contractor.bir_year1_5th = contractorDTO.bir_year1_2nd;
                contractor.netammountpaid_year1_5th = contractorDTO.netammountpaid_year1_5th;
                contractor.lddapno_year1_5th = contractorDTO.lddapno_year1_5th;
                contractor.date_lddap_year1_5th = contractorDTO.date_lddap_year1_5th;

                //year1 6th release
                contractor.grossammount_year1_6th = contractorDTO.grossammount_year1_6th;
                contractor.retention_fee_year1_6th = contractorDTO.retention_fee_year1_6th;
                contractor.mobilization_fund_year1_6th = contractorDTO.mobilization_fund_year1_6th;
                contractor.amountless_rf_mf_year1_6th = contractorDTO.amountless_rf_mf_year1_6th;
                contractor.bir_year1_6th = contractorDTO.bir_year1_6th;

                //year2 1st release
                contractor.survivalrate_year2_1st = contractorDTO.survivalrate_year2_1st;
                contractor.grossammount_year2_1st = contractorDTO.grossammount_year2_1st;
                contractor.redentionfee_fee_year2_1st = contractorDTO.redentionfee_fee_year2_1st;
                contractor.amountless_rf_year2_1st = contractorDTO.amountless_rf_year2_1st;
                contractor.bir_year2_1st = contractorDTO.bir_year2_1st;
                contractor.netamount_paid_year2_1st = contractorDTO.netamount_paid_year2_1st;
                contractor.lddapno_year2_1st = contractorDTO.lddapno_year2_1st;
                contractor.date_lddap_year2_1st = contractorDTO.date_lddap_year2_1st;



                //year2 2nd release
                contractor.survivalrate_year2_2nd = contractorDTO.survivalrate_year2_2nd;
                contractor.grossammount_year2_2nd = contractorDTO.grossammount_year2_2nd;
                contractor.redentionfee_fee_year2_2nd = contractorDTO.redentionfee_fee_year2_2nd;
                contractor.amountless_rf_year2_2nd = contractorDTO.amountless_rf_year2_2nd;
                contractor.bir_year2_2nd = contractorDTO.bir_year2_2nd;
                contractor.netamount_paid_year2_2nd = contractorDTO.netamount_paid_year2_2nd;
                contractor.lddapno_year2_2nd = contractorDTO.lddapno_year2_2nd;
                contractor.date_lddap_year2_2nd = contractorDTO.date_lddap_year2_2nd;



                //year2 3rd release
                contractor.survivalrate_year2_3rd = contractorDTO.survivalrate_year2_3rd;
                contractor.grossammount_year2_3rd = contractorDTO.grossammount_year2_3rd;
                contractor.redentionfee_fee_year2_3rd = contractorDTO.redentionfee_fee_year2_3rd;
                contractor.amountless_rf_year2_3rd = contractorDTO.amountless_rf_year2_3rd;
                contractor.bir_year2_3rd = contractorDTO.bir_year2_3rd;
                contractor.netamount_paid_year2_3rd = contractorDTO.netamount_paid_year2_3rd;
                contractor.lddapno_year2_3rd = contractorDTO.lddapno_year2_3rd;
                contractor.date_lddap_year2_3rd = contractorDTO.date_lddap_year2_3rd;

                //year2 4th release
                contractor.survivalrate_year2_4th = contractorDTO.survivalrate_year2_4th;
                contractor.grossammount_year2_4th = contractorDTO.grossammount_year2_4th;
                contractor.redentionfee_fee_year2_4th = contractorDTO.redentionfee_fee_year2_4th;
                contractor.amountless_rf_year2_4th = contractorDTO.amountless_rf_year2_4th;
                contractor.bir_year2_1st3 = contractorDTO.bir_year2_1st3;
                contractor.netamount_paid_year2_4th = contractorDTO.netamount_paid_year2_4th;
                contractor.lddapno_year2_4th = contractorDTO.lddapno_year2_4th;
                contractor.date_lddap_year2_4th = contractorDTO.date_lddap_year2_4th;





                contractor.RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.RoleID; //saving role depend in login id
                contractor.UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id; //saving role depend in UserId login
                contractor.UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName; //saving username depend in login
                contractor.Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name; //saving username depend in login
                Db.ngp_contractor.Add(contractor);
            }


            Db.NgpLogsContractors.Add(new NgpLogsContractor()
            {

                Date = DateTime.Now,
                Name = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Name,
                UserName = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.UserName,
                LogMessage = "Added a Contractor " + "Name: " + contractorDTO.contractor_name,
                UserId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.Id,
                RoleId = Db.NgpUsers.FirstOrDefault(o => o.Id == sess_id)?.NgpRole.RoleName,


            });

            Db.SaveChanges();

            return Ok();


        }

        //GET in form contractor
        [Route("api/contractorget/get/{id}")]
        [HttpGet]
        public IHttpActionResult GetContractorData(int id)
        {
            var contractor = Db.ngp_contractor.SingleOrDefault(d => d.contractorID == id);
            if (contractor == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<ngp_contractor, ContractorDTO>(contractor));
        }


        //Put
        [HttpPut]
        [Route("api/contractorput/updatecontractor/{id}")]
        public IHttpActionResult UpdateContrasctor(int id, ContractorDTO contractorDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sess_id = (int)HttpContext.Current.Session["LoginID"];
            var contractorinDb = Db.ngp_contractor.SingleOrDefault(d => d.contractorID == id);
            if (contractorinDb == null)
            {
                return NotFound();
            }
            Mapper.Map(contractorDTO, contractorinDb);
            contractorinDb.contractorID = id;

            contractorinDb.contractor_name = contractorDTO.contractor_name;
            contractorinDb.address_municipality = contractorDTO.address_municipality;
            contractorinDb.address_barangay = contractorDTO.address_barangay;
            contractorinDb.contractor_type = contractorDTO.contractor_type;

            contractorinDb.UserId = contractorDTO.UserId;
            contractorinDb.RoleId = contractorDTO.RoleId;
            contractorinDb.UserName = contractorDTO.UserName;
            contractorinDb.Name = contractorDTO.Name;
            //for Project
            contractorinDb.location_municipality = contractorDTO.location_municipality;
            contractorinDb.location_barangay = contractorDTO.location_barangay;
            contractorinDb.area = contractorDTO.area;
            contractorinDb.year_form = contractorDTO.year_form;
            contractorinDb.penro = contractorDTO.penro;
            contractorinDb.cenro = contractorDTO.cenro;
            contractorinDb.region = contractorDTO.region;
            //for contract year 1
            contractorinDb.moanumber_year1 = contractorDTO.moanumber_year1;
            contractorinDb.datemoasigned_year1 = contractorDTO.datemoasigned_year1;
            contractorinDb.contractcost_year1 = contractorDTO.contractcost_year1;
            contractorinDb.dateobligated_year1 = contractorDTO.dateobligated_year1;
            contractorinDb.orsno_year1 = contractorDTO.orsno_year1;
            contractorinDb.num_seedlings_produced_year1 = contractorDTO.num_seedlings_produced_year1;
            contractorinDb.commodity_year1 = contractorDTO.commodity_year1;
            contractorinDb.num_seedlings_planted_year1 = contractorDTO.num_seedlings_planted_year1;
            contractorinDb.survivalrate_year1 = contractorDTO.survivalrate_year1;
            //for contract year 2
            contractorinDb.moanumber_year2 = contractorDTO.moanumber_year2;
            contractorinDb.datemoasigned_year2 = contractorDTO.datemoasigned_year2;
            contractorinDb.unitcost_year2 = contractorDTO.unitcost_year2;
            contractorinDb.contractcost_year2 = contractorDTO.contractcost_year2;
            contractorinDb.dateobligated_year2 = contractorDTO.dateobligated_year2;
            contractorinDb.orsno_year2 = contractorDTO.orsno_year2;
            contractorinDb.num_seedlings_planted_year2 = contractorDTO.num_seedlings_planted_year2;
            contractorinDb.num_seedlings_survive_endofyear_1_year2 = contractorDTO.num_seedlings_survive_endofyear_1_year2;
            contractorinDb.survivalrate_year2 = contractorDTO.survivalrate_year2;
            contractorinDb.num_seedlings_replanted_year2 = contractorDTO.num_seedlings_replanted_year2;

            //for contract year 3
            contractorinDb.moanumber_year3 = contractorDTO.moanumber_year3;
            contractorinDb.datemoasigned_year3 = contractorDTO.datemoasigned_year3;
            contractorinDb.unitcost_year3 = contractorDTO.unitcost_year3;
            contractorinDb.contractcost_year3 = contractorDTO.contractcost_year3;
            contractorinDb.dateobligated_year3 = contractorDTO.dateobligated_year3;
            contractorinDb.orsno_year2 = contractorDTO.orsno_year2;
            contractorinDb.num_seedlings_planted_year3 = contractorDTO.num_seedlings_planted_year3;
            contractorinDb.num_seedlings_survive_endofyear_1_year3 = contractorDTO.num_seedlings_survive_endofyear_1_year3;
            contractorinDb.survivalrate_year3 = contractorDTO.survivalrate_year3;
            contractorinDb.num_seedlings_replanted_year3 = contractorDTO.num_seedlings_replanted_year3;

            //for payments 

            //year1 1st release
            contractorinDb.grossammount_year1_1st = contractorDTO.grossammount_year1_1st;
            contractorinDb.lddap_no_year1_1st = contractorDTO.lddap_no_year1_1st;
            contractorinDb.date_lddap_year1_1st = contractorDTO.date_lddap_year1_1st;

            //year1 2nd release
            contractorinDb.grossammount_year1_2nd = contractorDTO.grossammount_year1_2nd;
            contractorinDb.retention_fee_year1_2nd = contractorDTO.retention_fee_year1_2nd;
            contractorinDb.mobilization_fund_year1_2nd = contractorDTO.mobilization_fund_year1_2nd;
            contractorinDb.amountless_rf_mf_year1_2nd = contractorDTO.amountless_rf_mf_year1_2nd;
            contractorinDb.bir_year1_2nd = contractorDTO.bir_year1_2nd;
            contractorinDb.netammountpaid_year1_2nd = contractorDTO.netammountpaid_year1_2nd;
            contractorinDb.lddapno_year1_2nd = contractorDTO.lddapno_year1_2nd;
            contractorinDb.date_lddap_year1_2nd = contractorDTO.date_lddap_year1_2nd;


            //year1 3rd release
            contractorinDb.grossammount_year1_3rd = contractorDTO.grossammount_year1_3rd;
            contractorinDb.retention_fee_year1_3rd = contractorDTO.retention_fee_year1_3rd;
            contractorinDb.mobilization_fund_year1_3rd = contractorDTO.mobilization_fund_year1_3rd;
            contractorinDb.amountless_rf_mf_year1_3rd = contractorDTO.amountless_rf_mf_year1_3rd;
            contractorinDb.bir_year1_3rd = contractorDTO.bir_year1_2nd;
            contractorinDb.netammountpaid_year1_3rd = contractorDTO.netammountpaid_year1_3rd;
            contractorinDb.lddapno_year1_3rd = contractorDTO.lddapno_year1_3rd;
            contractorinDb.date_lddap_year1_3rd = contractorDTO.date_lddap_year1_3rd;


            //year1 4rd release
            contractorinDb.grossammount_year1_4th = contractorDTO.grossammount_year1_4th;
            contractorinDb.retention_fee_year1_4th = contractorDTO.retention_fee_year1_4th;
            contractorinDb.mobilization_fund_year1_4th = contractorDTO.mobilization_fund_year1_4th;
            contractorinDb.amountless_rf_mf_year1_4th = contractorDTO.amountless_rf_mf_year1_4th;
            contractorinDb.bir_year1_4th = contractorDTO.bir_year1_2nd;
            contractorinDb.netammountpaid_year1_4th = contractorDTO.netammountpaid_year1_4th;
            contractorinDb.lddapno_year1_4th = contractorDTO.lddapno_year1_4th;
            contractorinDb.date_lddap_year1_4th = contractorDTO.date_lddap_year1_4th;

            //year1 5th release
            contractorinDb.grossammount_year1_5th = contractorDTO.grossammount_year1_5th;
            contractorinDb.retention_fee_year1_5th = contractorDTO.retention_fee_year1_5th;
            contractorinDb.mobilization_fund_year1_5th = contractorDTO.mobilization_fund_year1_5th;
            contractorinDb.amountless_rf_mf_year1_5th = contractorDTO.amountless_rf_mf_year1_5th;
            contractorinDb.bir_year1_5th = contractorDTO.bir_year1_2nd;
            contractorinDb.netammountpaid_year1_5th = contractorDTO.netammountpaid_year1_5th;
            contractorinDb.lddapno_year1_5th = contractorDTO.lddapno_year1_5th;
            contractorinDb.date_lddap_year1_5th = contractorDTO.date_lddap_year1_5th;

            //year1 6th release
            contractorinDb.grossammount_year1_6th = contractorDTO.grossammount_year1_6th;
            contractorinDb.retention_fee_year1_6th = contractorDTO.retention_fee_year1_6th;
            contractorinDb.mobilization_fund_year1_6th = contractorDTO.mobilization_fund_year1_6th;
            contractorinDb.amountless_rf_mf_year1_6th = contractorDTO.amountless_rf_mf_year1_6th;
            contractorinDb.bir_year1_6th = contractorDTO.bir_year1_6th;

            //year2 1st release
            contractorinDb.survivalrate_year2_1st = contractorDTO.survivalrate_year2_1st;
            contractorinDb.grossammount_year2_1st = contractorDTO.grossammount_year2_1st;
            contractorinDb.redentionfee_fee_year2_1st = contractorDTO.redentionfee_fee_year2_1st;
            contractorinDb.amountless_rf_year2_1st = contractorDTO.amountless_rf_year2_1st;
            contractorinDb.bir_year2_1st = contractorDTO.bir_year2_1st;
            contractorinDb.netamount_paid_year2_1st = contractorDTO.netamount_paid_year2_1st;
            contractorinDb.lddapno_year2_1st = contractorDTO.lddapno_year2_1st;
            contractorinDb.date_lddap_year2_1st = contractorDTO.date_lddap_year2_1st;



            //year2 2nd release
            contractorinDb.survivalrate_year2_2nd = contractorDTO.survivalrate_year2_2nd;
            contractorinDb.grossammount_year2_2nd = contractorDTO.grossammount_year2_2nd;
            contractorinDb.redentionfee_fee_year2_2nd = contractorDTO.redentionfee_fee_year2_2nd;
            contractorinDb.amountless_rf_year2_2nd = contractorDTO.amountless_rf_year2_2nd;
            contractorinDb.bir_year2_2nd = contractorDTO.bir_year2_2nd;
            contractorinDb.netamount_paid_year2_2nd = contractorDTO.netamount_paid_year2_2nd;
            contractorinDb.lddapno_year2_2nd = contractorDTO.lddapno_year2_2nd;
            contractorinDb.date_lddap_year2_2nd = contractorDTO.date_lddap_year2_2nd;



            //year2 3rd release
            contractorinDb.survivalrate_year2_3rd = contractorDTO.survivalrate_year2_3rd;
            contractorinDb.grossammount_year2_3rd = contractorDTO.grossammount_year2_3rd;
            contractorinDb.redentionfee_fee_year2_3rd = contractorDTO.redentionfee_fee_year2_3rd;
            contractorinDb.amountless_rf_year2_3rd = contractorDTO.amountless_rf_year2_3rd;
            contractorinDb.bir_year2_3rd = contractorDTO.bir_year2_3rd;
            contractorinDb.netamount_paid_year2_3rd = contractorDTO.netamount_paid_year2_3rd;
            contractorinDb.lddapno_year2_3rd = contractorDTO.lddapno_year2_3rd;
            contractorinDb.date_lddap_year2_3rd = contractorDTO.date_lddap_year2_3rd;

            //year2 4th release
            contractorinDb.survivalrate_year2_4th = contractorDTO.survivalrate_year2_4th;
            contractorinDb.grossammount_year2_4th = contractorDTO.grossammount_year2_4th;
            contractorinDb.redentionfee_fee_year2_4th = contractorDTO.redentionfee_fee_year2_4th;
            contractorinDb.amountless_rf_year2_4th = contractorDTO.amountless_rf_year2_4th;
            contractorinDb.bir_year2_1st3 = contractorDTO.bir_year2_1st3;
            contractorinDb.netamount_paid_year2_4th = contractorDTO.netamount_paid_year2_4th;
            contractorinDb.lddapno_year2_4th = contractorDTO.lddapno_year2_4th;
            contractorinDb.date_lddap_year2_4th = contractorDTO.date_lddap_year2_4th;






            Db.SaveChanges();
            return Ok();
        }



        [HttpDelete]
        [Route("api/contractordelete/delete/{id}")]
        public IHttpActionResult DeleteContractor(int id)
        {
            var contractorinDb = Db.ngp_contractor.SingleOrDefault(d => d.contractorID == id);
            if (contractorinDb == null)
            {
                return NotFound();
            }
            Db.ngp_contractor.Remove(contractorinDb);
            //_db.LoginActivity.Add(new LoginActivity()
            //{
            //    UserName = User.Identity.GetFullName(),
            //    ActivityMessage = "Deleted A Department",
            //    ActivityDate = DateTime.Now.ToString("MMMM dd yyyy hh:mm tt"),
            //    Email = User.Identity.GetUserName(),

            //});
            Db.SaveChanges();
            return Ok();
        }

    }
}
